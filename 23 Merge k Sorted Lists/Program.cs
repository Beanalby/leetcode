namespace _23_Merge_k_Sorted_Lists;

using System.Resources;
using System.Text;
using Microsoft.VisualBasic;

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
    public static string formatListNode(ListNode? head) {
        ListNode? walker = head;
        StringBuilder sb = new();
        sb.Append('[');
        while(walker!=null) {
            if(walker!=head) {
                sb.Append(',');
            }
            sb.Append(walker.val);
            walker=walker.next;
        }
        sb.Append(']');
        return sb.ToString();
    }
    static void Main(string[] args)
    {
        List<ListNode?[]> problems = [
            [
                new ListNode(1, new ListNode(4, new ListNode(5))),
                new ListNode(1, new ListNode(3, new ListNode(4))),
                new ListNode(2, new ListNode(6))
            ],
            [],
            [null],
        ];
        var s = new Solution();
        foreach(var p in problems) {
            StringBuilder sb = new();
            foreach(var ln in p) {
                if(ln != p.First()) {
                    sb.Append(", ");
                }
                sb.Append(formatListNode(ln));
            }
            sb.Append(" -> " + formatListNode(s.MergeKLists(p)));
            Console.WriteLine(sb.ToString());
        }
    }
}
public class Solution {
    public ListNode? MergeKLists(ListNode?[] lists) {
        #region sanityCheck
        if(lists==null) {
            return null;
        }
        if(lists.Length == 0) {
            return null;
        }
        if(lists[0]==null) {
            return null;
        }
        #endregion

        ListNode dummy = new ListNode(-1);
        ListNode? current = dummy;
        while(true) {
            // check if we're done
            if(!lists.Any((ListNode? ln) => ln!=null)) {
                return dummy.next;
            }
            // find the lowest value among the list nodes
            int lowest = lists.Aggregate(int.MaxValue, (int x, ListNode? ln) => ln==null ? x : ln.val < x ? ln.val : x);
            // find ** list that has the lowest value, and advance it.
            // We don't care which one it is.
            for(int i=0;i<lists.Length;i++) {
                if(lists[i] == null) {
                    continue;
                }
                if(lists[i]?.val == lowest) {
                    // should never happen
                    if(current != null) {
                        current.next = lists[i];
                        current = current?.next;
                    }
                    lists[i] = lists[i]?.next;
                    // found the list we're advanding, don't need to look at rest
                    break;
                }
            }
        }
    }
}