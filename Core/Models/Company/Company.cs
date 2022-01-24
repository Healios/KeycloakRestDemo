using Core.Models.Common;

namespace Core.Models.Company
{
    public class Company : IEntity
    {
        public string Id { get; set; } = "";

        public string Name { get; set; } = "";

        public DateTime Created { get; set; }

        public Address Address { get; set; } = new Address();

        public string? VATNumber { get; set; }

        public PartnerReference Partner { get; set; } = new PartnerReference();
    }
}
