using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class HomeController : Controller
    {
        private IStudentManager manager;

        public HomeController()
        {
            manager = new StudentManager();
        }

        public ActionResult Index()
        {
            return View(manager.GetAllStudents());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}