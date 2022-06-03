namespace IceCreamAPIMongoDB.Data
{
    public class OrderDbSettings:IOrderSettings
    {
        public string ConnectionString { get; set; } = string.Empty;

        public string DatabaseName { get; set; } = string.Empty;

        public string IceCreamCollectionName { get; set; } = string.Empty;


    }
    public interface IOrderSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string IceCreamCollectionName { get; set; }
    }

}
