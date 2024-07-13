namespace _20___Valid_Parenthesis;

class Program
{
    static void Main(string[] args)
    {
        Solution s = new();
        string[] problems = [
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
        return stack.Count==0;
    }
}