// Define -- Parse tree node strategy for printing the special form define

using System;

namespace Tree
{
    public class Define : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Define() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            Node car = t.getCar();
            Node cdr = t.getCdr();
            if (cdr.getCar().isPair())
            {
                Console.WriteLine("(define");
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
            }
            else
            {
                Console.Write("(define");
                t.getCdr().print(0, true);
            }
        }
    }
}


