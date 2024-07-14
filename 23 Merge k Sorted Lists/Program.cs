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
            [null, new ListNode(1)],
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
        #endregion

        ListNode dummy = new ListNode(-1);
        ListNode? current = dummy;
        int i;
        bool sawNonNull;
        int lowest, lowestCount;
        while(true) {
            #region check if we're done
            sawNonNull = false;
            for(i=0;i<lists.Length; i++) {
                if(lists[i]!=null) {
                    sawNonNull = true;
                    break;
                }
            }
            if(!sawNonNull) {
                return dummy.next;
            }
            #endregion

            #region find the lowest value among the list nodes
            lowest = int.MaxValue;
            lowestCount=0;
            for(i=0;i<lists.Length;i++) {
                #pragma warning disable CS8602 // Dereference of a possibly null reference.
                if(lists[i]!=null) {
                    if(lists[i].val == lowest) {
                        lowestCount++;
                    }
                    if(lists[i].val < lowest) {
                        lowest = lists[i].val;
                        lowestCount=1;
                    }
                }
                #pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
            #endregion 

            #region find *SOME* list that has the lowest value, and advance it. We don't care which one it is.
            for(i=0;i<lists.Length;i++) {
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
                    // see if we have any more lists to advance
                    if(--lowestCount == 0) {
                        break;
                    }
                }
            }
            #endregion
        }
    }
}