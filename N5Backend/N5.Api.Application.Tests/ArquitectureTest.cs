using N5.Api.Application.Exceptions;
using NetArchTest.Rules;

namespace N5.Api.Application.Tests;

public class ArquitectureTest
{
    [Fact]
    public void ApplicationShouldNotHaveForbiddenDependencies()
    {

        var testResult = Types
        .InAssembly(typeof(BusinessException).Assembly)
        .ShouldNot()
        .HaveDependencyOnAny("N5.Api.Infrastructure", "N5.Api.Web")
        .GetResult();

        Assert.True(testResult.IsSuccessful);
    }
}
