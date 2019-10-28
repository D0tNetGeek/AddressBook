using System.Collections.Generic;
using AddressBook.Service.Models;

namespace AddressBook.Service
{
    public interface IAddressBookService
    {
        int CountPersonsBasedOnGender(Gender gender, IList<ContactDto> contacts);
        ContactDto GetOldestPerson(IList<ContactDto> contacts);
        int GetDaysBetweenTwoPersons(ContactDto contact1, ContactDto contact2);
    }
}
