using MyBusiness.BookAd.Common.Interfaces;

namespace MyBusiness.BookAd.Common.UnitTest
{
    /// <summary>
    /// Prints the logging into the Debug Window.
    /// </summary>
    public class DebugLogger : ILogger
    {
        public void Debug(string message)
        {
            System.Diagnostics.Debug.WriteLine("************");
            System.Diagnostics.Debug.WriteLine("****DEBUG: {0}", message);
            System.Diagnostics.Debug.WriteLine("********");
        }

        public void Error(string message)
        {
            System.Diagnostics.Debug.WriteLine("********");
            System.Diagnostics.Debug.WriteLine("****ERROR: {0}", message);
            System.Diagnostics.Debug.WriteLine("********");
//#if DEBUG
//            if (System.Diagnostics.Debugger.IsAttached)
//            {
//                System.Diagnostics.Debugger.Break();
//            }
//#endif
        }
    }
}
