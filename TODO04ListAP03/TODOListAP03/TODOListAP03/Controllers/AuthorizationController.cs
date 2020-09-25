using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODOListAP03.Models;

namespace TODOListAP03.Controllers
{
    public class AuthorizationController : Controller
    {
        public static List<Authorization> UserListe = new List<Authorization>();
            
        // GET: Authorization
        public ActionResult Index()
        {
            // V10 Patch correction cookies
            // Call cookie once for every index view ...  
            TODOListAP03.MvcApplication.CallCookieOnce();

            return View(UserListe);
        }

        // GET: Authorization/Details/5
        public ActionResult Details(int id)
        {
            var AuthToDisplay = UserListe.Where(x => x.Id == id).FirstOrDefault();

            return View(AuthToDisplay);
        }

        // GET: Authorization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Authorization/Create
        [HttpPost]
        public ActionResult Create(Authorization auth)
        {
            try
            {
                // TODO: Add insert logic here
                // Let's check if the user exists? 
                var AuthToCreate = UserListe.Where(x => x.UserId == auth.UserId).FirstOrDefault();

                if (AuthToCreate != null)
                {
                    TempData["Error"] = "User not allowed!";
                    return View();
                }

                var newUser = new Authorization();
                
                newUser.Id = UserListe.Count + 1;
                newUser.UserId = auth.UserId;
                
                
                // newUser.Password = auth.Password;
                newUser.Password = TODOListAP03.MvcApplication.GenerateHash(auth.Password);

                // Well, let's put salt and pepper on top of it ... 
                // salt = UserID
                // pepper = usually stored externally not within database or code ... 
                // for the showcase, we extend the inputs parameters with a pepper field. 
                // Extend the model and the create view ... 

                newUser.Password = TODOListAP03.MvcApplication.GenerateHash(auth.Password + auth.UserId + auth.Pepper);

                newUser.SessionId = TODOListAP03.MvcApplication.notactive;
                newUser.Role = auth.Role;
                newUser.Archive = true;
                    

                UserListe.Add(newUser);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Authorization/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authorization/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Authorization/Delete/5
        public ActionResult Delete(int id)
        {
            var AuthToDelete = UserListe.Where(x => x.Id == id).FirstOrDefault();
            return View(AuthToDelete);
        }

        // POST: Authorization/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var AuthToDelete = UserListe.Where(x => x.Id == id).FirstOrDefault();

                // Well ... remember, when we delete one item, what happends to the Id, 
                // when we create a new resource? 
                // Do not forget: We do not want to really delete an item, because of further 
                // DB inconsitencies ... 
                // -> Therefore we implement the ARCHIVE FLAG in the Authorization model ... 

                AuthToDelete.Archive = false;

                // Code to change due to archive flag -> Global.asax, Index.cshtml (Auth View) 

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
