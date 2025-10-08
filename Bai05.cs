using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1_BT5
{
    internal class Bai05
    {
        static void Main(string[] args)
        {
            // 1) Nhập ngày tháng năm
            int ngay = ReadPositiveInt("Nhập ngày: ");
            int thang = ReadPositiveInt("Nhập tháng: ");
            int nam = ReadPositiveInt("Nhập năm: ");
            int choice;
            do
            {
                // 2) In menu
                Console.WriteLine("\n=======MENU=======");
                Console.WriteLine("1. Thứ trong tuần theo ngày tháng năm vừa nhập");
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
                        if (!IsValidDate(ngay, thang, nam))
                        {
                            Console.WriteLine("Ngày tháng năm không hợp lệ! Vui lòng nhập lại.");
                        }
                        else
                        {
                            Console.WriteLine("Thứ trong tuần: " + DayOfWeek(ngay, thang, nam));
                        }
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
        // Kiểm tra tính hợp lệ của ngày tháng năm
        static bool IsValidDate(int d, int m, int y)
        {
            if (y < 1 || m < 1 || m > 12 || d < 1)
                return false;
            int[] DaysinMonth = { 31, (IsLeapYear(y) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (d > DaysinMonth[m - 1])
                return false;
            return true;
        }
        // Kiểm tra năm nhuận
        static bool IsLeapYear(int y)
        {
            return (y % 4 == 0 && y % 100 != 0) || (y % 400 == 0);
        }
        // Hàm trả về thứ của ngày tháng năm vừa nhập
        static string DayOfWeek(int d, int m, int y)
        {
            if (m < 3)
            {
                m += 12;
                y--;
            }
            int k = y % 100;
            int j = y / 100;
            int h = (d + (13 * (m + 1)) / 5 + k + k / 4 + j / 4 + 5 * j) % 7;

            switch (h)
            {
                case 0: return "Thứ Bảy";
                case 1: return "Chủ Nhật";
                case 2: return "Thứ Hai";
                case 3: return "Thứ Ba";
                case 4: return "Thứ Tư";
                case 5: return "Thứ Năm";
                case 6: return "Thứ Sáu";
                default: return "Không xác định";
            }
        }
    } 
}
