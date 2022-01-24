using Core.Models.Common;

namespace Core.Models.Partner.Events
{
    public record OnPartnerDeleted(UserReference Actor, Partner partner);
}
