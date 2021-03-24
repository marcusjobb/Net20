namespace TestingTestFrameworks
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {

            var num1 = (Double)1 / 2; // 0.5
            var num2 = (Double)1 / (Double)2; // 0.5;
            var num3 = (Double)((Double)1 / (Double)2); // 0.5
            var num4 = (Double)(1 / 2); //  0.0
            var num5 = 1d / 2d; //  0.5
            var num6 = (double)(1.0 / 2.0); // 0.5
            var num7 = (1 / 2d); // 0.5

            Console.WriteLine(num1);
            Console.WriteLine(num2);
            Console.WriteLine(num3);
            Console.WriteLine(num4);
            Console.WriteLine(num5);
            Console.WriteLine(num6);
            Console.WriteLine(num7);



        }
    }
}
