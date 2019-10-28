using System.Collections.Generic;

namespace AddressBook.FileOperations
{
    public interface IAddressBookFileOperations
    {
        string AddressBookFilePath { get; set; }
        IList<ContactDto> GetAllContacts();
    }
}
