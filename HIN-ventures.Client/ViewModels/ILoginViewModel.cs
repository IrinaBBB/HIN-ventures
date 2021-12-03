using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIN_ventures.Client.ViewModels
{
    public interface  ILoginViewModel
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public Task LoginUser();
    }
}
