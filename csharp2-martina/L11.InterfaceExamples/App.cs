using System;

namespace L11.InterfaceExamples;

public class App
{
    private IUserRepository userRepository;
    public App(IUserRepository userRepository) //constructor
    {
        this.userRepository = userRepository;
    }
    public void Run()
    {
        var users = this.userRepository.GetAllUsers();
        foreach (var user in users)
        {
            this.OutputUser(user);
        }
        this.userRepository.AddUser(new User { Name = "Martin", PhoneNumber = "+420111222333" });
        var usersAfter = this.userRepository.GetAllUsers();
        System.Console.WriteLine("Users after adding:");
        foreach (var user in usersAfter)
        {
            this.OutputUser(user);
        }
    }
    private void OutputUser(User user)
    {
        System.Console.WriteLine($"User {user.Name} has phone number {user.PhoneNumber}");
    }
}
