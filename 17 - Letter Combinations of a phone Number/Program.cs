namespace _17___Letter_Combinations_of_a_phone_Number;

class Program
{
    static void Main(string[] args) {
        string[] problems = ["2", "23", "2222"];
        Solution s = new();
        foreach(var problem in problems) {
            Console.WriteLine($"{problem} -> [{String.Join(",",s.LetterCombinations(problem))}]");
        }
    }
}

public class Solution {
    Dictionary<char,string[]> digitToLetters = new() {
        {'2', ["a", "b", "c"]},
        {'3', ["d", "e", "f"]},
        {'4', ["g", "h", "i"]},
        {'5', ["j", "k", "l"]},
        {'6', ["m", "n", "o"]},
        {'7', ["p", "q", "r", "s"]},
        {'8', ["t", "u", "v"]},
        {'9', ["w", "x", "y", "z"]},
    };
    public void AddDigits(List<string> results, string digits, string prefix, int pos) {
        int len = digits.Length;
        // short circuit special case
        if(len == 0) {
            return;
        }
        if(pos == digits.Length-1) {
            // last thing to add, just plop its digits on the end
            foreach(string s in digitToLetters[digits[pos]]) {
                results.Add(prefix + s);
            }
            return;
        } else {
            // need to recursively add further digts
            string newPrefix;
            foreach(string s in digitToLetters[digits[pos]]) {
                newPrefix = prefix + s;
                AddDigits(results, digits, newPrefix, pos+1);
            }
        }
    }

    public IList<string> LetterCombinations(string digits) {
        List<string> results = new();
        AddDigits(results, digits, "", 0);
        return results;
    }
}