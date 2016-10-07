// Begin -- Parse tree node strategy for printing the special form begin

using System;

namespace Tree
{
    public class Begin : Special
    {
        // TODO: Add any fields needed.
 
        // TODO: Add an appropriate constructor.
	public Begin() { }

        public override void print(Node t, int n, bool p)
        {
            // TODO: Implement this function.
            /* while (n > 0)
             {
                 Console.Write(" ");
                 n--;
             }
             if (p == false)
             {
                 Console.Write("(");
             }
             Console.Write("begin");
             Console.WriteLine();
             t.getCdr().print(n + 4, true);*/
            for (int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }

            Node cdr = t.getCdr();
            Console.WriteLine("(begin");
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

