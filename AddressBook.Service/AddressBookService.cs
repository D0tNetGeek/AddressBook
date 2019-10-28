using System;
using System.Collections.Generic;
using AddressBook.Service.Models;

namespace AddressBook.Service
{
    public class AddressBookService : IAddressBookService
    {
        public int CountPersonsBasedOnGender(Gender gender, IList<ContactDto> contacts)
        {
            throw new NotImplementedException();
        }

        public int GetDaysBetweenTwoPersons(ContactDto contact1, ContactDto contact2)
        {
            throw new NotImplementedException();
        }

        public ContactDto GetOldestPerson(IList<ContactDto> contacts)
        {
            throw new NotImplementedException();
        }
    }
}
