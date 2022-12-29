using TeamChat.Models.Authentication;
using TeamChat.Models.DTO;

namespace TeamChat.Models.Interfaces.Data;

public interface IUserService
{
    User Register(Registration registration);
    User ValidateUser(Login login);
    List<User> GetAll();
    List<User> Search(string name);
    User GetById(int id);
}