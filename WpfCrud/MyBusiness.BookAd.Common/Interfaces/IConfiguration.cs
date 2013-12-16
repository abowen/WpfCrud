namespace MyBusiness.BookAd.Common.Interfaces
{
    /// <summary>
    /// Allows the configuration of the application to come from different sources.
    /// e.g. App.Config, assembly, in memory, arg[], etc.
    /// </summary>
    public interface IConfiguration
    {
        string DataProvider { get; }
    }
}
