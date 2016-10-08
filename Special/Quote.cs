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
            Console.Write("'");
            Node cdr = t.getCdr();
            Node car = t.getCar();
            cdr.print(0, false);
            
            /*while (!cdr.isNull())
            {
                cdr.print(0, false);
                Console.Write(" ");
                cdr = cdr.getCdr();
            }*/
        }
    }
}

