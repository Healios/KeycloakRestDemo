namespace Persistance.Settings
{
    internal class DatabaseSettings
    {
        public string ConnectionString { get; set; } = "";
        public string DatabaseName { get; set; } = "";
        public string CompanyCollectionName { get; set; } = "";
        public string PartnerCollectionName { get; set; } = "";
    }
}
