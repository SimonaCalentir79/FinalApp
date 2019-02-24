using PagedList;
using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class GradeCategoryController : Controller
    {
        private IGradeCategoryManager manager;

        public GradeCategoryController()
        {
            manager = new GradeCategoryManager();
        }

        //public ActionResult Index()
        //{
        //    return View(manager.GetAllCategories());
        //}

        public ActionResult Index(string option, string search, int? pageNumber)
        {
            if (option == "Name")
                return View(manager.GetByName(search).ToPagedList(pageNumber ?? 1, 5));
            else
                return View(manager.GetAllCategories().ToPagedList(pageNumber ?? 1, 5));
        }

        public ActionResult Details(int id)
        {
            var gradeCtg = manager.Get(id);
            return View(gradeCtg);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var gradeCtg = manager.Get(id);
            if (gradeCtg == null)
            {
                return HttpNotFound();
            }
            return View(gradeCtg);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "CategoryID,CategoryName,Share")]GradeCategory gradeCtg)
        {
            if (ModelState.IsValid)
            {
                manager.Save(gradeCtg);
                return RedirectToAction("Index");
            }
            return View(gradeCtg);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed! Try again or see your sysadmin!";
            GradeCategory gradeCtg = manager.Get(id);
            if (gradeCtg == null)
            {
                return HttpNotFound();
            }
            return View(gradeCtg);
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
        public ActionResult Add([Bind(Include = "CategoryID,CategoryName,Share")]GradeCategory gradeCtg)
        {
            if (ModelState.IsValid)
            {
                manager.Add(gradeCtg);
                return RedirectToAction("Index");
            }
            return View(gradeCtg);
        }
    }
}