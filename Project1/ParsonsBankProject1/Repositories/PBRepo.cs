class PBRepo
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

    PBStorage bankingStorage = new();

    // Create
    public Users AddCustomer(Users cust)
    {
        cust.UserId = bankingStorage.userIdCounter++;

        bankingStorage.CustomerDirectory.Add(cust.UserId, cust);

        return cust;
    }

    public Accounts AddAccount(Accounts acc)
    {
        acc.Id = bankingStorage.idCounter++;

        bankingStorage.AccountDirectory.Add(acc.Id, acc);

        return acc;
    }

    // Read
    public Users? GetCustomer(int userId)
    {
        if(bankingStorage.CustomerDirectory.ContainsKey(userId))
        {
            return bankingStorage.CustomerDirectory[userId];    
        }
        else
        {
            System.Console.WriteLine("Invalid Customer Id - Please Try Again");
            return null;
        }
    }

    public Accounts? GetAccount(int id)
    {
        if(bankingStorage.AccountDirectory.ContainsKey(id))
        {
            return bankingStorage.AccountDirectory[id];    
        }
        else
        {
            System.Console.WriteLine("Invalid Account Id - Please Try Again");
            return null;
        }
    }

    // Update
    public Users? UpdateCustomer(Users cust)
    {
        try
        {
            bankingStorage.CustomerDirectory[cust.UserId] = cust;
            return cust;
        }
        catch (Exception)
        {
            System.Console.WriteLine("Invalid Customer Id - Please Try Again");
            return null;
        }
    }

    public Accounts? UpdateAccount(Accounts acc)
    {
        try
        {
            bankingStorage.AccountDirectory[acc.Id] = acc;
            return acc;
        }
        catch (Exception)
        {
            System.Console.WriteLine("Invalid Account Id - Please Try Again");
            return null;
        }
    }

    // Delete
    public Users? DeleteUser(Users cust)
    {
        //If we have the id - remove it from storage
        bool didRemove = bankingStorage.CustomerDirectory.Remove(cust.UserId);

        if (didRemove)
        {
            return cust;
        }    
        else
        {
            System.Console.WriteLine("Invalid Customer Id: Please Try Again");
            return null;
        }
    }

    public Accounts? DeleteAccount(Accounts acc)
    {
        //If we have the id - remove it from storage
        bool didRemove = bankingStorage.AccountDirectory.Remove(acc.Id);

        if (didRemove)
        {
            return acc;
        }    
        else
        {
            System.Console.WriteLine("Invalid Account Id: Please Try Again");
            return null;
        }
    }

    public Users? LoginCustomer(Users cust)
    {
        System.Console.WriteLine("Please enter your User Name below: ");
        string input = Console.ReadLine() ?? "";
        // if (input == bankingStorage.CustomerDirectory.ContainsValue(cust.UserName))
        // {

        // }
        // else
        // {
        //     System.Console.WriteLine("Invalid User Name, Please Try Again");
        //     return null;
        // }

        return cust;
    }

}