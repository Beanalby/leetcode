using System.Text;

namespace _12___Integer_to_Roman;

class Program
{
    static void Main(string[] args)
    {
        int[] problems = [
            1,2,3,4,5,6,7,8,9,10,11,12,3749,58,1994];
        Solution s = new();
        foreach(var problem in problems) {
            Console.WriteLine($"{problem} -> {s.IntToRoman(problem)}");
        }
    }
}

public class Solution {
    (int,string)[] maps = new[] {
            (1000, "M"),
            (900, "CM"),
            (500, "D"),
            (400, "CD"),
            (100, "C"),
            (90, "XC"),
            (50, "L"),
            (40, "XL"),
            (10, "X"),
            (9, "IX"),
            (5, "V"),
            (4, "IV"),
            (1, "I"),
        };
    public string IntToRoman(int num) {
        StringBuilder result = new();
        int minIndex = 0, i=0;
        while(num != 0) {
            for(i=minIndex;i<maps.Length;i++) {
                if(maps[i].Item1 <= num) {
                    result.Append(maps[i].Item2);
                    num -= maps[i].Item1;
                    break;
                } else {
                    minIndex = i+1;
                }
            }
        }
        return result.ToString();
    }
}