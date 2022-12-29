using NorthwindDemo.Services.Data.EF;
using TeamChat.Models.Authentication;
using TeamChat.Models.DTO;
using TeamChat.Models.Interfaces.Cryptography;
using TeamChat.Models.Interfaces.Data;

namespace NorthwindDemo.Services.Data;

public class EFUserService: IUserService
{
    private TeamChatDataContext db;
    private IHasher hasher;

    public EFUserService(IHasher hasher, TeamChatDataContext db)
    {
        this.hasher = hasher;
        this.db = db;
    }

    public User Register(Registration registration)
    {
        var salt = hasher.Salt;
        var hashedPassword = hasher.Hash(registration.Password, salt);

        var user = new User
                   {
                       UserName = registration.UserName,
                       HashedPassword = hashedPassword,
                       Salt = salt
                   };

        db.Users.Add(user);
        db.SaveChanges();

        return user;
    }

    public User ValidateUser(Login login)
    {
        if (login.UserName == null || login.Password == null)
            return null;

        var user = db.Users.FirstOrDefault(u => u.UserName.ToLower() == login.UserName.ToLower());
        if (user == null)
            return null;

        var hashedPassword = hasher.Hash(login.Password, user.Salt);
        if (!hashedPassword.Equals(user.HashedPassword))
            return null;

        return new User { UserId = user.UserId, UserName = user.UserName };
    }

    public List<User> GetAll()
    {
        return db.Users.ToList();
    }
    public List<User> Search(string name)
    {
        var users = from u in db.Users
                    where u.UserName.Contains(name)
                    select u;

        return users.ToList();
        //
        // return db.Users
        //          .Where(user => user.UserName.ToLower() == name.ToLower())
        //          .ToList();
    }

    public User GetById(int id)
    {
        return db.Users.Find(id);
    }

    
}