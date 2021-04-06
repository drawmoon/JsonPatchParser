using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NInfra.JsonPatchValidator.Extensions;
using NInfra.JsonPatchValidator.Sample.Models;

namespace NInfra.JsonPatchValidator.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        /**
         * 
         * PATCH http://localhost:5000/api/simple
         * 
         * Body:
         * [
         *   {
         *     "op": "replace",
         *     "path": "/name2",
         *     "from": "",
         *     "value": "xiaoli"
         *   }
         * ]
         */

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromBody, BindRequired] JsonPatchDocument<Column> patch)
        {
            // verify the syntax of json-patch
            if (!patch.TryVisit(ModelState))
                return BadRequest(ModelState);

            return Ok();
        }
    }
}