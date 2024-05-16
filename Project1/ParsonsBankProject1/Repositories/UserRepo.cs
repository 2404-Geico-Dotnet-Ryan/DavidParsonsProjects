class UserRepo
{
    /*
    This class is in the Data Access / Repository Layer of our application.
    So it is solely responsible for any data access and management centered around our Movie Object.

    4 Major Operations we'd like to manage in this location.
        - CRUD Operations
            - C - Create
            - R - Read
            - U - Update
            - D - Delete
    */

    UserStorage userStorage = new();

    // Create
    public User AddUser(User user)
    {
        user.UserId = userStorage.userIdCounter++;

        userStorage.CustomerDirectory.Add(user.UserId, user);

        return user;
    }

    // Read
    public User? GetUser(int userId)
    {
        if(userStorage.CustomerDirectory.ContainsKey(userId))
        {
            return userStorage.CustomerDirectory[userId];    
        }
        else
        {
            System.Console.WriteLine("Invalid Customer Id - Please Try Again");
            return null;
        }
    }

    public List<User> GetAllUsers()
    {
        //I am chooseing to return a List because that is a much more common collection to
        //work with. It does mean I have to do a little bit of work here - but its not bad.
        return userStorage.CustomerDirectory.Values.ToList();
    }

    // Update
    public User? UpdateUser(User user)
    {
        try
        {
            userStorage.CustomerDirectory[user.UserId] = user;
            return user;
        }
        catch (Exception)
        {
            System.Console.WriteLine("Invalid Customer Id - Please Try Again");
            return null;
        }
    }

    // Delete
    public User? DeleteUser(User user)
    {
        //If we have the id - remove it from storage
        bool didRemove = userStorage.CustomerDirectory.Remove(user.UserId);

        if (didRemove)
        {
            return user;
        }    
        else
        {
            System.Console.WriteLine("Invalid Customer Id: Please Try Again");
            return null;
        }
    }
}