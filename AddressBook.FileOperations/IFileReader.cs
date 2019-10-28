namespace AddressBook.FileOperations
{
    public interface IFileReader
    {
        string[] GetAllContactLines(string filePath);
    }
}
