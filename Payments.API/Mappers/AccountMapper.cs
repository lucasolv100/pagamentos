using System.Collections.Generic;
using Payments.Domain.Entities;
using Payments.Domain.ViewModels;

namespace Payments.API.Mappers
{
    public class AccountMapper
    {
        public AccountVM Mapper(Account entidade)
        {
            return new AccountVM{
                CreateDate = entidade.CreateDate,
                DeleteDate = entidade.DeleteDate,
                Document = entidade.Document,
                EditDate = entidade.EditDate,
                Id = entidade.Id,
                IsLegalPerson = entidade.IsLegalPerson,
                Name = entidade.Name
            };
        }
        public List<AccountVM> Mapper(List<Account> entidades)
        {
            List<AccountVM> retorno = new();
            foreach (var item in entidades)
            {
                retorno.Add(Mapper(item));
            }

            return retorno;
        }
    }
}