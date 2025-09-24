using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcl4.Context;
using mvcl4.Models;

namespace mvcl4.Controllers
{
    public class UserController : Controller
    {
        MyContext db = new MyContext();

        #region Login
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User u1)
        {
            var usr = db.Users.FirstOrDefault(e => e.Email == u1.Email);

            if (usr == null)// duplicatted email
            {
                ModelState.AddModelError("", "Email Doesn't Exist");
                return View();
            }


            if (usr.Email == u1.Email)
            {
                if (usr.Password == u1.Password)
                {
                    return RedirectToAction("GetAll", "Student");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Password");
                    return View();
                }

            }
            ModelState.AddModelError("", "Email Doesn't Exist");
            return View();

        }


        #endregion

        #region registeration
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Register(User us)
        {
            var existEmail = db.Users.FirstOrDefault(e => e.Email == us.Email);
            if (existEmail != null)// duplicatted email
            {
                ModelState.AddModelError("", "Email already Exist");// error message
                return View();
            }
            if (us != null && ModelState.IsValid)
            {
                db.Users.Add(us);
                db.SaveChanges();
                return RedirectToAction("GetAll","Student");
            }
            ModelState.AddModelError("", "All Fields Required");
            return View();

        }




        #endregion

        #region Welcome page

        public IActionResult Welcome()
        {
            return View();
        }


        #endregion

        #region Log out

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "User");
        }


        #endregion


        #region index
        public IActionResult Index()
        {
            return View();
        }
        #endregion
    }
}
