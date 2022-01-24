using Core.Models.Partner;

namespace Core.Repositories
{
    public interface IPartnerRepository
    {
        // Create.
        public Task<Partner> AddPartnerAsync(Partner partner);

        // Read.
        public Task<Partner> GetPartnerAsync(string id);
        public Task<IEnumerable<Partner>> GetPartnersAsync();

        // Update.
        public Task<Partner> UpdatePartner(Partner partner);

        // Delete.
        public Task<bool> DeletePartnerAsync(string id);
        public Task<long> DeletePartnersAsync(IEnumerable<string> ids);
    }
}
