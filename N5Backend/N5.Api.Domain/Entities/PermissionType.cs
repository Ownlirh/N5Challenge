﻿namespace N5.Api.Domain.Entities;

public class PermissionType
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public ICollection<EmployerPermission> Employers { get; } = new List<EmployerPermission>();
}