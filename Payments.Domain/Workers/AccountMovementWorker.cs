using System.Linq;
using System.Threading.Tasks;
using Payments.Domain.DTOs;
using Payments.Domain.Entities;
using Payments.Domain.Interfaces;
using Payments.Domain.ViewModels;

namespace Payments.Domain.Workers
{
    public class AccountMovementWorker : IWorker<RegisterOperationVM>
    {
        private readonly IRepository<AccountMovement> _repository;

        public AccountMovementWorker(IRepository<AccountMovement> repository)
        {
            _repository = repository;
        }
        public async Task<APIResponseDTO> Add(RegisterOperationVM model)
        {
            try
            {
                var accountMovement = new AccountMovement(model.Value, model.AccountId, model.Type);

                var validations = await accountMovement.ValidateAsync(accountMovement);

                if (!validations.IsValid)
                {
                    return new APIResponseDTO
                    {
                        Errors = validations.Errors.Select(s => s.ErrorMessage).ToList()
                    };
                }

                await _repository.AddAsync(accountMovement);

                return new APIResponseDTO();
            }
            catch (System.Exception ex)
            {
                //TODO: log de erros
                throw;
            }


        }

        public async Task<APIResponseDTO> Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<APIResponseDTO> Update(int id, RegisterOperationVM model)
        {
            throw new System.NotImplementedException();
        }
    }
}