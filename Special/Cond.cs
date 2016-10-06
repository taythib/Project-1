// Cond -- Parse tree node strategy for printing the special form cond

using System;

namespace Tree
{
    public class Cond : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Cond() { }

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
            Console.Write("cond");
            Console.WriteLine();
            t.getCdr().print(n + 4, true);
        }
    }
}


