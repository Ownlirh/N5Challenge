using Microsoft.AspNetCore.Mvc;
using N5.Api.Application.Exceptions;
using N5.Api.Application.Models;
using N5.Api.Application.Services;

namespace N5.Api.Controllers;

[Route("api/permission")]
public class PermissionController(
    IPermissionService permissionService) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetPermissions()
    {
        try
        {
            return Ok(await permissionService.GetPermissions());
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
