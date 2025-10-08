using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1_BT4
{
    internal class Bai04
    {
        static void Main(string[] args)
        {
            /// 1) Nhập tháng năm
            int thang = ReadPositiveInt("Nhập tháng: ");
            int nam = ReadPositiveInt("Nhập năm: ");
            int choice;
            do
            {
                // 2) In menu
                Console.WriteLine("\n=======MENU=======");
                Console.WriteLine("1. Số ngày trong tháng và năm vừa nhập");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");

                // 3) Đọc lựa chọn
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lựa chọn không hợp lệ!");
                    choice = -1;
                    continue;
                }
                // 4) Xử lý bằng switch
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Số ngày trong tháng, năm đã nhập: " + DaysinMonth(thang, nam));
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

            } while (choice != 0);
        }
        // Đọc số nguyên dương
        static int ReadPositiveInt(string message)
        {
            int n;
            do
            {
                Console.Write(message);
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);
            return n;
        }
        // Kiểm tra năm nhuận
        static bool IsLeapYear(int y)
        {
            return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
        }
        // Hàm trả về ngày của tháng và năm vừa nhập
        static int DaysinMonth(int m, int y)
        {
            if (m < 1 || m > 12 || y < 1) return 0;
            int[] days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};
            if (m == 2 && IsLeapYear(y))
            {
                return 29;
            }
            return days[m - 1];
        }
    }
}
