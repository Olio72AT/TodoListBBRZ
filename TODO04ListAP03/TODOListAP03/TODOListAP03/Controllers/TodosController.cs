using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODOListAP03.Models;
using TODOListAP03.Controllers;
using TODOListAP03.ViewModels;

namespace TODOListAP03.Controllers
{
    
    public class TodosController : Controller
    {
        // The Todos List 
        public static List<Todos> TodosListe = new List<Todos>();

        // Introducting the view model
        public static List<TodosDetailsViewModel> TDVM = new List<TodosDetailsViewModel>();



        // GET: Todos
        public ActionResult Index()
        {
            //  V5-Cookies-Sessions-Authorization
            TODOListAP03.MvcApplication.CallCookieOnce();


            // Dont forget to forward the LIST to the view .... see IEnumerated in View 
            return View(TodosListe);
        }
        
        // GET: Todos
        public ActionResult ShowViewModel()
        {
            // Fill up the ViewModel: 
            // First clear it
            TDVM.Clear(); 

            foreach(Todos i in TodosListe)
            {
                var DetailsToDisplay = DetailsController.DetailsListe.Where(x => x.Id == i.DetailsId).FirstOrDefault();

                TDVM.Add(new TodosDetailsViewModel()
                {
                    Id = i.Id,
                    Nummer = i.Nummer,
                    Kurzbeschreibung = i.Kurzbeschreibung,
                    DetailsId = i.DetailsId,
                    Beschreibung = DetailsToDisplay.Beschreibung,
                    Done = i.Done

                }) ;
            }

            
            return View(TDVM);
        }


        // GET: Todos/Details/5
        public ActionResult Details(int id)
        {
            var elemfordetail = TodosListe.Where(x => x.Id == id).FirstOrDefault();


            return View(elemfordetail);
        }

        // GET: Todos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        [HttpPost]
        public ActionResult Create(Todos todos)
        {
            var elemtocheck = DetailsController.DetailsListe.Where(x => x.Id == todos.DetailsId).FirstOrDefault();
            var failure = false;


            if (elemtocheck == null)
            {
                ViewBag.Error = "DetailsID does not exist";
                failure = true;
                //  return View();

            }

            var NUMMERToCheck = TodosController.TodosListe.Where(z => z.Nummer == todos.Nummer).FirstOrDefault();
            if (NUMMERToCheck != null)
             {
                ViewBag.Error2 = "NUMMER already exists";
                failure = true;
                // return View();

            }

            if (failure)
            {
                return View();
            }
            
            try
            {
                // TODO: Add insert logic here
                // Add Id to List Entry
                todos.Id = TodosListe.Count() + 1;
                
                // Set Element as Active
                todos.Active = true;
                TodosListe.Add(todos);


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todos/Edit/5
        public ActionResult Edit(int id)
        {
            var elemtoedit = TodosListe.Where(x => x.Id == id).FirstOrDefault();

            return View(elemtoedit);
        }

        // POST: Todos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Todos todos)
        {
            var elemtocheck = DetailsController.DetailsListe.Where(x => x.Id == todos.DetailsId).FirstOrDefault();

            if (elemtocheck == null)
            {
                ViewBag.Error = "DetailsID does not exist";
                return View();

            }


            try
            {
                var elemtoedit = TodosListe.Where(x => x.Id == id).FirstOrDefault();

                // TODO: Add update logic here
                TodosListe.Remove(elemtoedit);

                todos.Active = true;
                TodosListe.Add(todos);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Todos/Delete/5
        public ActionResult Delete(int id)
        {

            var elemtodelete = TodosListe.Where(x => x.Id == id).FirstOrDefault();

            return View(elemtodelete);
        }

        // POST: Todos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Todos todos)
        {
            try
            {
                var elemtodelete = TodosListe.Where(x => x.Id == id).FirstOrDefault();

                // Do not delete it / exchange the items ... set Active to false ;) 
                todos = elemtodelete;


                TodosListe.Remove(elemtodelete);
                todos.Active = false;
                TodosListe.Add(todos);


                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }
        }
    }
}
