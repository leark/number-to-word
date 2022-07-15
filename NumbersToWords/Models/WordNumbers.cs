using System.Collections.Generic;
using System;


namespace NumbersToWords.Models
{
  public class WordNumbers
  {
    public static string ConvertToWords(long num)
    {
      Dictionary<int, string> numToWord = new Dictionary<int, string>()
      {
        {0,""},
        {1,"one"},
        {2,"two"},
        {3,"three"},
        {4,"four"},
        {5,"five"},
        {6,"six"},
        {7,"seven"},
        {8,"eight"},
        {9,"nine"},
        {10,"ten"},
        {11,"eleven"},
        {12,"twelve"},
        {13,"thirteen"},
        {14,"fourteen"},
        {15,"fifteen"},
        {16,"sixteen"},
        {17,"seventeen"},
        {18,"eighteen"},
        {19,"nineteen"}
      };

      Dictionary<int, string> tenToWord = new Dictionary<int, string>()
      {
        {0,""},
        {20,"twenty"},
        {30,"thirty"},
        {40,"fourty"},
        {50,"fifty"},
        {60,"sixty"},
        {70,"seventy"},
        {80,"eighty"},
        {90,"ninety"}
      };

      string stringNum = num.ToString();
      string result = "";

      if (num < 20)
      {
        return numToWord[(int)num];
      }
      else if (num > 19)
      {
        // 11 -> 1 split
        // 111 -> 1 split
        // 1, 111 -> 2 splits
        // 1, 111, 111 -> 3 splits
        // 1, 111, 111, 111 -> 4 splits
        // 1, 111, 111, 111, 111 -> 5 splits
        int numberOfSplits = stringNum.Length / 3;
        numberOfSplits = (stringNum.Length % 3 > 0) ? numberOfSplits + 1 : numberOfSplits;

        // copy of num just in case
        long numC = num;

        for (int i = 0; i < numberOfSplits; i++)
        {
          // grab one "split" from the number
          // e.g. at i=0 and numC=12,345,678 then newNum=12
          long newNum = numC / (long)System.Numerics.BigInteger.Pow((long)1000, numberOfSplits - (i + 1));
          string newStringNum = newNum.ToString();

          // newNum cannot exceed 999
          result += ConvertUpToHundreds((int)newNum, newStringNum, tenToWord, numToWord);

          if (numC > 999)
          {
            if (numC > 999999999999)
            {
              result += " trillion ";
            }
            else if (numC > 999999999)
            {
              result += " billion ";
            }
            else if (numC > 999999)
            {
              result += " million ";
            }
            else if (numC > 999)
            {
              result += " thousand ";
            }
            // remove the split that was just parsed into words
            // e.g. at i=0 and numC=12,345,678 then now numC=345,678
            numC = long.Parse(numC.ToString().Substring(newStringNum.Length));
          }
        }
      }
      return result.TrimEnd(' '); ;
    }

    private static string ConvertUpToHundreds(int num, string stringNum, Dictionary<int, string> tenToWord, Dictionary<int, string> numToWord)
    {
      // string[] numArray = new string[stringNum.Length];
      string result = "";
      // for (int i = 0; i < stringNum.Length; i++)
      // {
      //   numArray[i] = stringNum[i].ToString();
      // }
      if (num > 99)
      {
        // result = numToWord[int.Parse(numArray[0])] + " hundred " + tenToWord[int.Parse(numArray[1] + "0")] + " " + numToWord[int.Parse(numArray[2])];
        int hundreds = num / 100;
        result += numToWord[hundreds] + " hundred ";
        num = num - (hundreds * 100);
      }

      // if (num > 99)
      // {
      //   string tens = "";
      //   if (stringNum[1] == '1')
      //   {
      //     tens = "1";
      //   }
      //   result =
      //     numToWord[int.Parse(numArray[0])] +
      //     " hundred " +
      //     numToWord[int.Parse(tens + numArray[2])];
      // }
      if (num > 19)
      {
        int tens = num / 10 * 10;
        num = num - tens;
        result += tenToWord[tens] + " " + numToWord[num];
      }
      else
      {
        result += numToWord[num];
      }

      return result.TrimEnd(' ');
    }
  }
}