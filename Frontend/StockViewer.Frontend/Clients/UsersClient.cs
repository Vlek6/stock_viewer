using StockViewer.Frontend.Models;
namespace StockViewer.Frontend.Clients;

public class UsersClient(HttpClient httpClient)
{
    private readonly List<User> users= new List<User>();

    public void AddUser(User user){
        users.Add(user);
    }

    // TODO: User credentials check implementation
    public bool CheckUser(User user){
        // coś jak SELECT usr FROM users WHERE usr.username == user.username
        // return user.comparePassoword(usr.password);
        if(users is not null) // póki co nigdy nie będzie null
        return true;
        else
        return false;
    }
}


