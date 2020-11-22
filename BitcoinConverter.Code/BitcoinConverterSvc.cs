using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

namespace CloudAcademy.Bitcoin
{
    public class ConverterSvc
    {
        private const string BITCOIN_CURRENTPRICE_URL = "https://api.coindesk.com/v1/bpi/currentprice.json";

        private HttpClient client;

        /*
        //curl -s https://api.coindesk.com/v1/bpi/currentprice.json | jq .
        //example json response from coindesk api:
        {
            "time": {
                "updated": "Oct 15, 2020 22:55:00 UTC",
                "updatedISO": "2020-10-15T22:55:00+00:00",
                "updateduk": "Oct 15, 2020 at 23:55 BST"
            },
            "disclaimer": "This data was produced from the CoinDesk Bitcoin Price Index (USD)",
            "chartName": "Bitcoin",
            "bpi": {
                "USD": {
                "code": "USD",
                "symbol": "&#36;",
                "rate": "11,486.5341",
                "description": "United States Dollar",
                "rate_float": 11486.5341
                },
                "GBP": {
                "code": "GBP",
                "symbol": "&pound;",
                "rate": "8,900.8693",
                "description": "British Pound Sterling",
                "rate_float": 8900.8693
                },
                "EUR": {
                "code": "EUR",
                "symbol": "&euro;",
                "rate": "9,809.3278",
                "description": "Euro",
                "rate_float": 9809.3278
                }
            }
        }
        */

        public ConverterSvc()
        {
            this.client = new HttpClient();
        }

        public ConverterSvc(HttpClient httpClient)
        {
            this.client = httpClient;
        }

        public enum Currency 
        {
            USD,
            GBP,
            EUR        
        }

        public async Task<double> GetExchangeRate(Currency currency)
        {
            double rate = 0;

            try
            {
                var response = await this.client.GetStringAsync(BITCOIN_CURRENTPRICE_URL);
                var jsonDoc = JsonDocument.Parse(Encoding.ASCII.GetBytes(response));

                var rateStr = jsonDoc.RootElement.GetProperty("bpi").GetProperty(currency.ToString()).GetProperty("rate");

                rate = Double.Parse(rateStr.GetString());
            }
            catch
            {
                rate = -1;
            }

            return Math.Round(rate, 4);
        }

        public async Task<double> ConvertBitcoins(Currency currency, double coins)
        {
            double dollars = 0;
            
            if (coins < 0)
            {
                throw new ArgumentException("Number of coins must not be less than zero"); 
            }

            double exchangeRate = await GetExchangeRate(currency);

            if (exchangeRate >= 0)
            {
                dollars = exchangeRate * coins;
            }
            else
            {
                dollars = -1;
            }

            return Math.Round(dollars, 4);
        }

    }
}
