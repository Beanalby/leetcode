// See https://aka.ms/new-console-template for more information
using System.Diagnostics.Contracts;
using System.Diagnostics.SymbolStore;
using System.Text;

class Program {
    public static void Main() {
        var s = new Solution();
        Problem[] problems = new[] {
            new Problem("PAYPALISHIRING", 3),
            new Problem("PAYPALISHIRING", 4),
            new Problem("A", 1),
            new Problem("AB", 1),
        };

        foreach(Problem p in problems) {
            Console.WriteLine($"{p.s} @ {p.numRows} -> {s.Convert(p.s, p.numRows)}");
        }
    }
}

class Problem {
    public string s;
    public int numRows;
    public Problem(String s, int numRows) {
        this.s = s;
        this.numRows = numRows;
    }
}

public class Solution {
    public string Convert(string s, int numRows) {
        // short-circuit direct case
        if(numRows == 1) {
            return s;
        }

        #region init
        int i;
        StringBuilder[] data = new StringBuilder[numRows];
        for(i=0;i<data.Length; i++) {
            data[i] = new StringBuilder();
        }
        #endregion

        #region build up the rows
        int currentRow = 0;
        int direction = 1;
        for(i=0;i<s.Length;i++) {
            data[currentRow].Append(s[i]);
            currentRow += direction;
            // check if we need to flip direction
            if(currentRow == data.Length - 1) {
                direction = -1;
            }
            if(currentRow == 0) {
                direction = 1;
            }
        }
        #endregion
        
        #region jam the arrays together into a result
        StringBuilder result = new StringBuilder();
        foreach(var part in data) {
            result.Append(part.ToString());
        }
        return result.ToString();
        #endregion
    }
}