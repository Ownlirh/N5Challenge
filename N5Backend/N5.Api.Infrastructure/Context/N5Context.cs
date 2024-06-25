using Microsoft.EntityFrameworkCore;
using N5.Api.Domain.Entities;
using N5.Api.Infrastructure.Extensions;

namespace N5.Api.Infrastructure.Context;

public class N5Context : DbContext
{
    public N5Context(DbContextOptions<N5Context> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(N5Context).Assembly);

        modelBuilder.SeedData();

        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<PermissionType> PermissionTypes { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }
}
