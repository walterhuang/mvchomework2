using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MvcHomework2.Models
{   
	public  class CustomerRepository : EFRepository<Customer>, ICustomerRepository
	{
        public override IQueryable<Customer> All()
        {
            return base.All().Where(i => i.IsDelete == false);
        }

        new public void Delete(Customer entity)
        {
            entity.IsDelete = true;
        }
	}

	public  interface ICustomerRepository : IRepository<Customer>
	{

	}
}