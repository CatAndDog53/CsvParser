using CsvParser.Interfaces;

namespace CsvParser
{
    public class Parser : IParser
    {
        private readonly IUserInteractor _userInteractor;

        public Parser(IUserInteractor userInteractor)
        {
            _userInteractor = userInteractor;
        }

        public string[] ExtractColumnData(string[] lines, string columnName)
        {
            if (lines == null || lines.Length == 0)
                return null;

            int columnIndex = Array.IndexOf(lines[0].Split(','), "\"" + columnName + "\"");
            if (columnIndex == -1)
            {
                throw new ArgumentException($"Column \"{columnName}\" not found in CSV file.");
            }

            return lines
                .Skip(1)
                .Select(line => line.Split(',')[columnIndex])
                .Select(value => value.Trim(new char[] { '[', ']', '"' }))
                .ToArray();
        }
    }
}
