using Core.Models.Partner;

namespace GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    internal class PartnerMutation
    {
        public Task<Partner> CreatePartner()
        {
            throw new NotImplementedException();
        }
    }
}
