using System.ComponentModel;

class AccountServices
{  
    
    AccountRepo accountRepo;

    public AccountServices(AccountRepo ar)
    {
        accountRepo = ar;
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

    public double MakeDeposit(Account account, double deposit)
    {
        double accountBalance = account.Balance;

        accountBalance += deposit;

        return accountBalance;
    }

    public double MakeWithdrawal(Account account, double withdrawal)
    {
        double accountBalance = account.Balance;

        accountBalance -= withdrawal;

        return accountBalance;
    }

    public Account? DeleteAccount(Account account)
    {
        return accountRepo.DeleteAccount(account);
    }
}