using ClinikMangementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClinikMangementSystem.DAL;



namespace ClinikMangementSystem.Controllers
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
        public IActionResult validate(Login chck)
        {
            if (ModelState.IsValid)
            {
                ClinikDAL obj = new ClinikDAL();
                int Result = obj.Verify(chck);
                if (Result == 1)
                    return RedirectToAction("HomePage");
                else
                {
                    TempData["msg"] = "<script>alert('Incorrect  UserName and PassWord');</script >";
                    return View("Index");
                }
                    
            } 
            return View("Index");
            
        }


        public IActionResult Homepage()
        {
            
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }
        public IActionResult NewDoctor(Doctor doc)
        {
            if (ModelState.IsValid)
            {
                ClinikDAL obj = new ClinikDAL();
                int Result = obj.NewDoctor(doc);
                if (Result == 1)
                {
                    TempData["msg"] = "<script>alert('New doctor Added Sucessfully');</script >";

                    return View("HomePage");
                }
                else
                {
                    
                    return View("Doctor");
                }
            }
            return View("Doctor");
        }
        public IActionResult GetDoctor()
        {
            ClinikDAL obj = new ClinikDAL();
            List<Doctor> Doc1 = new List<Doctor>();
            Doc1 = obj.getdoc();
            return View(Doc1);

        }


        public IActionResult Patient()
        {
            return View();
        }
        public IActionResult NewPatient(Patient ptnts)
        {
        //    if (ModelState.IsValid)
        //    {
                   ClinikDAL obj = new ClinikDAL();
                   int Result = obj.NewPatient(ptnts);
                   if (Result == 1)
                   {
                      TempData["msg"] = "<script>alert('New Patient Added Sucessfully');</script >";
                      return View("HomePage");
                   }
                   else
                   {
                    return View("Patient");
                    }

        //    }   
               return View("Patient");
        }
        public IActionResult ScheduleAppointment()
        {
            return View();
        }
        public IActionResult NewSchedule(Schedules sch)
        {
            ClinikDAL obj = new ClinikDAL();
            int Result = obj.NewSchedule(sch);
            if (Result == 1)
            {
                TempData["msg"] = "<script>alert('ScheduleAppointment Added Sucessfully');</script >";
                return View("HomePage");
            }
            else
            {
                return View("Schedules");
            }
        }
        public IActionResult CancelAppointment()
        {
            ClinikDAL obj = new ClinikDAL();
            List<Schedules> Schedules = new List<Schedules>();
            Schedules = obj.GetAllAppmnts();
            return View(Schedules);


        }
        public IActionResult Delapp(int id)
        {
            ClinikDAL obj = new ClinikDAL();
            int Result = obj.Delapp(id);
            if (Result == 1)
            {
                TempData["msg"] = "<script>alert('ScheduleAppointment Deleted Sucessfully');</script >";
                return View("HomePage");
            }
            else
            {
                return View("CancelAppointment");
            }

        }


        public IActionResult GetPatient()
        {
            ClinikDAL dal = new ClinikDAL();
            List<Patient> pat = new List<Patient>();
            pat = dal.getpat();
            return View(pat);

        }



        public IActionResult Privacy()
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
