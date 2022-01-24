using Core.Models.Company;
using Core.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Persistance.Settings;

namespace Persistance.Repositories
{
    internal class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(IOptions<DatabaseSettings> dbSettings, IMongoClient mongoClient) : base(dbSettings.Value, dbSettings.Value.DatabaseName, dbSettings.Value.CompanyCollectionName, mongoClient)
        {
        }

        // Create.
        public async Task<Company> AddCompanyAsync(Company company)
        {
            company.Created = DateTime.Now;

            return await AddDocumentAsync(company);
        }

        public async Task<IEnumerable<Company>> AddCompaniesAsync(IEnumerable<Company> companies)
        {
            foreach (var company in companies)
                company.Created = DateTime.Now;

            return await AddDocumentsAsync(companies);
        }

        // Read.
        public async Task<Company> GetCompanyAsync(string id) => await GetDocumentAsync(id);

        public async Task<IEnumerable<Company>> GetCompaniesAsync() => await GetDocumentsAsync();
        
        // Update.
        public async Task<Company> UpdateCompany(Company company) => await UpdateDocumentAsync(company);

        public async Task<IEnumerable<Company>> UpdateCompanies(IEnumerable<Company> companies) => await UpdateDocumentsAsync(companies);

        // Delete.
        public async Task<bool> DeleteCompanyAsync(string id) => await DeleteDocumentAsync(id);

        public async Task<long> DeleteCompaniesAsync(IEnumerable<string> ids) => await DeleteDocumentsAsync(ids);
    }
}
