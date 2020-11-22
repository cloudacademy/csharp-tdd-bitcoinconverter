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
        }

        public async Task<double> GetExchangeRate(string currency)
        {
            var response = await new HttpClient().GetStringAsync(BITCOIN_CURRENTPRICE_URL);

            if(currency.Equals("USD"))
            {
                var jsonDoc = JsonDocument.Parse(Encoding.ASCII.GetBytes(response));
                var rate = jsonDoc.RootElement.GetProperty("bpi").GetProperty(currency).GetProperty("rate");

                return Double.Parse(rate.GetString());
            }
            else if (currency.Equals("GBP"))
            {
                var jsonDoc = JsonDocument.Parse(Encoding.ASCII.GetBytes(response));
                var rate = jsonDoc.RootElement.GetProperty("bpi").GetProperty(currency).GetProperty("rate");

                return Double.Parse(rate.GetString());
            }
            else if (currency.Equals("EUR"))
            {
                var jsonDoc = JsonDocument.Parse(Encoding.ASCII.GetBytes(response));
                var rate = jsonDoc.RootElement.GetProperty("bpi").GetProperty(currency).GetProperty("rate");

                return Double.Parse(rate.GetString());
            }

            return 0;
        }

        public async Task<double> ConvertBitcoins(string currency, int coins)
        {
            var dollars = await GetExchangeRate(currency) * coins;
            return dollars;
        }

    }
}
