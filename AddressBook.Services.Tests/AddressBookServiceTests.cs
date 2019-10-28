using System;
using System.Collections.Generic;
using System.Linq;
using AddressBook.FileOperations;
using AddressBook.Service;
using AddressBook.Service.Models;
using Moq;
using Xunit;

namespace AddressBook.Services.Tests
{
    public class AddressBookServiceTests
    {
        private IAddressBookFileOperations _addressBookFileOperations;
        private IAddressBookService _addressBookService;

        public AddressBookServiceTests()
        {
            var addressBookFileOperationsMock = new Mock<IAddressBookFileOperations>();

            addressBookFileOperationsMock.Setup(addressBookService => addressBookService.GetAllContacts()).Returns(new List<ContactDto>()
            {
                new ContactDto(){Name = "John Snow",Gender=Gender.Male,BirthDate=DateTime.Parse("16/03/77")},
                new ContactDto(){Name = "Jimmy Neutron",Gender=Gender.Male,BirthDate=DateTime.Parse("15/01/85")},
                new ContactDto(){Name = "Dana Lane",Gender=Gender.Female,BirthDate=DateTime.Parse("20/11/91")},
                new ContactDto(){Name = "Sarah Connor",Gender=Gender.Female,BirthDate=DateTime.Parse("20/09/80")},
                new ContactDto(){Name = "Chuck Jackson",Gender=Gender.Male,BirthDate=DateTime.Parse("14/08/74")},
            });

            _addressBookFileOperations = addressBookFileOperationsMock.Object;
            _addressBookService = new AddressBookService();
        }

        [Fact]
        public void GetOldest_InputAllPersons_ReturnChuckJackson()
        {
            var contacts = _addressBookFileOperations.GetAllContacts();
            var expected = contacts.Last();

            var actual = _addressBookService.GetOldestPerson(contacts);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CountPerGender_InputAllPersons_ReturnThree()
        {
            var contacts = _addressBookFileOperations.GetAllContacts();
            var expected = 3;

            var actual = _addressBookService.CountPersonsBasedOnGender(Gender.Male, contacts);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void DaysBetween_InputBillAndPaul_ReturnDaysBetween()
        {
            var contact1 = new ContactDto() { Name = "John Snow", Gender = Gender.Male, BirthDate = DateTime.Parse("16/03/77") };
            var contact2 = new ContactDto() { Name = "Jimmy Neutron", Gender = Gender.Male, BirthDate = DateTime.Parse("15/01/85") };
            var expected = 2862;

            var actual = _addressBookService.GetDaysBetweenTwoPersons(contact1, contact2);

            Assert.Equal(expected, actual);
        }
    }
}
