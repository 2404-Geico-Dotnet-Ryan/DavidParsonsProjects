class AccountStorage
{
    // Temporary? Will need updating when we start learning about SQL/Database


    public Dictionary<int, Account> accountDirectory = [];
    public int idCounter = 100; // Can set the Id number and increment it with each additional movie that is added.
    // public Guid newId = Guid.NewGuid(); // Can set the Id number and increment it with each additional movie that is added.

    public AccountStorage()
    {
        Account user1Account = new(idCounter++, "David's Account", 1000.50, "Checking");
        Account user2Account = new(idCounter++, "Bob's Account", 10000.50, "Savings");

        accountDirectory.Add(user1Account.Id, user1Account);
        accountDirectory.Add(user2Account.Id, user2Account);
    }

}