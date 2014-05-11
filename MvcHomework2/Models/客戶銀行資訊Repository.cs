using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MvcHomework2.Models
{   
	public  class 客戶銀行資訊Repository : EFRepository<客戶銀行資訊>, I客戶銀行資訊Repository
	{
        public override IQueryable<客戶銀行資訊> All()
        {
            return base.All().Where(i => i.IsDelete == false);
        }

        public override IQueryable<客戶銀行資訊> AllIncluding(params System.Linq.Expressions.Expression<Func<客戶銀行資訊, object>>[] includeProperties)
        {
            return base.AllIncluding(includeProperties).Where(i => i.IsDelete == false);
        }

        new public void Delete(客戶銀行資訊 entity)
        {
            entity.IsDelete = true;
        }
	}

	public  interface I客戶銀行資訊Repository : IRepository<客戶銀行資訊>
	{

	}
}