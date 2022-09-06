using System.Collections.Generic;

namespace Lab01.Core
{
    public static class State
    {
        public static int Result { get; set; } = 0;
    }
    
    public class Data
    {
        private Stack<int> Stack { get; } = new Stack<int>();

        public int Peek() => Stack.Count > 0 ? Stack.Peek() : 0;
        
        public void Push(int value) => Stack.Push(value);
        
        public void Pop()
        {
            if (Stack.Count > 0)
            {
                Stack.Pop();
            }
        }
    }
}