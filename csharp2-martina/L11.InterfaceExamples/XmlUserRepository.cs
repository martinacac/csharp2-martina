using System;
using System.Xml.Serialization;

namespace L11.InterfaceExamples;

public class XmlUserRepository : IUserRepository
{
    public static string fileName = "userCollection.xml";
    private XmlSerializer serializer; //ne static
    public XmlUserRepository() //konstruktor
    {
        this.serializer = new XmlSerializer(typeof(List<User>));
    }
    //read the file with users
    //add the new user to the collection
    //write back
    public void AddUser(User user)
    {
        var users = this.GetAllUsers() as List<User>; //abych mohla využít metodu Add musím IEnumerable překonvertovat na List
        users.Add(user);

        using (var writer = new StreamWriter(fileName))
        {
            serializer.Serialize(writer, users);
        }
    }
    public IEnumerable<User> GetAllUsers()
    {
        //var serializer = new XmlSerializer(typeof(List<User>)); //jen pokud bych neměla private XmlSerializer ani konstruktor
        //if bych měla csv nebo txt - pomocí ReadAllLines
        if (!File.Exists(fileName))
        {
            return new List<User>(); 
        }
        else
        {
            using (var reader = new StreamReader(fileName))
            {
                var users = this.serializer.Deserialize(reader) as List<User>;
                return users;
            }
        }
    }
    //option 1
    //read the file
    //deserialize
    //filter

    //option 2
    //get all users
    //filter
    public User GetUser(string name)
    {
        //return users.Where(user => user.Name == name).First();
        var users = this.GetAllUsers();
        return users.Where(user => user.Name == name).First();
    }
}

