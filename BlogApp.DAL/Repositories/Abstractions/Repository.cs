using BlogApp.Core.Entities.Common;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Abstractions
{
    public class Repository<T> : IRepository<T> where T : BaseAuditableEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IQueryable<T>> ReadAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? expressionOrder = null,
            bool isDescending = false,
            params string[] includes
            )
        {
            IQueryable<T> query = _dbSet;
            if (expression is not null)
            {
                query = query.Where(expression);
            }
            if(expressionOrder is not null)
            {
                query = isDescending ? query.OrderByDescending(expressionOrder) : query.OrderBy(expressionOrder);
            }
            if(includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query.Include(includes[i]);
                }
            }

            return query
                .Where(x => !x.IsDeleted);
        }

        public async Task<T> ReadAsync(int Id)
        {
            return await _dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);

            return entity;
        }
        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);

            return entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            entity.IsDeleted = true;

            _dbSet.Update(entity);

            return entity;
        }
        
        public async Task<int> SaveChangesAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result;
        }

    }
}
