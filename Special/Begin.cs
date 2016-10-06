// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            while (n > 0)
            {
                Console.Write(" ");
                n--;
            }
            if (p == false)
            {
                Console.Write("(");
            }
            Console.Write("begin");
            Console.WriteLine();
            t.getCdr().print(n + 4, true);
        }
    }
}

