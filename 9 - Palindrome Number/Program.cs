class Program {
    static void Main(string[] args) {
        int[] problems = new int[] { 121, -121, 10};
        Solution s = new Solution();
        foreach(var problem in problems) {
            Console.WriteLine($"{problem} -> {s.IsPalindrome(problem)}");
        }
    }
}

public class Solution {
    public bool checkPalindrome(string s, int leftPos, int rightPos) {
        while(true) {
            if(leftPos == -1 && rightPos == s.Length) {
                return true;
            }
            if(leftPos <=-1 || rightPos >= s.Length) {
                return false;
            }
            if(s[leftPos] != s[rightPos]) {
                return false;
            }
            leftPos--;
            rightPos++;
        }
    }
    public bool IsPalindrome(int x) {
        if(x<0) {
            return false;
        }
        var xStr = x.ToString();
        if(xStr.Length%2 == 0) {
            return checkPalindrome(xStr, (xStr.Length/2)-1, xStr.Length/2);
        } else {
            return checkPalindrome(xStr, (xStr.Length/2)-1, (xStr.Length/2)+1);
        }
    }
}