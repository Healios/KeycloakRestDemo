namespace Keycloak.Settings
{
    internal class KeycloakSettings
    {
        public string BaseUrl { get; set; } = "";

        public OAuth2Settings OAuth2 { get; set; } = new OAuth2Settings();
    }
}
