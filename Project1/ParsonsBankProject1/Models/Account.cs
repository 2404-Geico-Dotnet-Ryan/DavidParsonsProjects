class Account
{
    public int Id { get; set; }
    public string AccountName { get; set; }
    public double Balance { get; set; }
    public string AccountType { get; set; }

    // User relationship - who owns the Account
    // public User? UserId { get; set; }


    public Account(int v)
    {
        AccountName = "";
        AccountType = "";
    }

    public Account(int id, string accountName, double balance, string accountType/*, User? userId*/)
    {
        Id = id;
        AccountName = accountName;
        Balance = balance;
        AccountType = accountType;
        // UserId = userId;
    }



    public override string ToString()
    {
        return $"id:{Id};name:'{AccountName}';balance:{Balance};type:'{AccountType}';"; 
    }

}