using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shared_Library.DTO;
using Shared_Library.Interface;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        
        IBusinessUser _busiuser;
        // GET: User
        public UserController(IBusinessUser busiuser)
        {
            _busiuser = busiuser;
            
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult RegisterUser()
        {
            return View("Create");
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult RegisterUser([Bind(Include = "ID,Email,Password,FullName")] LoginUserDTO user)
        {

            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Registration Successful";
                _busiuser.Insert(user);
                return RedirectToAction("Index", "Home");

            }
            else
                return View("Create");

        }

        public ActionResult LoginUser()
        {
            return View("LoginPage");
        }

        [HttpPost]
        public ActionResult LoginUser([Bind(Include = "Password,Email,FullName")] LoginUserDTO login)
        {
            bool status;

            if (ModelState.IsValid)
            {
                if (login.Email.Equals("admin@gmail.com") && login.FullName.Equals("admin") && login.Password.Equals("abcd"))
                {
                    Session["id"] = 8;
                    Session["user"] = login.Email;
                    var list = new List<LoginUserDTO>();
                    list = _busiuser.GetAll();
                   TempData["Message"] = "Your login was successful";
                    return View("WelcomePage",list);
                }
                

                LoginUserDTO users = _busiuser.LoginUser(login);
                  if (users != null)
                {
                    Session["id"] = users.ID;
                    Session["user"] = login.Email;
                    TempData["Message"] = "Your login was successful";
                    var value = new LoginUserDTO();
                    value = _busiuser.Get(users.ID);
                    return View("UserWelcomePage",value);
                }
                else
                {
                   // ModelState.AddModelError("", "User not found in Database");
                    TempData["Message"] = "Your login was unsuccessful";
                    return View("LoginPage");
                }
            }
            else
                return View("LoginPage");

        }


        public ActionResult EditIt(int userId)
        {
            
            var list = new List<LoginUserDTO>();
            int id = int.Parse(Session["id"].ToString());
            list = _busiuser.GetAll();
            var value = list.Where(s => s.ID == userId).FirstOrDefault();
            return View("EditPage", value);

        }

    

        [HttpPost]
        public ActionResult EditValue(LoginUserDTO user)
        {
            int id = int.Parse(Session["id"].ToString());
            var list = new List<LoginUserDTO>();
            var uservalue = new LoginUserDTO();
            TempData["NewMessage"] = "Value has been updated successfully";
            bool value = _busiuser.Update(user);
            if (int.Parse(Session["id"].ToString()) == 8)
            {
                if (value)
                {
                    list = _busiuser.GetAll();
                    return View("WelcomePage", list);
                }
                else
                    return View("Index");
            }
            else
            {
                if (value)
                {
                    uservalue = _busiuser.Get(id);
                    return View("UserWelcomePage", uservalue);
                }
                else
                    return View("Index");
            }

        }

       
    }



}
