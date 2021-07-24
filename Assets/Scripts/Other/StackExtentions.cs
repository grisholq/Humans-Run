using System.Collections.Generic;

public static class StackExtentions
{
    public static bool Empty<T>(this Stack<T> stack)
    {
        return stack.Count == 0;
    }
}