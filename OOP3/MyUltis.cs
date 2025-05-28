using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3_ExtensionMethod
{
    public static class MyUltis
    {
        //Câu 1: Cài một hàm TongTu1toiN vào kiểu int của Microsoft
        public static int TongTu1toiN(this int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += i;
            }
            return sum;
        }
        public static int Cong(this int a, int b)
        {
            return a + b;
        }
        
        public static void SapXepTangDan(this int[] a)
        {
            for(int i=0;i<a.Length; i++)
            {
                for(int j = i; j < a.Length; j++)
                {
                    if(a[i] > a[j])
                    {
                        int temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }
        public static void TaoMang(this int[] a) { 
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = random.Next(100);
            }
        }
        public static void XuatMang(this int[] a) 
        {
            Console.WriteLine("Array: ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]+ " ");
            }
        }
    }
}
