using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

namespace _29___Divided_Two_Integers;

class Program
{
    static void Main(string[] args)
    {
        (int, int)[] problems = [
            (int.MaxValue, 1),
            (int.MaxValue, -1),
            (int.MinValue, 1),
            (int.MinValue, -1),
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
    }
}

public class Solution {
    private delegate int Modify(int dividend, int divisor);
    private delegate bool Test(int divident, int divisor);
    public int Divide(int dividend, int divisor) {
        // Modify modify;
        // Test test;
        int count=0;
        bool flipCount = false;
        if(dividend > 0) {
            dividend -= (dividend + dividend);
            flipCount = !flipCount;
        }
        if(divisor > 0) {
            divisor -= (divisor + divisor);
            flipCount = !flipCount;
        }
        try {
            if(divisor == -1) {
                count = checked(-dividend);
            } else {
                while(dividend <= divisor) {
                    dividend = dividend - divisor;
                    count = checked(count+1);
                }
            }
            if(flipCount) {
                count = -count;
            }
        }catch(OverflowException) {
            count = flipCount ? int.MinValue : int.MaxValue;
        }
        return count;
    }
}