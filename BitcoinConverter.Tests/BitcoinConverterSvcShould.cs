using Xunit;

namespace CloudAcademy.Bitcoin.Tests
{
    public class BitcoinConverterSvcShould
    {
        [Fact]
        public void GetExchangeRate_USD_ReturnsUSDExchangeRate()
        {
            //arrange
            var converterSvc = new ConverterSvc();

            //act
            var exchangeRate = converterSvc.GetExchangeRate("USD");

            //assert
            var expected = 100;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetExchangeRate_GBP_ReturnsGBPExchangeRate()
        {
            //arrange
            var converterSvc = new ConverterSvc();

            //act
            var exchangeRate = converterSvc.GetExchangeRate("GBP");

            //assert
            var expected = 200;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void GetExchangeRate_EUR_ReturnsEURExchangeRate()
        {
            //arrange
            var converterSvc = new ConverterSvc();

            //act
            var exchangeRate = converterSvc.GetExchangeRate("EUR");

            //assert
            var expected = 300;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public void ConvertBitcoins_1BitCoinToUSD_ReturnsUSDDollars()
        {
            //arrange
            var converterSvc = new ConverterSvc();

            //act
            var dollars = converterSvc.ConvertBitcoins("USD", 1);

            //assert
            var expected = 100;
            Assert.Equal(expected, dollars);
        }

        [Fact]
        public void ConvertBitcoins_1BitCoinToGBP_ReturnsGBPPounds()
        {
            //arrange
            var converterSvc = new ConverterSvc();

            //act
            var dollars = converterSvc.ConvertBitcoins("GBP", 1);

            //assert
            var expected = 200;
            Assert.Equal(expected, dollars);
        }

        [Fact]
        public void ConvertBitcoins_1BitCoinToEUR_ReturnsEURDollars()
        {
            //arrange
            var converterSvc = new ConverterSvc();

            //act
            var dollars = converterSvc.ConvertBitcoins("EUR", 1);

            //assert
            var expected = 300;
            Assert.Equal(expected, dollars);
        }

    }
}
