using System;

namespace L11.InterfaceExamples;
//databáze
public interface IUserRepository
{
    void AddUser(User user);
    User GetUser(string name);
    IEnumerable<User> GetAllUsers();
}
