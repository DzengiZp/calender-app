public class ApiResponse
{
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public ICollection<string>? Errors { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public static ApiResponse Success(int statusCode = 200, string? message = null)
    {
        return new ApiResponse
        {
            IsSuccess = true,
            StatusCode = statusCode,
            Message = message,
        };
    }

    public static ApiResponse Error(
        int statusCode = 400,
        ICollection<string>? errors = null,
        string? message = null
    )
    {
        return new ApiResponse
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Errors = errors,
            Message = message,
        };
    }

    public static ApiResponse Error(int statusCode, string error)
    {
        return new ApiResponse { StatusCode = statusCode, Errors = [error] };
    }
}

public class ApiResponse<T> : ApiResponse
{
    public T? Data { get; set; }

    public static ApiResponse<T> Success(
        int statusCode = 200,
        T? data = default,
        string? message = null
    )
    {
        return new ApiResponse<T>
        {
            IsSuccess = true,
            StatusCode = statusCode,
            Data = data,
            Message = message,
        };
    }

    public static ApiResponse<T> Error(
        int statusCode = 400,
        T? data = default,
        ICollection<string>? errors = null,
        string? message = null
    )
    {
        return new ApiResponse<T>
        {
            IsSuccess = false,
            StatusCode = statusCode,
            Data = data,
            Errors = errors,
            Message = message,
        };
    }
}
