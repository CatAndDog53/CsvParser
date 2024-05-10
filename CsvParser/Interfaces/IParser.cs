namespace CsvParser.Interfaces
{
    public interface IParser
    {
        public string[] ExtractColumnData(string[] lines, string columnName);
    }
}
