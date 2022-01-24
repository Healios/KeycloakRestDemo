using Refit;

namespace Keycloak.Models
{
    internal class User
    {
        [AliasAs("id")]
        public string Id { get; set; } = "";

        [AliasAs("createdTimestamp")]
        public DateTime Created { get; set; }

        [AliasAs("username")]
        public string Username { get; set; } = "";

        [AliasAs("enabled")]
        public bool Enabled { get; set; }

        [AliasAs("totp")]
        public bool TimeBasedOnTimePassword { get; set; }

        [AliasAs("emailVerified")]
        public bool IsEmailVerified { get; set; }

        [AliasAs("firstName")]
        public string FirstName { get; set; } = "";

        [AliasAs("lastName")]
        public string LastName { get; set; } = "";

        [AliasAs("email")]
        public string Email { get; set; } = "";

        [AliasAs("attributes")]
        public Attributes? Attributes { get; set; }

        [AliasAs("requiredActions")]
        public IEnumerable<string> RequiredActions { get; set; } = new List<string>();
    }
}
