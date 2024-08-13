namespace vMake.Controllers.Models;

public interface IApiResponse
{
    public bool Success { get; }
    public string Message { get; }
}
