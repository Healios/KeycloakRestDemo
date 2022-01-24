using Core.Models.User;
using Core.Repositories;
using MapsterMapper;
using Refit;
using System.Net;
using IUserAPI = Keycloak.Models.IUserAPI;
using KeycloakUser = Keycloak.Models.User;

namespace Keycloak.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly IMapper mapper;
        private readonly IUserAPI userAPI;

        public UserRepository(IMapper mapper, IUserAPI userAPI)
        {
            this.mapper = mapper;
            this.userAPI = userAPI;
        }

        public async Task<User> AddUserAsync(User user)
        {
            var mapped = mapper.Map<KeycloakUser>(user);
            return mapper.Map<User>(await userAPI.CreateAsync(mapped));
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            try
            {
                await userAPI.DeleteAsync(id);
            }
            catch (ApiException ex)
            {
                // We force the DeleteAsync method to "fail" by specifying a bool return type.
                // The status code will still be "NoContent" though and we can return true.
                if (ex.StatusCode == HttpStatusCode.NoContent) return true;
                return false; // Handle other errors.
            }

            return true;
        }

        public async Task<int> DeleteUsersAsync(IEnumerable<string> ids)
        {
            var deletedUsers = 0;

            foreach(var id in ids)
            {
                try
                {
                    await userAPI.DeleteAsync(id);
                }
                catch (ApiException ex)
                {
                    // We force the DeleteAsync method to "fail" by specifying a bool return type.
                    // The status code will still be "NoContent" though and we can return true.
                    if (ex.StatusCode == HttpStatusCode.NoContent) deletedUsers++;
                    return 0; // Handle other errors.
                }
            }
           
            return deletedUsers;
        }

        public async Task<User> GetUserAsync(string id)
        {
            return mapper.Map<User>(await userAPI.GetUserAsync(id));
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return mapper.Map<IEnumerable<User>>(await userAPI.GetUsersAsync());
        }

        public async Task<User> UpdateUser(User user)
        {
            var mapped = mapper.Map<KeycloakUser>(user);
            return mapper.Map<User>(await userAPI.UpdateAsync(user.Id, mapped));
        }

        private string HttpStatusCodeToError(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.BadRequest:
                    return "";
                case HttpStatusCode.Unauthorized:
                    return "";
                case HttpStatusCode.Forbidden:
                    return "";
                case HttpStatusCode.NotFound:
                    return "";
                case HttpStatusCode.InternalServerError:
                    return "";
                case HttpStatusCode.ServiceUnavailable:
                    return "";
                default:
                    return "Unhandled exception";
            }
        }
    }
}
