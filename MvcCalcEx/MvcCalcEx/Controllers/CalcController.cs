using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCalcEx.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        [HttpGet]
        public ActionResult Index()
        {
            Models.CalcModel model = new Models.CalcModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string submit, Models.CalcModel model)
        {

            switch (submit)
            {
                case "add":
                    model.Result = model.Num1 + model.Num2;
                    break;
                case "subtract":
                    model.Result = model.Num1 - model.Num2;
                    break;
                case "divide":
                    model.Result = model.Num1 / model.Num2;
                    break;
                case "multiply":
                    model.Result = model.Num1 * model.Num2;
                    break;
                default:
                    return new HttpStatusCodeResult
                        (System.Net.HttpStatusCode.NotImplemented,
                        "calcControler not implemented " + submit);
            }
            
            //ModelState.Clear(); //ville fjerne indholdet i alle tekstboxe
            ModelState.Remove("Result"); //Clearer den bestemte tekstbox
            return View(model); //sender de nye værdier til viewet.
        }
    }
}