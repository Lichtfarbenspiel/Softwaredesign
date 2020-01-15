using System;
namespace Operations{
class Multiplication : IOperation
{
    public char OpSymbol => '*';

    public int PerformOperation(int a, int b)
    {
        int result = 0;
        return result = a*b;
    }
}
}