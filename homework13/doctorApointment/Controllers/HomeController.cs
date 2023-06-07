using doctorApointment.Models;
using doctorApointment.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace doctorApointment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/apointment", Name = "apointment")]
        public IActionResult apointment(string FirstName, string LastName, string Doctor, string Time)
        {
            var newApointment = new Apointment();
            newApointment.FirstName = FirstName;
            newApointment.LastName = LastName;
            newApointment.Doctor = Doctor;
            newApointment.Time = Time;
            var isValid = ApointmentService.saveNewApointment(newApointment);
            if (isValid)
            {
                return Redirect("./success");
            }
            else
            {
                return Redirect("./fail");

            }
        }

        [Route("/fail", Name = "ApointmentFail")]
        public IActionResult ApointmentFail()
        {
            return View();
        }

        [Route("/success", Name = "ApointmenSuccess")]
        public IActionResult ApointmenSuccess()
        {
            return View();
        }

        [Route("/list", Name = "List")]
        public IActionResult List()
        {
            ViewBag.List = ApointmentService.getApointmentList();
            return View();
        }

        [Route("/not-allowed", Name = "NotAllowed")]
        public IActionResult NotAllowed()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
