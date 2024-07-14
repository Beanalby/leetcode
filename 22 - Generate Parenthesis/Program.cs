using System.Transactions;

namespace _22___Generate_Parenthesis;

class Program
{
    static void Main(string[] args)
    {
        int[] problems = [
            1,
            2,
            3,
            4,
            5,
            6,
            7,
            8
        ];
        Solution s = new();
        foreach(var p in problems) {
            var result = s.GenerateParenthesis(p);
            Console.WriteLine($"{p} -> {result.Count} {String.Join(", ", result)}");
        }
    }
}

public class Solution {
    private void AddParenthesis(List<string> results, string prefix, int numOpen, int numClosed) {
        if(numOpen==0 && numClosed == 0) {
            results.Add(prefix);
            return;
        }
        if(numOpen > 0) {
            AddParenthesis(results, prefix + "(", numOpen-1, numClosed);
        }
        if(numClosed > numOpen) {
            AddParenthesis(results, prefix + ")", numOpen, numClosed-1);
        }
    }
    public IList<string> GenerateParenthesis(int n) {
        List<string> results = new();
        AddParenthesis(results, "", n, n);
        return results;
    }
}
