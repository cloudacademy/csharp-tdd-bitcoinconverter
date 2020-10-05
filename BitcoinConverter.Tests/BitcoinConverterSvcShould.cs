using System;
using Xunit;
using CloudAcademy.Bitcoin;

namespace CloudAcademy.Bitcoin.Tests
{
    public class BitcoinConverterSvcShould
    {
        private ConverterSvc converterSvc;

        public BitcoinConverterSvcShould()
        {
            converterSvc = new ConverterSvc();
        }

        [Fact]
        public void GetNZDExchangeRate()
        {
            //act
            var exchangeRate = converterSvc.GetExchangeRate("NZD");

            //assert
            var expected = 100;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetUSDExchangeRate()
        {
            //act
            var exchangeRate = converterSvc.GetExchangeRate("USD");

            //assert
            var expected = 200;
            Assert.Equal(expected, exchangeRate);
        }

        [Theory]
        [InlineData("NZD",1,100)]
        [InlineData("NZD",2,200)]
        [InlineData("USD",1,200)]
        [InlineData("USD",2,400)]
        public void ConvertBitcoinsToDollars(string currency, int coins, int convertedDollars)
        {
            //act
            var coverterSvc = new ConverterSvc();
            var dollars = converterSvc.ConvertBitcoins(currency, coins);

            //assert
            var expected = convertedDollars;
            Assert.Equal(expected, dollars);
        }
    }
}
