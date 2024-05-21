using Microsoft.Data.SqlClient;

class AccountRepo
{
    private readonly string _connectDatabase;

    public AccountRepo(string connectionString)
    {
        _connectDatabase = connectionString;
    }

    // Create
    public Account AddAccount(Account acc)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "INSERT INTO dbo.Account OUTPUT INSERTED.* VALUES (@AccountName, @Balance, @AccountType)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@AccountName", acc.AccountName);
        cmd.Parameters.AddWithValue("@Balance", acc.Balance);
        cmd.Parameters.AddWithValue("@AccountType", acc.AccountType);
        // cmd.Parameters.AddWithValue("@UserId", acc.UserId);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            Account newAcc = new()
            {
                Id = (int)reader["Id"],
                AccountName = (string)reader["AccountName"],
                Balance = (double)reader["Balance"],
                AccountType = (string)reader["AccountType"],
                // UserId = (User)reader["UserId"]
            };
            return newAcc;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

    // Read
    public Account? GetAccount(int id)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "INSERT INTO dbo.Account OUTPUT INSERTED.* WHERE Id = (@Id)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Id", id);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            Account newAcc = new()
            {
                Id = (int)reader["Id"],
                AccountName = (string)reader["AccountName"],
                Balance = (double)reader["Balance"],
                AccountType = (string)reader["AccountType"],
                // UserId = (User)reader["UserId"]
            };
            return newAcc;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }

    }

    public List<Account> GetAllAccounts()
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "SELECT * FROM dbo.Account"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        SqlCommand cmd = new(sql, connection);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        List<Account> accList = new();

        while (reader.Read())
        {
            Account retrievedAcc = new();
            {
                retrievedAcc.Id = (int) reader["Id"];
                retrievedAcc.AccountName = (string) reader["AccountName"];
                retrievedAcc.Balance = (double) reader["Balance"];
                retrievedAcc.AccountType = (string) reader["AccountType"];
                // retrievedAcc.UserId = (User) reader["UserId"];
            }
            accList.Add(retrievedAcc);
        }

        return accList;
    }

    // Update
    public Account? UpdateAccount(Account acc)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "UPDATE dbo.Account OUTPUT INSERTED.* SET (@AccountName, @Balance, @AccountType)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@AccountName", acc.AccountName);
        cmd.Parameters.AddWithValue("@Balance", acc.Balance);
        cmd.Parameters.AddWithValue("@AccountType", acc.AccountType);
        // cmd.Parameters.AddWithValue("@UserId", acc.UserId);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            Account updatedAcc = new()
            {
                Id = (int)reader["Id"],
                AccountName = (string)reader["AccountName"],
                Balance = (double)reader["Balance"],
                AccountType = (string)reader["AccountType"],
                // UserId = (User)reader["UserId"]
            };
            return updatedAcc;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

    // Delete
    public Account? DeleteAccount(Account acc)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "DELETE FROM dbo.Account OUTPUT INSERTED.* WHERE Id = (@Id)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Id", acc.Id);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            Account deletedAcc = new()
            {
                Id = (int)reader["Id"],
                AccountName = (string)reader["AccountName"],
                Balance = (double)reader["Balance"],
                AccountType = (string)reader["AccountType"],
                // UserId = (User)reader["UserId"]
            };
            return deletedAcc;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

}