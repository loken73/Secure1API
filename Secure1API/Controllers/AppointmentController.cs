using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Secure1API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Secure1API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Appointment")]
    public class AppointmentController : ApiController
    {
        private ApplicationUserManager _userManager;
        private ApplicationDbContext _appDb = new ApplicationDbContext();

        public AppointmentController()
        {
        }

        public AppointmentController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
            
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/Appointment
        [Route("All")]
        public List<AppointmentDetails> GetAll()
        {
            var details = new List<AppointmentDetails>();

            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());

            if (_appDb.Appointments == null)
            {
                return null;
            }
            else
            {
                var appointments = _appDb.Appointments.ToList();

                foreach (Appointment app in appointments)
                {
                    var appDetails = new AppointmentDetails
                    {
                        UserName = app.User.FirstName + " " + app.User.LastName,
                        Date = DTHelp.ParseDate(app.DateAndTime),
                        Time = DTHelp.ParseTime(app.DateAndTime),
                        Notes = app.Notes
                    };

                    details.Add(appDetails);
                }

                return details;
            }
          
        }

        // GET api/values/5
        public AppointmentsPerPersonModel Get()
        {
            ApplicationUser user = UserManager.FindById(User.Identity.GetUserId());

            var appointments = _appDb.Appointments
                    .Where(app => app.User.Id == user.Id).ToList();

            if (_appDb.Appointments.Where(app => app.User.Id == user.Id) == null)
            {
                return null;
            }
            else
            {
                var apptsPerPerson = new AppointmentsPerPersonModel
                {
                    UserName = user.FirstName + " " + user.LastName
                };

                foreach (Appointment app in appointments)
                {
                    var appView = new AppointmentViewModel
                    {
                        ApptDate = DTHelp.ParseDate(app.DateAndTime),
                        Time = DTHelp.ParseTime(app.DateAndTime),
                        Notes = app.Notes
                    };

                    apptsPerPerson.Appointments.Add(appView);
                }

                return apptsPerPerson;
            }
        }

        // POST api/values
        public void Post(AppointmentViewModel apptVM)
        {
            ApplicationUser Ouser = UserManager.FindById(User.Identity.GetUserId());

            var user = _appDb.Users.Where(u => u.Id == Ouser.Id).FirstOrDefault();

            var newAppt = new Appointment
            {
                DateAndTime = DateTime.Parse(apptVM.ApptDate + " " + apptVM.Time),
                Notes = apptVM.Notes,
                User = user
            };

            _appDb.Appointments.Add(newAppt);
            _appDb.SaveChanges();
        }

        /*/ PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        } */
    }
}
