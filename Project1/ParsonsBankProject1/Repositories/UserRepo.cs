using Microsoft.Data.SqlClient;

class UserRepo
{
    private readonly string _connectDatabase;

    public UserRepo(string connectionString)
    {
        _connectDatabase = connectionString;
    }

    // Create
    public User AddUser(User user)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "INSERT INTO dbo.[User] OUTPUT INSERTED.* VALUES (@Username, @Password, @FirstName, @LastName, @Role)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Username", user.Username);
        cmd.Parameters.AddWithValue("@Password", user.Password);
        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        cmd.Parameters.AddWithValue("@LastName", user.LastName);
        cmd.Parameters.AddWithValue("@Role", user.Role);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            User newUser = UserBuilder(reader);
            return newUser;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

    // Read
    public User? GetUser(int userId)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "SELECT * FROM dbo.[User] OUTPUT INSERTED.* WHERE UserId = (@UserId)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", userId);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            User newUser = UserBuilder(reader);
            return newUser;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

    public List<User>? GetAllUsers()
    {
        List<User> userList = new();

        try
        {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "SELECT * FROM dbo.[User]"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            User newUser = UserBuilder(reader);
            userList.Add(newUser);
        }

        return userList;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    // Update
    public User? UpdateUser(User user)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "UPDATE dbo.[User] SET Username = @Username, Password = @Password, Role = @Role OUTPUT INSERTED.* WHERE UserId = (@UserId)"; // The "Output inserted.*" will return the values

         // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", user.UserId);
        cmd.Parameters.AddWithValue("@Username", user.Username);
        cmd.Parameters.AddWithValue("@Password", user.Password);
        cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
        cmd.Parameters.AddWithValue("@LastName", user.LastName);
        cmd.Parameters.AddWithValue("@Role", user.Role);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            User newUser = UserBuilder(reader);
            return newUser;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

    // Delete
    public User? DeleteUser(User user)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "DELETE FROM dbo.[User] OUTPUT DELETED.* WHERE UserId = (@UserId)"; // The "Output inserted.*" will return the values

         // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", user.UserId);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            User newUser = UserBuilder(reader);
            return newUser;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

    private static User UserBuilder(SqlDataReader reader)
    {
        User newUser = new();
        newUser.UserId = (int)reader["UserId"];
        newUser.Username = (string)reader["Username"];
        newUser.Password = (string)reader["Password"];
        newUser.FirstName = (string)reader["FirstName"];
        newUser.LastName = (string)reader["LastName"];
        newUser.Role = (string)reader["Role"];
        return newUser;
    }
}