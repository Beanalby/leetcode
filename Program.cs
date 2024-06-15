﻿using System.Globalization;


class Problem {
    public int[] nums1, nums2;
    public Problem(int[] nums1, int[] nums2) {
        this.nums1 = nums1;
        this.nums2 = nums2;
    }
    public override string ToString()
    {
        return $"[{String.Join(",", nums1)}] [{String.Join(",", nums2)}]";
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        // Solution s = new SolutionSort();
        Solution s = new SolutionStep();
        Problem[] problems = new[] {
            new Problem(
                new int[] {1,3},
                new int[] {2}),
            new Problem(
                new int[] {1,2},
                new int[] {3,4}
            )
        };
        foreach(Problem problem in problems) {  
            Console.WriteLine($"{problem.ToString()} -> "
                + s.FindMedianSortedArrays(problem.nums1, problem.nums2));
        }
    }
}

class SolutionStep: Solution {
    private int Step(int[] nums1, int[] nums2, ref int i1, ref int i2) {
        int num1 = (i1 < nums1.Length) ? nums1[i1] : int.MaxValue;
        int num2 = (i2 < nums2.Length) ? nums2[i2] : int.MaxValue;
        if(num1 < num2) {
            return nums1[i1++];
        } else {
            return nums2[i2++];
        }
    }
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int i1=0,i2=0;
        Console.WriteLine("------------------------------");
        int numSteps = (nums1.Length + nums2.Length - 1) / 2;
        Console.WriteLine($"Start @ {numSteps}: [{String.Join(",", nums1)}] [{String.Join(",", nums2)}]");
        for(int i=0;i<numSteps; i++) {
            int num = Step(nums1, nums2, ref i1, ref i2);
            Console.WriteLine($"{num}: {i1} @ [{String.Join(",", nums1)}], {i2} @ [{String.Join(",", nums2)}]");
        }
        if((nums1.Length + nums2.Length) % 2 != 0) {
            return Step(nums1, nums2, ref i1, ref i2);
        } else {
            return ((double)Step(nums1, nums2, ref i1, ref i2) + Step(nums1, nums2, ref i1, ref i2)) / 2;
        }
    }
}

public class SolutionSort: Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int[] combined = new int[nums1.Length + nums2.Length];
        nums1.CopyTo(combined, 0);
        nums2.CopyTo(combined, nums1.Length);
        Array.Sort(combined);
        int iHalf = combined.Length/2;
        if(combined.Length%2!=0) {
            return combined[iHalf];
        } else {
            return ((double)combined[iHalf-1] + combined[iHalf]) / 2;
        }
    }
}
 interface Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2);
}
