using System.ComponentModel;

class AccountServices
{  
    
    AccountRepo accountRepo;

    public AccountServices(AccountRepo ar)
    {
        accountRepo = ar;
    }

    public Account? NewAccount(Account account)
    {
        return accountRepo.AddAccount(account);
    }

    public double MakeInitialDeposit()
    {
        double initialDeposit = 0;


        return initialDeposit;
    }

    public Account? RetrieveAccount(int id)
    {
        // Need to create code block to view existing $$ amount in account
        return accountRepo.GetAccount(id);
    }

    public List<Account?> RetrieveAllAccounts(User currentUser)
    {
        // Need to create code block to view existing $$ amount in account
        List<Account> allAccounts = accountRepo.GetAllAccounts();

        //Then Filter out movies you dont want.
        List<Account> userAccounts = new();
        //run a loop over all movies to determine if they make the cut - to be added to the filtered list.
        foreach (Account a in allAccounts)
        {
            if (a.UserId == currentUser.UserId)
            {
                userAccounts.Add(a);
            }
        }
        return userAccounts;
    }

    public Account MakeDeposit(Account account, double deposit)
    {
        account.Balance += deposit;

        accountRepo.UpdateAccount(account);

        return account;
    }

    public Account MakeWithdrawal(Account account, double withdrawal)
    {
        account.Balance -= withdrawal;

        accountRepo.UpdateAccount(account);

        return account;
    }

    public Account? DeleteAccount(Account account)
    {
        return accountRepo.DeleteAccount(account);
    }
}