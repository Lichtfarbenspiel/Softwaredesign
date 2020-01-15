using System;

namespace Operations{
class Subtraction : IOperation
{
    char IOperation.OpSymbol => '-';

    int IOperation.PerformOperation(int a, int b)
    {
        int result = 0;
        return result = a-b;
    }
}
}