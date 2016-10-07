// Lambda -- Parse tree node strategy for printing the special form lambda

using System;

namespace Tree
{
    public class Lambda : Special
    {
        // TODO: Add any fields needed.

        // TODO: Add an appropriate constructor.
	public Lambda() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }

            Node cdr = t.getCdr();
            Node car = t.getCar();
            Node cddr = t.getCdr().getCdr();
            Console.WriteLine("(lambda");
            cdr.getCar().print(0, false);
            while (!cddr.isNull())
            {
                cddr.print(n + 4, true);
                cddr = cddr.getCdr();
            }
        }
    }
}

