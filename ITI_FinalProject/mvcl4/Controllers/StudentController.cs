using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using mvcl4.Context;
using mvcl4.Models;
namespace mvcl4.Controllers
{
    public class StudentController : Controller
    {
        MyContext db = new MyContext();

        #region GetAll

        public IActionResult GetAll()
        {
            var stds = db.Students.Include( s => s.Department).ToList();
            return View(stds);
        }




        #endregion

        #region Add Student
        [HttpGet]
        public IActionResult Create()
        {//                                   collection    K as in T    Val name as in tabla
            ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");// for dropdown list
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            ModelState.Remove("Department");// ignore validation of referance
            var existEmail = db.Students.FirstOrDefault(e => e.Email == s.Email);
            if (existEmail != null)// duplicatted email
            {
                ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
                ModelState.AddModelError("", "Email already Exist");// error message
                return View();
            }

            if (s != null && ModelState.IsValid)
            {
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("GetAll");

            }

            ModelState.AddModelError("", "All Fields Required");
            ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
            return View();

        }


        #endregion

        #region Details
        public IActionResult Details(int id)
        {
            var st = db.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            return View(st);

        }



        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var st = db.Students.Include( e => e.Department).FirstOrDefault( w => w.Id == id);
            if (st == null)
            {
                return RedirectToAction("GetAll");
            }
    

            ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
            return View(st);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {

            if (std.Name == null)
            {
                ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
                ModelState.AddModelError("", "Name can't be empty");// error message
                return View();
            }
            //var existEmail = db.Students.FirstOrDefault(e => e.Email == std.Email);
            //if (existEmail != null)// duplicatted email
            //{
            //    ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
            //    ModelState.AddModelError("", "Email already Exist");// error message
            //    return View();
            //}
            if (std.Email == null)
            {
                ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
                ModelState.AddModelError("", "Email Can't be empty");// error message
                return View();
            }
            if (std.Age == null)
            {
                ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
                ModelState.AddModelError("", "Age Can't be empty");// error message
                return View();
            }
            if (std.Address == null)
            {
                ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
                ModelState.AddModelError("", "Address Can't be empty");// error message
                return View();
            }
            if (std.Password == null)
            {
                ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
                ModelState.AddModelError("", "Password Can't be empty");// error message
                return View();
            }
            if (std.ConfirmPassword == null)
            {
                ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
                ModelState.AddModelError("", "Confirm password Can't be empty");// error message
                return View();
            }
            if (std.Password != std.ConfirmPassword)
            {
                ViewBag.depts = new SelectList(db.Departments, "DeptId", "DeptName");
                ModelState.AddModelError("", "confirm password don't mathc the password");// error message
                return View();
            }

            db.Update(std);
            db.SaveChanges();
            return RedirectToAction("GetAll");

         
        }


        #endregion

        #region Delete
        public IActionResult Check(int id)
        {
            var sts = db.Students.Find(id);
            return View(sts);
        }


        public IActionResult Delete(Student s)
        {
            db.Students.Remove(s);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }


        #endregion

        






        public IActionResult Index()
        {
            return View();
        }
    }
}
