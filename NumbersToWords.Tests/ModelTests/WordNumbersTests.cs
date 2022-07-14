using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumbersToWords.Models;

namespace NumbersToWords.Tests
{
  [TestClass]
  public class WordNumbersTests
  {

    [TestMethod]
    public void ConvertToWords_ReturnOneFor1_One()
    {
      Assert.AreEqual("one", WordNumbers.ConvertToWords(1));
    }

    [TestMethod]
    public void ConvertToWords_ReturnWordFor2Through19_Word()
    {
      Assert.AreEqual("two", WordNumbers.ConvertToWords(2));
      Assert.AreEqual("three", WordNumbers.ConvertToWords(3));
      Assert.AreEqual("four", WordNumbers.ConvertToWords(4));
      Assert.AreEqual("five", WordNumbers.ConvertToWords(5));
      Assert.AreEqual("six", WordNumbers.ConvertToWords(6));
      Assert.AreEqual("seven", WordNumbers.ConvertToWords(7));
      Assert.AreEqual("eight", WordNumbers.ConvertToWords(8));
      Assert.AreEqual("nine", WordNumbers.ConvertToWords(9));
      Assert.AreEqual("ten", WordNumbers.ConvertToWords(10));
      Assert.AreEqual("eleven", WordNumbers.ConvertToWords(11));
      Assert.AreEqual("twelve", WordNumbers.ConvertToWords(12));
      Assert.AreEqual("thirteen", WordNumbers.ConvertToWords(13));
      Assert.AreEqual("fourteen", WordNumbers.ConvertToWords(14));
      Assert.AreEqual("fifteen", WordNumbers.ConvertToWords(15));
      Assert.AreEqual("sixteen", WordNumbers.ConvertToWords(16));
      Assert.AreEqual("seventeen", WordNumbers.ConvertToWords(17));
      Assert.AreEqual("eighteen", WordNumbers.ConvertToWords(18));
      Assert.AreEqual("nineteen", WordNumbers.ConvertToWords(19));
    }

    [TestMethod]
    public void ConvertToWords_ReturnWordFor20_Twenty()
    {
      Assert.AreEqual("twenty", WordNumbers.ConvertToWords(20));
    }

    [TestMethod]
    public void ConvertToWords_ReturnWordFor21_TwentyOne()
    {
      Assert.AreEqual("twenty one", WordNumbers.ConvertToWords(21));
    }

    [TestMethod]
    public void ConvertToWords_ReturnWordFor100_OneHundred()
    {
      Assert.AreEqual("one hundred", WordNumbers.ConvertToWords(100));
    }

    [TestMethod]
    public void ConvertToWords_ReturnWordFor121_OneHundredTwentyOne()
    {
      Assert.AreEqual("one hundred twenty one", WordNumbers.ConvertToWords(121));
    }

    [TestMethod]
    public void ConvertToWords_ReturnWordFor119_OneHundredNineteen()
    {
      Assert.AreEqual("one hundred nineteen", WordNumbers.ConvertToWords(119));
    }

    [TestMethod]
    public void ConvertToWords_ReturnWordFor1119_OneThousandOneHundredNineteen()
    {
      Assert.AreEqual("one thousand one hundred nineteen", WordNumbers.ConvertToWords(1119));
    }
  }
}