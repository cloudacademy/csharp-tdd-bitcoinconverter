using System;

namespace CloudAcademy.Bitcoin
{
    public class ConverterSvc
    {
        public ConverterSvc()
        {
        }

        public int GetExchangeRate(string currency)
        {
            if(currency.Equals("NZD"))
            {
                return 100;
            }
            else if (currency.Equals("USD"))
            {
                return 200;
            }

            return 0;
        }

        public int ConvertBitcoins(string currency, int coins)
        {
            var dollars = GetExchangeRate(currency) * coins;
            return dollars;
        }

    }
}
