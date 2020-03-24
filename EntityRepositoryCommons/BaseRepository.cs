using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace EntityRepositoryCommons
{
    public abstract class BaseRepository<TEntity, TModel> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext context { get; set; }
        internal DbSet<TEntity> dbSet;
        internal MapperConfiguration mapperConfiguration;
        public BaseRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
            mapperConfiguration = new MapperConfiguration(cfg => {
                cfg.AllowNullCollections = true;
                cfg.AllowNullDestinationValues = true;
                cfg.CreateMap<TModel, TEntity>();
            });

        }

        public virtual TEntity toEntity(TModel model)
        {
            var mapper = new Mapper(this.mapperConfiguration);
            return mapper.Map<TEntity>(model);
        }

        public virtual TModel toModel(TEntity entity)
        {
            var mapper = new Mapper(this.mapperConfiguration);
            return mapper.Map<TModel>(entity);
        }

        public virtual List<TModel> toList(IEnumerable<TEntity> entitiesList)
        {
            var mapper = new Mapper(this.mapperConfiguration);
            return mapper.Map<IEnumerable<TEntity>, List<TModel>>(entitiesList.ToList<TEntity>());
        }


        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            return dbSet.SqlQuery(query, parameters).ToList();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual TModel Insert(TModel model)
        {
            TEntity entity = toEntity(model);
            return toModel(Insert(entity));
        }


        public virtual TEntity Insert(TEntity entity)
        {
            return dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

    }
}

