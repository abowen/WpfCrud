using MyBusiness.BookAd.Common.Interfaces;

namespace MyBusiness.BookAd.Common.Loggers
{
    public class BasicLog4NetLogger : ILogger
    {
        public BasicLog4NetLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        
        public void Debug(string message)
        {
            var logger = log4net.LogManager.GetLogger("Log");
            logger.Debug(message);
        }

        public void Error(string message)
        {
            var logger = log4net.LogManager.GetLogger("Log");
            logger.Error(message);
        }
    }
}
