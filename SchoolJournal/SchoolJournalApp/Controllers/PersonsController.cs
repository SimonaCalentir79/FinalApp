using PagedList;
using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class PersonsController : Controller
    {
        private IPersonsManager manager;

        public PersonsController()
        {
            manager = new PersonsManager();
        }

        //public ActionResult Index()
        //{
        //    return View(manager.GetAllPersons());
        //}

        public ActionResult Index(string option, string search, int? pageNumber)
        {
            if (option == "Name")
            {
                return View(manager.GetByName(search).ToPagedList(pageNumber ?? 1, 5));
            }
            else if (option == "Address")
            {
                return View(manager.GetByAddress(search).ToPagedList(pageNumber ?? 1, 5));
            }
            else
            {
                return View(manager.GetAllPersons().ToPagedList(pageNumber ?? 1, 5));
            }
        }

        public ActionResult Details(int id)
        {
            var person = manager.Get(id);
            return View(person);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var person = manager.Get(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "PersonID,PersonName,PersonEmail,PersonPhone,PersonAddress")]Persons person)
        {
            if (ModelState.IsValid)
            {
                manager.Save(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed! Try again or see your sysadmin!";
            Persons person = manager.Get(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                manager.Delete(id);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id, saveChangesError = true });
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "PersonName,PersonEmail,PersonPhone,PersonAddress")]Persons person)
        {
            if (ModelState.IsValid)
            {
                manager.Add(person);
                return RedirectToAction("Index");
            }
            return View(person);
        }
    }
}