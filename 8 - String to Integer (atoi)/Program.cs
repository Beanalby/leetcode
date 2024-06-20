using System.Text;

namespace _8___String_to_Integer__atoi_;

class Program
{
    static void Main(string[] args)
    {
        string[] problems = new string[] {
            "42",
            "   -042",
            "1337c0d3",
            "123456789123456789",
            "   -34753952958259 is too low",
            "0-1",
            "words and 987"
        };
        var s = new Solution();
        foreach(var problem in problems) {
            Console.WriteLine($"{problem} -> {s.MyAtoi(problem)}");
        }
        Console.WriteLine("Hello, World!");
    }
}

public class Solution {
    public int MyAtoi(string s) {
        int i=0;
        StringBuilder sb = new StringBuilder();
        bool sawNegative = false;
        int result = 0;

        // skip leading whitespace
        while(i < s.Length && Char.IsWhiteSpace(s[i])) {
            i++;
        }

        // apply signed-ness, if necessary
        if(i < s.Length && s[i]=='+') {
            // noting positive, just skip past it
            i++;
        } else if(i < s.Length && s[i] == '-') {
            sawNegative = true;
            sb.Append(s[i]);
            i++;
        }
        
        // skip zero(es)
        while(i < s.Length && s[i] == '0') {
            i++;
        }
        // eat digits
        bool gotDigit = false;
        while(i < s.Length && s[i] >= '0' && s[i] <= '9') {
            sb.Append(s[i]);
            i++;
            gotDigit = true;
        }
        if(!gotDigit) {
            return 0;
        }

        // try parsing number
        string resultStr = sb.ToString();
        if(!System.Int32.TryParse(resultStr, out result)) {
            /* outside the Int32 range.  This problem told us to ROUND,
             * so use either max or min, depending on whether we saw
             * a negation for this number. */
            return sawNegative ? Int32.MinValue : Int32.MaxValue;
        } else {
            return result;
        }
    }
}