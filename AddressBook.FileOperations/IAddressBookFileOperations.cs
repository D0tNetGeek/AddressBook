using System.Collections.Generic;
using AddressBook.Service.Models;

namespace AddressBook.FileOperations
{
    public interface IAddressBookFileOperations
    {
        string AddressBookFilePath { get; set; }
        IList<ContactDto> GetAllContacts();
    }
}
