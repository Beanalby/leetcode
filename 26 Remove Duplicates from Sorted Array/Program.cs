namespace _26_Remove_Duplicates_from_Sorted_Array;

class Program
{
    static void Main(string[] args)
    {
        int[][] problems = [
            [1,1,2],
            [0,0,1,1,1,2,2,3,3,4],
        ];
        Solution s = new();
        foreach(var p in problems) {
            Console.Write($"[{String.Join(",",p)}] -> ");
            int result = s.RemoveDuplicates(p);
            Console.WriteLine($" {result} - [{String.Join(",", p[..result])}]");
        }
    }
}

public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int len = nums.Length;
        if(len<= 1) {
            return len;
        }
        int near=0, far=1, i=0, lastSeen=nums[i];
        while(far!=len) {
            if(nums[near] != nums[far]) {
                nums[++near] = nums[far];
            }
            far++;
        }
        return near+1;
    }
}