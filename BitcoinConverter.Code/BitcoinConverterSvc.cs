using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

namespace CloudAcademy.Bitcoin
{
    public class ConverterSvc
    {
        private const string NZD_URL = "https://api.coindesk.com/v1/bpi/currentprice/NZD.json";
        private const string USD_URL = "https://api.coindesk.com/v1/bpi/currentprice/USD.json";

        public ConverterSvc()
        {
        }

        public async Task<double> GetExchangeRate(string currency)
        {
            if(currency.Equals("NZD"))
            {
                var response = await new HttpClient().GetStringAsync(NZD_URL);
                var jsonDoc = JsonDocument.Parse(Encoding.ASCII.GetBytes(response));
                var rate = jsonDoc.RootElement.GetProperty("bpi").GetProperty(currency).GetProperty("rate");

                return Double.Parse(rate.GetString());
            }
            else if (currency.Equals("USD"))
            {
                var response = await new HttpClient().GetStringAsync(NZD_URL);
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
