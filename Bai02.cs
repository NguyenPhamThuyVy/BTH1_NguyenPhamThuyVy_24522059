using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1_BT2
{
    internal class Bai02
    {
        static void Main(string[] args)
        {
            // 1) Nhập n
            int n = ReadPositiveInt("Nhập n (n > 0): ");
            int choice;
            do
            {
                // 2) In menu
                Console.WriteLine("\n=======MENU=======");
                Console.WriteLine("1. Tính tổng các số nguyên tố nhỏ hơn n");
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
                        Console.WriteLine("Tổng các số nguyên tố nhỏ hơn n: " + SumPrimesLessThanN(n));
                        break;
                    case 0:
                        Console.WriteLine("Kết thúc chương trình.");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ!");
                        break;
                }

            } while (choice != 0);
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

            // Kiểm tra số nguyên tố
            static bool IsPrime(int n)
            {
                if (n < 2) return false;
                for (int i = 2; i <= (int)Math.Sqrt(n); i++)
                {
                    if (n % i == 0) return false;
                }
                return true;
            }

            // Tính tổng các số nguyên tố < n
            static long SumPrimesLessThanN(int n)
            {
                bool[] isPrime = new bool[n];
                for (int i = 2; i < n; i++) isPrime[i] = true;

                for (int i = 2; i * i < n; i++)
                {
                    if (isPrime[i])
                    {
                        for (int j = i * i; j < n; j += i)
                            isPrime[j] = false;
                    }
                }

                long sum = 0;
                for (int i = 2; i < n; i++)
                    if (isPrime[i]) sum += i;

                return sum;
            }
        }
    }
}
