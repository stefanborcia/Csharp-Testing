global using NUnit.Framework;

namespace Testing_Palindrome_Numbers
{
    public class TestPalindromeNumber
    {
        public bool isPalindromeNumber(double num)
        {
            if (num >= 10000 && num < 100000)
            {
                double oldNum = num;
                double FirstDig = num % 10;
                num = num - (num % 10);
                double SecondDig = num % 100;
                num = num - (num % 100);
                double ThirdDig = num % 1000;
                num = num - (num % 1000);
                double FourthDig = num % 10000;
                num = num - (num % 10000);
                double FifthDig = num % 100000;
                num = num - (num % 100000);
                FirstDig = FirstDig / 10;
                SecondDig = SecondDig / 100;
                ThirdDig = ThirdDig / 1000;
                FourthDig = FourthDig / 10000;
                FifthDig = FifthDig / 100000;
                double flippedNum = FirstDig + SecondDig + ThirdDig + FourthDig + FifthDig;
                flippedNum = flippedNum * 100000;
                if (flippedNum == oldNum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}


