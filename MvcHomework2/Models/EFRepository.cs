using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MvcHomework2.Models
{
	public class EFRepository<T> : IRepository<T> where T : class
	{
		public IUnitOfWork UnitOfWork { get; set; }
		
		private IDbSet<T> _objectset;
		private IDbSet<T> ObjectSet
		{
			get
			{
				if (_objectset == null)
				{
					_objectset = UnitOfWork.Context.Set<T>();
				}
				return _objectset;
			}
		}

		#region added by walter

		public T Find(params object[] keys)
        {
            return ObjectSet.Find(keys);
        }

        public void Update(T entity)
        {
            var entry = UnitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = ObjectSet;
            foreach (var property in includeProperties)
                query = query.Include(property);
            return query;
        }

		#endregion

		public virtual IQueryable<T> All()
		{
			return ObjectSet.AsQueryable();
		}

		public IQueryable<T> Where(Expression<Func<T, bool>> expression)
		{
			return ObjectSet.Where(expression);
		}

		public void Add(T entity)
		{
			ObjectSet.Add(entity);
		}

		public void Delete(T entity)
		{
			ObjectSet.Remove(entity);
		}

	}
}