using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using N5.Api.Domain.Entities;

namespace N5.Api.Infrastructure.Configurations;

public sealed class EmployerPermissionConfiguration : IEntityTypeConfiguration<EmployerPermission>
{
    public void Configure(EntityTypeBuilder<EmployerPermission> builder)
    {
        builder.HasKey((employer) => employer.Id);

        builder.Property((employer) => employer.Name)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnType("nvarchar(250)");

        builder.Property((employer) => employer.Surname)
                    .IsRequired()
                    .HasMaxLength(250)
                    .HasColumnType("nvarchar(250)");

        builder.Property((employer) => employer.CreatedAt)
                    .IsRequired()
                    .HasColumnType("datetime2");


        builder.HasOne((employer) => employer.PermissionTypeRel)
               .WithMany((permissions) => permissions.Employers)
               .HasForeignKey((employer) => employer.PermissionId);
    }
}
