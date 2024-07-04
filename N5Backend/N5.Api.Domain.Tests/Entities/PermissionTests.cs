using N5.Api.Domain.Entities;

namespace N5.Api.Domain.Tests.Entities;

public class PermissionTests
{
    [Fact]
    public void Permission_ShouldHaveDefaultCreatedAt()
    {
        // Arrange
        var permission = new Permission()
        {
            Name = "John",
            Surname = "Doe"
        };

        // Act
        var createdAt = permission.CreatedAt;

        // Assert
        Assert.Equal(DateTime.UtcNow, createdAt, TimeSpan.FromSeconds(1));
    }

    [Fact]
    public void Permission_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var id = 1;
        var name = "John";
        var surname = "Doe";
        var permissionId = 1;

        // Act
        var permission = new Permission
        {
            Id = id,
            Name = name,
            Surname = surname,
            PermissionId = permissionId
        };

        // Assert
        Assert.Equal(id, permission.Id);
        Assert.Equal(name, permission.Name);
        Assert.Equal(surname, permission.Surname);
        Assert.Equal(permissionId, permission.PermissionId);
    }
}