namespace v1.Models
{
    public class AppV1DatabaseSettings : IAppV1DatabaseSettings
    {
        public string AppV1CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IAppV1DatabaseSettings
    {
        string AppV1CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}