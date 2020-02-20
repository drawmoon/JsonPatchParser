using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonPatchValidator.Extensions;
using JsonPatchValidator.Sample.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace JsonPatchValidator.Sample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
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