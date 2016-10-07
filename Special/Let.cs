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
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }

            Node cdr = t.getCdr();
            Console.WriteLine("(let");
            n = n + 4;
            while (!cdr.isNull())
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(" ");
                }
                cdr.getCar().print(0, false);
                Console.WriteLine();
                cdr = cdr.getCdr();
            }
            Console.Write(")");
        }
    }
}


