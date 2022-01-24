using Core.Models.Partner;
using Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Persistance.Settings;

namespace Persistance.Repositories
{
    internal class PartnerRepository : BaseRepository<Partner>, IPartnerRepository
    {
        public PartnerRepository(IOptions<DatabaseSettings> dbSettings, IMongoClient mongoClient) : base(dbSettings.Value, dbSettings.Value.DatabaseName, dbSettings.Value.PartnerCollectionName, mongoClient)
        {
        }

        // Create.
        public async Task<Partner> AddPartnerAsync(Partner partner)
        {
            partner.Created = DateTime.Now;

            return await AddDocumentAsync(partner);
        }

        // Read.
        public async Task<Partner> GetPartnerAsync(string id) => await GetDocumentAsync(id);

        public async Task<IEnumerable<Partner>> GetPartnersAsync() => await GetDocumentsAsync();

        // Update.
        public async Task<Partner> UpdatePartner(Partner partner) => await UpdateDocumentAsync(partner);

        // Delete.
        public async Task<bool> DeletePartnerAsync(string id) => await DeleteDocumentAsync(id);

        public async Task<long> DeletePartnersAsync(IEnumerable<string> ids) => await DeleteDocumentsAsync(ids);
    }
}
