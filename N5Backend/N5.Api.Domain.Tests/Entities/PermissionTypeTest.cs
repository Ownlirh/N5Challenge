using N5.Api.Domain.Entities;

namespace N5.Api.Domain.Tests.Entities;

public class PermissionTypeTests
{
    [Fact]
    public void PermissionType_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var id = 1;
        var description = "Admin Permission";

        // Act
        var permissionType = new PermissionType
        {
            Id = id,
            Description = description
        };

        // Assert
        Assert.Equal(id, permissionType.Id);
        Assert.Equal(description, permissionType.Description);
    }
}