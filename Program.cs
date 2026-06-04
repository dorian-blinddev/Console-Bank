using System.Text.RegularExpressions;

string accountName = "";
string accountNumber = "";
string password = "";
decimal balance = 1000.0m;
bool isRunning = true;

List<string> history = new();

OpenAccount();

Console.WriteLine("Welcome to the E-Banking System!");

do
{
    Console.WriteLine("""
Please select an option:
1. Deposit Money
2. Withdraw Money
3. Transfer Money
4. View account information
5. View transaction history
0. Exit
Enter your choice (0-5):
""");

    if (int.TryParse(Console.ReadLine(), out int choice) && (choice >= 0 && choice <= 5))
    {
        switch (choice)
        {
            case 1:
                balance = Deposit(balance, history);
                break;
            case 2:
                balance = Withdraw(balance, history);
                break;
            case 3:
                balance = Transfer(balance, history);
                break;
            case 4:
                ViewInformation(accountName, accountNumber, balance);
                break;
            case 5:
                ViewHistory(history);
                break;
            case 0:
                Console.WriteLine("Thank you for using our services. Goodbye!");
                isRunning = false;
                break;
        }
    }
    else
    {
        Console.WriteLine("Invalid choice. Please enter a number between 0 and 5.");
    }

    Console.WriteLine();

} while (isRunning);

static void CheckBalance(decimal balance)
{
    Console.WriteLine($"Your current balance is: ${balance}");
}

static decimal Deposit(decimal balance, List<string> history)
{
    Console.WriteLine("Enter the amount you want to deposit:");

    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
    {
        balance += depositAmount;
        history.Add($"Nạp tiền: ${depositAmount}");
        Console.WriteLine("Deposit successful!");
        CheckBalance(balance);
    }
    else
    {
        Console.WriteLine("Invalid deposit amount!");
    }

    return balance;
}

static decimal Withdraw(decimal balance, List<string> history)
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
        history.Add($"Rút tiền: ${withdrawalAmount}");
        Console.WriteLine("Withdrawal successful!");
        CheckBalance(balance);
    }

    return balance;
}

static decimal Transfer(decimal balance, List<string> history)
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
        history.Add($"Chuyển tiền: ${transferAmount} đến tài khoản {recipientAccountNumber}");
        Console.WriteLine($"Successfully transferred ${transferAmount} to account {recipientAccountNumber}!");
        CheckBalance(balance);
    }

    return balance;
}

static void ViewInformation(string accountName, string accountNumber, decimal balance)
{
    Console.WriteLine("=== THÔNG TIN TÀI KHOẢN ===");
    Console.WriteLine($"Chủ tài khoản: {accountName}");
    Console.WriteLine($"Số tài khoản: {accountNumber}");
    Console.WriteLine($"Số dư hiện tại: ${balance}");
}

static void ViewHistory(List<string> history)
{
    Console.WriteLine("=== LỊCH SỬ GIAO DỊCH ===");

    if (history.Count == 0)
    {
        Console.WriteLine("Chưa có giao dịch nào được thực hiện.");
    }
    else
    {
        foreach (string transaction in history)
        {
            Console.WriteLine(transaction);
        }
    }
}

void OpenAccount()
{
    Console.WriteLine("=== ĐĂNG KÝ TÀI KHOẢN NGÂN HÀNG ===");

    do
    {
        Console.WriteLine("Nhập tên của bạn (chỉ nhập chữ):");
        accountName = Console.ReadLine() ?? "";
        Regex.IsMatch(accountName, @"\d");
    } while (string.IsNullOrEmpty(accountName) || Regex.IsMatch(accountName, @"\d"));

    do
    {
        int number = 0;

        Console.WriteLine("Nhập số tài khoản mong muốn (chỉ nhập số):");

        if (int.TryParse(Console.ReadLine(), out number) && number > 0)
        {
            accountNumber = number.ToString();
            break;
        }
        else
        {
            continue;
        }
    } while (string.IsNullOrEmpty(accountNumber));

    do
    {
        Console.WriteLine("Nhập mật khẩu tài khoản:");
        password = Console.ReadLine() ?? "";
    } while (string.IsNullOrEmpty(password));

    Console.WriteLine("Chúc mừng, mở tài khoản thành công!");
    Console.WriteLine("-------------------------------------");
}
