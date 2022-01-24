namespace Keycloak.Models
{
    internal class Attributes
    {
        public IEnumerable<string> CompanyId { get; set; } = new List<string>();

        public IEnumerable<string> CompanyName { get; set; } = new List<string>();

        public IEnumerable<string> PartnerId { get; set; } = new List<string>();

        public IEnumerable<string> PartnerName { get; set; } = new List<string>();
    }
}
