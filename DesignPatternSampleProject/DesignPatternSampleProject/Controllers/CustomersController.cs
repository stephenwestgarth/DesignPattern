using DesignPatternSampleProject.ViewModelExtensions;
using DesignPatternSampleProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignPatternSampleProject.Controllers
{
    public class CustomersController : BaseController
    {
        

        // GET: Customers
        public ActionResult Index()
        {
            var results =_UOW.CustomerRepository.Get().Select(p => p.ToViewModel());
            return View(results);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var result = _UOW.CustomerRepository.GetByID(id).ToViewModel();
            return View(result);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        public ActionResult Create(CustomerViewModel collection)
        {
            if(ModelState.IsValid)
            {
                _UOW.CustomerRepository.Insert(collection.ToModel());
                _UOW.Save();
                return RedirectToAction("Index");
            }
            return View(collection);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            var result = _UOW.CustomerRepository.GetByID(id).ToViewModel();
            return View(result);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CustomerViewModel collection)
        {
            if (ModelState.IsValid)
            {
                _UOW.CustomerRepository.Update(collection.ToModel(),id);
                _UOW.Save();
                return RedirectToAction("Index");

            }
            return View(collection);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            var result = _UOW.CustomerRepository.GetByID(id).ToViewModel();
            return View(result);
        }

        // POST: Customers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CustomerViewModel collection)
        {
            _UOW.CustomerRepository.Delete(collection.ToModel());
            _UOW.Save();
            return RedirectToAction("Index");
        }
    }
}
