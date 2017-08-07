using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace dojo_survey.Controllers
{
    public class DojoSurveyController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("results")]
        public IActionResult Results(string Name, string Location, string Language, string Comment)
        {
            ViewBag.Errors = new List<string>();

            if(Name == null)
            {
                ViewBag.Errors.Add("Name cannot be empty");
            }

            if(Location == null)
            {
                ViewBag.Errors.Add("Please select  a valid location");
            }

            if(Language == null)
            {
                ViewBag.Errors.Add("Please select a valid language");
            }

            if(Comment == null)
            {
                Comment = "";
            }

            if(ViewBag.Errors.Count > 0)
            {
                return View("Index");
            }

            ViewBag.Name = Name;
            ViewBag.Location = Location;
            ViewBag.Language = Language;
            ViewBag.Comment = Comment;
            
            return View("Success");
        }
    }
}