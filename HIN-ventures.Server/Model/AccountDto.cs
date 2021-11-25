using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIN_ventures.Server.Model
{
    public class AccountDto
    {
        public string status { get; set; }

        public _Balance data { get; set; }
    }

    public class _Balance
    {
        public string network { get; set; }

        public decimal available_balance { get; set; }

        public decimal pending_received_balance { get; set; }

    }
}


