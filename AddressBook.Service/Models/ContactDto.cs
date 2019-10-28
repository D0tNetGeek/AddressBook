using System;

namespace AddressBook.Service.Models
{
    public class ContactDto : IComparable<ContactDto>
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public int CompareTo(ContactDto contact)
        {
            if (this.BirthDate > contact.BirthDate) return -1;
            if (this.BirthDate < contact.BirthDate) return 0;
            return 1;
        }
    }
}