using System.Collections.Generic;
using System;


namespace NumbersToWords.Models
{
  public class WordNumbers
  { 
    public static string ConvertToWords(int num)
    {
      Dictionary<int,string> numToWord = new Dictionary<int,string>()
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

      Dictionary<int,string> tenToWord = new Dictionary<int,string>()
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

      // if num is greater than 19, split into tens and ones
      // 21 -> 20, 1
      string stringNum = num.ToString();

      if (num < 20)
      { 
        return numToWord[num];
      }
      else if (num > 19)
      {
        // 999, 999, 999, 999
        string result = "";
        int numberOfSplits = stringNum.Length / 3 + 1;
        string[] thousands = new string[4] {"trillion", "billion", "million", "thousand"};
        // 1, 119 -> 2 splits
        // 1, 111, 111 -> 3 splits
        // 1, 111, 111, 111 -> 4 splits
        for (int i = 0; i < numberOfSplits; i++) 
        {
          int newNum = num / (int) Math.Pow(Convert.ToDouble(1000), Convert.ToDouble(numberOfSplits - 1));
          string newStringNum = newNum.ToString();
          result += ConvertUpToHundreds(newNum, newStringNum, tenToWord, numToWord);
          if (num > 999 && i == 0)
          {
            result += " thousand ";
          }
        }

        return result;
      }
      return "zero";
    }

    private static string ConvertUpToHundreds(int num, string stringNum, Dictionary<int,string> tenToWord, Dictionary<int,string> numToWord)
    {
        string[] numArray = new string[stringNum.Length];
        string result = "";
        for (int i = 0; i < stringNum.Length; i++)
        {
          numArray[i] = stringNum[i].ToString();
        }
        if (num > 120)
        {
          result = numToWord[int.Parse(numArray[0])] + " hundred " + tenToWord[int.Parse(numArray[1] + "0")] + " " + numToWord[int.Parse(numArray[2])];
        } 
        else if (num > 99)
        {
          // covering 100 to 119
          // 119
          // numToWord(1) + "hundred" + tenToWord(10) + numToWord(9)
          // one hundred error nine

          // to cover teens
          // 119 
          // 109
          // numToWord(1) + hundred + numToWord(tens + 9)
          // numToWord(19) = nineteen
          string tens = "";
          if (stringNum[1] == '1')
          {
            tens = "1";
          }
          result = 
            numToWord[int.Parse(numArray[0])] +
            " hundred " + 
            numToWord
            [int.Parse(tens + numArray[2])];
        }
        else 
        {
          result = tenToWord[int.Parse(numArray[0] + "0")] + " " + numToWord[int.Parse(numArray[1])];
        }

        return result.TrimEnd(' ');
    }
  }
}