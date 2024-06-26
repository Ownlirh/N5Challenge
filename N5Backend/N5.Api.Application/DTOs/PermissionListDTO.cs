namespace N5.Api.Application.DTOs;

public class PermissionListDTO
{
    public IReadOnlyCollection<PermissionDTO> Permissions { get; set; } = new List<PermissionDTO>();
    public int Limit { get; set; }
    public long Total { get; set; }
}
