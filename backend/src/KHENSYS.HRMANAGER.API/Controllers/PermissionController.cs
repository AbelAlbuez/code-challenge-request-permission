using KHENSYS.HRMANAGER.APPLICATION.Features.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KHENSYS.HRMANAGER.API.Controllers
{
    [ApiVersion("1.0")]
    public class PermissionController : BaseApiController
    {
        /// <summary>
        /// Gets all Permissions.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPermissionsQuery()));
        }

        /// <summary>
        /// Gets Permission Entity by Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPermissionByIdQuery { Id = id }));
        }
    }
}
