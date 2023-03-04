using System.Net;

namespace ChatGPTApis.Contracts;

public class Error
{
    public string Message { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public Error()
    {
            
    }
}