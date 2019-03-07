using PagedList;
using SchoolJournalApp.Models;
using SchoolJournalBusinessLogic;
using SchoolJournalInterfaces;
using SchoolJournalModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournalApp.Controllers
{
    public class StudentController : Controller
    {
        private IStudentManager manager;

        public StudentController()
        {
            manager = new StudentManager();
        }

        [HttpPost]
        public ActionResult UploadPhoto(Student student, UploadFileModel photo)
        {
            string folder = "~/Images/";
            if (photo != null && photo.File != null && photo.File.ContentLength > 0)
            {
                var photoName = Path.GetFileName(photo.File.FileName);
                photo.File.SaveAs(Path.Combine(folder,photoName));
            }
            //if (photo != null && photo.ContentLength > 0)
            //{
            //    string folder = "~/Images/";
            //    if (photo.ContentLength > 10240)
            //    {
            //        ModelState.AddModelError("photo","The size of the photo should not exceed 10 KB.");
            //        return View();
            //    }
            //    var supportedTypes = new[] {"jpg","jpeg","png"};
            //    var fileExt = Path.GetExtension(photo.FileName).Substring(1);
            //    if (!supportedTypes.Contains(fileExt))
            //    {
            //        ModelState.AddModelError("photo","Invalid type. Only the following types (jpg, jpeg, png) are supported.");
            //        return View();
            //    }
            //    var fileName = Path.GetFileName(photo.FileName);
            //    var fileID = Guid.NewGuid().ToString();
            //    photo.SaveAs(Path.Combine(folder,fileName, fileID));
            //    student.StudentPhoto = string.Concat(fileName, fileID);
            //}
            return View();
        }

        public ActionResult Index(string option, string search, int? pageNumber)
        {
            if (option == "Name")
                return View(manager.GetByName(search).ToPagedList(pageNumber ?? 1, 5));
            else
                return View(manager.GetAllStudents().ToPagedList(pageNumber ?? 1, 5));
        }

        public ActionResult Details(int id)
        {
            return View(manager.Get(id));
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "StudentId,StudentName,StudentPhoto,Observations")]Student student, UploadFileModel image)
        {
            if (ModelState.IsValid)
            {
                UploadPhoto(student, image);
                manager.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            if (manager.Get(id) == null)
            {
                return HttpNotFound();
            }
            return View(manager.Get(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update([Bind(Include = "StudentId,StudentName,StudentPhoto,Observations")]Student student, UploadFileModel image)
        {
            if (ModelState.IsValid)
            {
                UploadPhoto(student,image);
                manager.Save(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
                ViewBag.ErrorMessage = "Delete failed! Try again or see your sysadmin!";
            if (manager.Get(id) == null)
            {
                return HttpNotFound();
            }
            return View(manager.Get(id));
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
    }
}