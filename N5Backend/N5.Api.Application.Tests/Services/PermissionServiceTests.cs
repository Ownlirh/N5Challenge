using Moq;
using N5.Api.Application.Contracts;
using N5.Api.Application.DTOs;
using N5.Api.Application.Exceptions;
using N5.Api.Application.Services;
using N5.Api.Domain.Entities;

namespace N5.Api.Application.Tests.Services;

public class PermissionServiceTests
{
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IPermissionsRepository> _permissionRepositoryMock;
    private readonly Mock<IPermissionTypeRepository> _permissionTypeRepositoryMock;
    private readonly Mock<IPermissionsElasticSearchService> _permissionsElasticSearchServiceMock;
    private readonly PermissionService _permissionService;

    public PermissionServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _permissionRepositoryMock = new Mock<IPermissionsRepository>();
        _permissionTypeRepositoryMock = new Mock<IPermissionTypeRepository>();
        _permissionsElasticSearchServiceMock = new Mock<IPermissionsElasticSearchService>();

        _unitOfWorkMock.Setup(u => u.PermissionRepository).Returns(_permissionRepositoryMock.Object);
        _unitOfWorkMock.Setup(u => u.PermissionTypeRepository).Returns(_permissionTypeRepositoryMock.Object);

        _permissionService = new PermissionService(_unitOfWorkMock.Object, _permissionsElasticSearchServiceMock.Object);
    }

    [Fact]
    public async Task CreatePermission_ShouldCreatePermissionAndAddToElasticSearch()
    {
        // Arrange
        var request = new RegisterPermissionDTO
        {
            Name = "John",
            Surname = "Doe",
            PermissionTypeId = 1
        };

        var permissionType = new PermissionType { Id = 1, Description = "Admin" };

        _permissionTypeRepositoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(permissionType);
        _permissionsElasticSearchServiceMock.Setup(e => e.AddOrUpdate(It.IsAny<PermissionDTO>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

        // Act
        await _permissionService.CreatePermission(request, CancellationToken.None);

        // Assert
        _unitOfWorkMock.Verify(u => u.BeginTransactionAsync(), Times.Once);
        _permissionRepositoryMock.Verify(p => p.Add(It.IsAny<Permission>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        _permissionTypeRepositoryMock.Verify(p => p.GetByIdAsync(request.PermissionTypeId), Times.Once);
        _permissionsElasticSearchServiceMock.Verify(e => e.AddOrUpdate(It.IsAny<PermissionDTO>(), It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.DisposeAsync(), Times.Once);
    }

    [Fact]
    public async Task CreatePermission_ShouldRollbackTransactionAndThrow_WhenElasticSearchFails()
    {
        // Arrange
        var request = new RegisterPermissionDTO
        {
            Name = "John",
            Surname = "Doe",
            PermissionTypeId = 1
        };

        var permissionType = new PermissionType { Id = 1, Description = "Admin" };

        _permissionTypeRepositoryMock.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(permissionType);
        _permissionsElasticSearchServiceMock.Setup(e => e.AddOrUpdate(It.IsAny<PermissionDTO>(), It.IsAny<CancellationToken>())).ReturnsAsync(false);

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _permissionService.CreatePermission(request, CancellationToken.None));

        _unitOfWorkMock.Verify(u => u.BeginTransactionAsync(), Times.Once);
        _permissionRepositoryMock.Verify(p => p.Add(It.IsAny<Permission>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        _permissionTypeRepositoryMock.Verify(p => p.GetByIdAsync(request.PermissionTypeId), Times.Once);
        _permissionsElasticSearchServiceMock.Verify(e => e.AddOrUpdate(It.IsAny<PermissionDTO>(), It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.RollBackAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.DisposeAsync(), Times.Once);
    }

    [Fact]
    public async Task CreatePermission_ShouldRollbackTransactionAndThrow_WhenExceptionIsThrown()
    {
        // Arrange
        var request = new RegisterPermissionDTO
        {
            Name = "John",
            Surname = "Doe",
            PermissionTypeId = 1
        };

        _permissionRepositoryMock.Setup(p => p.Add(It.IsAny<Permission>())).ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _permissionService.CreatePermission(request, CancellationToken.None));

        _unitOfWorkMock.Verify(u => u.BeginTransactionAsync(), Times.Once);
        _permissionRepositoryMock.Verify(p => p.Add(It.IsAny<Permission>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.RollBackAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.DisposeAsync(), Times.Once);
    }

    [Fact]
    public async Task GetPermissionById_ShouldCallElasticSearchServiceWithCorrectId()
    {
        // Arrange
        int permissionId = 1;
        CancellationToken cancellationToken = CancellationToken.None;
        var expectedPermissionDTO = new PermissionDTO { Id = permissionId, Name = "John Doe", PermissionType = "ADmin", Surname = "Test" };

        _permissionsElasticSearchServiceMock.Setup(e => e.GetDocument(permissionId, cancellationToken)).ReturnsAsync(expectedPermissionDTO);

        // Act
        var result = await _permissionService.GetPermissionById(permissionId, cancellationToken);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(expectedPermissionDTO.Id, result.Id);
        Assert.Equal(expectedPermissionDTO.Name, result.Name);

        _permissionsElasticSearchServiceMock.Verify(e => e.GetDocument(permissionId, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task GetPermissionById_ShouldHandleNullReturnFromElasticSearchService()
    {
        // Arrange
        int permissionId = 1;
        CancellationToken cancellationToken = CancellationToken.None;

        _permissionsElasticSearchServiceMock.Setup(e => e.GetDocument(permissionId, cancellationToken)).ReturnsAsync((PermissionDTO)null);

        // Act
        var result = await _permissionService.GetPermissionById(permissionId, cancellationToken);

        // Assert
        Assert.Null(result);

        _permissionsElasticSearchServiceMock.Verify(e => e.GetDocument(permissionId, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task GetPermissionById_ShouldHandleExceptionFromElasticSearchService()
    {
        // Arrange
        int permissionId = 1;
        CancellationToken cancellationToken = CancellationToken.None;

        _permissionsElasticSearchServiceMock.Setup(e => e.GetDocument(permissionId, cancellationToken)).ThrowsAsync(new Exception("ElasticSearch error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _permissionService.GetPermissionById(permissionId, cancellationToken));

        _permissionsElasticSearchServiceMock.Verify(e => e.GetDocument(permissionId, cancellationToken), Times.Once);
    }

    [Fact]
    public async Task ModifyPermission_ShouldUpdatePermissionAndSyncWithElasticSearch()
    {
        // Arrange
        var request = new ModifyPermissionDTO
        {
            Id = 1,
            Name = "Updated Name",
            Surname = "Updated Surname",
            PermissionTypeId = 2
        };

        var existingPermission = new Permission
        {
            Id = request.Id,
            Name = "Original Name",
            Surname = "Original Surname",
            PermissionId = 1
        };

        var permissionType = new PermissionType { Id = 2, Description = "Updated Type" };

        _unitOfWorkMock.Setup(u => u.PermissionRepository.GetByIdAsync(request.Id)).ReturnsAsync(existingPermission);
        _unitOfWorkMock.Setup(u => u.PermissionTypeRepository.GetByIdAsync(request.PermissionTypeId)).ReturnsAsync(permissionType);
        _unitOfWorkMock.Setup(u => u.SaveChangesAsync()).Returns(Task.CompletedTask);
        _permissionsElasticSearchServiceMock.Setup(e => e.AddOrUpdate(It.IsAny<PermissionDTO>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);

        // Act
        await _permissionService.ModifyPermission(request, CancellationToken.None);

        // Assert
        _unitOfWorkMock.Verify(u => u.BeginTransactionAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.PermissionRepository.GetByIdAsync(request.Id), Times.Once);
        _unitOfWorkMock.Verify(u => u.PermissionTypeRepository.GetByIdAsync(request.PermissionTypeId), Times.Once);
        _unitOfWorkMock.Verify(u => u.PermissionRepository.Update(existingPermission), Times.Once);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Once);
        _permissionsElasticSearchServiceMock.Verify(e => e.AddOrUpdate(It.IsAny<PermissionDTO>(), It.IsAny<CancellationToken>()), Times.Once);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.DisposeAsync(), Times.Once);

        Assert.Equal(request.Name, existingPermission.Name);
        Assert.Equal(request.Surname, existingPermission.Surname);
        Assert.Equal(request.PermissionTypeId, existingPermission.PermissionId);
    }

    [Fact]
    public async Task ModifyPermission_ShouldThrowBusinessException_WhenPermissionNotFound()
    {
        // Arrange
        var request = new ModifyPermissionDTO { Id = 1, Name = "Test", Surname = "Test" };

        _unitOfWorkMock.Setup(u => u.PermissionRepository.GetByIdAsync(request.Id)).ReturnsAsync((Permission)null);

        // Act & Assert
        await Assert.ThrowsAsync<BusinessException>(() => _permissionService.ModifyPermission(request, CancellationToken.None));

        _unitOfWorkMock.Verify(u => u.BeginTransactionAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.PermissionRepository.GetByIdAsync(request.Id), Times.Once);
        _unitOfWorkMock.Verify(u => u.RollBackAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.DisposeAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.PermissionRepository.Update(It.IsAny<Permission>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Never);
        _permissionsElasticSearchServiceMock.Verify(e => e.AddOrUpdate(It.IsAny<PermissionDTO>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Never);
    }

    [Fact]
    public async Task ModifyPermission_ShouldRollbackTransactionAndThrow_WhenExceptionOccurs()
    {
        // Arrange
        var request = new ModifyPermissionDTO
        {
            Id = 1,
            Name = "Updated Name",
            Surname = "Updated Surname",
            PermissionTypeId = 2
        };

        _unitOfWorkMock.Setup(u => u.PermissionRepository.GetByIdAsync(request.Id)).ThrowsAsync(new Exception("Database error"));

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => _permissionService.ModifyPermission(request, CancellationToken.None));

        _unitOfWorkMock.Verify(u => u.BeginTransactionAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.PermissionRepository.GetByIdAsync(request.Id), Times.Once);
        _unitOfWorkMock.Verify(u => u.RollBackAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.DisposeAsync(), Times.Once);
        _unitOfWorkMock.Verify(u => u.PermissionRepository.Update(It.IsAny<Permission>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.SaveChangesAsync(), Times.Never);
        _permissionsElasticSearchServiceMock.Verify(e => e.AddOrUpdate(It.IsAny<PermissionDTO>(), It.IsAny<CancellationToken>()), Times.Never);
        _unitOfWorkMock.Verify(u => u.CommitAsync(), Times.Never);
    }
}