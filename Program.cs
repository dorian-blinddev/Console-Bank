decimal balance = 1000.0m;
bool isRunning = true;

Console.WriteLine("Chào mừng bạn đến với ngân hàng!");

do
{
    Console.WriteLine("""
Danh sách lựa chọn:
1. Xem số dư
2. Nạp tiền
3. Rút tiền
4. Chuyển tiền
0. Thoát
Vui lòng chọn tính năng (0-4)
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
                Console.WriteLine("Cảm ơn bạn đã xử dụng dịch vụ, tạm biệt!");
                isRunning = false;
                break;
        }
    }
    else
    {
        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập một trong các số từ 0 đến 4");
    }
} while (isRunning);

static void CheckBalance(decimal balance)
{
    Console.WriteLine($"Số dư tài hoản hiện tại của bạn là: {balance}");
}

static decimal Deposit(decimal balance)
{
    Console.WriteLine("Nhập số tiền bạn muốn nạp:");

    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
    {
        balance += depositAmount;
        Console.WriteLine($"Nạp tiền thành công!");
        CheckBalance(balance);
    }
    else
    {
        Console.WriteLine("Số tiền nạp không hợp lệ!");
    }

    return balance;
}

static decimal Withdraw(decimal balance)
{
    Console.WriteLine("Nhập số tiền bản muốn rút:");

    if ((decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount) == false) || (withdrawalAmount <= 0))
    {
        Console.WriteLine("Số tiền rút không hợp lệ!");
    }
    else if (withdrawalAmount > balance)
    {
        Console.WriteLine("Tài khoản không đủ tiền để thực hiện giao dịch");
    }
    else
    {
        balance -= withdrawalAmount;
        Console.WriteLine($"Rút tiền thành công!");
        CheckBalance(balance);
    }

    return balance;
}

static decimal Transfer(decimal balance)
{
    int recipientAccountNumber = 0;
    Console.WriteLine("Nhập số tài khoản người nhận:");

    // Ở mức cơ bản, tạm xem mọi recipientAccountNumber đều hợp lệ. Miễn không trống rổng và là số nguyên
    if (int.TryParse(Console.ReadLine(), out recipientAccountNumber) == false)
    {
        Console.WriteLine("Số tài khoản người nhận không hợp lệ!");
        return balance;
    }

    Console.WriteLine($"Nhập số tiền bản muốn chuyển cho: {recipientAccountNumber}");

    if ((decimal.TryParse(Console.ReadLine(), out decimal transferAmount) == false) || (transferAmount <= 0))
    {
        Console.WriteLine("Số tiền chuyển không hợp lệ!");
    }
    else if (transferAmount > balance)
    {
        Console.WriteLine("Tài khoản không đủ tiền để thực hiện giao dịch");
    }
    else
    {
        balance -= transferAmount;
        Console.WriteLine($"Đã chuyển thành công {transferAmount} đến số tài khoản {recipientAccountNumber}!");
        CheckBalance(balance);
    }

    return balance;
}