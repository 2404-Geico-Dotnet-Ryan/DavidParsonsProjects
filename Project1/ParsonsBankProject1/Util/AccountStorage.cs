class AccountStorage
{
    // Temporary? Will need updating when we start learning about SQL/Database


    public Dictionary<int, Account> AccountDirectory = [];
    public int idCounter = 1; // Can set the Id number and increment it with each additional movie that is added.
    // public Guid newId = Guid.NewGuid(); // Can set the Id number and increment it with each additional movie that is added.

    public AccountStorage()
    {
        
    }

    public AccountStorage(User owner)
    {
        Account user1Account = new(100, "David's Account", 1000.50, "Checking", owner);
        Account user2Account = new(101, "Bob's Account", 10000.50, "Savings", owner);

        AccountDirectory.Add(user1Account.Id, user1Account);
        AccountDirectory.Add(user2Account.Id, user2Account);
    }
}