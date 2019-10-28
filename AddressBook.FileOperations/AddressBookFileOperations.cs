using System;
using System.Collections.Generic;
using AddressBook.Service;
using AddressBook.Service.Models;

namespace AddressBook.FileOperations
{
    public class AddressBookFileOperations : IAddressBookFileOperations
    {
        private IFileReader _fileReader;

        public string AddressBookFilePath { get; set; }

        public AddressBookFileOperations(IFileReader fileReader)
        {
            _fileReader = fileReader;
        }

        public IList<ContactDto> GetAllContacts()
        {
            var lines = _fileReader.GetAllContactLines(AddressBookFilePath);

            var contacts = new List<ContactDto>();

            foreach (var line in lines)
            {
                var newContact = new ContactDto
                {
                    Name = line.Split(',')[0],
                    Gender = line.Split(',')[1] == "Male" ? Gender.Male : Gender.Female,
                    BirthDate = DateTime.Parse(line.Split(',')[2])
                };
                contacts.Add(newContact);
            }

            return contacts;
        }
    }
}
