namespace N5.Api.Application.DTOs;

public class PermissionDTO
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public DateTime CreatedAt { get; set; }
    public int PermissionId { get; set; }
    public required string PermissionType { get; set; }
}
