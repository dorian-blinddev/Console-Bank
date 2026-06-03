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
