// If -- Parse tree node strategy for printing the special form if

using System;

namespace Tree
{
    public class If : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public If() { }

        public override void print(Node t, int n, bool p)
        {
            /*while (n > 0)
            {
                Console.Write(" ");
                n--;
            }
            if (p == false)
            {
                Console.Write("(");
            }
            Console.Write("if");
            t.getCdr().getCar().print(1, true);
            Console.WriteLine();
            t.getCdr().getCdr().print(n + 4, true);*/
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }

            Node cdr = t.getCdr();
            Node car = t.getCar();
            Node cddr = t.getCdr().getCdr();
            Console.WriteLine("(if");
            cdr.getCar().print(0, false);
            while (!cddr.isNull())
            {
                cddr.print(n + 4, true);
                cddr = cddr.getCdr();
            }
            cddr.print(n, true);
        }
    }
}

