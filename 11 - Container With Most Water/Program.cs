namespace _11___Container_With_Most_Water;

class Program
{
    static void Main(string[] args)
    {
        Solution s = new();
        List<int[]> problems = [ [1,8,6,2,5,4,8,3,7], [1,1] ];
        foreach(var problem in problems) {
            Console.WriteLine($"[{String.Join(",", problem)}] -> {s.MaxArea(problem)}");
        }
    }
}

public class Solution {
    public int MaxArea(int[] height) {
        int maxSeen=-1;
        int i=0, j=height.Length-1;
        while(i!=j) {
            maxSeen = Math.Max(maxSeen, (j-i) * Math.Min(height[i],height[j]));
            if(height[i] < height[j]) {
                i++;
            } else {
                j--;
            }
        }
        return maxSeen;
    }
}