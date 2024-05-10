namespace ParsonsBankProject1;

class Program
{
    static void Main(string[] args)
    {
        PBRepo acc = new();
        PBRepo cust = new();
        String[] menuOptions = ["[1] View Account Balance", "[2] Make a Deposit", "[3] Make a Withdrawal", "[0] Log Out"];

        System.Console.WriteLine("||||||||||||||||||||||||||||||||||||");
        System.Console.WriteLine("|     Welcome to Parsons Bank!     |");
        System.Console.WriteLine("||||||||||||||||||||||||||||||||||||");
        System.Console.WriteLine();
        Thread.Sleep(1000);
        System.Console.WriteLine("Do you currently have an account with us? Y/N");
        var input = Console.ReadLine() ?? "";
        // if (input.ToLower() == "y")
        // {
        //     //Send to the login page
        //     bool loginSuccessful = false;
        //     LogInToAccount();

        //     if(loginSuccessful)
        //     {
        //         MainMenu(menuOptions, acc);
        //     }
        //     else
        //     {
        //         ExitApplication();
        //     }
        // }
        // else
        // {
        //     //time to create an account - keep it simple - 
        //     CreateAnAccount(cust, acc);

        //     MainMenu(menuOptions, acc);
        // }

        MainMenu(menuOptions, acc);
    }

    private static void MainMenu(string[] menuOptions, PBRepo acc)
    {
        //Something that happens after login or account is created - go to Main Menu
        bool keepGoing = true;
        while (keepGoing)
        {
        System.Console.WriteLine();
        System.Console.WriteLine("Please select which action you would like to take: ");
        Thread.Sleep(1000);
        for (int i = 0; i < menuOptions.Count(); i++)
        {
            System.Console.WriteLine($"{i + 1} {menuOptions[i]}");
        }

        

        var selections = Convert.ToInt32(Console.ReadLine());
        
        switch (selections)
        {
            case 1:
                ViewAccountBalance(acc);
                break;
            case 2:
                DepositMoney(acc);
                break;
            case 3:
                WithdrawalMoney(acc);
                break;
            case 0:
                LogOut();
                break;
        }

        selections = ValidateSelection(selections, 3);

        }
        // do I need more here - next steps?
    }

    public static void LogInToAccount()
    {
        // Need to create code block for a customer to log into the Bank Account
        System.Console.WriteLine("Please enter your User Name below: ");
        string input = Console.ReadLine() ?? "";
        

    }

    public static PBRepo CreateAnAccount(PBRepo cust, PBRepo acc)
    {
        // Need to create code block for a customer to create an account
        System.Console.WriteLine("Let's create a new account!");
        System.Console.WriteLine("Please provide your First Name");
        string firstName = Console.ReadLine() ?? "";

        System.Console.WriteLine("Please provide your Last Name");
        string lastName = Console.ReadLine() ?? "";

        System.Console.WriteLine("What would you like your username to be?");
        string userName = Console.ReadLine() ?? "";

        System.Console.WriteLine("Please provide a password");
        string password = Console.ReadLine() ?? "";

        System.Console.WriteLine("What would you like the name of your account to be?");
        string accountName = Console.ReadLine() ?? "";

        System.Console.WriteLine("What type of account would you like to open? (Checking/Savings)");
        string accountType = Console.ReadLine() ?? "";

        System.Console.WriteLine("Please enter the $ amount you would like to add to your new account!");
        double balance = double.Parse(Console.ReadLine() ?? "0");

        // Lets just assume that the available will default to true and by extension the returnDate will be 0.
        // Also not going to ask for id - because our movie repo already gives it the next correct value for id.
        // Now we need to collect all this info into a new movie object

        Users customer = new(0, userName, password, firstName, lastName);
        Accounts account = new(0, accountName, balance, accountType, customer.UserId);

        // Now that the info is collected into a Movie object, lets use the Movie Repo to add into our collection.
        // Reusing the movie variable to store the updated values if any from the add movie process
        cust.AddCustomer(customer);
        acc.AddAccount(account);

        // For the sake of clarity to the user of the app lets inform them of the newly added movie.

        System.Console.WriteLine("Newly Added Account: " + acc);

        return acc;
    }

    public static PBRepo ViewAccountBalance(PBRepo acc)
    {
        // Need to create code block to view existing $$ amount in account
        Accounts retrievedAccount = PromptUserForAccount(acc);
        double accountBalance = retrievedAccount.Balance;

        System.Console.WriteLine("Account Balance: " + accountBalance);
        System.Console.WriteLine();

        return acc;
    }

    public static PBRepo DepositMoney(PBRepo acc)
    {
        // Need to create code block to add a $$ amount to existing balance
        Accounts retrievedAccount = PromptUserForAccount(acc);
        double accountBalance = retrievedAccount.Balance;

        System.Console.WriteLine("Please enter the amount your would like to deposit into your account: " + retrievedAccount.AccountName);
        double deposit = double.Parse(Console.ReadLine() ?? "0");

        accountBalance += deposit;
        // double newAccountBalance = accountBalance + deposit; // Initally had this before the line above.

        System.Console.WriteLine("The new balance for " + retrievedAccount.AccountName + " is: " + accountBalance);
        System.Console.WriteLine();

        return acc;
    }

    public static PBRepo WithdrawalMoney(PBRepo acc)
    {
        // Need to create code block to remove $$ from existing balance
        Accounts retrievedAccount = PromptUserForAccount(acc);
        double accountBalance = retrievedAccount.Balance;

        System.Console.WriteLine("Please enter the amount your would like to deposit into your account: " + retrievedAccount.AccountName);
        double deposit = double.Parse(Console.ReadLine() ?? "0");

        double newAccountBalance = accountBalance + deposit;

        System.Console.WriteLine("The new balance for " + retrievedAccount.AccountName + " is: " + newAccountBalance);
        System.Console.WriteLine();

        return acc;
    }

    public static void LogOut()
    {
        System.Console.WriteLine("Thanks for stopping by!");
    }

    public static void ExitApplication()
    {
        // Need code block to Exit Application
    }

    private static Accounts PromptUserForAccount(PBRepo acc)
    {
        Accounts? retrievedAccount = null;
        while (retrievedAccount == null)
        {
            System.Console.WriteLine("Lets find the your Account!");
            System.Console.WriteLine("Please enter an account id: ");
            int input = int.Parse(Console.ReadLine() ?? "0");
            retrievedAccount = acc.GetAccount(input);
        }
        return retrievedAccount;
    }

    private static int ValidateSelection(int cmd, int maxValue)
    {
        while (cmd < 0 || cmd == maxValue)
        {
            System.Console.WriteLine("Invalid selection, please make a selection of 1-" + maxValue + " or 0 to logout");
            cmd = int.Parse(Console.ReadLine() ?? "0");
        }
        return cmd;
    }
}
