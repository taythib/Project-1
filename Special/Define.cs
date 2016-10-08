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
                Console.Write("(");
                car.print(0, true);
                Console.Write(" ");
                cdr.getCar().print(0, false);
                Console.WriteLine();
                cdr = cdr.getCdr();
                n = n + 4;
                while (!cdr.isNull())
                {
                    cdr.getCar().print(n, false);
                    Console.WriteLine();
                    cdr = cdr.getCdr();
                }
                Console.WriteLine(")");
            }
            else
            {
                Console.Write("(define");
                t.getCdr().print(0, true);
            }
        }
    }
}


