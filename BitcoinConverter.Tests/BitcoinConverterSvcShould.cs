using System;
using Xunit;
using CloudAcademy.Bitcoin;

namespace CloudAcademy.Bitcoin.Tests
{
    public class BitcoinConverterSvcShould
    {
        [Fact]
        public void GetNZDExchangeRate()
        {
            //act
            var converterSvc = new ConverterSvc();
            var exchangeRate = converterSvc.GetExchangeRate("NZD");

            //assert
            var expected = 100;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetUSDExchangeRate()
        {
            //act
            var converterSvc = new ConverterSvc();
            var exchangeRate = converterSvc.GetExchangeRate("USD");

            //assert
            var expected = 200;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void ConvertBitcoinsToNZD()
        {
            //act
            var converterSvc = new ConverterSvc();
            var dollars = converterSvc.ConvertBitcoins("NZD", 1);

            //assert
            var expected = 100;
            Assert.Equal(expected, dollars);
        }

        [Fact]
        public void ConvertBitcoinsToUSD()
        {
            //act
            var converterSvc = new ConverterSvc();
            var dollars = converterSvc.ConvertBitcoins("USD", 1);

            //assert
            var expected = 200;
            Assert.Equal(expected, dollars);
        }
    }
}
