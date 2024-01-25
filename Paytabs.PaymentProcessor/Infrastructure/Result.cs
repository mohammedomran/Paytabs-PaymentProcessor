namespace Paytabs.PaymentProcessor.Infrastructure;

public class Result<T>
{
    public T Value { get; set; }
    public string Error { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsFail
    {
        get
        {
            return !IsSuccess;
        }
    }

    public static Result<T> Ok(T t)
    {
        return new Result<T>
        {
            IsSuccess = true,
            Value = t
        };
    }

    public static Result<T> Fail(string error)
    {
        return new Result<T>
        {
            IsSuccess = false,
            Error = error
        };
    }
}

