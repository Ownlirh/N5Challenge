using MediatR;
using Microsoft.AspNetCore.Mvc;
using N5.Api.Application.Exceptions;
using N5.Api.Application.Features.PermissionTypes.Queries.GetPermissionTypes;
using N5.Api.Application.Models;

namespace N5.Api.Controllers;

[Route("api/permission-types")]
public class PermissionTypeController(
    IMediator mediatoR) : ControllerBase
{
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> GetPermissionTypes()
    {
        try
        {
            var query = new GetPermissionTypeQuery() { };

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
}
