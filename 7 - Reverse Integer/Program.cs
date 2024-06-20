namespace _7___Reverse_Integer;

class Program
{
    static void Main(string[] args)
    {
        var s = new Solution();
        int[] problems = new int[] {1, 0, -1, 10, 01, 101000, 123, -123, 120, Int32.MaxValue, Int32.MinValue};
        foreach(int problem in problems) {
            Console.WriteLine($"{problem} -> {s.Reverse(problem)}");
        }
        Console.WriteLine("Hello, World!");
    }
}

public class Solution {
    public int Reverse(int x) {
        bool negate = false;
        if(x < 0) {
            x = -x;
            negate = true;
        }

        String s = x.ToString();
        char[] array = s.ToCharArray();
        Array.Reverse(array);
        s = new string(array);

        System.Int32 result;
        if(!System.Int32.TryParse(s, out result)) {
            result = 0;
        }
        if(negate) {
            result = -result;
        }
        return result;
    }
}