class UserService
{
    UserRepo ur;

    public UserService(UserRepo ur)
    {
        this.ur = ur;
    }

    public User? CreateUserAccount(User user)
    {
        // Lets not them register is the role is anything other than "User".
        if(user.Role != "user")
        {
            System.Console.WriteLine("Invalid role - please try again");
            return null; // reject them
        }

        // Let's not let them register if the username is already taken
        List<User> allUsers = ur.GetAllUsers();

        foreach(User u in allUsers)
        {
            if(user.Username == u.Username)
            {
                System.Console.WriteLine("Username already taken - please try again");
                return null; // reject them
            }
        }

        // If we do not care about any validation - this is a simple/trivial service method
        return ur.AddUser(user);
    }

    public User? Login(string username, string password)
    {
        List<User> allUsers = ur.GetAllUsers();

        foreach(User u in allUsers)
        {
            if(u.Username == username && u.Password == password)
            {
                return u; // Us returning the user will indicate success
            }
        }
        System.Console.WriteLine("Invalid Username or Password, please try again");
        return null; // reject login
    }
}