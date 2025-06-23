using System;

namespace L11.InterfaceExamples;

public class InMemoryUserReporitory : IUserRepository
{
    private List<User> users; //nebo prázdný seznam (pak bych nepotřebovala bezparametrický konstruktor): private List<User> users = new List<User>();
    public InMemoryUserReporitory() //bezparametrický konstruktor
    {
        this.users = new List<User>();
    }
    public void AddUser(User user)
    {
        users.Add(user);
    }
    public IEnumerable<User> GetAllUsers()
    {
        return users;
    }
    public User GetUser(string name)
    {
        return users.Where(user => user.Name == name).First();
    }
}
