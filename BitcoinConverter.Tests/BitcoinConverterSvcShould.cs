using System;
using Xunit;
using CloudAcademy.Bitcoin;

namespace CloudAcademy.Bitcoin.Tests
{
    public class BitcoinConverterSvcShould
    {
        [Fact]
        public void GetUSDExchangeRate()
        {
            //act
            var converterSvc = new ConverterSvc();
            var exchangeRate = converterSvc.GetExchangeRate("USD");

            //assert
            var expected = 100;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetGBPExchangeRate()
        {
            //act
            var converterSvc = new ConverterSvc();
            var exchangeRate = converterSvc.GetExchangeRate("GBP");

            //assert
            var expected = 200;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetEURExchangeRate()
        {
            //act
            var converterSvc = new ConverterSvc();
            var exchangeRate = converterSvc.GetExchangeRate("EUR");

            //assert
            var expected = 300;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void ConvertBitcoinsToUSD()
        {
            //act
            var converterSvc = new ConverterSvc();
            var dollars = converterSvc.ConvertBitcoins("USD", 1);

            //assert
            var expected = 100;
            Assert.Equal(expected, dollars);
        }

        [Fact]
        public void ConvertBitcoinsToGBP()
        {
            //act
            var converterSvc = new ConverterSvc();
            var dollars = converterSvc.ConvertBitcoins("GBP", 1);

            //assert
            var expected = 200;
            Assert.Equal(expected, dollars);
        }

        [Fact]
        public void ConvertBitcoinsToEUR()
        {
            //act
            var converterSvc = new ConverterSvc();
            var dollars = converterSvc.ConvertBitcoins("EUR", 1);

            //assert
            var expected = 300;
            Assert.Equal(expected, dollars);
        }

    }
}
