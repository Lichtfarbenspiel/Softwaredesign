﻿using System;
using System.Collections.Generic;
using Operations;
using static Operations.Ops;

namespace Calculator
{
    class Program
    {
       
       static void Main(string[] args)
       {
            List<IOperation> operations = new List<IOperation>();
            operations.AddRange(OperationBuilder.GetOperations());


            Console.WriteLine("Welcome to the Calculator. Start entering calculations!");
            for (;;) // ever
            {
                Console.Write("> ");
                string command = Console.ReadLine();
                if (command.ToLower() == "exit")
                    break;             
                int left = 0;
                int right = 0;
                int opInx = FindFirstNonDigit(command);
                if (opInx < 0)
                    Console.WriteLine("No operator specified");
                char opSymbol = command[opInx];
                try
                {
                    left = int.Parse(command.Substring(0, opInx));
                    right = int.Parse(command.Substring(opInx + 1));
                }
                catch (Exception)
                {
                    Console.WriteLine("Error parsing commmand");
                }

                Console.WriteLine($"Calculating {left} {opSymbol} {right}...");
                int result = 0;
                foreach(IOperation op in operations){
                    if(op.OpSymbol == opSymbol){
                        result = op.PerformOperation(left, right);
                    }
                }
                Console.WriteLine($"{left} {opSymbol} {right} = {result}");
                System.Threading.Thread.Sleep(5000);                        
            }
        }

       private static int FindFirstNonDigit(string s)
       {
           for (int i = 0; i < s.Length; i++)
           {
               if (!Char.IsDigit(s[i]))
                   return i;
           }
           return -1;
       }        
   }
}
