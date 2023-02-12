using ChatGPTApis.Config;
using ChatGPTApis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTApis.Tests
{
    
    [TestFixture]
    public  class ChatGPTServiceTestWithMoq
    {
        //private ChatGPTService _chatGPTService;
        //private Mock<IConfiguration> _mockConfiguration;
        //private ChatGPTConfig _chatGPTConfig;
        //private Mock<HttpClient> _mockHttpClient;

        //[SetUp]
        //public void SetUp()
        //{
        //    _mockConfiguration = new Mock<IConfiguration>();
        //    _chatGPTConfig = new ChatGPTConfig
        //    {
        //        Url = "https://api.openai.com/v1/completions",
        //        API_KEY = "1234"
        //    };
        //   // _mockConfiguration.SetupGet(x => x.GetSection("ChatGPTConfig")).Returns(new ConfigurationSection(_chatGPTConfig));
        //   // _mockConfiguration.SetupGet(x => x.GetSection("ChatGPTConfig")).Returns((IConfigurationSection)_chatGPTConfig);
        //    _mockHttpClient = new Mock<HttpClient>();
        //    _chatGPTService = new ChatGPTService(_mockConfiguration.Object);
        //}
        //[Ignore]
        //[Test]
        //public async Task GetResponse_ValidQuery_ReturnsResponse()
        //{
        //    // Arrange
        //    string query = "Hello, who are you?";
        //    var mockResponse = new HttpResponseMessage
        //    {
        //        Content = new StringContent("{\"choices\":[{\"text\":\"I am Shatrughna\"}]}")
        //    };
        //    _mockHttpClient.Setup(c => c.SendAsync(It.IsAny<HttpRequestMessage>())).ReturnsAsync(mockResponse);

        //    // Act
        //    var response = await _chatGPTService.GetResponse(query);

        //    // Assert
        //    Assert.IsNotNull(response);
        //    Assert.AreEqual("I am Shatrughna", response);
        //}
    }
}

