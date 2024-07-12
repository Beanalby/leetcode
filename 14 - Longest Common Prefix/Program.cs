namespace _14___Longest_Common_Prefix;

class Program
{
    static void Main(string[] args)
    {
        Solution s = new();
        string[][] problems = [
            ["","","",""],
            ["foo"],
            ["ab","a"],
            ["flower","flow","flight"],
            ["abc","def","ghij"],
            ];
        foreach(var problem in problems) {
            Console.WriteLine($"[{String.Join(",",problem)}] -> {s.LongestCommonPrefix(problem)}");
        }
        Console.WriteLine("Hello, World!");
    }
}

public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        // short-circuit a single string
        if(strs.Length == 1) {
            return strs[0];
        }
        int minLength = strs.Aggregate(int.MaxValue, (i,s) => Math.Min(i,s.Length));
        if(minLength==0) {
            return "";
        }
        int i = 0;
        string s = strs[0];
        bool sawInvalid = false;
        for(i=0;i<minLength && !sawInvalid;i++) {
            for(int strNum=1;strNum<strs.Length;strNum++) {
                if(strs[strNum][i] != s[i]) {
                    sawInvalid = true;
                    i--;
                    break;
                }
            }
        }
        return s[..i];
    }
}