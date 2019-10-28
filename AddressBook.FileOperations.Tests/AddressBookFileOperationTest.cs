using Moq;
using Xunit;

namespace AddressBook.FileOperations.Tests
{
    public class AddressBookFileOperationTest
    {
        private IAddressBookFileOperations _addressBookFileOperations;

        public AddressBookFileOperationTest()
        {
            var addressBookLines = new string[]
            {
                "John Snow,Male,16/03/77",
                "Jimmy Neutron,Male,15/01/85",
                "Dana Lane,Female,20/11/91",
                "Sarah Connor,Female,20/09/80",
                "Chuck Jackson,Male,14/08/74"
            };
            var fileReaderMock = new Mock<IFileReader>();

            fileReaderMock.Setup(fileReader => fileReader.GetAllLines(It.IsAny<string>())).Returns(addressBookLines);

            _addressBookFileOperations = new AddressBookFileOperation(fileReaderMock.Object);
        }

        [Fact]
        public void GetAllContacts_InputIsFilePath_ReturnContacts()
        {
            var contacts = _addressBookFileOperations.GetAllContactLines();

            Assert.IsType<ContactDto>(contacts.First());
        }

        [Fact]
        public void GetAllContacts_InputIsFilePath_ReturnFourContacts()
        {
            var contacts = _addressBookFileOperations.GetAll();

            Assert.Equal(5, contacts.Count);
        }

        [Fact]
        public void GetAllContacts_InputIsFilePath_ShouldMapPropertiesProperly()
        {
            var contacts = _addressBookFileOperations.GetAll();
            var firstContact = contacts.First();

            Assert.Equal("John Snow", firstContact.Name);
            Assert.Equal(Gender.Male, firstContact.Gender);
            Assert.Equal("16/03/77", firstContact.BirthDate.ToString("dd/MM/yy"));
        }
    }
}