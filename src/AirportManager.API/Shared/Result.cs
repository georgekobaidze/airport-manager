namespace AirportManager.API.Shared;

public class Result
{
    public bool Success { get; protected set; }
    public string? Message { get; protected set; }
    public int StatusCode { get; protected set; }

    public static Result Ok()
    {
        return new Result
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK
        };
    }

    public static Result Fail(string message, int statusCode = StatusCodes.Status500InternalServerError)
    {
        return new Result
        {
            Success = false,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static Result FailNotFound()
    {
        return new Result
        {
            Success = false,
            StatusCode = StatusCodes.Status404NotFound,
            Message = "Resource not found"
        };
    }

    public Result WithStatus(int statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public Result WithMessage(string message)
    {
        Message = message;
        return this;
    }
}

public class Result<T> : Result
{
    public T? Data { get; protected set; }

    public static Result<T> Ok(T data)
    {
        return new Result<T>
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = data
        };
    }

    public static new Result<T> Fail(string message, int statusCode = StatusCodes.Status500InternalServerError)
    {
        return new Result<T>
        {
            Success = false,
            StatusCode = statusCode,
            Message = message
        };
    }

    public static new Result<T> FailNotFound()
    {
        return new Result<T>
        {
            Success = false,
            StatusCode = StatusCodes.Status404NotFound,
            Message = "Resource not found"
        };
    }

    public new Result<T> WithStatus(int statusCode)
    {
        StatusCode = statusCode;
        return this;
    }

    public new Result<T> WithMessage(string message)
    {
        Message = message;
        return this;
    }
}

public class PaginatedResult<T> : Result<T>
{
    public PaginationMetadata PaginationMetadata { get; private set; }

    public new static PaginatedResult<T> Ok(T data, PaginationMetadata paginationMetadata)
    {
        return new PaginatedResult<T>
        {
            Success = true,
            StatusCode = StatusCodes.Status200OK,
            Data = data,
            PaginationMetadata = paginationMetadata
        };
    }
}