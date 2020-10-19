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
        public void GetUSDExchangeRate()
        {
            //act
            var exchangeRate = converterSvc.GetExchangeRate("USD");

            //assert
            var expected = 100;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetGBPExchangeRate()
        {
            //act
            var exchangeRate = converterSvc.GetExchangeRate("GBP");

            //assert
            var expected = 200;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetEURExchangeRate()
        {
            //act
            var exchangeRate = converterSvc.GetExchangeRate("EUR");

            //assert
            var expected = 300;
            Assert.Equal(expected, exchangeRate);
        }

        [Theory]
        [InlineData("USD",1,100)]
        [InlineData("USD",2,200)]
        [InlineData("GBP",1,200)]
        [InlineData("GBP",2,400)]
        [InlineData("EUR",1,300)]
        [InlineData("EUR",2,600)]
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
