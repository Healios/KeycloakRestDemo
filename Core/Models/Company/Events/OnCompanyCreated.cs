using Core.Models.Common;

namespace Core.Models.Company.Events
{
    public record OnCompanyCreated(UserReference Actor, Company Company);
}
