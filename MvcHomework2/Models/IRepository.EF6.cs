﻿

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MvcHomework2.Models
{ 
	public interface IRepository<T> 
	{
		IUnitOfWork UnitOfWork { get; set; }
		IQueryable<T> All();
		IQueryable<T> Where(Expression<Func<T, bool>> expression);
		void Add(T entity);
		void Delete(T entity);
		
		// add by walter
		T Find(params object[] keys);
		void Update(T entity);
		IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
	}
}

