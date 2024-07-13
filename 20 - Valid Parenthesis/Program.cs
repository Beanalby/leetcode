namespace _20___Valid_Parenthesis;

class Program
{
    static void Main(string[] args)
    {
        Solution s = new();
        string[] problems = [
            "]",
            "([{()[]}][])",
            "()[]{}",
            "(]",
        ];
        foreach(var p in problems) {
            Console.WriteLine($"{p} -> {s.IsValid(p)}");
        }
    }
}

public class Solution {
    public bool IsValid(string s) {
        Stack<char> stack = new();
        try {
            foreach(char c in s) {
                switch(c) {
                    case '(':
                    case '[':
                    case '{':
                        stack.Push(c);
                        break;
                    case ')':
                        if(stack.Pop()!='(') {
                            return false;
                        }
                        break;
                    case ']':
                        if(stack.Pop()!='[') {
                            return false;
                        }
                        break;
                    case '}':
                        if(stack.Pop()!='{') {
                            return false;
                        }
                        break;
                }
            }
        } catch(InvalidOperationException e) {
            // tried to pop when the stack is empty
            return false;
        }
        return stack.Count==0;
    }
}