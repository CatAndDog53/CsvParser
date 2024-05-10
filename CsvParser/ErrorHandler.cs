using CsvParser.Interfaces;

namespace CsvParser
{
    public class ErrorHandler : IErrorHandler
    {
        private readonly IUserInteractor _userInteractor;

        public ErrorHandler(IUserInteractor userInteractor) 
        { 
            _userInteractor = userInteractor;
        }

        public void HandleError(Exception ex)
        {
            _userInteractor.ShowMessageToUser($"Error: {ex.Message}");
        }
    }
}
