// Regular -- Parse tree node strategy for printing regular lists

using System;

namespace Tree
{
    public class Regular : Special
    {
        // TODO: Add any fields needed.
    
        // TODO: Add an appropriate constructor.
        public Regular() { }

        public override void print(Node t, int n, bool p)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            if (!p)
                Console.Write("(");
            else
                Console.Write(" ");
            Node cdr = t.getCdr();
            Node car = t.getCar();
            car.print(n, true);
            if (cdr.isPair() || cdr.isNull())
            {
                if (cdr.getCar().isPair())
                    cdr.print(n, false);
                else
                    cdr.print(n, true);
            }
            else
            {
                Console.Write(". ");
                cdr.print(n, true);
                Console.Write(")");
            }
        }
    }
}


