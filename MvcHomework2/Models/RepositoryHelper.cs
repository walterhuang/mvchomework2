namespace MvcHomework2.Models
{
	public static class RepositoryHelper
	{
		public static IUnitOfWork GetUnitOfWork()
		{
			return new EFUnitOfWork();
		}		
		
		public static ContactRepository GetContactRepository()
		{
			var repository = new ContactRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static ContactRepository GetContactRepository(IUnitOfWork unitOfWork)
		{
			var repository = new ContactRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static CustomerRepository GetCustomerRepository()
		{
			var repository = new CustomerRepository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static CustomerRepository GetCustomerRepository(IUnitOfWork unitOfWork)
		{
			var repository = new CustomerRepository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		

		public static 客戶銀行資訊Repository Get客戶銀行資訊Repository()
		{
			var repository = new 客戶銀行資訊Repository();
			repository.UnitOfWork = GetUnitOfWork();
			return repository;
		}

		public static 客戶銀行資訊Repository Get客戶銀行資訊Repository(IUnitOfWork unitOfWork)
		{
			var repository = new 客戶銀行資訊Repository();
			repository.UnitOfWork = unitOfWork;
			return repository;
		}		
	}
}