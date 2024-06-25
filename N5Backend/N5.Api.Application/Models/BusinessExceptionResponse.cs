namespace N5.Api.Application.Models;

public class BusinessErrorExceptionResponse
{
    public required string Message { get; set; }
    public dynamic? Data { get; set; }
}
