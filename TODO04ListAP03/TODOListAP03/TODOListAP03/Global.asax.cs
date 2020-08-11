using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TODOListAP03.Models;

namespace TODOListAP03
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            TODOListAP03.Controllers.DetailsController.DetailsListe.Clear();
            TODOListAP03.Controllers.DetailsController.DetailsListe.Add(new Details() { Id = 1, Beschreibung = "Zuhause" });
            TODOListAP03.Controllers.DetailsController.DetailsListe.Add(new Details() { Id = 2, Beschreibung = "Im Büro" });
            TODOListAP03.Controllers.DetailsController.DetailsListe.Add(new Details() { Id = 3, Beschreibung = "Im BBRZ" });
            TODOListAP03.Controllers.DetailsController.DetailsListe.Add(new Details() { Id = 4, Beschreibung = "Im Freien" });




            TODOListAP03.Controllers.TodosController.TodosListe.Add(new Todos()
            {
                Id = TODOListAP03.Controllers.TodosController.TodosListe.Count() + 1,
                Active = true,
                DetailsId = 2,
                Done = false,
                Kurzbeschreibung = "MVC Lernen",
                Nummer = 12
            });

            TODOListAP03.Controllers.TodosController.TodosListe.Add(new Todos()
            {
                Id = TODOListAP03.Controllers.TodosController.TodosListe.Count() + 1,
                Active = true,
                DetailsId = 1,
                Done = true,
                Kurzbeschreibung = "MVC Üben",
                Nummer = 13
            });

            TODOListAP03.Controllers.TodosController.TodosListe.Add(new Todos()
            {
                Id = TODOListAP03.Controllers.TodosController.TodosListe.Count() + 1,
                Active = true,
                DetailsId = 3,
                Done = false,
                Kurzbeschreibung = "MVC Weiterüben",
                Nummer = 14
            });

            TODOListAP03.Controllers.TodosController.TodosListe.Add(new Todos()
            {
                Id = TODOListAP03.Controllers.TodosController.TodosListe.Count() + 1,
                Active = true,
                DetailsId = 4,
                Done = false,
                Kurzbeschreibung = "MVC Schummelzettel schreiben",
                Nummer = 18
            });




            List<int> TodosWalter = new List<int>();
            TodosWalter.Add(1);
            TodosWalter.Add(2);
            


            TODOListAP03.Controllers.RessourcenController.ResourcesListe.Add(new Resourcen()
            {
                Id = 1,
                Name = "Walter",
                TodosId = TodosWalter,
                Active = true

            }) ;

            List<int> TodosOliver = new List<int>();
            TodosOliver.Add(1);
            TodosOliver.Add(2);
            TodosOliver.Add(3);
            TodosOliver.Add(4);



            TODOListAP03.Controllers.RessourcenController.ResourcesListe.Add(new Resourcen()
            {
                Id = 2,
                Name = "Oliver",
                TodosId = TodosOliver,
                Active = true

            });
 

        }

        public static void CallCookieOnce()
        {

            // V5-Cookies-Sessions-Authorization
            // Read Cookie "" if it exists

            if ( TODOListAP03.Controllers.RessourcenController.cookievalue == "null")
            {

                HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("todoAPP");

                if (HttpContext.Current.Request.Cookies["todoAPP"] != null)
                {
                    TODOListAP03.Controllers.RessourcenController.cookievalue = cookie.Value.ToString();

                }
                else
                {
                    TODOListAP03.Controllers.RessourcenController.cookievalue = "never";

                }


                // Now write the current time to the cookie

                HttpCookie cookienew = new HttpCookie("todoAPP");

                cookienew.Value = DateTime.Now.ToString();

                HttpContext.Current.Response.SetCookie(cookienew);

            }
        }
    }
}
