class PBStorage
{
    // Temporary? Will need updating when we start learning about SQL/Databases

    public Dictionary<int, Users> CustomerDirectory = [];
    public int userIdCounter = 1; // Can set the Id number and increment it with each additional movie that is added.
    // public Guid newUserId = Guid.NewGuid(); // Can set the Id number and increment it with each additional movie that is added.



    public Dictionary<int, Accounts> AccountDirectory = [];
    public int idCounter = 1; // Can set the Id number and increment it with each additional movie that is added.
    // public Guid newId = Guid.NewGuid(); // Can set the Id number and increment it with each additional movie that is added.


    public PBStorage()
    {
        Users user1 = new(1, "customer1", "12345", "David", "Parsons");
        Users user2 = new(2, "customer2", "12345", "Bob", "Dylan");

        CustomerDirectory.Add(user1.UserId, user1);
        CustomerDirectory.Add(user2.UserId, user2);



        Accounts user1Account = new(100, "David's Account", 1000.50, "Checking", user1.UserId);
        Accounts user2Account = new(101, "Bob's Account", 10000.50, "Savings", user2.UserId);

        AccountDirectory.Add(user1Account.Id, user1Account);
        AccountDirectory.Add(user2Account.Id, user2Account);
    }

}