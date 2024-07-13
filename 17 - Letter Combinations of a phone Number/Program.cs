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
    public void PopulateDigits(Dictionary<int, string[]> memos, string digits, int pos) {
        if(memos.ContainsKey(pos)) {
            return;
        }
        // need to populate it
        // if it's the last spot, just load it up directly
        if(pos == digits.Length-1) {
            memos.Add(pos, digitToLetters[digits[pos]]);
            return;
        } else {
            // populate recursively.
            // Make sure the next spot's been done first, then use it
            PopulateDigits(memos, digits, pos+1);
            List<string> l = new();
            foreach(String prefix in digitToLetters[digits[pos]]) {
                foreach(String suffix in memos[pos+1]) {
                    l.Add(prefix + suffix);
                }
            }
            memos.Add(pos, l.ToArray());
        }
    }

    public IList<string> LetterCombinations(string digits) {
        Dictionary<int, string[]> memos = new();
        // AddDigits(memos, results, digits, "", 0);
        PopulateDigits(memos, digits, 0);
        return memos[0];
    }
}