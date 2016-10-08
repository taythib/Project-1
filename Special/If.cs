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
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }

            Node cdr = t.getCdr();
            Node car = t.getCar();
            Node cddr = t.getCdr().getCdr();
            Console.Write("(if ");
            cdr.getCar().print(0, false);
            Console.WriteLine();
            while (!cddr.isNull())
            {
                if(cddr.getCar().isPair())
                    cddr.getCar().print(n + 4, false);
                else
                    cddr.getCar().print(n + 4, true);
                cddr = cddr.getCdr();
                Console.WriteLine();
            }
            cddr.print(n, true);
        } 
    }
}

