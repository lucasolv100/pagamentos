using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Payments.Domain.Entities;

namespace Payments.Domain.Interfaces
{
    public interface IRepository<T> where T : Base<T>
    {
         Task AddAsync(T entidade, bool saveChanges = true);
		 Task UpdateAsync(T entidade, bool saveChanges = true);
		 Task<IEnumerable<T>> GetAllAsync();
		 Task<T> GetAsync(int id);
		 Task<T> GetByExpressionAsync(Expression<Func<T, bool>> exp);
    }
}