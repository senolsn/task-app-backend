using Core.DataAccess.Paging;
using Core.Entities.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories
{
    public interface IAsyncRepository<TEntity> : IQuery<TEntity> where TEntity : IEntity
    {
        Task<TEntity?> GetAsync(
           Expression<Func<TEntity, bool>> predicate,
           bool withDeleted = false,
           bool enableTracking = true,
           CancellationToken cancellationToken = default
        );

        Task<IPaginate<TEntity>> GetPaginatedListAsync(
           Expression<Func<TEntity, bool>> predicate,
           int index = 0,
           int size = 10,
           bool withDeleted = false,
           bool enableTracking = true,
           CancellationToken cancellationToken = default
        );

        Task<ICollection<TEntity>> GetListAsyncOrderBy(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool withDeleted = false, bool enableTracking = true,
            CancellationToken cancellationToken = default);

        Task<ICollection<TEntity>> GetListAsync(
          Expression<Func<TEntity, bool>>? predicate = null,
          bool withDeleted = false,
          bool enableTracking = true,
          CancellationToken cancellationToken = default
       );

        Task<IPaginate<TEntity>> GetListPaginatedAsyncOrderBy(
       Expression<Func<TEntity, bool>>? predicate = null,
       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
       int index = 0,
       int size = 10,
       bool withDeleted = false,
       bool enableTracking = true,
       CancellationToken cancellationToken = default
   );

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteAsync(TEntity entity, bool permanent = false);

        Task<bool> SaveChangesAsync();


    }
}
