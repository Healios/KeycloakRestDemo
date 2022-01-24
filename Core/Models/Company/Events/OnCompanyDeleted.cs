using Core.Models.Common;

namespace Core.Models.Company.Events
{
    public record OnCompanyDeleted(UserReference Actor, Company Company);
}
