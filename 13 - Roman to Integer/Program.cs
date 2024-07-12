using System.Reflection.Metadata.Ecma335;

namespace _13___Roman_to_Integer;

class Program
{
    static void Main(string[] args)
    {
        Solution s = new();
        string[] problems = ["III", "LVIII", "MCMXCIV"];
        foreach(var problem in problems) {
            Console.WriteLine($"{problem} -> {s.RomanToInt(problem)}");
        }
    }
}

public class Solution {
    public int RomanToInt(string s) {
        int result = 0, len=s.Length;
        for(int i=0;i<len;i++) {
            switch(s[i]) {
                case 'M':
                    result += 1000;
                    break;
                case 'D':
                    result += 500;
                    break;
                case 'C':
                    if(i+1<len && s[i+1]=='D') {
                        result += 400;
                        i++;
                    } else if(i+1<len && s[i+1]=='M') {
                        result += 900;
                        i++;
                    } else {
                        result += 100;
                    }
                    break;
                case 'L':
                    result += 50;
                    break;
                case 'X':
                    if(i+1<len && s[i+1]=='L') {
                        result += 40;
                        i++;
                        break;
                    } else if(i+1<len && s[i+1]=='C') {
                        result += 90;
                        i++;
                        break;
                    } else {
                        result += 10;
                    }
                    break;
                case 'V':
                    result += 5;
                    break;
                case 'I':
                    if(i+1<len && s[i+1]=='V') {
                        result += 4;
                        i++;
                        break;
                    } else if(i+1<len && s[i+1]=='X') {
                        result += 9;
                        i++;
                        break;
                    } else {
                        result += 1;
                    }
                break;
            }
        }
        return result;
    }
}