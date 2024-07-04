using N5.Api.Application.Models;

namespace N5.Api.Application.Tests.Models;


public class BusinessErrorExceptionResponseTests
{
    [Fact]
    public void BusinessErrorExceptionResponse_ShouldSetMessageCorrectly()
    {
        // Arrange
        var message = "Error occurred";

        // Act
        var response = new BusinessErrorExceptionResponse
        {
            Message = message
        };

        // Assert
        Assert.Equal(message, response.Message);
    }

    [Fact]
    public void BusinessErrorExceptionResponse_Data_ShouldBeNullByDefault()
    {
        // Act
        var response = new BusinessErrorExceptionResponse
        {
            Message = "Error occurred"
        };

        // Assert
        Assert.Null(response.Data);
    }

    [Fact]
    public void BusinessErrorExceptionResponse_Data_ShouldAcceptValues()
    {
        // Arrange
        var data = new { Detail = "Some detail" };

        // Act
        var response = new BusinessErrorExceptionResponse
        {
            Message = "Error occurred",
            Data = data
        };

        // Assert
        Assert.Equal(data, response.Data);
    }

    [Fact]
    public void BusinessErrorExceptionResponse_Data_ShouldAcceptDifferentTypes()
    {
        // Arrange
        var dataString = "Some detail";
        var dataInt = 42;

        // Act
        var responseString = new BusinessErrorExceptionResponse
        {
            Message = "Error occurred",
            Data = dataString
        };

        var responseInt = new BusinessErrorExceptionResponse
        {
            Message = "Error occurred",
            Data = dataInt
        };

        // Assert
        Assert.Equal(dataString, responseString.Data);
        Assert.Equal(dataInt, responseInt.Data);
    }
}