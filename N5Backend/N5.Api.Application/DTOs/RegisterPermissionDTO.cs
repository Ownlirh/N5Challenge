namespace N5.Api.Application.DTOs;

public class RegisterPermissionDTO
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public int PermissionTypeId { get; set; }
}
