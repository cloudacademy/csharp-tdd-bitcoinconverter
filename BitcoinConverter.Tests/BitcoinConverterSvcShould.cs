using System;
using Xunit;
using CloudAcademy.Bitcoin;
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
        private const string MOCK_RESPONSE_JSON = @"{""bpi"":{""USD"":{""code"":""USD"",""rate"":""10,095.9106"",""description"":""United States Dollar"",""rate_float"":10095.9106},""NZD"":{""code"":""NZD"",""rate"":""15,095.5670"",""description"":""New Zealand Dollar"",""rate_float"":15095.567}}}";

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
        public async void GetNZDExchangeRate()
        {
            //act
            var exchangeRate = await mockConverter.GetExchangeRate("NZD");

            //assert
            double expected = 15095.5670;
            Assert.Equal(expected, exchangeRate);
        }

        [Fact]
        public async void GetUSDExchangeRate()
        {
            //act
            var exchangeRate = await mockConverter.GetExchangeRate("USD");

            //assert
            double expected = 10095.9106;
            Assert.Equal(expected, exchangeRate);
        }

        [Theory]
        [InlineData("NZD", 1, 15095.5670)]
        [InlineData("NZD", 2, 30191.1340)]
        [InlineData("USD", 1, 10095.9106)]
        [InlineData("USD", 2 ,20191.8212)]
        public async void ConvertBitcoinsToDollars(string currency, int coins, double convertedDollars)
        {
            //act
            var dollars = await mockConverter.ConvertBitcoins(currency, coins);

            //assert
            var expected = convertedDollars;
            Assert.Equal(expected, dollars);
        }
    }
}
