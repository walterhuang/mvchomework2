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
    public class CustomerController : BaseController
    {
        //private CustomerEntities db = new CustomerEntities();
        private ICustomerRepository repo;

        public CustomerController()
        {
            repo = RepositoryHelper.GetCustomerRepository();
        }

        // GET: /Customer/
        [HandleError(ExceptionType=typeof(ArgumentException), View="Error2")]
        public ActionResult Index()
        {
            throw new ArgumentException("system error");
            return View(repo.All()); //db.Customers.ToList());

        }

        [HttpPost]
        public ActionResult Index(List<CustomerBatchUpdateVM> form) //int[] id, string[] 統一編號)
        {
            if (form != null) //if (id != null)
            {
                //for (int i = 0; i < id.Length; i++)
                //{
                //    var data = repo.Find(id[i]);
                //    data.統一編號 = 統一編號[i];
                //}

                foreach (var item in form)
                {
                    var data = repo.Find(item.Id);
                    data.統一編號 = item.統一編號;
                    data.Phone = item.Phone;
                }

                repo.UnitOfWork.Commit();
            }
            return RedirectToAction("Index");
        }

        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = repo.Find(id); //repo.All().SingleOrDefault(i => i.Id == (int)id); //db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,統一編號,Address,Email,DateCreated,Phone,Fax")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Customers.Add(customer);
                //db.SaveChanges();
                repo.Add(customer);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: /Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = repo.Find(id); //db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            ViewData.Model = customer;
            ViewBag.Contacts = customer.Contacts.ToList();

            return View();
        }

        // POST: /Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerUpdateVM customerVM) //[Bind(Include = "Id,Name,統一編號,Address,Email,DateCreated,Phone,Fax")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(customer).State = EntityState.Modified;
                //db.SaveChanges();
                //repo.Update(customer);
                
                var data = repo.Find(customerVM.Id);
                AutoMapper.Mapper.DynamicMap<CustomerUpdateVM, Customer>(customerVM, data);

                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(customerVM);
        }

        // GET: /Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = repo.Find(id); //db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Customer customer = db.Customers.Find(id);
            //db.Customers.Remove(customer);
            //db.SaveChanges();
            repo.Delete(repo.Find(id));
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
