using Xunit;
using Moq;
using Moq.Protected;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace CloudAcademy.Bitcoin.Tests
{
    public class BitcoinConverterSvcShould
    {
        private const string MOCK_RESPONSE_JSON = @"{""time"": {""updated"": ""Oct 15, 2020 22:55:00 UTC"",""updatedISO"": ""2020-10-15T22:55:00+00:00"",""updateduk"": ""Oct 15, 2020 at 23:55 BST""},""chartName"": ""Bitcoin"",""bpi"": {""USD"": {""code"": ""USD"",""symbol"": ""&#36;"",""rate"": ""11,486.5341"",""description"": ""United States Dollar"",""rate_float"": 11486.5341},""GBP"": {""code"": ""GBP"",""symbol"": ""&pound;"",""rate"": ""8,900.8693"",""description"": ""British Pound Sterling"",""rate_float"": 8900.8693},""EUR"": {""code"": ""EUR"",""symbol"": ""&euro;"",""rate"": ""9,809.3278"",""description"": ""Euro"",""rate_float"": 9809.3278}}}";

        private ConverterSvc mockConverter;
        
        public BitcoinConverterSvcShould()
        {
            mockConverter = GetMockBitcoinConverterService();
        }

        private ConverterSvc GetMockBitcoinConverterService() {
            var handlerMock = new Mock<HttpMessageHandler>();
            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(MOCK_RESPONSE_JSON),
            };

            handlerMock
               .Protected()
               .Setup<Task<HttpResponseMessage>>(
                  "SendAsync",
                  ItExpr.IsAny<HttpRequestMessage>(),
                  ItExpr.IsAny<CancellationToken>())
               .ReturnsAsync(response);

            var httpClient = new HttpClient(handlerMock.Object);

            var converter = new ConverterSvc(httpClient);

            return converter;
        }

        [Fact]
        public async void GetExchangeRate_USD_ReturnsUSDExchangeRate()
        {
            //act
            var exchangeRate = await mockConverter.GetExchangeRate(ConverterSvc.Currency.USD);

            //assert
            double expected = 11486.5341;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public async void GetExchangeRate_GBP_ReturnsGBPExchangeRate()
        {
            //act
            var exchangeRate = await mockConverter.GetExchangeRate(ConverterSvc.Currency.GBP);

            //assert
            double expected = 8900.8693;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public async void GetExchangeRate_EUR_ReturnsEURExchangeRate()
        {
            //act
            var exchangeRate = await mockConverter.GetExchangeRate(ConverterSvc.Currency.EUR);

            //assert
            double expected = 9809.3278;
            Assert.Equal(expected, exchangeRate);
        }

        [Theory]
        [InlineData(ConverterSvc.Currency.USD, 1, 11486.5341)]
        [InlineData(ConverterSvc.Currency.USD, 2 ,22973.0682)]
        [InlineData(ConverterSvc.Currency.USD, 2.5 ,28716.3353)]
        [InlineData(ConverterSvc.Currency.GBP, 1, 8900.8693)]
        [InlineData(ConverterSvc.Currency.EUR, 1, 9809.3278)]
        public async void ConvertBitcoins_BitCoinsToCurrency_ReturnsCurrency(ConverterSvc.Currency currency, double coins, double convertedDollars)
        {
            //act
            var dollars = await mockConverter.ConvertBitcoins(currency, coins);

            //assert
            var expected = convertedDollars;
            Assert.Equal(expected, dollars);
        }

    }
}