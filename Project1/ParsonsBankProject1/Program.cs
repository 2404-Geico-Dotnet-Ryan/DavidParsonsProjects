using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using Microsoft.Win32.SafeHandles;

namespace ParsonsBankProject1;

class Program
{
    static AccountServices aS = new();
    static UserService uS = new();
    static User? currentUser = null;

    static void Main(string[] args)
    {

        System.Console.WriteLine();
        System.Console.WriteLine("||||||||||||||||||||||||||||||||||||");
        System.Console.WriteLine("|     Welcome to Parsons Bank!     |");
        System.Console.WriteLine("||||||||||||||||||||||||||||||||||||");
        System.Console.WriteLine();

        Thread.Sleep(1000);

        MainLoginMenu(uS);

        Thread.Sleep(1000);

        MainMenu();
    }

    private static void MainLoginMenu(UserService uS)
    {
        while (true)
        {
            System.Console.WriteLine("Please select which option applies below: ");
            System.Console.WriteLine("=================================");
            System.Console.WriteLine("[1] New Customer: Create new account");
            System.Console.WriteLine("[2] Existing Customer: Login");
            System.Console.WriteLine("[0] Exit");
            System.Console.WriteLine("=================================");

            int input = int.Parse(Console.ReadLine() ?? "0");
            //Same Validation method copied over
            input = ValidateSelection(input, 3);

            switch (input)
        {
            case 1:
                {
                    CreateAnAccount();
                    return;
                }
            case 2:
                {
                    LoginToAccount(uS);
                    return;
                }
            case 0:
                {
                    System.Console.WriteLine("Thanks for stopping by!");
                    return;
                }
            default:
                {
                    //If option 0 or anything else -> set keepGoing to false.
                    System.Console.WriteLine("Invalid selection, please try again");
                    break;
                }
        }

            //Extracted to method - uses switch case to determine what to do next.
            // keepGoing = DecideNextOptionOne(uS, input);
        }
    }

    // private static bool DecideNextOptionOne(UserService uS, int input)
    // {
    //     switch (input)
    //     {
    //         case 1:
    //             {
    //                 CreateAnAccount();
                    
    //                 return false;
    //             }
    //         case 2:
    //             {
    //                 LoginToAccount(uS);
    //                 return false;
    //             }
    //         case 0:
    //         default:
    //             {
    //                 //If option 0 or anything else -> set keepGoing to false.
    //                 return false;
    //             }
    //     }

    // }

    private static void MainMenu()
    {
        //Something that happens after login or account is created - go to Main Menu
        // bool keepGoing = true;
        while (true)
        {
            System.Console.WriteLine("Please select which option applies below: ");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("[1] View Account Balance");
            System.Console.WriteLine("[2] Make a Deposit");
            System.Console.WriteLine("[3] Make a Withdrawal");
            System.Console.WriteLine("[4] Delete Account");
            System.Console.WriteLine("[0] Exit");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            int input = int.Parse(Console.ReadLine() ?? "0");
            //Same Validation method copied over
            input = ValidateSelection(input, 5);

            switch (input)
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
                    DeletingAccount();
                    break;
                case 0:
                    System.Console.WriteLine("Logged out, thanks for stopping by!");
                    return;
                default:
                    System.Console.WriteLine("Invalid choice, please try again");
                    break;
            }

            //Extracted to method - uses switch case to determine what to do next.
            // keepGoing = DecideNextOptionTwo(input);
        }
    }

    // private static bool DecideNextOptionTwo(int input)
    // {
    //     switch (input)
    //     {
    //         case 1:
    //             ViewAccountBalance();
    //             break;
    //         case 2:
    //             DepositMoney();
    //             break;
    //         case 3:
    //             WithdrawalMoney();
    //             break;
    //         case 4:
    //             DeletingAccount();
    //             break;
    //         case 0:
    //             LogOut();
    //             return false;
    //     }

    //     return true;
    // }

    private static void LoginToAccount(UserService uS)
    {
        // Need to create code block for a customer to log into the Bank Account
        System.Console.WriteLine("Please log into your account");
        System.Console.WriteLine("Username:");
        string username = Console.ReadLine() ?? "";
        System.Console.WriteLine("Password:");
        string password = Console.ReadLine() ?? "";

        uS.Login(username, password);

        System.Console.WriteLine("Login Successful");;
    }

    private static void CreateAnAccount()
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

        User user = new(0, userName, password, firstName, lastName, "user");
        Account account = new(0, accountName, balance, accountType);

        // Now that the info is collected into a Movie object, lets use the Movie Repo to add into our collection.
        // Reusing the movie variable to store the updated values if any from the add movie process

        // For the sake of clarity to the user of the app lets inform them of the newly added movie.

        System.Console.WriteLine("Newly Added Account: " + account);
    }

    private static void ViewAccountBalance()
    {
        // Need to create code block to view existing $$ amount in account
        Account? retrievedAccount = PromptUserForAccount();
        double accountBalance = retrievedAccount.Balance;

        System.Console.WriteLine("Account Balance: " + accountBalance);
        System.Console.WriteLine();
    }

    private static void DepositMoney()
    {
        // Need to create code block to add a $$ amount to existing balance
        Account? account = PromptUserForAccount();
        if (account == null) return;

        System.Console.WriteLine("Please enter the amount your would like to deposit into your account: " + account.AccountName);
        double deposit = double.Parse(Console.ReadLine() ?? "0");
        
        double accountBalance = aS.MakeDeposit(account, deposit);

        // double newAccountBalance = accountBalance + deposit; // Initally had this before the line above.

        System.Console.WriteLine("The new balance for " + account.AccountName + " is: " + accountBalance);
        System.Console.WriteLine();
    }

    private static void WithdrawalMoney()
    {
        // Need to create code block to remove $$ from existing balance
        Account? account = PromptUserForAccount();
        if (account == null) return;

        System.Console.WriteLine("Please enter the amount your would like to withdrawal from your account: " + account.AccountName);
        double withdrawal = double.Parse(Console.ReadLine() ?? "0");

        double accountBalance = aS.MakeWithdrawal(account, withdrawal);

        System.Console.WriteLine("The new balance for " + account.AccountName + " is: " + accountBalance);
        System.Console.WriteLine();
    }

    private static void DeletingAccount()
    {
        Account? account = PromptUserForAccount();

        account = aS.DeleteAccount(account);

        System.Console.WriteLine("Deleted Account: " + account);
    }

    private static Account? PromptUserForAccount()
    {
        Account? retrievedAccount = null;
        while (retrievedAccount == null)
        {
            System.Console.WriteLine("Lets find the your Account!");
            System.Console.WriteLine("Please enter an account id: ");
            int id = int.Parse(Console.ReadLine() ?? "0");
            if (id == 0) return null;
            retrievedAccount = aS.RetrieveAccount(id);
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
