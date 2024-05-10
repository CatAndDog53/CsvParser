using CsvParser.Interfaces;

namespace CsvParser
{
    public class FileProcessor : IFileProcessor
    {
        private readonly IUserInteractor _userInteractor;
        private readonly IErrorHandler _errorHandler;

        public FileProcessor(IUserInteractor userInteractor, IErrorHandler errorHandler)
        {
            _userInteractor = userInteractor;
            _errorHandler = errorHandler;
        }

        public string[] ReadAllLinesFromFile(string filePath)
        {
            ValidateFilePath(filePath);
            CheckIfFileExistsAndThrowExceptionIfNot(filePath);
            return File.ReadAllLines(filePath);
        }

        public bool WriteAllLinesToFile(string filePath, string[] allLines)
        {
            ValidateFilePath(filePath);
            if (File.Exists(filePath))
            {
                bool rewriteFile = _userInteractor.GetBoolFromUser("File already exists. Do you want to rewrite it? (y/n): ",
                    new char[] { 'Y', 'y' }, new char[] { 'N', 'n' });
                if (!rewriteFile)
                {
                    return false;
                }
            }
            File.WriteAllLines(filePath, allLines);
            return true;
        }

        private static void ValidateFilePath(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException("Given file path is empty or null!");
            }
        }

        private static void CheckIfFileExistsAndThrowExceptionIfNot(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Specified input file not found!");
            }
        }
    }
}
