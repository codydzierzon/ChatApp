using TeamChat.Models.DTO;

namespace TeamChat.Models.Interfaces.Authentication;

public interface IUserAuthService
{
    Task SignIn(User user);
    Task SignOut();
}