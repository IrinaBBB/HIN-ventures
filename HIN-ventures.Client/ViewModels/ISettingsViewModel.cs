using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIN_ventures.Client.ViewModels
{
    public interface ISettingsViewModel
    {
        public long UserId { get; set; }
        public bool Notifications { get; set; }
        public bool DarkTheme { get; set; }

        public Task Save();
        public Task GetProfile();
    }
}
