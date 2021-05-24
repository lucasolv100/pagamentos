﻿using System;
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
    [Route("api/v1/account")]
    public class AccountController : ControllerBase
    {
         private readonly IWorker<RegisterAccountVM> _worker;

        public AccountController(
            IWorker<RegisterAccountVM> worker
        )
        {
            _worker = worker;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount(RegisterAccountVM model)
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
