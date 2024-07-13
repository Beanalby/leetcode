using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace _16___3Sum_Closest;

class Program
{
    static void Main(string[] args)
    {
        List<(int[],int)> problems = new() {
            ([-1,2,1,-4],1),
            ([0,0,0], 1),
        };
        Solution s = new();
        foreach(var problem in problems) {
            Console.Write($"([{String.Join(",",problem.Item1)}], {problem.Item2}) -> ");
            Console.WriteLine(s.ThreeSumClosest(problem.Item1, problem.Item2));
        }
    }
}

public class Solution {
    public int ThreeSumClosest(int[] nums, int target) {
        Array.Sort(nums);
        int j, k, len=nums.Length, sum, closest = int.MaxValue;
        for(int i=0;i<len-2; i++) {
            if(i!=0 && nums[i] == nums[i-1]) {
                continue;
            }
            j = i+1;
            k = len-1;
            while(j < k) {
                sum = nums[i] + nums[j] + nums[k];
                if(Math.Abs(target-sum) < Math.Abs(target-closest) ) {
                    closest = sum;
                    j++;
                    k--;
                    if(closest == target) {
                        // we're there, no point in looking more
                        return target;
                    }
                } else if(target-sum > 0) {
                    j++;
                } else {
                    k--;
                }
            }
        }
        return closest;
    }
}