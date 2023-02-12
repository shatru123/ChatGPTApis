namespace ChatGPTApis.Services
{
    public interface IChatGPTService
    {
        Task<string> GetResponse(string query);
    }
}
