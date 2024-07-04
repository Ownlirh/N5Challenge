using N5.Api.Domain.Models;
using NetArchTest.Rules;

namespace N5.Api.Domain.Tests;

public class ArquitectureTest
{
    [Fact]
    public void DomainShouldNotHaveForbiddenDependencies()
    {
        var testResult = Types
        .InAssembly(typeof(AppSettings).Assembly)
        .ShouldNot()
        .HaveDependencyOnAny("N5.Api.Web", "N5.Api.Web")
        .GetResult();

        Assert.True(testResult.IsSuccessful);
    }
}
