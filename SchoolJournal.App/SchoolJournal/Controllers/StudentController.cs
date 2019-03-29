using SchoolJournal.BusinessLogic;
using SchoolJournal.Interfaces;
using SchoolJournal.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Controllers
{
    [MyExceptionHandler]
    public class StudentController : Controller
    {
        private IStudentManager manager;
        private const string uploadedFilesPath = "~/UploadedFiles";

        public StudentController()
        {
            manager = new StudentManager();
        }

        [MyExceptionHandler]
        public ActionResult Index()
        {
            return View(manager.GetAllStudents().ToList());
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Student student = manager.GetStudentByID(id);

            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [MyExceptionHandler]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentName,StudentPhoto,Observations")]Student student, HttpPostedFileBase imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null)
                {
                    var fileName = Path.GetFileName(imageFile.FileName);
                    var directoryToSave = Server.MapPath(Url.Content(uploadedFilesPath));
                    var pathToSave = Path.Combine(directoryToSave, fileName);

                    imageFile.SaveAs(pathToSave);
                    student.StudentPhoto = fileName;
                }
                manager.AddStudent(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Student student = manager.GetStudentByID(id);

            if (student != null)
            {
                //Session["StudentID"] = student.StudentID.ToString();
                //Session["StudentPhoto"] = student.StudentPhoto.ToString();
            }
            else
            {
                return HttpNotFound();
            }
            return View(student);
        }

        [MyExceptionHandler]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentID,StudentName,StudentPhoto,Observations")]Student student, int? id, HttpPostedFileBase imageFile)
        {
            if (id == null)
                return HttpNotFound();

            //var fileName = "";

            if (ModelState.IsValid)
            {
                //if (imageFile != null)
                //{
                //    fileName = Path.GetFileName(imageFile.FileName);
                //    var directoryToSave = Server.MapPath(Url.Content(uploadedFilesPath));
                //    string pathToSave = Path.Combine(directoryToSave, fileName);

                //    imageFile.SaveAs(pathToSave);
                //    student.StudentPhoto = fileName;
                //}
                //else
                //{
                //    fileName = Session["StudentPhoto"].ToString();
                //    student.StudentPhoto = fileName;
                //}
                manager.UpdateStudent(student);
                return RedirectToAction("Index");
            }
            //Session.Abandon();
            return View(student);
        }

        [MyExceptionHandler]
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Student student = manager.GetStudentByID(id);

            if (student == null)
                return HttpNotFound();
            return View(student);
        }

        [MyExceptionHandler]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Student student = manager.GetStudentByID(id);
            //System.IO.File.SetAttributes(Server.MapPath(uploadedFilesPath), FileAttributes.Normal);
            System.IO.File.Delete(Path.Combine(Server.MapPath(uploadedFilesPath),student.StudentPhoto));

            manager.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}