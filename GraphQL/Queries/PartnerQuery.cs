using Core.Models.Partner;
using Core.Repositories;

namespace GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    internal class PartnerQuery
    {
        private readonly IPartnerRepository partnerRepository;

        public PartnerQuery(IPartnerRepository partnerRepository)
        {
            this.partnerRepository = partnerRepository;
        }

        public async Task<Partner> GetMyPartnerAsync([GlobalState] string partnerId)
        {
            return await GetPartnerAsync(partnerId);
        }

        public async Task<Partner> GetPartnerAsync(string id)
        {
            return await partnerRepository.GetPartnerAsync(id);
        }

        public async Task<IEnumerable<Partner>> GetPartnersAsync()
        {
            return await partnerRepository.GetPartnersAsync();
        }
    }
}
