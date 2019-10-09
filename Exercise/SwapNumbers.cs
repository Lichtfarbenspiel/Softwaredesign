using System;

namespace Softwaredesign{

    public class SwapNumbers{
              

        public static void Swap(){
            
            int a = 1;
            int b = 2; 
            
            int c = a;
            a = b;
            b = c;

            Console.WriteLine("A is: " + a);
            Console.WriteLine("B is: " + b);
        }

    }
}