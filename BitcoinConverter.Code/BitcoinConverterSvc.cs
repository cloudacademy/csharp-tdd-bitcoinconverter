using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

namespace CloudAcademy.Bitcoin
{
    public class ConverterSvc
    {
        private const string BITCOIN_NZDUSD_URL = "https://api.coindesk.com/v1/bpi/currentprice/NZD.json";

        private HttpClient client;

        public ConverterSvc()
        {
            this.client = new HttpClient();
        }

        public ConverterSvc(HttpClient httpClient)
        {
            this.client = httpClient;
        }

        public async Task<double> GetExchangeRate(string currency)
        {
            double rate = 0;

            try{
                var response = await this.client.GetStringAsync(BITCOIN_NZDUSD_URL);
                var jsonDoc = JsonDocument.Parse(Encoding.ASCII.GetBytes(response));

                if(currency.Equals("NZD"))
                {
                    var nzdRate = jsonDoc.RootElement.GetProperty("bpi").GetProperty("NZD").GetProperty("rate");

                    rate = Double.Parse(nzdRate.GetString());
                }
                else if (currency.Equals("USD"))
                {
                    var usdRate = jsonDoc.RootElement.GetProperty("bpi").GetProperty("USD").GetProperty("rate");

                    rate = Double.Parse(usdRate.GetString());
                }
            }
            catch
            {
                rate = -1;
            }

            return rate;
        }

        public async Task<double> ConvertBitcoins(string currency, int coins)
        {
            var dollars = await GetExchangeRate(currency) * coins;
            return dollars;
        }

    }
}
