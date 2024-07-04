namespace N5.Api.Application.Tests.Validators.Permissions;

using FluentValidation.TestHelper;
using N5.Api.Application.DTOs;
using N5.Api.Application.Validators.Permissions;
using Xunit;

public class UpsertPermissionDTOValidatorTests
{
    private readonly UpsertPermissionDTOValidator _validator;

    public UpsertPermissionDTOValidatorTests()
    {
        _validator = new UpsertPermissionDTOValidator();
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Null()
    {
        // Arrange
        var dto = new RegisterPermissionDTO { Name = null, Surname = "Valid SurName" };

        // Act & Assert
        var result = _validator.TestValidate(dto);
        result.ShouldHaveValidationErrorFor(permission => permission.Name);
    }

    [Fact]
    public void Should_Have_Error_When_Name_Is_Empty()
    {
        // Arrange
        var dto = new RegisterPermissionDTO { Name = "", Surname = null };

        // Act & Assert
        var result = _validator.TestValidate(dto);
        result.ShouldHaveValidationErrorFor(permission => permission.Name);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Name_Is_Specified()
    {
        // Arrange
        var dto = new RegisterPermissionDTO { Name = "Valid Name", Surname = "Valid SurName" };

        // Act & Assert
        var result = _validator.TestValidate(dto);
        result.ShouldNotHaveValidationErrorFor(permission => permission.Name);
    }

    [Fact]
    public void Should_Have_Error_When_Surname_Is_Null()
    {
        // Arrange
        var dto = new RegisterPermissionDTO { Name = "Valid Name", Surname = null };

        // Act & Assert
        var result = _validator.TestValidate(dto);
        result.ShouldHaveValidationErrorFor(permission => permission.Surname);
    }

    [Fact]
    public void Should_Have_Error_When_Surname_Is_Empty()
    {
        // Arrange
        var dto = new RegisterPermissionDTO { Name = "Valid Name", Surname = "" };

        // Act & Assert
        var result = _validator.TestValidate(dto);
        result.ShouldHaveValidationErrorFor(permission => permission.Surname);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Surname_Is_Specified()
    {
        // Arrange
        var dto = new RegisterPermissionDTO { Name = "Valid Name", Surname = "Valid Surname" };

        // Act & Assert
        var result = _validator.TestValidate(dto);
        result.ShouldNotHaveValidationErrorFor(permission => permission.Surname);
    }

    [Fact]
    public void Should_Have_Error_When_PermissionTypeId_Is_Less_Than_Or_Equal_To_Zero()
    {
        // Arrange
        var dto = new RegisterPermissionDTO { Name = "Valid Name", Surname = "Valid Surname", PermissionTypeId = 0 };

        // Act & Assert
        var result = _validator.TestValidate(dto);
        result.ShouldHaveValidationErrorFor(permission => permission.PermissionTypeId);
    }

    [Fact]
    public void Should_Not_Have_Error_When_PermissionTypeId_Is_Greater_Than_Zero()
    {
        // Arrange
        var dto = new RegisterPermissionDTO { Name = "Valid Name", Surname = "Valid Surname", PermissionTypeId = 1 };

        // Act & Assert
        var result = _validator.TestValidate(dto);
        result.ShouldNotHaveValidationErrorFor(permission => permission.PermissionTypeId);
    }
}
