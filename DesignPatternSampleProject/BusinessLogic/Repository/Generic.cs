using EntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.EntityExtensions;
using BusinessLogic.Models;

namespace BusinessLogic.Repository
{
    public class Generic<TEntity, TModel> where TEntity : class
    {
        internal DesignPatternSampleEntities context;
        internal DbSet<TEntity> dbSet;

        private GenericEntityExtensions<TEntity,TModel> EntityExtension;


        public GenericEntityExtensions<TEntity, TModel> entityExtension
        {
            get
            {
                return this.EntityExtension ?? new GenericEntityExtensions<TEntity, TModel>();
            }
        }


        public Generic(DesignPatternSampleEntities context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TModel> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
               
                var output = orderBy(query).ToList();
                var returnlist = new List<TModel>();
                foreach(var o in output)
                {
                   returnlist.Add(entityExtension.ToModel(o));
                }
                return returnlist;

            }
            else
            {
                var output = query.ToList();
                var returnlist = new List<TModel>();
                foreach (var o in output)
                {
                    returnlist.Add(entityExtension.ToModel(o));
                }
                return returnlist;
            }
        }

        public virtual TModel GetByID(object id)
        {
            
            var returnval = dbSet.Find(id);
            var output = entityExtension.ToModel((TEntity)(object)returnval);
            
            return output;
        }

        public virtual void Insert(TModel entity)
        {
            var output = entityExtension.ToEntity(((TModel)(object)entity),null);
            dbSet.Add(output);
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

        public virtual void Update(TModel entityToUpdate, object id)
        {
            TEntity entity = dbSet.Find(id);
            var output = entityExtension.ToEntity(((TModel)(object)entityToUpdate), entity);
            dbSet.Attach(output);
            context.Entry(output).State = EntityState.Modified;
        }
    }
}
