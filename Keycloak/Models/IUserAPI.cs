using Refit;

namespace Keycloak.Models
{
    internal interface IUserAPI
    {
        // Create.
        [Post("/users")]
        public Task<User> CreateAsync(User user);

        // Read.
        [Get("/users/{user}")]
        public Task<IEnumerable<User>> GetUserAsync(string id);

        [Get("/users")]
        public Task<IEnumerable<User>> GetUsersAsync();

        // Update.
        [Put("/users/{user}")]
        public Task<User> UpdateAsync(string id, User user);

        // Delete.
        [Delete("/users/{user}")]
        public Task<bool> DeleteAsync(string id);
    }
}