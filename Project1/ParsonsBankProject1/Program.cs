using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Net.Mail;
using Microsoft.Win32.SafeHandles;

namespace ParsonsBankProject1;

class Program
{
    static AccountServices accountServices;
    static UserService userService;
    static User? currentUser = null;
    private static int retrievedAccounts;

    static void Main(string[] args)
    {
        string path = @"C:\Users\U30A97\RevatureBootcamp\DavidParsonsProjects\Project1\ParsonsBankProject1\ParsonsBankingApp-DB.txt"; // Can also add and @ in front of the string "" to allow the single backslash.
        string connectionString = File.ReadAllText(path);

        // System.Console.WriteLine(connectionString); // Remove later

        UserRepo ur = new(connectionString);
        userService = new(ur);

        AccountRepo ar = new(connectionString);
        accountServices = new(ar);

        System.Console.WriteLine();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine();
        System.Console.WriteLine();
        System.Console.WriteLine("    /|||||||||||||||||||||||||||||||||||||||||||\\");
        System.Console.WriteLine("    ||||||||||||||||||||||||||||||||||||||||||||||");
        System.Console.WriteLine("    ||||||/                                \\||||||");
        System.Console.WriteLine("    ||||||     WELCOME TO PARSONS BANK!     ||||||");
        System.Console.WriteLine("    ||||||\\                                /||||||");
        System.Console.WriteLine("    ||||||||||||||||||||||||||||||||||||||||||||||");
        System.Console.WriteLine("    ||||||||||||||||||||||||||||||||||||||||||||/");
        System.Console.WriteLine("    ||||||");
        System.Console.WriteLine("    ||||||");
        System.Console.WriteLine("    ||||||");
        System.Console.WriteLine("    ||||||");
        System.Console.WriteLine("    ||||||");
        System.Console.WriteLine("    ||||||");
        System.Console.WriteLine("    ||||||");
        System.Console.WriteLine("    ||||||");
        System.Console.WriteLine();

        Thread.Sleep(1000);

        MainLoginMenu();

        Thread.Sleep(1000);

        // MainMenu();
    }

    private static void MainLoginMenu()
    {
        bool again = true;
        while (again)
        {
            Console.ForegroundColor = ConsoleColor.White;
            System.Console.WriteLine("Please select which option applies below: ");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            System.Console.WriteLine("[1] New Customer: Create new account");
            System.Console.WriteLine("[2] Existing Customer: Login");
            System.Console.WriteLine("[0] Exit");
            System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            int input = int.Parse(Console.ReadLine() ?? "0");
            //Same Validation method copied over
            input = ValidateSelection(input, 3);

            again = DecideLoginOption(input);
        }
    }

    private static bool DecideLoginOption(int input)
    {
        switch (input)
        {
            case 1:
                CreateAnAccount(); break;
            case 2:
                LoginToAccount(); break;
            case 0:
                {
                    System.Console.WriteLine("Thanks for stopping by!");
                    Environment.Exit(0);
                    return false;
                }
            default:
                {
                    //If option 0 or anything else -> set keepGoing to false.
                    System.Console.WriteLine("Invalid selection, please try again");
                    break;
                }
        
        }
        return true;
    }

    private static void MainMenu()
    {
        //Something that happens after login or account is created - go to Main Menu
        bool again = true;
        while (again)
        {
            Console.ForegroundColor = ConsoleColor.White;
            if(currentUser.Role == "user")
            {
                System.Console.WriteLine();
                System.Console.WriteLine("*** Welcome, " + currentUser.FirstName + "! ***");
                System.Console.WriteLine();
                System.Console.WriteLine("Please select which option applies below: ");
                System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                System.Console.WriteLine("[1] Open Account");
                System.Console.WriteLine("[2] View My Accounts");
                System.Console.WriteLine("[3] Make a Deposit");
                System.Console.WriteLine("[4] Make a Withdrawal");
                System.Console.WriteLine("[5] Delete Account");
                System.Console.WriteLine("[6] Logout");
                System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                int input = int.Parse(Console.ReadLine() ?? "0");
                //Same Validation method copied over
                input = ValidateSelection(input, 7);
                again = MainMenuOption(input);
            }
            else
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Welcome, " + currentUser.FirstName);
                System.Console.WriteLine();
                System.Console.WriteLine("Please select which option applies below: ");
                System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                System.Console.WriteLine("[1] Open Account");
                System.Console.WriteLine("[2] View Account Balance");
                System.Console.WriteLine("[3] Delete Account");
                System.Console.WriteLine("[4] Logout");
                System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                int input = int.Parse(Console.ReadLine() ?? "0");
                //Same Validation method copied over
                input = ValidateSelection(input, 5);
                again = MainMenuOption(input);
            }
            Thread.Sleep(1000);
        }
    }

    private static bool MainMenuOption(int input)
    {
        if (currentUser.Role == "user")
        {
            switch (input)
            {
                case 1:
                    OpenAccount(); break;
                case 2:
                    ViewMyAccounts(); break;
                case 3:
                    DepositMoney(); break;
                case 4:
                    WithdrawalMoney(); break;
                case 5:
                    DeletingAccount(); break;
                case 6:
                    LogOut();
                    System.Console.WriteLine("Logged out, thanks for stopping by!");
                    return false;
                default:
                    System.Console.WriteLine("Invalid choice, please try again");
                    break;
            }
            return true;
        }
        else
        {
            switch (input)
            {
                case 1:
                    OpenAccount(); break;
                case 2:
                    ViewAccountBalance(); break;
                case 3:
                    DeletingAccount(); break;
                case 4:
                    LogOut();
                    System.Console.WriteLine("Logged out, thanks for stopping by!");
                    return false;
                default:
                    System.Console.WriteLine("Invalid choice, please try again");
                    break;
            }
            return true;
        }
    }

    private static void LoginToAccount()
    {
        while (currentUser == null)
        {
            System.Console.WriteLine("Please log into your account");
            System.Console.WriteLine("Username:");
            string username = Console.ReadLine() ?? "";
            System.Console.WriteLine();
            System.Console.WriteLine("Password:");
            string password = Console.ReadLine() ?? "";
            System.Console.WriteLine();

            currentUser = userService.Login(username, password);

            if (currentUser == null)
            {
                System.Console.WriteLine("Login Failed");
            }
            else
            {
                System.Console.WriteLine("Login Successful");
            }

        }
        Thread.Sleep(1000);
        MainMenu();
    }

    private static void CreateAnAccount()
    {
        // Need to create code block for a customer to create an account
        System.Console.WriteLine("Let's create a new account!");
        System.Console.WriteLine("Please provide your First Name");
        string firstName = Console.ReadLine() ?? "";
        System.Console.WriteLine();
        System.Console.WriteLine("Please provide your Last Name");
        string lastName = Console.ReadLine() ?? "";
        System.Console.WriteLine();
        System.Console.WriteLine("What would you like your username to be?");
        string userName = Console.ReadLine() ?? "";
        System.Console.WriteLine();
        System.Console.WriteLine("Please provide a password");
        string password = Console.ReadLine() ?? "";
        System.Console.WriteLine();

        User? user = new(0, userName, password, firstName, lastName, "user");

        user = userService.CreateUserAccount(user);

        if (user != null)
        {
            System.Console.WriteLine("Newly Added User: " + user);
        }
        else
        {
            System.Console.WriteLine("Failed to Register user, please try again");
        } 
    }

    private static void OpenAccount()
    {
        System.Console.WriteLine("Let's create a new account!");
        System.Console.WriteLine("What type of account would you like to open? (Checking/Savings)");
        string accountType = Console.ReadLine() ?? "";
        System.Console.WriteLine();
        System.Console.WriteLine("What would you like the name of your account to be?");
        string accountName = Console.ReadLine() ?? "";
        System.Console.WriteLine();
        System.Console.WriteLine("Please enter the $ amount you would like to add to your new account!");
        double balance = double.Parse(Console.ReadLine() ?? "0");
        System.Console.WriteLine();
        int userId = currentUser.UserId;

        Account? account = new(0, accountName, balance, accountType, userId);

        account = accountServices.NewAccount(account);
        
        if (account != null)
        {
            System.Console.WriteLine("Newly Added Account: " + account);    
        }
        else
        {
            System.Console.WriteLine("Failed to create account, please try again");
        }
    }

    private static void ViewAccountBalance()
    {
        // Need to create code block to view existing $$ amount in account
        Account? retrievedAccount = PromptUserForAccount();
        double accountBalance = retrievedAccount.Balance;

        System.Console.WriteLine("Account Balance: " + accountBalance);
        System.Console.WriteLine();
    }

    private static void ViewMyAccounts()
    {
        List<Account> accounts = accountServices.RetrieveAllAccounts(currentUser);
        System.Console.WriteLine();
        System.Console.WriteLine("~~~~~~~~~ Here is a summary of your accounts ~~~~~~~~~");
        foreach (Account a in accounts)
        {
            System.Console.WriteLine("Account: " + a.AccountName + " has a balance of: " + a.Balance + ".");
        }
        System.Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        System.Console.WriteLine();
        Thread.Sleep(1000);
    }
    private static void DepositMoney()
    {
        // Need to create code block to add a $$ amount to existing balance
        Account? account = PromptUserForAccount();
        if (account == null) return;

        System.Console.WriteLine("Please enter the amount you would like to deposit into your account: " + account.AccountName);
        double deposit = double.Parse(Console.ReadLine() ?? "0");
        
        accountServices.MakeDeposit(account, deposit);

        // double newAccountBalance = accountBalance + deposit; // Initally had this before the line above.

        System.Console.WriteLine("The new balance for " + account.AccountName + " is: " + account.Balance);
        System.Console.WriteLine();
        Thread.Sleep(1000);
    }

    private static void WithdrawalMoney()
    {
        // Need to create code block to remove $$ from existing balance
        Account? account = PromptUserForAccount();
        if (account == null) return;

        System.Console.WriteLine("Please enter the amount you would like to withdrawal from your account: " + account.AccountName);
        double withdrawal = double.Parse(Console.ReadLine() ?? "0");

        accountServices.MakeWithdrawal(account, withdrawal);

        System.Console.WriteLine("The new balance for " + account.AccountName + " is: " + account.Balance);
        System.Console.WriteLine();
        Thread.Sleep(1000);
    }

    private static void DeletingAccount()
    {
        System.Console.WriteLine();
        System.Console.WriteLine("You have selected to Delete an account");
        Account? account = PromptUserForAccount();

        account = accountServices.DeleteAccount(account);

        System.Console.WriteLine("Deleted Account: " + account);
        Thread.Sleep(1000);
    }

    private static void LogOut()
    {
        currentUser = null;
    }

    private static Account? PromptUserForAccount()
    {
        Account? retrievedAccount = null;
        while (retrievedAccount == null)
        {
            System.Console.WriteLine("Lets find the your Account!");
            System.Console.WriteLine("Please enter an account id (press 0 to exit)");
            int id = int.Parse(Console.ReadLine() ?? "0");
            if (id == 0) return null;
            retrievedAccount = accountServices.RetrieveAccount(id);
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
