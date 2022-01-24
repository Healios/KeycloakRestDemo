using Core.Models.Company;

namespace Core.Repositories
{
    public interface ICompanyRepository
    {
        // Create.
        public Task<Company> AddCompanyAsync(Company company);

        // Read.
        public Task<Company> GetCompanyAsync(string id);
        public Task<IEnumerable<Company>> GetCompaniesAsync();

        // Update.
        public Task<Company> UpdateCompany(Company company);
        public Task<IEnumerable<Company>> UpdateCompanies(IEnumerable<Company> companies);

        // Delete.
        public Task<bool> DeleteCompanyAsync(string id);
        public Task<long> DeleteCompaniesAsync(IEnumerable<string> ids);
    }
}
