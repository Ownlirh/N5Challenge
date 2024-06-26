using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Api.Application.DTOs;
using N5.Api.Application.Exceptions;
using N5.Api.Application.Features.Permissions.Commands;
using N5.Api.Application.Models;

namespace N5.Api.Controllers;

[Route("api/permission")]
public class PermissionController(
    IMediator mediatoR) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetPermissions()
    {
        try
        {
            // TODO
            return Ok();
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
                PermissionId = request.PermissionId
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
