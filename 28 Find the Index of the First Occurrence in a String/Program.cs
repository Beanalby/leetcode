namespace _28_Find_the_Index_of_the_First_Occurrence_in_a_String;

class Program
{
    static void Main(string[] args)
    {
        (string haystack, string needle)[] problems = [
            ("a", "b"),
            ("sadbutsad", "sad"),
            ("leetcode", "leeto"),
            ("foobarbaz", "bar"),
        ];
        Solution s = new();
        foreach(var (haystack, needle) in problems) {
            Console.WriteLine($"{haystack}, {needle} -> {s.StrStr(haystack,needle)}");
        }
    }
}

public class Solution {
    public int StrStr(string haystack, string needle) {
        return haystack.IndexOf(needle);
    }
}