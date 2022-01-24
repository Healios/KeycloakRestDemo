using Core.Models.Common;

namespace Core.Models.User
{
    public class User
    {
        public string Id { get; set; } = "";

        public string Email { get; set; } = "";

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public DateTime Create { get; set; }

        public bool IsEmailConfirmed { get; set; }

        public CompanyReference Company { get; set; } = new CompanyReference();

        public PartnerReference Partner { get; set; } = new PartnerReference();
    }
}
