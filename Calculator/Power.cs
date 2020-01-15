using System;
using Operations;
using static Operations.Ops;

class Power : IOperation
{
    char IOperation.OpSymbol => '^';

    int IOperation.PerformOperation(int a, int b)
    {
        int result = 0;
        return result = Ops.Power(a, b);
    }
}