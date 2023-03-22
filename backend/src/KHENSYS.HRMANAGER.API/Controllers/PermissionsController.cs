using Application.Features.ProductFeatures.Commands;
using KHENSYS.HRMANAGER.APPLICATION.Features.Command;
using KHENSYS.HRMANAGER.APPLICATION.Features.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KHENSYS.HRMANAGER.API.Controllers
{
    [ApiVersion("1.0")]
    public class PermissionsController : BaseApiController
    {
        /// <summary>
        /// Creates a New Permission.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreatePermissionCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

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

        /// <summary>
        /// Deletes Permission Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePermissionByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates the Permission Entity based on Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdatePermissionCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
