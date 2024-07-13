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
        Queue<ListNode> queue = new(n+1);
        ListNode? walker = head;
        while(walker!=null) {
            // if queue is already full, pop off one
            if(queue.Count == n+1) {
                queue.Dequeue();
            }
            queue.Enqueue(walker);
            walker = walker?.next;
        };
        Console.WriteLine($"Walked list, left with {Program.formatListNode(queue.First())}");
        // if there's less than n+1 things in the queue,
        // then we gotta chop off the head
        if(queue.Count < n+1) {
            return head?.next;
        } else {
            // n+1 items in the queue, grab the first item, and remove the next link
            ListNode nodeBeforeRemoval = queue.First();
            nodeBeforeRemoval.next = nodeBeforeRemoval?.next?.next;
        }
        return head;
    }
}