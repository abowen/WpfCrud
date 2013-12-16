
namespace MyBusiness.BookAd.Common.Interfaces
{
    /// <summary>
    /// Basic logging to only log the most important information
    /// </summary>
    public interface ILogger
    {        
        void Debug(string message);
        void Error(string message);
    }
}
