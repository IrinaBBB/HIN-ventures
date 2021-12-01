using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIN_ventures.Models;

namespace HIN_ventures_Client.Model.ViewModel
{
    public class CustomerVM
    {
        //public DateTime StartDate { get; set; } = DateTime.Now;
        //public DateTime EndDate { get; set; }
        //public int NoOfNights { get; set; } = 1;
        public string Speciality { get; set; }

        public UserDto CustomerLoggedIn { get; set; }
    }
}