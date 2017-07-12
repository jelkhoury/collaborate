using SABISCollaborate.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace SABISCollaborate.SharedKernel
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private DbContext _context;

        protected DbContext DbContext
        {
            get
            {
                return this._context;
            }
        }

        public GenericRepository(DbContext context)
        {
            this._context = context;
        }

        public virtual IQueryable<T> GetAll()
        {
            IQueryable<T> query = this._context.Set<T>();
            return query;
        }
        public virtual T GetSingle(int id)
        {
            T entity = this._context.Set<T>().Find(id);
            return entity;
        }
        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this._context.Set<T>().Where(predicate);
            return query;
        }
        public virtual void Add(T entity)
        {
            this._context.Set<T>().Add(entity);
        }
        public virtual void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }
        public virtual void Edit(T entity)
        {
            this._context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Save()
        {
            this._context.SaveChanges();
        }
    }
}
