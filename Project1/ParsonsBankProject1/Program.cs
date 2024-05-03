namespace ParsonsBankProject1;

class Program
{
    static void Main(string[] args)
    {
        String[] menuOptions = ["View Account Balance", "Make a Deposit", "Make a Withdrawal", "Log Out"];

        System.Console.WriteLine("||||||||||||||||||||||||||||||||||||");
        System.Console.WriteLine("|     Welcome to Parsons Bank!     |");
        System.Console.WriteLine("||||||||||||||||||||||||||||||||||||");
        System.Console.WriteLine();
        Thread.Sleep(2000);
        System.Console.WriteLine("Do you currently have an account with us? Y/N");
        var input = Console.ReadLine();
        if (input.ToLower() == "y")
        {
            //Send to the login page
            bool loginSuccessful = false;
            LogInToAccount();

            if(loginSuccessful)
            {
                MainMenu(menuOptions);
            }
            else
            {
                ExitApplication();
            }
        }
        else
        {
            //time to create an account - keep it simple - 
            CreateAnAccount();

            MainMenu(menuOptions);
        }
    }

    private static void MainMenu(string[] menuOptions)
    {
        //Something that happens after login or account is created - go to Main Menu
        System.Console.WriteLine();
        System.Console.WriteLine("Please select which action you would like to take: ");
        Thread.Sleep(2000);
        for (int i = 0; i < menuOptions.Count(); i++)
        {
            System.Console.WriteLine($"{i + 1} {menuOptions[i]}");
        }

        var selections = Convert.ToInt32(Console.ReadLine());

        switch (selections)
        {
            case 1:
                ViewAccountBalance();
                break;
            case 2:
                DepositMoney();
                break;
            case 3:
                WithdrawalMoney();
                break;
            case 4:
                LogOut();
                break;
        }

        // do I need more here - next steps?
    }

    public static void LogInToAccount()
    {
        // Need to create code block for a customer to log into the Bank Account
        System.Console.WriteLine("Please enter your User Name below: ");
        string input = Console.ReadLine();
        

    }

    public static void CreateAnAccount()
    {
        // Need to create code block for a customer to create an account
    }

    public static void ViewAccountBalance()
    {
        // Need to create code block to view existing $$ amount in account
        System.Console.WriteLine();
    }

    public static void DepositMoney()
    {
        // Need to create code block to add a $$ amount to existing balance
    }

    public static void WithdrawalMoney()
    {
        // Need to create code block to remove $$ from existing balance
    }

    public static void LogOut()
    {
        // Need to create code block to log out of account.
    }

    public static void ExitApplication()
    {
        // Need code block to Exit Application
    }
}
