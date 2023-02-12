using ChatGPTApis.Config;
using ChatGPTApis.Models;
using ChatGPTApis.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPTApis.Tests
{
    [TestFixture]
    public class ChatGPTServiceTests
    {
        private IChatGPTService _chatGPTService;
        private IConfiguration _configuration;

        [SetUp]
        public void SetUp()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(x => new ConfigurationBuilder().AddJsonFile("appsettings.json").Build());
            services.AddSingleton<IChatGPTService, ChatGPTService>();
            var serviceProvider = services.BuildServiceProvider();
            _chatGPTService = serviceProvider.GetService<IChatGPTService>();
            _configuration = serviceProvider.GetService<IConfiguration>();
        }

        [Test]
        public async Task GetResponse_ValidQuery_ReturnsResponse()
        {
            // Arrange
            string query = "Hello, who are you?";

            // Act
            var response = await _chatGPTService.GetResponse(query);

            // Assert
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task GetResponse_InvalidQuery_ThrowsException()
        {
            // Arrange
            string query = "";

            // Act & Assert
             Assert.ThrowsAsync<Exception>(async () => await _chatGPTService.GetResponse(query));
        }
    }
}
