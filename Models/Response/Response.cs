namespace backend.Models.Response;

public class Response
{
    public int code { get; set; }
    public string message { get; set; }
    public string? accessToken { get; set; }
    public string? refreshToken { get; set; }
    public JsonContent? data { get; set; }
}