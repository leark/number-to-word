using System;
using NumbersToWords.Models;

namespace NumbersToWords
{
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("Type a number in numeric form to convert to word form.");
      Console.WriteLine("e.g. 23021 will convert to twenty three thousand twenty one");
      Console.WriteLine("Max of 999999999999999999 and min of -999999999999999999");
      string numString = Console.ReadLine();
      string result = WordNumbers.ConvertToWords((long)System.Numerics.BigInteger.Parse(numString));
      Console.WriteLine("{0} converts to {1}", numString, result);
      Console.WriteLine("Check for a different number? (y/n)");
      string redo = Console.ReadLine();
      if (redo.ToLower() == "y")
      {
        Main();
      }
    }
  }
}