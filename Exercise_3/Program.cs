using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class Node
    {
        /*creates Nodes for the circular nexted list*/
        public int rollNumber;
        public string name;
        public Node next;
    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }
        public bool Search(int rollNo, ref Node previous, ref Node current)/*Seaches for the specofoed node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true); /* returns true if the node is found */
            }
            if (rollNo == LAST.rollNumber) /* if the node is present at the end*/
                return true;
            else
                return (false); /*returns false if the node is not found*/
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
