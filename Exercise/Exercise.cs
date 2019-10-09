    using System;

namespace Softwaredesign{
    class Exercise{

     

        static void Main(){
            // Print();
            // ArrayTask();
            SwapNumbers.Swap();

        }

        static void ArrayTask(){
            int[] ia = {1, 0, 2, 9, 3, 8, 4, 7, 5, 6};

            int result = ia[2] * ia [8] + ia[4];

            Console.WriteLine("The result is: " + result);

        }

        static void Print(){

            var i = 42;
            var pi = 3.1415;
            var salute = "Hello, World"; 


            Console.WriteLine(i);
            Console.WriteLine(pi);
            Console.WriteLine(salute);
        }
    }
}   