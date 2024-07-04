using N5.Api.Infrastructure;
using NetArchTest.Rules;

namespace N5.Api.Domain.Tests;

public class ArquitectureTest
{
    [Fact]
    public void InfrastructureShouldNotHaveForbiddenDependencies()
    {
        var testResult = Types
        .InAssembly(typeof(InfrastructureRegistration).Assembly)
        .ShouldNot()
        .HaveDependencyOnAny("N5.Api.Web")
        .GetResult();

        Assert.True(testResult.IsSuccessful);
    }
}
