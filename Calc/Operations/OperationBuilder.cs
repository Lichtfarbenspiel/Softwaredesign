using System;

namespace Operations{
public static class OperationBuilder
  {
      public static IOperation[] GetOperations() 
      {
          return new IOperation[]{ new Addition(), new Multiplication(), new Power(), new Subtraction(), new GCDenominator(), new Division()};
      }
  }
}