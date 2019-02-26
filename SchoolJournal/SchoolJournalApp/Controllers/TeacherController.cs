using Newtonsoft.Json;
using PagedList;
using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class TeacherController : Controller
    {
        private ITeacherManager manager;

        public TeacherController()
        {
            manager = new TeacherManager();
        }

        public ActionResult Index(string option, string search, int? pageNumber)
        {
            if (option == "Name")
                return View(manager.GetByName(search).ToPagedList(pageNumber ?? 1, 5));
            else
                return View(manager.GetAllTeachers().ToPagedList(pageNumber ?? 1, 5));
        }

        public ActionResult Details(int id)
        {
            var teacher = manager.Get(id);
            return View(teacher);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var teacher = manager.Get(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "TeacherID,TeacherName,TeacherEmail,TeacherPhone")]Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                manager.Save(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed! Try again or see your sysadmin!";
            Teacher teacher = manager.Get(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
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
        public ActionResult Add([Bind(Include = "TeacherID,TeacherName,TeacherEmail,TeacherPhone")]Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                manager.Add(teacher);
                return RedirectToAction("Index");
            }
            return View(teacher);
        }
    }
}