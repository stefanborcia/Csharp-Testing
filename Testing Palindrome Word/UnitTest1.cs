using NUnit.Framework;

namespace Testing_Palindrome_Word;

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
    [TestCase("Won’t l4overs revolt now")]
    [TestCase("Don’t nod")]
    [TestCase("deified")]
    [TestCase("repaper")]

    public void IsPalindrome(string word)
    {
        var r = _palindromeService!.IsPalindromeWord(word);
        Assert.AreEqual(r, true);
    }
}