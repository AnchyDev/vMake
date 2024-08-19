namespace vMake.Models;

public class MakeResult<T>
{
    public bool Success { get; set; }
    public string Message { get; set; }

    public T Result { get; set; } = default!;

    public MakeResult(bool success, string message = "")
    {
        this.Success = success;
        this.Message = message;
    }

    public static MakeResult<T> Fail(string message = "")
    {
        return new MakeResult<T>(false, message);
    }

    public static MakeResult<T> Succeed(string message = "", T? result = default)
    {
        return new MakeResult<T>(true, message)
        {
            Result = result
        };
    }
}
