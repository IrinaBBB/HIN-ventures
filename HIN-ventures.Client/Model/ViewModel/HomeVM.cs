﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIN_ventures_Client.Model.ViewModel
{
    public class HomeVM
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        public int NoOfNights { get; set; } = 1;
        public bool IsAvailable { get; set; } = true;
    }
}