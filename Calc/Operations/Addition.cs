using System;
namespace Operations{
    class Addition : IOperation
    {
        char IOperation.OpSymbol => '+';

        int IOperation.PerformOperation(int a, int b)
        {
            int result = 0;
            return result = a+b;
        }
    }
}