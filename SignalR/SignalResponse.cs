namespace vMake.SignalR;

public class SignalResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public object? Object { get; set; }
    public object? Metadata { get; set; }

    public SignalResponse(bool success, string message, object? obj = null, object? metadata = null)
    {
        Success = success;
        Message = message;

        Object = obj;
        Metadata = metadata;
    }
}
