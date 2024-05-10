using CsvParser.Enums;
using CsvParser.Interfaces;

namespace CsvParser
{
    public class ConsoleInteractor : IUserInteractor
    {
        private static string[] _args;
        public ConsoleInteractor(string[] args) 
        { 
            _args = args;
        }

        public string GetInputPathFromUser()
        {
            int argIndex = (int)CommandLineArgs.CsvFilePath;
            if (_args.Length > argIndex && !string.IsNullOrEmpty(_args[argIndex]))
            {
                return _args[argIndex];
            }
            return GetStringFromUser("Input file path");
        }

        public string GetOutputPathFromUser()
        {
            int argIndex = (int)CommandLineArgs.OutputFilePath;
            if (_args.Length > argIndex && !string.IsNullOrEmpty(_args[argIndex]))
            {
                return _args[argIndex];
            }
            return GetStringFromUser("Output file path");
        }

        public string GetColumnNameFromUser()
        {
            int argIndex = (int)CommandLineArgs.ColumnName;
            if (_args.Length > argIndex && !string.IsNullOrEmpty(_args[argIndex]))
            {
                return _args[argIndex];
            }
            return GetStringFromUser("Column name");
        }

        public string GetStringFromUser(string whatToAskToEnter)
        {
            string enteredString;

            if (!string.IsNullOrEmpty(whatToAskToEnter))
            {
                Console.Write("Please enter {0}: ", Char.ToLower(whatToAskToEnter[0]) + whatToAskToEnter.Substring(1));
            }

            while (true)
            {
                enteredString = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(enteredString))
                {
                    Console.Write("Entered {0} is empty! Enter another one: ", Char.ToLower(whatToAskToEnter[0]) + whatToAskToEnter.Substring(1));
                }
                else
                {
                    return enteredString;
                }
            }
        }

        public bool GetBoolFromUser(string whatToAsk, char[] positiveAnswers, char[] negativeAnswers)
        {
            char charResult;

            Console.Write(Char.ToUpper(whatToAsk[0]) + whatToAsk.Substring(1));
            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out charResult))
                {
                    foreach (char positiveAnswer in positiveAnswers)
                    {
                        if (charResult == positiveAnswer)
                        {
                            return true;
                        }
                    }

                    foreach (char negativeAnswer in negativeAnswers)
                    {
                        if (charResult == negativeAnswer)
                        {
                            return false;
                        }
                    }
                }
                Console.Write("Entered data is incorrect! Enter another value: ");
            }
        }

        public void ShowMessageToUser(string message)
        {
            Console.WriteLine(message);
        }
    }
}
