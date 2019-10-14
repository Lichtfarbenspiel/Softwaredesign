    using System;

namespace Softwaredesign{
    class Exercise{

     

        // static void Main(){
        //     // Print();
        //     // ArrayTask();
        //     // SwapNumbers.Swap();
        //     // Strings();

        // }

        static void Strings(){
            // string someString = "This is a String!";

            string a = "eins";
            string b = "zwei";
            string c = "eins";
            bool a_eq_b = (a == b);
            bool a_eq_c = (a == c);

            Console.WriteLine("A equals B: " + a_eq_b);
            Console.WriteLine("A equals c: " + a_eq_c);

            // char character = someString[5];
            // Console.WriteLine(character);

        }   

        static void ArrayTask(){
            int[] ia = {1, 0, 2, 9, 3, 8, 4, 7};
            int result = ia[2] * ia [7] + ia[4];

            double[] da = {3.14159265, 2.71828, 2.9745};

            Console.WriteLine("The result is: " + result);
            Console.WriteLine("ia length is: " + ia.Length + " da length is: " + da.Length);
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