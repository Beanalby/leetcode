using System.Text;

namespace _21___Merge_Two_Sorted_Lists;

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
        List<(ListNode?,ListNode?)> problems = [
            (new ListNode(1, new ListNode(2, new ListNode(4))), new ListNode(1, new ListNode(3, new ListNode(4)))),
            (null, null),
            (null, new ListNode(0)),
        ];
        Solution s = new();
        foreach(var p in problems) {
            Console.WriteLine($"{formatListNode(p.Item1)}, {formatListNode(p.Item2)} -> {formatListNode(s.MergeTwoLists(p.Item1, p.Item2))}");
        }
    }
}
public class Solution {
    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2) {
        ListNode? dummy = new ListNode(-1), current = dummy;
        while(list1 != null || list2 != null) {
            if(current == null) {
                // should never happen
                return null;
            }
            if(list1 == null) {
                current.next = list2;
                list2 = list2.next;
            } else if(list2 == null) {
                current.next = list1;
                list1 = list1.next;
            } else if(list1.val < list2.val) {
                current.next = list1;
                list1 = list1.next;
            } else {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }
        return dummy.next;
    }
}