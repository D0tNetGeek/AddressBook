using System;
using System.Collections.Generic;
using System.Linq;
using AddressBook.Service.Models;

namespace AddressBook.Service
{
    public class AddressBookService : IAddressBookService
    {
        public int CountPersonsBasedOnGender(Gender gender, IList<ContactDto> contacts)
        {
            return contacts.Where(contact => contact.Gender == gender).Count();
        }

        public int GetDaysBetweenTwoPersons(ContactDto contact1, ContactDto contact2)
        {
            var days = (int)(contact1.BirthDate - contact2.BirthDate).TotalDays;
            return Math.Abs(days);
        }

        public ContactDto GetOldestPerson(IList<ContactDto> contacts)
        {
            return contacts.Max();
        }
    }
}
