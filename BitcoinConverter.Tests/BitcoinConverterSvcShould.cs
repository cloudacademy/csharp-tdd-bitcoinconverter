using Xunit;

namespace CloudAcademy.Bitcoin.Tests
{
    public class BitcoinConverterSvcShould
    {
        [Fact]
        public void GetExchangeRate_USD_ReturnsUSDExchangeRate()
        {
            //act
            var converterSvc = new ConverterSvc();
            var exchangeRate = converterSvc.GetExchangeRate("USD");

            //assert
            var expected = 100;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetExchangeRate_GBP_ReturnsGBPExchangeRate()
        {
            //act
            var converterSvc = new ConverterSvc();
            var exchangeRate = converterSvc.GetExchangeRate("GBP");

            //assert
            var expected = 200;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetExchangeRate_EUR_ReturnsEURExchangeRate()
        {
            //act
            var converterSvc = new ConverterSvc();
            var exchangeRate = converterSvc.GetExchangeRate("EUR");

            //assert
            var expected = 300;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void ConvertBitcoins_1BitCoinToUSD_ReturnsUSDDollars()
        {
            //act
            var converterSvc = new ConverterSvc();
            var dollars = converterSvc.ConvertBitcoins("USD", 1);

            //assert
            var expected = 100;
            Assert.Equal(expected, dollars);
        }

        [Fact]
        public void ConvertBitcoins_1BitCoinToGBP_ReturnsGBPPounds()
        {
            //act
            var converterSvc = new ConverterSvc();
            var dollars = converterSvc.ConvertBitcoins("GBP", 1);

            //assert
            var expected = 200;
            Assert.Equal(expected, dollars);
        }

        [Fact]
        public void ConvertBitcoins_1BitCoinToEUR_ReturnsEURDollars()
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
