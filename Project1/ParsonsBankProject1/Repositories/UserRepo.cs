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
        SqlCommand cmd = new(sql, connection);
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
            User newUser = new();
            newUser.UserId = (int) reader["UserId"];
            newUser.Username = (string) reader["Username"];
            newUser.Password = (string) reader["Password"];
            newUser.Password = (string) reader["FirstName"];
            newUser.Password = (string) reader["LastName"];
            newUser.Role = (string) reader["Role"];
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
        string sql = "SELECT * FROM dbo.[User] OUTPUT INSERTED.* WHERE Id = (@UserId)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@UserId", userId);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            User retrievedUser = new();
            retrievedUser.UserId = (int) reader["UserId"];
            retrievedUser.Username = (string) reader["Username"];
            retrievedUser.Password = (string) reader["Password"];
            retrievedUser.Password = (string) reader["FirstName"];
            retrievedUser.Password = (string) reader["LastName"];
            retrievedUser.Role = (string) reader["Role"];
            return retrievedUser;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

    public List<User> GetAllUsers()
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "SELECT * FROM dbo.[User] OUTPUT INSERTED.*"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        SqlCommand cmd = new(sql, connection);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            User retrievedUser = new();
            retrievedUser.UserId = (int) reader["UserId"];
            retrievedUser.Username = (string) reader["Username"];
            retrievedUser.Password = (string) reader["Password"];
            retrievedUser.Password = (string) reader["FirstName"];
            retrievedUser.Password = (string) reader["LastName"];
            retrievedUser.Role = (string) reader["Role"];
            return null;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

    // Update
    public User? UpdateUser(User user)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "UPDATE dbo.[User] OUTPUT INSERTED.* SET (@Username, @Password, @Role)"; // The "Output inserted.*" will return the values

         // Set up SqlCommand Command object and use its methods to modify the parameterized values
        SqlCommand cmd = new(sql, connection);
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
            User updatedUser = new();
            updatedUser.UserId = (int) reader["UserId"];
            updatedUser.Username = (string) reader["Username"];
            updatedUser.Password = (string) reader["Password"];
            updatedUser.Password = (string) reader["FirstName"];
            updatedUser.Password = (string) reader["LastName"];
            updatedUser.Role = (string) reader["Role"];
            return updatedUser;
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
        string sql = "DELETE FROM dbo.[User] OUTPUT INSERTED.* WHERE Id = (@Id)"; // The "Output inserted.*" will return the values

         // Set up SqlCommand Command object and use its methods to modify the parameterized values
        SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Id", user.UserId);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            User deletedUser = new();
            deletedUser.UserId = (int) reader["UserId"];
            deletedUser.Username = (string) reader["Username"];
            deletedUser.Password = (string) reader["Password"];
            deletedUser.Password = (string) reader["FirstName"];
            deletedUser.Password = (string) reader["LastName"];
            deletedUser.Role = (string) reader["Role"];
            return deletedUser;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }
}