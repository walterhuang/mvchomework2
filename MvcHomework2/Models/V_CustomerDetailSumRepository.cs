using System;
using System.Linq;
using System.Collections.Generic;
	
namespace MvcHomework2.Models
{   
	public  class V_CustomerDetailSumRepository : EFRepository<V_CustomerDetailSum>, IV_CustomerDetailSumRepository
	{

	}

	public  interface IV_CustomerDetailSumRepository : IRepository<V_CustomerDetailSum>
	{

	}
}