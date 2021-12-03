using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HIN_ventures.Client.ViewModels
{
    public interface IContactsViewModel
    {
        public List<Contact> Contacts { get; set; }
        public Task<List<Contact>> GetContacts();
        public Task<List<Contact>> GetAllContacts();
        public Task<List<Contact>> GetOnlyVisibleContacts(int startIndex, int numberOfUsers);
        public Task<int> GetContactsCount();
        public Task<List<Contact>> GetVisibleContacts(int startIndex, int numberOfUsers);

    }
}
