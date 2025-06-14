namespace AirportManager.API.Shared;

public class Result<T>
{
    public bool Success { get; private set; }
    public string? Message { get; private set; }
    public int StatusCode { get; private set; }
    public T? Data { get; private set; }

    public static Result<T> Ok(T data)
    {
        return new Result<T>
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = data
        };
    }

    public static Result<T> Fail(string message, int statusCode = StatusCodes.Status500InternalServerError)
    {
        return new Result<T>
        {
            Success = false,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static Result<T> FailNotFound()
    {
        return new Result<T>
        {
            Success = false,
            StatusCode = StatusCodes.Status404NotFound,
            Message = "Resource not found"
        };
    }

    public Result<T> WithStatus(int statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public Result<T> WithMessage(string message)
    {
        Message = message;
        return this;
    }
}