using ChatGPTApis.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatGPTApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        private readonly IChatGPTService _chatGPTService;
        public ChatGPTController(IChatGPTService chatGPTService)
        {
            _chatGPTService = chatGPTService;
        }
        [HttpPost]
        public async Task<IActionResult> GetResult(string query)
        {
          var result = await _chatGPTService.GetResponse(query);
           return result != null ?  Ok(result) : Problem("Something is wrong : ", query);
        }
    }
}
