using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Payments.Domain.Entities;
using Payments.Domain.Interfaces;

namespace Payments.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Base<T>
    {
        private readonly PaymentsContext _context;

        public Repository(PaymentsContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entidade, bool saveChanges = true)
        {
            await _context.Set<T>().AddAsync(entidade);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().Where(w => w.DeleteDate == null).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllExpressionAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().Where(exp).ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(f => f.Id == id && f.DeleteDate == null);
        }

        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().Where(w => w.DeleteDate == null).FirstOrDefaultAsync(exp);
        }

        public async Task UpdateAsync(T entidade, bool saveChanges = true)
        {
            _context.Set<T>().Update(entidade);
            if (saveChanges)
                await _context.SaveChangesAsync();
        }
    }
}