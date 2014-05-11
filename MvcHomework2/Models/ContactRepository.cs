using System;
using System.Linq;
using System.Collections.Generic;

namespace MvcHomework2.Models
{
    public class ContactRepository : EFRepository<Contact>, IContactRepository
    {
        public override IQueryable<Contact> All()
        {
            return base.All().Where(i => i.IsDelete == false);
        }

        new public void Delete(Contact entity)
        {
            entity.IsDelete = true;
        }
    }

    public interface IContactRepository : IRepository<Contact>
    {

    }
}