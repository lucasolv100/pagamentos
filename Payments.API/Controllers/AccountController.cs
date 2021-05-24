using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payments.API.Mappers;
using Payments.Domain.Entities;
using Payments.Domain.Interfaces;
using Payments.Domain.ViewModels;

namespace Payments.API.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountController : ControllerBase
    {
        private readonly IWorker<RegisterAccountVM> _worker;
        private readonly IRepository<Account> _repository;
        private readonly AccountMapper _mapper;

        public AccountController(
            IWorker<RegisterAccountVM> worker,
            IRepository<Account> repository,
            AccountMapper mapper
        )
        {
            _worker = worker;
            _repository = repository;
            _mapper = mapper;
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
        [HttpGet]
        public async Task<IActionResult> GetAllAccount()
        {
            try
            {
                var accLst = await _repository.GetAllAsync();
                return Ok(_mapper.Mapper(accLst.ToList()));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
