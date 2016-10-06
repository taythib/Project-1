// Set -- Parse tree node strategy for printing the special form set!

using System;

namespace Tree
{
    public class Set : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Set() { }
	
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
            Console.Write("set!");
            t.getCdr().print(1, true);
        }
    }
}

