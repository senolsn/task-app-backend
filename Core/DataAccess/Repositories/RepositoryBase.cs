using Core.DataAccess.Paging;
using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DataAccess.Repositories
{
    public class RepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity> where TEntity : BaseEntity where TContext : DbContext
    {
        protected readonly TContext Context;

        public RepositoryBase(TContext context) 
        {
            Context = context;
        }

        public IQueryable<TEntity> Query() => Context.Set<TEntity>();

        public async virtual Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<bool> SaveChangesAsync()
        {
           return await Context.SaveChangesAsync() > 0;
        }
        //SaveChangesAsync'lerin hepsini sil.
        //Dışarda metodu çağırdıktan sonra savechangesasync çağır. Bir metodda birden fazla ekleme yapabiliriz. sonra savechanges yapmak daha performanslı.

        public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent)
        {
            await SetEntityAsDeletedAsync(entity, permanent);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();
            if (!enableTracking)
                queryable = queryable.AsNoTracking(); 
            if (withDeleted) 
                queryable = queryable.IgnoreQueryFilters();
            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        /*Non-paginated list metodu*/
        public virtual async Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters().Where(field => field.DeletedDate == null); //Girdiğim filter koşulunu sağlayan verileri topla.
            if (predicate != null)
                queryable = queryable.Where(predicate);
            return await queryable.ToListAsync(cancellationToken);
        }

        /*Paginated list metodu*/
        public virtual async Task<IPaginate<TEntity>> GetPaginatedListAsync(Expression<Func<TEntity, bool>> predicate, int index = 0, int size = 10, bool withDeleted = false, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters().Where(field => field.DeletedDate == null); //Girdiğim filter koşulunu sağlayan verileri topla.
            if (predicate != null)
                queryable = queryable.Where(predicate);
            return await queryable.ToPaginateAsync(index, size, from: 0, cancellationToken);
        }

        /*Non-paginated list metodu*/
        public virtual async Task<ICollection<TEntity>> GetListAsyncOrderBy(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            bool withDeleted = false, bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters().Where(field => field.DeletedDate == null);
            if (predicate != null)
                queryable = queryable.Where(predicate);

            return await orderBy(queryable).ToListAsync(cancellationToken);
        }

        /*Paginated list metodu*/
        public async Task<IPaginate<TEntity>> GetListPaginatedAsyncOrderBy(
        Expression<Func<TEntity, bool>>? predicate = null, 
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default 
    )
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();
            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters().Where(field => field.DeletedDate == null);
            if (predicate != null)
                queryable = queryable.Where(predicate);
            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, from: 0, cancellationToken);
            return await queryable.ToPaginateAsync(index, size, from: 0, cancellationToken);
        }

        #region Helper Methods

        protected async Task SetEntityAsDeletedAsync(TEntity entity, bool permanent)
        {
            if (!permanent)
            {
                CheckHasEntityHaveOneToOneRelation(entity);
                await setEntityAsSoftDeletedAsync(entity);
            }
            else
            {
                Context.Remove(entity);
            }
        }

        protected async Task SetEntityAsDeletedAsync(IEnumerable<TEntity> entities, bool permanent)
        {
            foreach (TEntity entity in entities)
                await SetEntityAsDeletedAsync(entity, permanent);
        }

        protected void SetEntityAsDeleted(TEntity entity, bool permanent)
        {
            if (!permanent)
            {
                CheckHasEntityHaveOneToOneRelation(entity);
                setEntityAsSoftDeleted(entity);
            }
            else
            {
                Context.Remove(entity);
            }
        }

        protected void SetEntityAsDeleted(IEnumerable<TEntity> entities, bool permanent)
        {
            foreach (TEntity entity in entities)
                SetEntityAsDeleted(entity, permanent);
        }

        protected IQueryable<object> GetRelationLoaderQuery(IQueryable query, Type navigationPropertyType)
        {
            Type queryProviderType = query.Provider.GetType();
            MethodInfo createQueryMethod =
                queryProviderType
                    .GetMethods()
                    .First(m => m is { Name: nameof(query.Provider.CreateQuery), IsGenericMethod: true })
                    ?.MakeGenericMethod(navigationPropertyType)
                ?? throw new InvalidOperationException("CreateQuery<TElement> method is not found in IQueryProvider.");
            var queryProviderQuery =
                (IQueryable<object>)createQueryMethod.Invoke(query.Provider, parameters: new object[] { query.Expression })!;
            return queryProviderQuery.Where(x => !((IEntityTimestamps)x).DeletedDate.HasValue);
        }

        protected void CheckHasEntityHaveOneToOneRelation(TEntity entity)
        {
            bool hasEntityHaveOneToOneRelation =
                Context
                    .Entry(entity)
                    .Metadata.GetForeignKeys()
                    .All(
                        x =>
                            x.DependentToPrincipal?.IsCollection == true
                            || x.PrincipalToDependent?.IsCollection == true
                            || x.DependentToPrincipal?.ForeignKey.DeclaringEntityType.ClrType == entity.GetType()
                    ) == false;
            if (hasEntityHaveOneToOneRelation)
                throw new InvalidOperationException(
                    "Entity has one-to-one relationship. Soft Delete causes problems if you try to create entry again by same foreign key."
                );
        }

        private async Task setEntityAsSoftDeletedAsync(IEntityTimestamps entity)
        {
            if (entity.DeletedDate.HasValue)
                return;
            entity.DeletedDate = DateTime.UtcNow;

            var navigations = Context
                .Entry(entity)
                .Metadata.GetNavigations()
                .Where(x => x is { IsOnDependent: false, ForeignKey.DeleteBehavior: DeleteBehavior.ClientCascade or DeleteBehavior.Cascade })
                .ToList();
            foreach (INavigation? navigation in navigations)
            {
                if (navigation.TargetEntityType.IsOwned())
                    continue;
                if (navigation.PropertyInfo == null)
                    continue;

                object? navValue = navigation.PropertyInfo.GetValue(entity);
                if (navigation.IsCollection)
                {
                    if (navValue == null)
                    {
                        IQueryable query = Context.Entry(entity).Collection(navigation.PropertyInfo.Name).Query();
                        navValue = await GetRelationLoaderQuery(query, navigationPropertyType: navigation.PropertyInfo.GetType()).ToListAsync();
                        if (navValue == null)
                            continue;
                    }

                    foreach (IEntityTimestamps navValueItem in (IEnumerable)navValue)
                        await setEntityAsSoftDeletedAsync(navValueItem);
                }
                else
                {
                    if (navValue == null)
                    {
                        IQueryable query = Context.Entry(entity).Reference(navigation.PropertyInfo.Name).Query();
                        navValue = await GetRelationLoaderQuery(query, navigationPropertyType: navigation.PropertyInfo.GetType())
                            .FirstOrDefaultAsync();
                        if (navValue == null)
                            continue;
                    }

                    await setEntityAsSoftDeletedAsync((IEntityTimestamps)navValue);
                }
            }

            Context.Update(entity);
        }

        private void setEntityAsSoftDeleted(IEntityTimestamps entity)
        {
            if (entity.DeletedDate.HasValue)
                return;
            entity.DeletedDate = DateTime.UtcNow;

            var navigations = Context
                .Entry(entity)
                .Metadata.GetNavigations()
                .Where(x => x is { IsOnDependent: false, ForeignKey.DeleteBehavior: DeleteBehavior.ClientCascade or DeleteBehavior.Cascade })
                .ToList();
            foreach (INavigation? navigation in navigations)
            {
                if (navigation.TargetEntityType.IsOwned())
                    continue;
                if (navigation.PropertyInfo == null)
                    continue;

                object? navValue = navigation.PropertyInfo.GetValue(entity);
                if (navigation.IsCollection)
                {
                    if (navValue == null)
                    {
                        IQueryable query = Context.Entry(entity).Collection(navigation.PropertyInfo.Name).Query();
                        navValue = GetRelationLoaderQuery(query, navigationPropertyType: navigation.PropertyInfo.GetType()).ToList();
                        if (navValue == null)
                            continue;
                    }

                    foreach (IEntityTimestamps navValueItem in (IEnumerable)navValue)
                        setEntityAsSoftDeleted(navValueItem);
                }
                else
                {
                    if (navValue == null)
                    {
                        IQueryable query = Context.Entry(entity).Reference(navigation.PropertyInfo.Name).Query();
                        navValue = GetRelationLoaderQuery(query, navigationPropertyType: navigation.PropertyInfo.GetType()).FirstOrDefault();
                        if (navValue == null)
                            continue;
                    }

                    setEntityAsSoftDeleted((IEntityTimestamps)navValue);
                }
            }

            Context.Update(entity);
        }
        #endregion
    }
}
