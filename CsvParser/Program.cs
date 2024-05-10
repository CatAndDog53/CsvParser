using CsvParser.Interfaces;

namespace CsvParser
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            IUserInteractor userInteractor = new ConsoleInteractor(args);
            IErrorHandler errorHandler = new ErrorHandler(userInteractor);
            IFileProcessor fileProcessor = new FileProcessor(userInteractor, errorHandler);
            IParser parser = new Parser(userInteractor);

            string csvFilePath = userInteractor.GetInputPathFromUser();
            string outputFilePath = userInteractor.GetOutputPathFromUser();
            string columnName = userInteractor.GetColumnNameFromUser();

            try
            {
                fileProcessor.WriteAllLinesToFile(
                outputFilePath,
                parser.ExtractColumnData(
                    fileProcessor.ReadAllLinesFromFile(csvFilePath),
                    columnName));

                userInteractor.ShowMessageToUser($"The values from the \"{columnName}\" column were written to the file: {outputFilePath}");
            }
            catch (Exception ex)
            {
                errorHandler.HandleError(ex);
            }
        }
    }
}
