using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Blob.Core.Data;
using Blob.Core;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace Blob.Data
{
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        protected virtual IDbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.set<T>();

                return _entities;
            }
        }

        public EfRepository(IDbContext context)
        {
            this._context = context;
        }

        #region IRepository<T> Members

        public T GetById(object id)
        {            
            return this.Entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                this.Entities.Add(entity);
                this._context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = string.Empty;

                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += string.Format("Property {0}: Error {1} :", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;

                var fail = new Exception(msg, dbEx);

                throw fail;
            }
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Table
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryable<T> TableNoTracking
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
