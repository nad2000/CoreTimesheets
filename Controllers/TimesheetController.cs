using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Timesheets.Controllers
{
    public class TimesheetController : Controller
    {

        public IActionResult Index()
        {
            ViewData["Message"] = "Fill in the timesheet.";

            return View();
        }

        public IActionResult Save()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
