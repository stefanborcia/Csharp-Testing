using Testing_Palindrome_Word;

namespace Palindrome.Services.Tests;

using NUnit.Framework;

public class Tests
{
    private PalindromeService? _palindromeService;

    [SetUp]
    public void SetUp()
    {
        _palindromeService = new PalindromeService();
    }

    [TestCase("racecar")]
    [TestCase("nun")]
    [TestCase("bird rib")]
    [TestCase("Borrow or rob")]
    [TestCase("Never odd or even")]
    [TestCase("Won’t lovers revolt now")]
    [TestCase("Don’t nod")]
    [TestCase("deified")]
    [TestCase("repaper")]

    public void IsPalindrome(string word)
    {
        var r = _palindromeService!.IsPalindrome(word);
        Assert.AreEqual(r, true);
    }
}