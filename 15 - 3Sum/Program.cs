using System.ComponentModel;
using System.Net.Http.Headers;
using System.Text;

namespace _15___3Sum;

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
        // binTest();
        // return;
        Solution s = new();
        int[][] problems = [
            [0, 0, 0],
            [0,1,1],
            [-1, 0, 1, 2, -1, -4]
            // [2, -1, -1, -4]
            ];
        foreach(var problem in problems) {
            Console.WriteLine($"[{String.Join(",", problem)}] -> {formatAnswer(s.ThreeSum(problem))}");
        }
        Console.WriteLine("Hello, World!");
    }
}

public class Solution {

    public IList<IList<int>> ThreeSum(int[] nums) {
        HashSet<(int,int,int)> result = new();
        Array.Sort(nums);
        int j,k, sum, len=nums.Length;
        
        // stop early when nums[i] is positive - can't have
        // a solution involving 3 positive numbers
        for(int i=0;i<nums.Length-2 && nums[i] <= 0; i++) {
            // if this is the same number as the previous one,
            // we already found all the solutions where this is
            // the first number
            if(i>0 && nums[i]==nums[i-1]) {
                continue;
            }
            j=i+1;
            k=len-1;
            while(j < k) {
                sum = nums[i] + nums[j] + nums[k];
                if(sum == 0) {
                    result.Add( (nums[i], nums[j], nums[k]));
                    j++;
                    k--;
                } else if(sum < 0) {
                    j++;
                } else {
                    k--;
                }
            }
        }
        return result.Select<(int, int, int), IList<int>>(t => [t.Item1, t.Item2, t.Item3]).ToList();
    }
}