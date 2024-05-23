using System.Net;
using Microsoft.Data.SqlClient;

class AccountRepo
{
    private readonly string _connectDatabase;
    static UserRepo ur;
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
        string sql = "INSERT INTO dbo.Account OUTPUT Inserted.* VALUES (@AccountName, @Balance, @AccountType, @UserId)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@AccountName", acc.AccountName);
        cmd.Parameters.AddWithValue("@Balance", acc.Balance);
        cmd.Parameters.AddWithValue("@AccountType", acc.AccountType);
        cmd.Parameters.AddWithValue("@UserId", acc.UserId);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            Account newAcc = AccountBuilder(reader);
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
        string sql = "SELECT * FROM dbo.Account WHERE Id = (@Id)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Id", id);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            Account newAcc = AccountBuilder(reader);
            return newAcc;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }

    }

    public List<Account>? GetAllAccounts()
    {
        List<Account> accList = new();
        
        try
        {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "SELECT * FROM dbo.Account"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
            {
                Account newAcc = AccountBuilder(reader);
                accList.Add(newAcc);
            }

            return accList;
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
            System.Console.WriteLine(e.StackTrace);
            return null;
        }
    }

    // Update
    public Account? UpdateAccount(Account account)
    {
        using SqlConnection connection = new(_connectDatabase);  // add the using keyword to say we are using this variable and to call dispose method when we leave the scope of its use - Method scope.
        connection.Open();

        // Create the SQL String
        string sql = "UPDATE dbo.Account SET AccountName = @AccountName, Balance = @Balance, AccountType = @AccountType OUTPUT Inserted.* WHERE Id = (@Id)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Id", account.Id);
        cmd.Parameters.AddWithValue("@AccountName", account.AccountName);
        cmd.Parameters.AddWithValue("@Balance", account.Balance);
        cmd.Parameters.AddWithValue("@AccountType", account.AccountType);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            Account newAcc = AccountBuilder(reader);
            return newAcc;
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
        string sql = "DELETE FROM dbo.Account OUTPUT DELETED.* WHERE Id = (@Id)"; // The "Output inserted.*" will return the values

        // Set up SqlCommand Command object and use its methods to modify the parameterized values
        using SqlCommand cmd = new(sql, connection);
        cmd.Parameters.AddWithValue("@Id", acc.Id);

        //Execute the query
        // cmd.ExecuteNonQuery(); // Executes a non select SQL statement (inserts, updates, deletes). ** NOT NEEDED WITH THE Output inserted.* above **
        using SqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            // If Read() found data - > then extract it
            Account newAcc = AccountBuilder(reader);
            return newAcc;
        }
        else
        {
            // Else Read() found nothing -> Insert Failed.
            return null;
        }
    }

    private static Account AccountBuilder(SqlDataReader reader)
    {
        Account newAcc = new();
        newAcc.Id = (int)reader["Id"];
        newAcc.AccountName = (string)reader["AccountName"];
        newAcc.Balance = (double)(decimal)reader["Balance"];
        newAcc.AccountType = (string)reader["AccountType"];
        newAcc.UserId = (int)reader["UserId"];
        return newAcc;
    }

}