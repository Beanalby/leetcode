using System.Text;

namespace _18___4Sum;

class Program
{
    static string formatAnswer(IList<IList<int>> x) {
        StringBuilder sb = new();
        sb.Append("[");
        foreach(var l in x) {
            sb.Append(" [");
            sb.Append(String.Join(",", l));
            sb.Append("]");
            if(x.Last()!=l) {
                sb.Append(",");
            }
        }
        sb.Append(" ]");
        return sb.ToString();
    }
    static void Main(string[] args)
    {
        Solution s = new();
        List<(int[], int)> problems = [
                ([1,0,-1,0,-2,2], 0),
                ([2,2,2,2,2], 8),
                ([1,-2,-5,-4,-3,3,3,5], -11)
            ];
        foreach(var problem in problems) {
            Console.WriteLine($"[{String.Join(",", problem.Item1)}],{problem.Item2} -> {formatAnswer(s.FourSum(problem.Item1, problem.Item2))}");
        }
        Console.WriteLine("Hello, World!");
    }
}
public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        HashSet<(int,int,int,int)> result = new();
        Array.Sort(nums);
        int k, l, sum, len=nums.Length;
        for(int i=0;i<nums.Length-3;i++) {
            // short-circuit - if we're left with only positive numbers
            // that are greater than the target, we cna stop looking
            if(nums[i] > 0 && nums[i] > target) {
                break;
            }
            for(int j=i+1;j<nums.Length-2; j++) {
                // if the first two digits are the same as they were
                // last time, don't need to bother looking.  We already
                // found all combinations for them
                if(i!=0 && nums[i-1] == nums[i] && nums[i] == nums[i+1]) {
                    continue;
                }
                k = j+1;
                l = len-1;
                while(k < l) {
                    sum = nums[i] + nums[j] + nums[k] + nums[l];
                    if(sum == target) {
                        result.Add((nums[i], nums[j], nums[k], nums[l]));
                        k++;
                        l--;
                    } else if(sum < target) {
                        k++;
                    } else {
                        l--;
                    }
                }
            }
        }
        return result.Select<(int, int, int,int), IList<int>>(t => [t.Item1, t.Item2, t.Item3, t.Item4]).ToList();
    }
}