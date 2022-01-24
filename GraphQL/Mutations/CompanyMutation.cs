using Core.Models.Company;

namespace GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    internal class CompanyMutation
    {
        public Task<Company> CreateCompany()
        {
            throw new NotImplementedException();
        }
    }
}
