using Core.Models.User;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        // Create.
        public Task<User> AddUserAsync(User user);

        // Read.
        public Task<User> GetUserAsync(string id);
        public Task<IEnumerable<User>> GetUsersAsync();

        // Update.
        public Task<User> UpdateUser(User user);

        // Delete.
        public Task<bool> DeleteUserAsync(string id);
        public Task<int> DeleteUsersAsync(IEnumerable<string> ids);
    }
}
