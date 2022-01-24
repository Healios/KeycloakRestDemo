using Core.Models.User;

namespace GraphQL.Mutations
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    internal class UserMutation
    {
        public Task<User> CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}
