﻿using System.ComponentModel;
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
    static void binTest() {
        Solution s = new();
        int[] nums = [-1, 0, 1, 2, -1, -4];
        Array.Sort(nums);
        for(int i=-5;i<4;i++) {
            Console.WriteLine($"{i} -> {s.binSearch(nums, 3, i)}");
        }
    }
}

public class Solution {
    // Returns the index of the target element, -1 if not found
    public int binSearch(int[] nums, int startPos, int target) {
        int lower = startPos, upper = nums.Length-1, current;
        while(true) {
            current = (lower + upper) / 2;
            if(nums[current] == target) {
                return current;
            }
            if(nums[current] < target) {
                // because of floor on integer division,
                // let lower to increase even if it's current,
                // as long as it's not upper
                if(lower == upper) {
                    return -1;
                }
                // accomplishing the setup for the above test,
                // let lower go to 1 more than current if it's
                // current at the moment.
                lower = (lower == current) ? current+1 : current;
            } else {
                if(upper == current) {
                    return -1;
                }
                upper = current;
            }
        }
    }

    public IList<IList<int>> ThreeSum(int[] nums) {
        HashSet<(int,int,int)> result = new();
        Array.Sort(nums);
        for(int i=0;i<nums.Length-2; i++) {
            for(int j=i+1; j<nums.Length-1; j++) {
                var target = -(nums[i] + nums[j]);
                // don't bother looking if the target
                // is lower than either number - we would've already
                // found this triplet when "target" was num1 or num2.
                if(target < nums[i] || target < nums[j]) {
                    continue;
                }
                if(-1 != binSearch(nums, j+1, target)) {
                    result.Add( (nums[i], nums[j], target));
                }
            }
        }
        return result.Select<(int, int, int), IList<int>>(t => [t.Item1, t.Item2, t.Item3]).ToList();
    }
}