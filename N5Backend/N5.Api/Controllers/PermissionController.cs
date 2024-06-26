using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Api.Application.DTOs;
using N5.Api.Application.Exceptions;
using N5.Api.Application.Features.Permissions.Commands.CreatePermission;
using N5.Api.Application.Features.Permissions.Commands.ModifyPermission;
using N5.Api.Application.Features.Permissions.Queries.GetPermissions;
using N5.Api.Application.Features.Permissions.Queries.Queries;
using N5.Api.Application.Models;

namespace N5.Api.Controllers;

[Route("api/permission")]
public class PermissionController(
    IMediator mediatoR) : ControllerBase
{
    [HttpGet]
    [Route("{permissionId:int}")]
    public async Task<ActionResult> GetPermissionById(int permissionId)
    {
        try
        {
            var query = new GetPermissionByIdQuery() { PermissionId = permissionId };

            return Ok(await mediatoR.Send(query));
        }
        catch (BusinessException ex)
        {
            return BadRequest(new BusinessErrorExceptionResponse()
            {
                Data = ex.ExceptionData,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetPermissions(int limit = 5)
    {
        try
        {
            var query = new GetPermissionQuery() { Limit = limit };

            return Ok(await mediatoR.Send(query));
        }
        catch (BusinessException ex)
        {
            return BadRequest(new BusinessErrorExceptionResponse()
            {
                Data = ex.ExceptionData,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    [HttpPut]
    [Route("{permissionId:int}")]
    public async Task<ActionResult> ModifyPermission(int permissionId, [FromBody] RegisterPermissionDTO request)
    {
        try
        {
            var query = new ModifyPermissionCommand()
            {
                Id = permissionId,
                Name = request.Name,
                Surname = request.Surname,
                PermissionTypeId = request.PermissionTypeId
            };

            await mediatoR.Send(query);

            return Ok("Succesfully modify permission.");
        }
        catch (BusinessException ex)
        {
            return BadRequest(new BusinessErrorExceptionResponse()
            {
                Data = ex.ExceptionData,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }

    // Not asked in the challenge but used for upload permissions to elastic search
    [HttpPost]
    [Route("")]
    public async Task<ActionResult> CreatePermission([FromBody] RegisterPermissionDTO request)
    {
        try
        {
            var command = new CreatePermissionCommand()
            {
                Name = request.Name,
                Surname = request.Surname,
                PermissionTypeId = request.PermissionTypeId
            };

            await mediatoR.Send(command).ConfigureAwait(false);

            return Ok("Succesfully create permission");
        }
        catch (BusinessException ex)
        {
            return BadRequest(new BusinessErrorExceptionResponse()
            {
                Data = ex.ExceptionData,
                Message = ex.Message
            });
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }


}
