namespace _25_Reverse_Nodes_in_k_Group;
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
        List<(ListNode?,int)> problems = [
            (new ListNode([1,2,3,4,5]), 2),
            (new ListNode([1,2,3,4,5]), 3),
            (new ListNode([1,2]), 3),
        ];
        Solution s = new();
        foreach(var p in problems) {
            Console.WriteLine($"{p.Item1}, {p.Item2} -> {s.ReverseKGroup(p.Item1, p.Item2)}");
        }
    }
}

public class Solution {
    private bool ReverseGroup(ListNode? previous, int k) {
        if(previous == null) {
            return false;
        }
        ListNode top = previous, current = previous, a, b, d;
        ListNode? c;
        // before we start, make sure we have enough nodes to swap
        current = previous;
        for(int i=0;i<k;i++) {
            if(current.next == null) {
                return false;
            }
            current = current.next;
        }
        // we've got enough nodes to do the swap
        #pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        #pragma warning disable CS8602 // Dereference of a possibly null reference.
        current = previous;
        a = current.next;
        b = a.next;
        c = b.next;
        d = a;

        while(k>1) {
            top.next = b;
            b.next = a;
            d.next = c;
            c = c.next;
            b = d.next;
            a = top.next;
            k--;
        }
        return true;
        #pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        #pragma warning restore CS8602 // Dereference of a possibly null reference.
    }
    public ListNode? ReverseKGroup(ListNode head, int k) {
        ListNode dummy = new ListNode(-1, head);
        ListNode? current = dummy;
        int i;
        while(ReverseGroup(current, k)) {
            // successfully reversed the group, march down k items
            // for the next attempt
            for(i=0;i<k;i++) {
                current = current?.next;
            }
        }
        return dummy.next;
    }
}