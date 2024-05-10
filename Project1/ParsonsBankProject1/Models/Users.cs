class Users
{
    public int UserId { get; set; } 
    public string UserName { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }   
    public string LastName { get; set; }


    public Users(Guid newUserId)
    {
        UserName = "";
        Password = "";
        FirstName = "";
        LastName = "";
    }

    public Users(int userId, string userName, string password, string firstName, string lastName)
    {
        UserId = userId;
        UserName = userName;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }


    public override string ToString()
    {
        return $"id:{UserId};userName:{UserName};password:{Password};firstName:{FirstName};lastName:{LastName}";
    }

} 