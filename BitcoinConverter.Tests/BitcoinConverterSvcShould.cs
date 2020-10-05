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
            var coverterSvc = new ConverterSvc();
            var exchangeRate = coverterSvc.GetExchangeRate("NZD");

            //assert
            var expected = 100;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetUSDExchangeRate()
        {
            //act
            var coverterSvc = new ConverterSvc();
            var exchangeRate = coverterSvc.GetExchangeRate("USD");

            //assert
            var expected = 200;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void ConvertBitcoinsToNZD()
        {
            //act
            var coverterSvc = new ConverterSvc();
            var dollars = coverterSvc.ConvertBitcoins("NZD", 1);

            //assert
            var expected = 100;
            Assert.Equal(expected, dollars);
        }

        [Fact]
        public void ConvertBitcoinsToUSD()
        {
            //act
            var coverterSvc = new ConverterSvc();
            var dollars = coverterSvc.ConvertBitcoins("USD", 1);

            //assert
            var expected = 200;
            Assert.Equal(expected, dollars);
        }
    }
}
