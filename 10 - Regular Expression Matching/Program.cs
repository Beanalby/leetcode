namespace _10___Regular_Expression_Matching;

struct Problem {
    public string s;
    public string p;
    public Problem(string s, string p) {
        this.s = s;
        this.p = p;
    }
}
class Program
{
    static void Main(string[] args)
    {
        var s = new Solution();
        var problems = new Problem[] {
            new("aaaab", "a*.*aab"),
            // new("aaabc", "a*b*c"),
            new("aa", "a"),
            new("aa", "a*"),
            new("ab", ".*"),
        };
        foreach(Problem p in problems) {
            Console.WriteLine($"{p.s},{p.p} -> {s.IsMatch(p.s,p.p)}");
        }
    }
}

public class Solution {

    private bool MatchGroup(string s, int sPos, string p, int pPos) {
        // if we're done with both the string and the pattern,
        // then we're successful
        if(sPos == s.Length && pPos == p.Length) {
            return true;
        }
        // if we're already too far in the pattern, bail
        if(pPos >= p.Length) {
            return false;
        }
        char matchChar = p[pPos++];
        int minMatch, maxMatch;
        // see if it's a glob
        if(pPos<p.Length && p[pPos]=='*') {
            pPos++;
            minMatch = 0;
            maxMatch = int.MaxValue;
        } else {
            minMatch = 1;
            maxMatch = 1;
        }
        int numMatched = 0;
        // match as many occurrences as possible
        while(numMatched < maxMatch) {
            // if there's no more s, group is done
            if(sPos >= s.Length) {
                break;
            }
            // if it's not . and it doesn't match, group is done
            if(matchChar != '.' && s[sPos] != matchChar) {
                break;
            }
            // successfully matched character
            numMatched++;
            sPos++;
        }
        // Console.WriteLine($"Matched {matchChar} {numMatched} ({minMatch}-{maxMatch}) times");
        
        // if we weren't able to match enough, we're done
        if(numMatched < minMatch) {
            return false;
        }        

        // try the next expression, possibly repeating and
        // backing off numMatches if nested MatchGroup fails
        do {
            if(MatchGroup(s, sPos, p, pPos)) {
                // next group said success, we're good!
                return true;
            }
            // next group didn't work - try backing off a
            // character match
            numMatched--;
            sPos--;
        }while(numMatched  >= minMatch);

        // went below minMatched backing off for the next
        // group, that's a failure.
        return false;
    }
    public bool IsMatch(string s, string p) {
        return MatchGroup(s, 0, p, 0);
    }
}