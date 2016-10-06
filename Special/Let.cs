// Let -- Parse tree node strategy for printing the special form let

using System;

namespace Tree
{
    public class Let : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Let() { }

        public override void print(Node t, int n, bool p)
        {
            while (n > 0)
            {
                Console.Write(" ");
                n--;
            }
            if (p == false)
            {
                Console.Write("(");
            }
            Console.Write("let");
            Console.WriteLine();
            t.getCdr().print(n + 4, true);
        }
    }
}


