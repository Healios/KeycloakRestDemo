using Core.Models.Common;

namespace Core.Models.User.Events
{
    public record OnUserDeleted(UserReference Actor, User user);
}
