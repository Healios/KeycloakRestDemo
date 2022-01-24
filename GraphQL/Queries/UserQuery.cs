using Core.Models.User;
using Core.Repositories;

namespace GraphQL.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    internal class UserQuery
    {
        private readonly IUserRepository userRepository;

        public UserQuery(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> GetMyUserAsync([GlobalState] string userId)
        {
            return await GetUserAsync(userId);
        }

        public async Task<User> GetUserAsync(string id)
        {
            return await userRepository.GetUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetUsersAsync(string companyId)
        {
            return await userRepository.GetUsersAsync();
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await userRepository.GetUsersAsync();
        }
    }
}
