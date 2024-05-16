class UserStorage
{
    // Temporary? Will need updating when we start learning about SQL/Databases

    public Dictionary<int, User> CustomerDirectory = [];
    public int userIdCounter = 1; // Can set the Id number and increment it with each additional movie that is added.
    // public Guid newUserId = Guid.NewGuid(); // Can set the Id number and increment it with each additional movie that is added.


    public UserStorage()
    {
        User user1 = new(1, "customer1", "12345", "David", "Parsons", "user");
        User user2 = new(2, "customer2", "12345", "Bob", "Dylan", "admin");

        CustomerDirectory.Add(user1.UserId, user1);
        CustomerDirectory.Add(user2.UserId, user2);

    }
}