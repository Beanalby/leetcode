using System.Security.Cryptography.X509Certificates;

namespace _29___Divided_Two_Integers;

class Program
{
    static void Main(string[] args)
    {
        (int, int)[] problems = [
            (0, 10),
            (3, 3),
            (-3, 3),
            (3, -3),
            (-3, -3),
            (10000, 5),
            (10, 3),
            (7, -3),
        ];
        Solution s = new();
        foreach(var (dividend, divisor) in problems) {
            Console.WriteLine($"{dividend} / {divisor} -> {s.Divide(dividend, divisor)}");
        }
        Console.WriteLine("Hello, World!");
    }
}

public class Solution {
    public int Divide(int dividend, int divisor) {
        bool flipSign = false;
        if(dividend < 0) {
            dividend -= dividend + dividend;
            flipSign =! flipSign;
        }
        if(divisor < 0) {
            divisor -= divisor + divisor;
            flipSign =! flipSign;
        }
        int count = 0;
        while(dividend >= divisor) {
            count += 1;
            dividend -= divisor;
        }
        if(flipSign) {
            count -= (count + count);
        }
        return count;
    }
}