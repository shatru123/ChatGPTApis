using Newtonsoft.Json;

namespace ChatGPTApis.Models
{
   
    public class ChatGPTResponse
    {
        public string Id { get; set; }
        [JsonProperty("object")]
        public string @Object { get; set; }
        public int Created { get; set; }
        public string Model { get; set; }
        public List<Choice> Choices { get; set; }
        public Usage Usage { get; set; }
    }

    public class Choice
    {
        public string Text { get; set; }
        public int Index { get; set; }
        public object Logprobs { get; set; }
        public string Finish_reason { get; set; }
    }

    public class Usage
    {
        public int Prompt_tokens { get; set; }
        public int Completion_tokens { get; set; }
        public int Total_tokens { get; set; }
    }
}
