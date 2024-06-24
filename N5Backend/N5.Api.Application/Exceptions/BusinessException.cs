namespace N5.Api.Application.Exceptions;
public class BusinessException : Exception
{
    public dynamic? ExceptionData { get; set; }
    public BusinessException(string message) : base(message)
    {

    }
    public BusinessException(string message, dynamic data) : base(message)
    {
        ExceptionData = data;
    }
}
