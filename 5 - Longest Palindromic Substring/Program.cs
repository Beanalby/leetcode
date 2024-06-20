class Program {
    static void Main(string[] args)
    {
        string[] problems = {
            "babad",
            "cbbd",
            "This is an arbitrary test that makes me wonder how many unexpected plaindromes we may find in arbitrary text that we type.  I don't think there would be many, but who knows?"
        };
        var s = new Solution();
        foreach(string problem in problems) {
            Console.WriteLine($"{problem} -> {s.LongestPalindrome(problem)}");
        }
    }

}

class Solution
{
    private void FindPalidromeHelper(string s, ref int posLeft, ref int posRight) {
        while(true) {
            // if there's no more charcters on either side, we're done
            if(posLeft <= 0 || posRight >= s.Length-1) {
                break;
            }
            // if the next characers don't match, we're done
            if(s[posLeft-1] != s[posRight+1]) {
                break;
            }
            // they match, expand the palindrome
            posLeft -= 1;
            posRight += 1;
            continue;
        }
    }
    private string LongestPalindromeAtPosition(string s, int pos, int previousMax) {
        int leftEven=-1, rightEven=-1, leftOdd=pos, rightOdd=pos;
        string result = "";
        // try using pos as the center point
        FindPalidromeHelper(s, ref leftOdd, ref rightOdd);
        // try starting in-between this character & the next.
        // only start looking if they already match.
        if(pos+1 < s.Length && s[pos] == s[pos+1]) {
            leftEven = pos; rightEven = pos+1;
            FindPalidromeHelper(s, ref leftEven, ref rightEven);
        }
        if(rightOdd - leftOdd + 1 > previousMax) {
            result = s.Substring(leftOdd, rightOdd-leftOdd+1);
            previousMax = result.Length;
        }
        if(rightEven - leftEven + 1 > previousMax) {
            result = s.Substring(leftEven, rightEven-leftEven+1);
            previousMax = result.Length;
        }
        return result;
    }
    public string LongestPalindrome(string s) {
        string result = "";
        for(int i=0;i<s.Length; i++) {
            string newResult = LongestPalindromeAtPosition(s, i, result.Length);
            if(newResult.Length > result.Length)
                result = newResult;
        }
        return result;
    }
}
