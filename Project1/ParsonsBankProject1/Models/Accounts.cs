class Accounts
{
    public int Id { get; set; }
    public string AccountName { get; set; }
    public double Balance { get; set; }
    public string AccountType { get; set; }
    public int UserId { get; set; }


    public Accounts()
    {
        AccountName = "";
        AccountType = "";
    }

    public Accounts(int id, string accountName, double balance, string accountType, int userId)
    {
        Id = id;
        AccountName = accountName;
        Balance = balance;
        AccountType = accountType;
        UserId = userId;
    }



    public override string ToString()
    {
        return $"id:{Id};name:{AccountName};balance:{Balance};type:{AccountType};userId:{UserId}";
    }

}