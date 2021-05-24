using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payments.Domain.Interfaces;
using Payments.Domain.ViewModels;

namespace Payments.API.Controllers
{
    [ApiController]
    [Route("api/v1/operation")]
    public class OperationController : ControllerBase
    {
         private readonly IWorker<RegisterOperationVM> _worker;

        public OperationController(
            IWorker<RegisterOperationVM> worker
        )
        {
            _worker = worker;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperation(RegisterOperationVM model)
        {
            var resp = await _worker.Add(model);
            
            if (!resp.Success)
            {
                return BadRequest(resp);
            }

            return NoContent();
        }
    }
}
