using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5.Api.Domain.Entities;

namespace N5.Api.Infrastructure.Configurations;

public sealed class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
{
    public void Configure(EntityTypeBuilder<PermissionType> builder)
    {
        builder.HasKey((permission) => permission.Id);

        builder.Property((employer) => employer.Description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnType("nvarchar(500)");
    }
}
