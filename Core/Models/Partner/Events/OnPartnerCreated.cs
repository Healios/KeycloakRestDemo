using Core.Models.Common;

namespace Core.Models.Partner.Events
{
    public record OnPartnerCreated(UserReference Actor, Partner partner);
}
