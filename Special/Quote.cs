// Quote -- Parse tree node strategy for printing the special form quote

using System;

namespace Tree
{
    public class Quote : Special
    {
        // TODO: Add any fields needed.
  
        // TODO: Add an appropriate constructor.
	public Quote() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            Node cdr = t.getCdr();
            Node car = t.getCar();
            while (!cdr.isNull())
            {
                cdr.getCar().print(0, true);
                Console.Write(" ");
                cdr = cdr.getCdr();
            }
        }
    }
}

