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
            Node cdr = t.getCdr();
            Node car = t.getCar();
            if(car.isPair())
            {
                car.print(0, false);
            }
            else
                car.print(0, true);
            if (cdr.isPair() || cdr.isNull())
            {
                if (cdr.isNull())
                    cdr.print(0, true);
                else
                {
                    Console.Write(" ");
                    cdr.print(0, true);
                }
            }
            else
            {
                Console.Write(".");
                cdr.print(n, true);
                Console.Write(")");
            }
        }
    }
}


