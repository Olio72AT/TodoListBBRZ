using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TODOListAP03.Models;

namespace TODOListAP03
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public const string notactive = "Not-active";
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

            // Add two demo users for authrorization

            /*
            TODOListAP03.Controllers.AuthorizationController.UserListe.Add(new Authorization()
            {
                Id = 1,
                UserId = "Oliver",
                Password = "hallo",
                Role = roleType.admin,
                SessionId = HttpContext.Current.Session.SessionID
            }

            );
            */

            // Well, we have a problem here. The Session Id is yet not available so far ... 
            // So we need to implement a work arround ... Lets use "Active" ...

            TODOListAP03.Controllers.AuthorizationController.UserListe.Add(new Authorization()
            {
                Id = 1,
                UserId = "Oliver",

                // we replaced it 
                Password = "���\u001d��S\u001a�_S�\b�#A",
                Role = roleType.admin,
                SessionId = "Active",
                Archive = true
            }

            ) ;

            // See Session_Start beneath


            TODOListAP03.Controllers.AuthorizationController.UserListe.Add(new Authorization()
            {
                Id = 2,
                UserId = "Martha",

                // we replaced it 
                Password = "WxS\r��Ǵo�7\u0019L1's",
                Role = roleType.user,
                SessionId = notactive,
                Archive = true
            }

            );


        }

        // Bug in MVC5 ... you need to initialize the Session, otherwise the ID always changes
        private static void Session_Start()
        {
            HttpContext.Current.Session.Add("__MyAppSession", string.Empty);

            // From here sessions will be available at runtime for sure. 
            // Now set the right value for Session ID and replace "active"

            var active_user = TODOListAP03.Controllers.AuthorizationController.UserListe.Where(y => y.SessionId == "Active").FirstOrDefault();

            if (active_user != null)
                active_user.SessionId = HttpContext.Current.Session.SessionID;



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

            // So let's get the Session ID and store it ...
            Session_Start();

            // In the Session variable MyID - which is available as long as the session is existing
            HttpContext.Current.Session["MyID"] = TODOListAP03.Controllers.RessourcenController.sessionID;

            // Or for further purpose in the global variable sessionID, located @ the Resource Controller
            TODOListAP03.Controllers.RessourcenController.sessionID = HttpContext.Current.Session.SessionID;

            
        }

        public static string GenerateHash(string cleanpw)
        {
            var md5 = new MD5CryptoServiceProvider();
            var ba = Encoding.UTF8.GetBytes(cleanpw);
            var md5data = md5.ComputeHash(ba, 0, ba.Length);

            string pwrStr = System.Text.Encoding.UTF8.GetString(md5data, 0, md5data.Length);
            return pwrStr;
        }


    }
}
