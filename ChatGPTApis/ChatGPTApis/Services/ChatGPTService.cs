using ChatGPTApis.Config;
using ChatGPTApis.Models;
using Newtonsoft.Json;
using OpenAI_API.Models;
using System.Text;

namespace ChatGPTApis.Services
{
    public class ChatGPTService : IChatGPTService
    {
        private readonly IConfiguration _configuration;
        private readonly ChatGPTConfig _chatGPTConfig;
        private readonly HttpClient _httpClient;
        public ChatGPTService(IConfiguration configuration)
        { 
            _configuration = configuration;
            _chatGPTConfig = _configuration.GetSection("ChatGPTConfig").Get<ChatGPTConfig>();
            _httpClient = new HttpClient();
        }

        public async Task<string> GetResponse(string query)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, _chatGPTConfig.Url);
                request.Headers.Add("Authorization", "Bearer " + _chatGPTConfig.API_KEY + "");              

                var requestContent = new
                {
                    model = "text-davinci-002",
                    prompt = query,
                    max_tokens = 100,
                    n = 1,
                    stop = "",
                    temperature = 0.5
                };

                request.Content = new StringContent(JsonConvert.SerializeObject(requestContent), Encoding.UTF8, "application/json");

                var response = await _httpClient.SendAsync(request);
                //response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ChatGPTResponse>(responseContent);
                return result.Choices[0].Text; //.choices[0].text;
            }
            catch (Exception exception)
            {
                throw;
            }
        }
    }
}
