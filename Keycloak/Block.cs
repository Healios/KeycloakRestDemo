using Core.Repositories;
using IdentityModel.Client;
using Keycloak.Models;
using Keycloak.Repositories;
using Keycloak.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace Keycloak
{
    public static class Block
    {
        /// <summary>
        /// Hooks up Keycloak.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddKeycloak(this IServiceCollection services, IConfiguration configuration)
        {
            // Get Keycloak settings.
            var keycloakClientSection = configuration.GetSection("Keycloak");
            var keycloakSettings = new KeycloakSettings();
            keycloakClientSection.Bind(keycloakSettings);

            // Add OAuth2.0
            services.AddAccessTokenManagement(options =>
            {
                options.Client.Clients.Add("identityserver", new ClientCredentialsTokenRequest
                {
                    Address = keycloakSettings.OAuth2.Url,
                    ClientId = keycloakSettings.OAuth2.ClientId,
                    ClientSecret = keycloakSettings.OAuth2.ClientSecret
                });
            });

            // Add OAuth2.0 x and configure it as a Refit IUserAPI client. 
            services.AddClientAccessTokenHttpClient("client", configureClient: client =>
            {
                client.BaseAddress = new Uri(keycloakSettings.BaseUrl);
            })
            .AddTypedClient(client => RestService.For<IUserAPI>(client));

            // Add services to DI.
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
