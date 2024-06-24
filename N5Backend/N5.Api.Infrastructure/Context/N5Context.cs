using Microsoft.EntityFrameworkCore;
using N5.Api.Domain.Entities;

namespace N5.Api.Infrastructure.Context;

public class N5Context : DbContext
{
    public N5Context(DbContextOptions<N5Context> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(N5Context).Assembly);
    }

    public virtual DbSet<PermissionType> PermissionTypes { get; set; }
    public virtual DbSet<EmployerPermission> EmployerPermissions { get; set; }
}
