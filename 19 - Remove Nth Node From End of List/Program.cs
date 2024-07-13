using System.Text;

namespace _19___Remove_Nth_Node_From_End_of_List;


 public class ListNode {
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode? next=null) {
        this.val = val;
        this.next = next;
    }
}

class Program
{
    public static string formatListNode(ListNode head) {
        ListNode walker = head;
        StringBuilder sb = new();
        sb.Append("[");
        while(walker!=null) {
            if(walker!=head) {
                sb.Append(",");
            }
            sb.Append(walker.val);
            walker=walker.next;
        }
        sb.Append("]");
        return sb.ToString();
    }
    static void Main(string[] args)
    {
        (ListNode,int)[] problems = [
            (new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5))))), 2),
            (new ListNode(1), 1),
            (new ListNode(1, new ListNode(2)), 1)
        ];
        Solution s = new();
        foreach(var p in problems) {
            Console.WriteLine($"{formatListNode(p.Item1)}, {p.Item2} -> {formatListNode(s.RemoveNthFromEnd(p.Item1,p.Item2))}");
        }
    }
}

public class Solution {
    public ListNode? RemoveNthFromEnd(ListNode? head, int n) {
        ListNode? walkFar = head, walkNear = head;
        for(int i=0;i<n;i++) {
            walkFar = walkFar?.next;
        }
        if(walkFar==null) {
            // removing the head
            return head?.next;
        }
        while(walkFar?.next !=null) {
            walkFar = walkFar.next;
            walkNear = walkNear?.next;
        }
        if(walkNear?.next!=null) {
            walkNear.next = walkNear?.next?.next;
        }
        return head;
    }
}