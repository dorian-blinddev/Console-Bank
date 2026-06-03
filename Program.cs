decimal balance = 1000.0m;
bool isRunning = true;

Console.WriteLine("Welcome to the E-Banking System!");

do
{
    Console.WriteLine("""
Please select an option:
1. Check Balance
2. Deposit Money
3. Withdraw Money
4. Transfer Money
0. Exit
Enter your choice (0-4):
""");

    if (int.TryParse(Console.ReadLine(), out int choice) && (choice >= 0 && choice <= 4))
    {
        switch (choice)
        {
            case 1:
                CheckBalance(balance);
                break;
            case 2:
                balance = Deposit(balance);
                break;
            case 3:
                balance = Withdraw(balance);
                break;
            case 4:
                balance = Transfer(balance);
                break;
            case 0:
                Console.WriteLine("Thank you for using our services. Goodbye!");
                isRunning = false;
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid choice. Please enter a number between 0 and 4.");
    }
    
    // Thêm một dòng trống để giao diện Console dễ nhìn hơn sau mỗi lượt giao dịch
    Console.WriteLine(); 

} while (isRunning);

static void CheckBalance(decimal balance)
{
    Console.WriteLine($"Your current balance is: ${balance}");
}

static decimal Deposit(decimal balance)
{
    Console.WriteLine("Enter the amount you want to deposit:");

    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
    {
        balance += depositAmount;
        Console.WriteLine("Deposit successful!");
        CheckBalance(balance);
    }
    else
    {
        Console.WriteLine("Invalid deposit amount!");
    }

    return balance;
}

static decimal Withdraw(decimal balance)
{
    Console.WriteLine("Enter the amount you want to withdraw:");

    if ((decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount) == false) || (withdrawalAmount <= 0))
    {
        Console.WriteLine("Invalid withdrawal amount!");
    }
    else if (withdrawalAmount > balance)
    {
        Console.WriteLine("Insufficient funds! Your balance is not enough for this transaction.");
    }
    else
    {
        balance -= withdrawalAmount;
        Console.WriteLine("Withdrawal successful!");
        CheckBalance(balance);
    }

    return balance;
}

static decimal Transfer(decimal balance)
{
    int recipientAccountNumber = 0;
    Console.WriteLine("Enter the recipient's account number:");

    if (int.TryParse(Console.ReadLine(), out recipientAccountNumber) == false)
    {
        Console.WriteLine("Invalid account number!");
        return balance;
    }

    Console.WriteLine($"Enter the amount you want to transfer to account {recipientAccountNumber}:");

    if ((decimal.TryParse(Console.ReadLine(), out decimal transferAmount) == false) || (transferAmount <= 0))
    {
        Console.WriteLine("Invalid transfer amount!");
    }
    else if (transferAmount > balance)
    {
        Console.WriteLine("Insufficient funds! Your balance is not enough for this transaction.");
    }
    else
    {
        balance -= transferAmount;
        Console.WriteLine($"Successfully transferred ${transferAmount} to account {recipientAccountNumber}!");
        CheckBalance(balance);
    }

    return balance;
}