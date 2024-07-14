namespace _24___Swap_Nodes_in_Pairs;

using System.ComponentModel;
using System.Text;

public class ListNode {
    public int val;
    public ListNode? next;
    public ListNode(int val=0, ListNode? next=null) {
        this.val = val;
        this.next = next;
    }
    public ListNode(int[] vals) {
        if(vals.Length == 0) {
            return;
        }
        this.val = vals[0];
        ListNode current = this;
        for(int i=1;i<vals.Length; i++) {
            current.next = new ListNode(vals[i]);
            current = current.next;
        }
    }
    public override string ToString() {
        ListNode? walker = this;
        StringBuilder sb = new();
        sb.Append('[');
        while(walker!=null) {
            if(walker!=this) {
                sb.Append(',');
            }
            sb.Append(walker.val);
            walker=walker.next;
        }
        sb.Append(']');
        return sb.ToString();
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<ListNode> problems = [
            new ListNode([1,2,3,4]),
            null,
            new ListNode([1]),
        ];
        Solution s = new();
        foreach(var p in problems) {
            Console.WriteLine($"{p} -> {s.SwapPairs(p)}");
        }
    }
}

public class Solution {
    public ListNode? SwapPairs(ListNode? head) {
        ListNode dummy = new ListNode(-1, head);
        ListNode current = dummy;
        while(true) {
            if(current == null || current.next == null || current.next.next == null) {
                return dummy?.next;
            }
            ListNode near = current.next;
            ListNode far = near.next;
            ListNode? rest = far.next;
            current.next = far;
            near.next = rest;
            far.next = near;
            current = near;
        }
    }
}