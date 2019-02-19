using Newtonsoft.Json;
using PagedList;
using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
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

        [HttpGet]
        public ActionResult AddSchoolSubject()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSchoolSubject(Subjects subject)
        {
            if (ModelState.IsValid)
            {
                manager.AddSchoolSubject(subject);
                return RedirectToAction("../Home/Index");
            }
            return View(subject);
        }

        [HttpGet]
        [Route("/Persons/GetAllSubjects")]
        public string GetAllSubjects()
        {
            var subjects = manager.GetSubjects();
            return JsonConvert.SerializeObject(subjects);
        }

        [HttpGet]
        public ActionResult AddHomework()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHomework(Homework homework)
        {
            if (ModelState.IsValid)
            {
                manager.AddHomework(homework);
                return RedirectToAction("../Home/Index");
            }
            return View(homework);
        }
    }
}