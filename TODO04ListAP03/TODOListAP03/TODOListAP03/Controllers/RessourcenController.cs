using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODOListAP03.Models;
using TODOListAP03.ViewModels;

namespace TODOListAP03.Controllers
{
    public class RessourcenController : Controller
    {
        public static List<Resourcen> ResourcesListe = new List<Resourcen>();
        public static List<ResourcenTodosDetailsViewModel> AnzeigeListe = new List<ResourcenTodosDetailsViewModel>();
        

        // GET: Ressourcen
        public ActionResult Index()
        {
            return View(ResourcesListe);
        }

        public ActionResult IndexVM()
        {
            // AnzeigeListe löschen ... 
            AnzeigeListe.Clear();
            
            // Alle Resourcen anzeigen 
            foreach (Resourcen r in ResourcesListe)
            {
                // Fill up first line - only Resource  
                var temp_line = new ResourcenTodosDetailsViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    TodosVM = null,
                    Active = r.Active
                };

                AnzeigeListe.Add(temp_line);

                foreach(int t in r.TodosId)
                {
                    // Read TodosListe  
                    var TodoToDisplay = TodosController.TodosListe.Where(x => x.Id == t).FirstOrDefault();
                    TodosDetailsViewModel TodosInDetail = new TodosDetailsViewModel();

                    TodosInDetail.Id = TodoToDisplay.Id;
                    TodosInDetail.Kurzbeschreibung = TodoToDisplay.Kurzbeschreibung;
                    TodosInDetail.Nummer = TodoToDisplay.Nummer;
                    TodosInDetail.Done = TodoToDisplay.Done;

                    // Now read the DetailsList 
                    var DetailsToDisplay = DetailsController.DetailsListe.Where(y => y.Id == TodoToDisplay.DetailsId).FirstOrDefault();
                    TodosInDetail.Beschreibung = DetailsToDisplay.Beschreibung;
                    TodosInDetail.DetailsId = DetailsToDisplay.Id;



                    // Fill up sub lines - Todos assotiated

                    var temp_line2 = new ResourcenTodosDetailsViewModel()
                    {
                        Id = r.Id,
                        Name = "",
                        TodosVM = TodosInDetail,
                        Active = r.Active

                    };

                    AnzeigeListe.Add(temp_line2);

                }
            }




            return View(AnzeigeListe);
        }

        // GET: Ressourcen/Details/5
        public ActionResult Details(int id)
        {
            // A simple details view on Resourcen

            var tempResource = new Resourcen();
            tempResource = ResourcesListe.Where(x => x.Id == id).FirstOrDefault();

            // So let's bring the tempResource to the view ... 
            // return View();
            return View(tempResource);


            
        }

        // GET: Ressourcen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ressourcen/Create
        [HttpPost]
        public ActionResult Create(ResourcenTodosDetailsViewModel res)
        {
            // Do not forget to change the FormCollection variable to the model type (for now)
            // public ActionResult Create(FormCollection collection) -> 
            // public ActionResult Create(ResourcenTodosDetailsViewModel res)
            // So it easier for you to access ... 

            try
            {
                // TODO: Add insert logic here

                // Create temp. Resource 
                var resource = new Resourcen();

                // Now supply the correct values 

                resource.Id = ResourcesListe.Count() + 1;
                resource.Name = res.Name;

                // Don't forget to supply a valid TodosId value -> null IS THE WRONG VALUE ...
                // You need to supply an empty list of todos ... therefore ...
                // Create empty tempTodos list 

                // resource.TodosId = null;
                List<int> tempTodos = new List<int> ();
                resource.TodosId = tempTodos;


                // resource is not "deleted"
                resource.Active = true;
                               
                // Add it to the existing list
                ResourcesListe.Add(resource);


                // Be careful to return to the IndexVM view 
                // return RedirectToAction("Index");
                return RedirectToAction("IndexVM");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ressourcen/Edit/5
        public ActionResult Edit(int id)
        {
            // Edit case: In this case we can edit the resource only, if we like ... 
            // So we can create a view directly on "resource", because we only want to change the name
            // 
            var tempResource = new Resourcen();
            tempResource = ResourcesListe.Where(x => x.Id == id).FirstOrDefault();

            // So let's bring the tempResource to the view ... 
            return View(tempResource);
        }

        // POST: Ressourcen/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Resourcen res)
        {
            // Do not forget to change the FormCollection variable to the model type (for now)
            // public ActionResult Edit(int id, FormCollection collection) --> 
            // public ActionResult Edit(int id, Resourcen res)

            try
            {
                // TODO: Add update logic here

                // Surprise, surprise: As you learned in PR ... you can change 
                // the value in the LIST also without deleting and adding to the list 
                // You just need to instanciate the model and change the values 

                // Get the old entry and change it: 

                var tempResource = new Resourcen();
                tempResource = ResourcesListe.Where(x => x.Id == id).FirstOrDefault();

                tempResource.Name = res.Name;

                // Be careful to return to the IndexVM view 
                // return RedirectToAction("Index");
                return RedirectToAction("IndexVM");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ressourcen/Delete/5
        public ActionResult Delete(int id)
        {
            var ElemToDelete = ResourcesListe.Where(x => x.Id == id).FirstOrDefault();
                        
            return View(ElemToDelete);
        }

        // POST: Ressourcen/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var ElemToDelete = ResourcesListe.Where(x => x.Id == id).FirstOrDefault();
                // ResourcesListe.Remove(ElemToDelete);
                ElemToDelete.Active = false;
                // ResourcesListe.Add(ElemToDelete);

                // Remember Action -> IndexVM
                return RedirectToAction("IndexVM");
            }
            catch
            {
                return View();
            }
        }

        // DeleteTodo: Add a separate GET Method: 

        public ActionResult DeleteTodo(int id, int todoid)
        {
            // So what do we want to transfer to the view? 

            var ResourceToBeModified = ResourcesListe.Where(x => x.Id == id).FirstOrDefault();
            var TodoListToModify = ResourceToBeModified.TodosId;

            // To combine those again, we need another ViewModel -> ResourcenTodosRemoveViewModel.cs 

            ResourcenTodosRemoveViewModel RTRVM = new ResourcenTodosRemoveViewModel();

            RTRVM.Res = ResourceToBeModified;

            // We only want this one INT entry ...
            RTRVM.TodoId = TodoListToModify.Where(y => y == todoid).FirstOrDefault();


            return View(RTRVM);

            // return RedirectToAction("IndexVM");
        }




        // Change old GET to POST
        [HttpPost]
        public ActionResult DeleteTodo(int id, ResourcenTodosRemoveViewModel RTRVM)
        {
            // We need to expand the POST parameter in order to realize the GET with ResourcenTodosRemoveViewModel var

            var ResourceToBeModified = ResourcesListe.Where(x => x.Id == id).FirstOrDefault();
            var TodoListItemToModify = RTRVM.TodoId;

            // Access the TodoList in ResourceListe and REMOVE the LIST item out of the ResourcesListe

            ResourceToBeModified.TodosId.Remove(TodoListItemToModify);

            return RedirectToAction("IndexVM");
        }



        // GET: Ressourcen/AddTodo
        public ActionResult AddTodo(int Id)
        {
            // First, we receive the RESOURCE ID ... 
            // ->  public ActionResult AddTodo(int Id)

            var ResourceToModify = ResourcesListe.Where(x => x.Id == Id).FirstOrDefault();
                       

            // Instanciate the ViewModel to display, so add and access
            // Add above: 
            // public static List<AddTodoViewModel> AddTodoAnzeigeListe = new List<AddTodoViewModel>();
            // now access it.

            var LineToDisplay = new AddTodoViewModel();

            LineToDisplay.ResourceId = ResourceToModify.Id;
            LineToDisplay.ResourceName = ResourceToModify.Name;

            // Now lets prepare the LIST of Todos by accessing the TodosListe of all existing Todos
                       
            // V4 AddTodo Part: Transfer only missing items:
            // Bad solution: SQL queries, if you have many items ... (if the DB is externaly bind)
            // Better read all Tasks once, then campare in memory with LINQ

            // HOW TO FIND NOT EXISTING TODOS 

            var TempTodosList = TodosController.TodosListe.Where(s => !ResourceToModify.TodosId.Where(es => es == s.Id).Any());

            LineToDisplay.TodoItem = TempTodosList;

            return View(LineToDisplay);
        }

        // POST: Ressourcen/AddTodo
        [HttpPost]
        public ActionResult AddTodo(int Id, int TodoItem)
        {
            // MVC can Modelbind, so you can access the parameter TodoItem directly
            // Ask the teacher about model binding, to get a better understanding of it

            // Don't forget the DataAnnotation [REQUIRED] in the view model for Todos
            // If no value is REQUIRED, you would get a NULL EXCEPTION for TodoItem,
            // because int does not allow NULL

            try
            {
                // TODO: Add insert logic here
                var ResourceToModify = ResourcesListe.Where(x => x.Id == Id).FirstOrDefault();
                ResourceToModify.TodosId.Add(TodoItem);

                // And thats it ... ;) 


                return RedirectToAction("IndexVM");
            }
            catch
            {
                return View();
            }
        }

    }
}
