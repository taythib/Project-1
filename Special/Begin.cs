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
            for(int i = 0; i < n; i++)
            {
                Console.Write(" ");
            }
            if(p == true)
            {
                Console.Write("(");
            }
            Console.Write("begin ")
            t.getCar().print();
        }
    }
}

