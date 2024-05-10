class PBServices
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
    
    PBRepo bankr = new();

    public double GetAccountBalance(int id)
    {
        // Need to create code block to view existing $$ amount in account
        Accounts? retrievedAccount = bankr.GetAccount(id);
        double accountBalance = retrievedAccount.Balance;

        return accountBalance;
    }

    public double MakeDeposit(int id, double deposit)
    {
        Accounts? retrievedAccount = bankr.GetAccount(id);
        double accountBalance = retrievedAccount.Balance;

        accountBalance += deposit;

        return accountBalance;
    }

    public double MakeWithdrawal(int id, double withdrawal)
    {
        Accounts? retrievedAccount = bankr.GetAccount(id);
        double accountBalance = retrievedAccount.Balance;

        accountBalance -= withdrawal;

        return accountBalance;
    }
}