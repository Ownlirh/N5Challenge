using Microsoft.EntityFrameworkCore;
using N5.Api.Domain.Entities;

namespace N5.Api.Infrastructure.Extensions;

public static class ModelBuilderExtensions
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PermissionType>().HasData(
            new PermissionType() { Id = 1, Description = "UI/UX" },
            new PermissionType() { Id = 2, Description = "Programmer" },
            new PermissionType() { Id = 3, Description = "Designer" },
            new PermissionType() { Id = 4, Description = "Team Lead" }
            );

        modelBuilder.Entity<Permission>().HasData(
            new Permission() { Id = 1, Name = "Jhon", Surname = "Doe", CreatedAt = DateTime.UtcNow, PermissionId = 1 },
            new Permission() { Id = 2, Name = "Jane", Surname = "Doe", CreatedAt = DateTime.UtcNow, PermissionId = 2 },
            new Permission() { Id = 3, Name = "Seven", Surname = "Doe", CreatedAt = DateTime.UtcNow, PermissionId = 3 },
            new Permission() { Id = 4, Name = "Clop", Surname = "Doe", CreatedAt = DateTime.UtcNow, PermissionId = 4 }
            );
    }
}