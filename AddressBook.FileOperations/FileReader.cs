namespace AddressBook.FileOperations
{
    public class FileReader : IFileReader
    {
        public string[] GetAllContactLines(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath);
        }
    }
}