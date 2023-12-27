﻿using BlogApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseAuditableEntity
    {
        Task<IQueryable<T>> ReadAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? expressionOrder = null,
            bool isDescending = false,
            params string[] includes
            );
        Task<T> ReadIdAsync(int Id = 0, params string[] entityIncludes);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int Id);
        Task<int> SaveChangesAsync();
    }
}
