namespace CsvParser.Interfaces
{
    public interface IFileProcessor
    {
        public string[] ReadAllLinesFromFile(string filePath);
        public bool WriteAllLinesToFile(string filePath, string[] allLines);
    }
}
