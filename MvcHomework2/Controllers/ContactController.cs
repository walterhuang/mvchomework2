using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcHomework2.Models;

namespace MvcHomework2.Controllers
{
    public class ContactController : BaseController
    {
        //private CustomerEntities db = new CustomerEntities();
        private IContactRepository repo;
        private ICustomerRepository customerRepo;

        public ContactController()
        {
            repo = RepositoryHelper.GetContactRepository();
            customerRepo = RepositoryHelper.GetCustomerRepository(repo.UnitOfWork);
        }

        // GET: /Contact/
        public ActionResult Index()
        {
            var contacts = repo.All(); //db.Contacts.Include(c => c.Customer);
            return View(contacts.ToList());
        }

        // GET: /Contact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = repo.Find(id); //db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: /Contact/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(customerRepo.All() /*db.Customers*/, "Id", "Name");
            return View();
        }

        // POST: /Contact/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,CustomerId,Title,Name,Email,Mobile,Phone")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                //db.Contacts.Add(contact);
                //db.SaveChanges();
                repo.Add(contact);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(customerRepo.All() /*db.Customers*/, "Id", "Name", contact.CustomerId);
            return View(contact);
        }

        // GET: /Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = repo.Find(id); //db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(customerRepo.All() /*db.Customers*/, "Id", "Name", contact.CustomerId);
            return View(contact);
        }

        // POST: /Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,CustomerId,Title,Name,Email,Mobile,Phone")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(contact).State = EntityState.Modified;
                //db.SaveChanges();
                repo.Update(contact);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(customerRepo.All() /*db.Customers*/, "Id", "Name", contact.CustomerId);
            return View(contact);
        }

        // GET: /Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = repo.Find(id); //db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: /Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = repo.Find(id); //db.Contacts.Find(id);
            //db.Contacts.Remove(contact);
            //db.SaveChanges();
            repo.Delete(contact);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
