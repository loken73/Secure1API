using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Secure1API.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Notes { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual string UserId { get; set; }
    }

    public class AppointmentViewModel
    {
        public string ApptDate { get; set; }

        public string Time { get; set; }

        public string Notes { get; set; }

    }

    public class AppointmentsPerPersonModel
    {
        public List<AppointmentViewModel> Appointments { get; set; } = new List<AppointmentViewModel>();

        public string UserName { get; set; }
    }

    public class AppointmentDetails
    {
        public string UserName { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Notes { get; set; }
    }

}