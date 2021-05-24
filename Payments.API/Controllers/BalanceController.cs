using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Payments.Domain.Entities;
using Payments.Domain.Interfaces;
using Payments.Domain.ViewModels;

namespace Payments.API.Controllers
{
    [ApiController]
    [Route("api/v1/balance")]
    public class BalanceController : ControllerBase
    {
        private readonly IRepository<AccountMovement> _repository;

        public BalanceController(
           IRepository<AccountMovement> repository
       )
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetBalance()
        {
            try
            {
                var creditList = await _repository.GetAllExpressionAsync(w => w.MovementType == Domain.Enums.MovementTypeEnum.Credit);
                var debitList = await _repository.GetAllExpressionAsync(w => w.MovementType == Domain.Enums.MovementTypeEnum.Debit);

                BalanceVM balance = new()
                {
                    Value = creditList.Sum(s => s.Value) - debitList.Sum(s => s.Value)
                };

                return Ok(balance);

            }
            catch (System.Exception ex)
            {
                //TODO: log de erros
                return StatusCode(500, ex.Message);
            }
        }
    }
}
