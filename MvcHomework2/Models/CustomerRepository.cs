using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MvcHomework2.Models
{   
	public  class CustomerRepository : EFRepository<Customer>, ICustomerRepository
	{

	}

	public  interface ICustomerRepository : IRepository<Customer>
	{

	}
}