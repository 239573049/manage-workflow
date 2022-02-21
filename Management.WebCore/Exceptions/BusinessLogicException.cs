namespace Management.WebCore.Exceptions;

public class BusinessLogicException: Exception
{
    public int Code
    {
        get;
        set;
    }

    public BusinessLogicException()
    {
    }

    public BusinessLogicException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
        Code = 400;
    }

    public BusinessLogicException(int code, string message, Exception? innerException = null)
        : base(message, innerException)
    {
        Code = code;
    }
}
