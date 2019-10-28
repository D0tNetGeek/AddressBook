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
        }
    }
}
