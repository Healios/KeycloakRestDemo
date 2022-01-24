using Core.Models.Common;

namespace Core.Models.User.Events
{
    public record OnUserCreated(UserReference Actor, User user);
}
