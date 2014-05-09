using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MvcHomework2.Models
{   
	public  class ContactRepository : EFRepository<Contact>, IContactRepository
	{

	}

	public  interface IContactRepository : IRepository<Contact>
	{

	}
}