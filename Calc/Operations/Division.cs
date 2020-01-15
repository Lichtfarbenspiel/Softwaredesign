using System;

namespace Operations{
class Division : IOperation
{
    char IOperation.OpSymbol => '/';

    int IOperation.PerformOperation(int a, int b)
    {
        int result = 0;
        return result = a/b;
    }
}
}