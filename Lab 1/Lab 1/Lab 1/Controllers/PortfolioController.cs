using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab_1.Models;

namespace Lab_1.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: Protfolio
        public ActionResult Index()
        {
            ViewBag.title2 = "Welcome to Advance ASP.NET!";
            ViewBag.subTitle = "This is the home page of the Advance ASP.NET application.";
            return View();
        }

        public ActionResult Project()
        {
            List<Project> projects = new List<Project>();
            for (int i = 0; i < 10; i++)
            {
                projects.Add(new Project() {
                    Title = "Project " + (i + 1),
                    Language = "Language " + (i + 1)
                });
            }
            return View(projects);
        }

        public ActionResult Education()
        {
            List<Education> educations = new List<Education>();

            educations.Add(new Education()
            {
                Name = "SSC",
                Year = 2019,
                Result = 5.0f
            });

            educations.Add(new Education()
            {
                Name = "HSC",
                Year = 2021,
                Result = 5.0f
            });



            return View(educations);
        }

        public ActionResult Reference()
        {
            return View();
        }

    }
}