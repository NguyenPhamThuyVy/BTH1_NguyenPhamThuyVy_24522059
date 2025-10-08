using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1_BT6
{
    internal class Bai06
    {
        static void Main(string[] args)
        {
            // 1) Nhập n, m và tạo ma trận
            int n = ReadPositiveInt("Nhập số dòng (n > 0): ");
            int m = ReadPositiveInt("Nhập số cột (m > 0): ");
            int[,] Matrix = CreateRandomMatrix(n, m, -100, 100);
            int choice;
            do
            {
                // 2) In menu
                Console.WriteLine("\n=======MENU=======");
                Console.WriteLine("1. Xuất ma trận");
                Console.WriteLine("2. Tìm phần tử lớn nhất");
                Console.WriteLine("3. Tìm phần tử nhỏ nhất");
                Console.WriteLine("4. Tìm dòng có tổng lớn nhất");
                Console.WriteLine("5. Tính tổng các số không phải số nguyên tố");
                Console.WriteLine("6. Xóa dòng thứ k trong ma trận");
                Console.WriteLine("7. Xóa cột chứa phần tử lớn nhất");
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
                        Console.WriteLine("Ma trận: ");
                        PrintMatrix(Matrix);
                        break;
                    case 2:
                        Console.WriteLine("Phần tử lớn nhất: " + FindMax(Matrix));
                        break;
                    case 3:
                        Console.WriteLine("Phần tử nhỏ nhất: " + FindMin(Matrix));
                        break;
                    case 4:
                        Console.WriteLine("Dòng có tổng lớn nhất: " + MaxRowSum(Matrix));
                        break;
                    case 5:
                        Console.WriteLine("Tổng các số không phải số nguyên tố: " + SumNonPrimes(Matrix));
                        break;
                    case 6:
                        int k = ReadPositiveInt("Nhập dòng k cần xóa (k > 0): ");
                        if (k > Matrix.GetLength(0))
                        {
                            Console.WriteLine("Dòng k vượt quá số dòng của ma trận!");
                            break;
                        }
                        int[,] tempMat = DeleteKthRow(Matrix, k - 1);
                        if (tempMat.Length == 0)
                        {
                            Console.WriteLine("Ma trận rỗng. Không thể xóa dòng!");
                        }
                        else
                        {
                            Console.WriteLine("Ma trận sau khi xóa dòng thứ k: ");
                            PrintMatrix(tempMat);
                        }
                        break;
                    case 7:
                        int[,] resultMat = DeleteColumn(Matrix);
                        if (resultMat.Length == 0)
                        {
                            Console.WriteLine("Ma trận rỗng. Không thể xóa cột!");
                        }
                        else
                        {
                            Console.WriteLine("Ma trận sau khi xóa cột chứa phần tử lớn nhất: ");
                            PrintMatrix(resultMat);
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
            } while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > 1000000);
            return n;
        }
        // Tạo ma trận ngẫu nhiên
        static int[,] CreateRandomMatrix(int n, int m, int minVal, int maxVal)
        {
            var rnd = new Random();
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = rnd.Next(minVal, maxVal + 1);
                }
            }
            return a;
        }
        // (a) Xuất ma trận
        static void PrintMatrix(int[,] a)
        {
            if (a.Length == 0)
            {
                Console.WriteLine("Ma trận rỗng");
                return;
            }
            int n = a.GetLength(0), m = a.GetLength(1);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{a[i, j],5}");
                }
                Console.WriteLine();
            }
        }
        // (b) Tìm phần tử lớn nhất/nhỏ nhất
        static int FindMax(int[,] a)
        {
            int max = a[0, 0];
            foreach (int x in a)
            {
                if (x > max)
                {
                    max = x;
                }
            }
            return max;
        }
        static int FindMin(int[,] a)
        {
            int min = a[0, 0];
            foreach (int x in a)
            {
                if (x < min)
                {
                    min = x;
                }
            }
            return min;
        }
        // (c) Tìm dòng có tổng lớn nhất
        static int MaxRowSum(int[,] a)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            int bestRow = 0;
            int bestSum = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += a[i, j];
                }
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = i;
                }
            }
            return bestRow + 1;
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
        // (d) Tính tổng các số không phải số nguyên tố
        static int SumNonPrimes(int[,] a)
        {
            int sum = 0;
            foreach (int x in a)
            {
                if (!IsPrime(x))
                {
                    sum += x;
                }
            }
            return sum;
        }
        // (e) Xóa dòng thứ k trong ma trận
        static int[,] DeleteKthRow(int[,] a, int k)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            if (k < 0 || k >= n || n <= 1) return new int[0, 0];
            int[,] b = new int[n - 1, m];
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == k) continue;
                for (int j = 0; j < m; j++)
                {
                    b[r, j] = a[i, j];
                }
                r++;
            }
            return b;
        }
        // (f) Xóa cột chứa phần tử lớn nhất trong ma trận
        static int[,] DeleteColumn(int[,] a)
        {
            int n = a.GetLength(0), m = a.GetLength(1);
            if (n == 0 || m == 0) return a;
            if (m <= 1) return new int[0, 0];
            int max = FindMax(a);
            int column = -1;
            for (int i = 0; i < n && column == -1; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i, j] == max)
                    {
                        column = j;
                        break;
                    }
                }
            }
            if (column == -1) return a;
            int[,] b = new int[n, m - 1];
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int j = 0; j < m; j++)
                {
                    if (j == column) continue;
                    b[i, c++] = a[i, j];
                }
            }
            return b;
        }
    }
}
