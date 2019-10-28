using AddressBook.FileOperations;
using AddressBook.Service;
using Microsoft.Extensions.DependencyInjection;

namespace AddressBook.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IAddressBookFileOperations, AddressBookFileOperations>()
                .AddSingleton<IAddressBookService, AddressBookService>()
                .AddSingleton<IFileReader, FileReader>()
                .BuildServiceProvider();

            var addressBookFileOperations = serviceProvider.GetService<IAddressBookFileOperations>();

            var addressBookService = serviceProvider.GetService<IAddressBookService>();

            addressBookFileOperations.AddressBookFilePath = "/Users/Vinnie/Projects/AddressBook/contacts.txt";

            var contacts = addressBookFileOperations.GetAllContacts();

            System.Console.WriteLine("Q : How many males are in the address book ?");
            System.Console.WriteLine($"A : {addressBookService.CountPersonsBasedOnGender(Gender.Male, contacts)}");

            System.Console.WriteLine("Q : Who is the oldest person in the address book ?");
            System.Console.WriteLine($"A : {addressBookService.GetOldestPerson(contacts).Name}");

            System.Console.WriteLine("Q : How many days older is John than Jimmy ?");
            System.Console.WriteLine($"A : {addressBookService.GetDaysBetweenTwoPersons(contacts[0], contacts[1])}");
        }
    }
}
