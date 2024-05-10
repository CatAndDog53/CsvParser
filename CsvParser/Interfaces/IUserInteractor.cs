namespace CsvParser.Interfaces
{
    public interface IUserInteractor
    {
        public string GetStringFromUser(string whatToAskToEnter);
        public string GetInputPathFromUser();
        public string GetOutputPathFromUser();
        public string GetColumnNameFromUser();
        public bool GetBoolFromUser(string whatToAsk, char[] positiveAnswers, char[] negativeAnswers);
        public void ShowMessageToUser(string message);
    }
}
