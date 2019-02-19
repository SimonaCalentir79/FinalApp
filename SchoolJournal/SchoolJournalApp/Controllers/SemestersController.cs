using PagedList;
using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class SemestersController : Controller
    {
        private ISemestersManager manager;

        public SemestersController()
        {
            manager = new SemestersManager();
        }

        public ActionResult Index(string option, string search, int? pageNumber)
        {
            if (option == "Number")
            {
                return View(manager.GetByNumber(search).ToPagedList(pageNumber ?? 1, 5));
            }
            else if (option == "Year")
            {
                return View(manager.GetByYear(search).ToPagedList(pageNumber ?? 1, 5));
            }
            else
            {
                return View(manager.GetAllSemesters().ToPagedList(pageNumber ?? 1, 5));
            }
        }

        public ActionResult Details(int id)
        {
            var semester = manager.Get(id);
            return View(semester);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var semester = manager.Get(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "SemesterID,SemesterNumber,SchoolYear")]Semesters semester)
        {
            if (ModelState.IsValid)
            {
                manager.Save(semester);
                return RedirectToAction("Index");
            }
            return View(semester);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed! Try again or see your sysadmin!";
            Semesters semester = manager.Get(id);
            if (semester == null)
            {
                return HttpNotFound();
            }
            return View(semester);
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
        public ActionResult Add([Bind(Include = "SemesterID,SemesterNumber,SchoolYear")]Semesters semester)
        {
            if (ModelState.IsValid)
            {
                manager.Add(semester);
                return RedirectToAction("Index");
            }
            return View(semester);
        }
    }
}