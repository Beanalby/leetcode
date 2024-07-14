namespace _27___Remove_Element;

class Program
{
    static void Main(string[] args)
    {
        (int[] nums, int val)[] problems = [
            ([], 42),
            ([0], 0),
            ([3,3,3], 3),
            ([3,3,3], 42),
            ([3,2,2,3], 3),
            ([0,1,2,2,3,0,4,2], 2),
        ];
        Solution s = new();
        foreach(var p in problems) {
            Console.Write($"[{String.Join(",", p.nums)}], {p.val} -> ");
            int result = s.RemoveElement(p.nums, p.val);
            Console.WriteLine($"{result} - {String.Join(",", p.nums[..result])}]");
        }
        Console.WriteLine("Hello, World!");
    }
}

public class Solution {
    public int RemoveElement(int[] nums, int val) {
        int near = 0, far=0, len=nums.Length;
        while(far<len) {
            if(nums[far]!=val) {
                nums[near++] = nums[far];
            }
            far++;
        }
        return near;
    }
}