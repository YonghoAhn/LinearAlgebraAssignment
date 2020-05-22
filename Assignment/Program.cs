using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix m1 = new Matrix(2,2);
            m1.PutData(new int[] {5,1,3,-2});
            Console.WriteLine(m1.ToString());
            Matrix m2 = new Matrix(2,2);
            m2.PutData(new int[] {2,0,4,3});
            Console.WriteLine(m2.ToString());
            Console.WriteLine("-----------------------");
            Matrix matrix3 = m1 * m2;
            Console.WriteLine(matrix3.ToString());
            Console.WriteLine("-----------------------");
            matrix3 = m2 * m1;
            Console.WriteLine(matrix3.ToString());
            Console.ReadKey();
        }
    }
}

/*
            int x1, x2, y1, y2;
            Console.WriteLine("첫 번째 행렬의 크기 입력:");
            Console.Write("행:");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("열:");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("두 번째 행렬의 크기 입력:");
            Console.Write("행:");
            x2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("열:");
            y2 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("첫 번째 행렬의 값 입력:");
            Matrix matrix1 = new Matrix(x1, y1);
            for (int i = 0; i < x1; i++)
                for (int j = 0; j < y1; j++)
                    matrix1.PutData(i, j, Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(matrix1.ToString());
           
            Console.WriteLine("두 번째 행렬의 값 입력:");
            Matrix matrix2 = new Matrix(x2, y2);
            for (int i = 0; i < x2; i++)
                for (int j = 0; j < y2; j++)
                    matrix2.PutData(i, j, Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine(matrix2.ToString());
            */
