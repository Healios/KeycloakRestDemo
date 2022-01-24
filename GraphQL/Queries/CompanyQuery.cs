using Core.Models.Company;
using Core.Repositories;

namespace GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    internal class CompanyQuery
    {
        private readonly ICompanyRepository companyRepository;

        public CompanyQuery(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<Company> GetMyCompanyAsync([GlobalState] string companyId)
        {
            return await GetCompanyAsync(companyId);
        }

        public async Task<Company> GetCompanyAsync(string id)
        {
            return await companyRepository.GetCompanyAsync(id);
        }

        public async Task<IEnumerable<Company>> GetCompaniesAsync()
        {
            return await companyRepository.GetCompaniesAsync();
        }
    }
}
