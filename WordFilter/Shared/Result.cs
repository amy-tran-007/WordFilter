namespace TextFilter.Shared;
public class Result
{
    public bool Success { get; }
    public bool Failed => !Success;
    public string ErrorMessage { get; }
    private Result(bool success, string? errorMessage)
    {
        Success = success;
        ErrorMessage = errorMessage ?? string.Empty;

    }


    public static Result OK()
    {
        return new(true, null);
    }

    public static Result OK(object value)
    {
        return new(true, null);
    }

    public static Result Error(string errorMessage)
    {
        return new(false, errorMessage);
    }
}