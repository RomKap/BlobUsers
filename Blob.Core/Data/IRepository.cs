using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Blob.Core.Data
{
    public partial interface IRepository<T> where T: BaseEntity
    {
        T GetById(object id);

        void Insert(T entity);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }
    }
}
