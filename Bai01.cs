using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1_BT1
{
    internal class Bai01
    {
        static void Main(string[] args)
        {
            // 1) Nhập n và tạo mảng 
            int n = ReadPositiveInt("Nhập n (n > 0): ");
            int[] arr = CreateRandomArray(n, -100, 100);

            int choice;
            do
            {
                // 2) In menu
                Console.WriteLine("\n=======MENU=======");
                Console.WriteLine("1. In mảng");
                Console.WriteLine("2. Tính tổng các số lẻ");
                Console.WriteLine("3. Đếm số nguyên tố");
                Console.WriteLine("4. Tìm số chính phương nhỏ nhất");
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
                        Console.WriteLine("Mảng:");
                        Console.WriteLine(string.Join(" ", arr));
                        break;
                    case 2:
                        Console.WriteLine("Tổng các số lẻ: " + SumOdd(arr, n));
                        break;
                    case 3:
                        Console.WriteLine("Số lượng số nguyên tố: " + CountPrimes(arr, n));
                        break;
                    case 4:
                        Console.WriteLine("Số chính phương nhỏ nhất: " + SmallestPerfectSquare(arr));
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
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > 1000000);
            return n;
        }
        // Tạo mảng ngẫu nhiên
        static int[] CreateRandomArray(int n, int minVal, int maxVal)
        {
            var rnd = new Random();
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = rnd.Next(minVal, maxVal + 1);
            }
            return a;
        }

        // (a) Tổng số lẻ
        static int SumOdd(int[] arr, int n)
        {
            int sum = 0;
            foreach (int x in arr)
            {
                if (x % 2 != 0)
                {
                   sum += x;
                }
            }
                return sum;
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
        // (b) Đếm số nguyên tố 
        static int CountPrimes(int[] arr, int n)
        {
            int count = 0;
            foreach (int x in arr)
            {
                if (IsPrime(x)) count++;
            }
            return count;
        }
        //Kiểm tra số chính phương
        static bool IsPerfectSquare(int x)
        {
            if (x < 0) return false;
            int r = (int)Math.Sqrt(x);
            return r * r == x;
        }
        // (c) Tìm số chính phương nhỏ nhất
        static int SmallestPerfectSquare(int[] arr)
        {
            int? best = null;
            foreach (int x in arr)
            {
                if (IsPerfectSquare(x))
                {
                    if (best == null || x < best.Value)
                    {
                        best = x;
                    }
                }
            }
            return best ?? -1;
        }
    }
}


        /*
        Console.Write("Nhap so phan tu trong mang: ");
        int n = int.Parse(Console.ReadLine()!);

        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Nhap phan tu thu ");
            Console.Write(i);
            Console.Write(": ");
            arr[i] = int.Parse(Console.ReadLine()!);
        }
        Console.Write("Tong cac so le trong mang la: ");
        Console.WriteLine(TongSoLe(arr, n));
        Console.Write("So so nguyen to trong mang la: ");
        Console.WriteLine(DemSoNguyenTo(arr, n));
        Console.Write("So chinh phuong nho nhat la: ");
        Console.WriteLine(SoChinhPhuongNhoNhat(arr, n));
    }
    static int TongSoLe(int[] arr, int n)
    {
        int Tong = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] % 2 != 0)
            {
                Tong += arr[i];
            }
        }
        return Tong;
    }
    static bool IsSoNguyenTo(int n)
    {
        if (n < 2) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;

    }
    static int DemSoNguyenTo(int[] arr, int n)
    {
        int Dem = 0;
        for (int i = 0; i < n; i++) 
        {
            if (IsSoNguyenTo(arr[i]))
            {
                Dem++;
            }
        }
        return Dem;
    }
    static bool IsSoChinhPhuong(int n)
    {
        int r = (int)Math.Sqrt(n);
        if (r*r == n)
        {
            return true;
        }
        return false;
    }
    static int SoChinhPhuongNhoNhat(int[] arr, int n)
    {
        int min = -1;
        for (int i = 0; i < n; i++)
        {
            if (IsSoChinhPhuong(arr[i]))
            {
                if (min == -1 || arr[i] < min)
                {
                    min = arr[i];
                }
            }
        }
        return min;
    }
    */
