namespace N5.Api.Domain.Entities;

public class EmployerPermission
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int PermissionId { get; set; }
    public required PermissionType PermissionTypeRel { get; set; }
}
