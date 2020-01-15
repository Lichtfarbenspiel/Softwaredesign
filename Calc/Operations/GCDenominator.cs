using System;
using static Operations.Ops;

namespace Operations{
class GCDenominator : IOperation
{
    char IOperation.OpSymbol => '#';

    int IOperation.PerformOperation(int a, int b)
    {
        int result = 0;
        return result = GreatestCommonDenominator(a, b);
    }
}
}