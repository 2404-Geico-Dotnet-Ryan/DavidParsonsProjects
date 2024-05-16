using System.ComponentModel;

class AccountServices
{  
    /*
        Service:
            - Create User
            - Create Account
            - Check Account Balance
            - Deposite Money into Account
            - Withdrawal Money from Account
            - Delete Account
    */
    
    AccountRepo bankr = new();

    public double MakeInitialDeposit()
    {
        double initialDeposit = 0;


        return initialDeposit;
    }

    public Account? RetrieveAccount(int id)
    {
        // Need to create code block to view existing $$ amount in account
        return bankr.GetAccount(id);
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
        return bankr.DeleteAccount(account);
    }

    public static Account PromptUserForAccount(AccountRepo acc)
    {
        Account? retrievedAccount = null;
        while (retrievedAccount == null)
        {
            System.Console.WriteLine("Lets find the your Account!");
            System.Console.WriteLine("Please enter an account id: ");
            int input = int.Parse(Console.ReadLine() ?? "0");
            retrievedAccount = acc.GetAccount(input);
        }
        return retrievedAccount;
    }
}