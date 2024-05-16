class User
{
    public int UserId { get; set; } 
    public string Username { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }   
    public string LastName { get; set; }
    public string Role { get; set; }


    public User()
    {
        Username = "";
        Password = "";
        FirstName = "";
        LastName = "";
        Role = "";
    }

    public User(int userId, string userName, string password, string firstName, string lastName, string role)
    {
        UserId = userId;
        Username = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Role = role;
    }


    public override string ToString()
    {
        return $"id:{UserId};userName:{Username};password:{Password};firstName:{FirstName};lastName:{LastName};role:{Role}";
    }

} 