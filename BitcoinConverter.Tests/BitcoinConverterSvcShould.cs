using Xunit;

namespace CloudAcademy.Bitcoin.Tests
{
    public class BitcoinConverterSvcShould
    {
        private ConverterSvc converterSvc;

        public BitcoinConverterSvcShould()
        {
            //arrange
            converterSvc = new ConverterSvc();
        }

        [Fact]
        public async void GetExchangeRate_USD_ReturnsUSDExchangeRate()
        {
            //act
            var exchangeRate = await converterSvc.GetExchangeRate("USD");

            //assert
            double expected = 100.00;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public async void GetExchangeRate_GBP_ReturnsGBPExchangeRate()
        {
            //act
            var exchangeRate = await converterSvc.GetExchangeRate("GBP");

            //assert
            double expected = 200.00;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public async void GetExchangeRate_EUR_ReturnsEURExchangeRate()
        {
            //act
            var exchangeRate = await converterSvc.GetExchangeRate("EUR");

            //assert
            double expected = 300.00;
            Assert.Equal(expected, exchangeRate);
        }

        [Theory]
        [InlineData("USD",1,100.00)]
        [InlineData("USD",2,200.00)]
        [InlineData("GBP",1,200.00)]
        [InlineData("GBP",2,400.00)]
        [InlineData("EUR",1,300.00)]
        [InlineData("EUR",2,600.00)]
        public async void ConvertBitcoins_BitCoinsToCurrency_ReturnsCurrency(string currency, int coins, double convertedDollars)
        {
            //act
            var coverterSvc = new ConverterSvc();
            var dollars = await converterSvc.ConvertBitcoins(currency, coins);

            //assert
            var expected = convertedDollars;
            Assert.Equal(expected, dollars);
        }
    }
}
