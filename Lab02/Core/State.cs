using System.Collections.Generic;

namespace Lab02.Core
{
    public static class State
    {
        private static Stack<int> Stack { get; } = new Stack<int>();
        public static int Result { get; set; } = 0;

        public static int Peek() => Stack.Count > 0 ? Stack.Peek() : 0;
        
        public static void Push(int value) => Stack.Push(value);
        
        public static void Pop()
        {
            if (Stack.Count > 0)
            {
                Stack.Pop();
            }
        }

        public static Data GetData()
        {
            return new Data()
            {
                Result = State.Result + Peek()
            };
        }
    }
}