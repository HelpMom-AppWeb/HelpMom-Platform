

namespace webexperts.helpmom.platform.API.IAM.Domain.Model.Aggregates;

public class User(string username, string passwordHash)
{
    public int Id { get; }

    public string Username { get; private set; } = username;
    
    public string PasswordHash { get; private set; } = passwordHash;

  
    public User UpdateUsername(string username)
    {
        this.Username = username;
        return this;
    }
    
 
    public User UpdatePasswordHash(string passwordHash)
    {
        this.PasswordHash = passwordHash;
        return this;
    }
    

}