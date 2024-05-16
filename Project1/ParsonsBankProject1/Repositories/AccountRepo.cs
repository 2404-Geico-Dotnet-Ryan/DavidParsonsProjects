class AccountRepo
{
    /*
    This class is in the Data Access / Repository Layer of our application.
    So it is solely responsible for any data access and management centered around our Movie Object.

    4 Major Operations we'd like to manage in this location.
        - CRUD Operations
            - C - Create
            - R - Read
            - U - Update
            - D - Delete
    */

    AccountStorage accountStorage = new();

    // Create
    public Account AddAccount(Account acc)
    {
        acc.Id = accountStorage.idCounter++;

        accountStorage.AccountDirectory.Add(acc.Id, acc);

        return acc;
    }

    // Read
    public Account? GetAccount(int id)
    {
        if(accountStorage.AccountDirectory.ContainsKey(id))
        {
            return accountStorage.AccountDirectory[id];    
        }
        else
        {
            System.Console.WriteLine("Invalid Account Id - Please Try Again");
            return null;
        }
    }

    public List<Account> GetAllAccounts()
    {
        //I am chooseing to return a List because that is a much more common collection to
        //work with. It does mean I have to do a little bit of work here - but its not bad.
        return accountStorage.AccountDirectory.Values.ToList();
    }

    // Update
    public Account? UpdateAccount(Account acc)
    {
        try
        {
            accountStorage.AccountDirectory[acc.Id] = acc;
            return acc;
        }
        catch (Exception)
        {
            System.Console.WriteLine("Invalid Account Id - Please Try Again");
            return null;
        }
    }

    // Delete
    public Account? DeleteAccount(Account account)
    {
        //If we have the id - remove it from storage
        bool didRemove = accountStorage.AccountDirectory.Remove(account.Id);

        if (didRemove)
        {
            return account;
        }    
        else
        {
            System.Console.WriteLine("Invalid Account Id: Please Try Again");
            return null;
        }
    }

}