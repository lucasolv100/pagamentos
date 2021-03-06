using System.Linq;
using System.Threading.Tasks;
using Payments.Domain.DTOs;
using Payments.Domain.Entities;
using Payments.Domain.Interfaces;
using Payments.Domain.ViewModels;

namespace Payments.Domain.Workers
{
    public class AccountWorker : IWorker<RegisterAccountVM>
    {
        private readonly IRepository<Account> _repository;

        public AccountWorker(IRepository<Account> repository)
        {
            _repository = repository;
        }
        public async Task<APIResponseDTO> Add(RegisterAccountVM model)
        {
            try
            {
                var account = new Account(model.Name, model.Document, model.IsLegalPerson);

                var validations = await account.ValidateAsync(account);

                if (!validations.IsValid)
                {
                    return new APIResponseDTO
                    {
                        Errors = validations.Errors.Select(s => s.ErrorMessage).ToList()
                    };
                }

                await _repository.AddAsync(account);

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

        public async Task<APIResponseDTO> Update(int id, RegisterAccountVM model)
        {
            throw new System.NotImplementedException();
        }
    }
}