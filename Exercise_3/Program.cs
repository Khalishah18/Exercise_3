using System;
using System.Collections;
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
        public Node next; //point to the succeding node

    }
    class CircularList
    {
        Node LAST;

        public CircularList()
        {
            LAST = null;
        }
        public void addNode() //add a node in the list
        {
            int rollNumber;
            string nm;
            Console.WriteLine("\nEnter the roll number of the student: ");
            rollNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the roll name of the student: ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNumber;
            newnode.name = nm;

            //if the node to be inserted is the first node
            if ((LAST == null) || rollNumber <= LAST.rollNumber)
            {
                if ((LAST != null) && (rollNumber == LAST.rollNumber))
                {
                    Console.WriteLine();
                    return;
                }
                newnode.next = LAST;
                LAST = newnode;
                return;
            }

            Node previous, current;
            previous = LAST;
            current = LAST;

            while ((current != null) && (rollNumber >= current.rollNumber))
            {
                if (rollNumber == current.rollNumber)
                {
                    Console.WriteLine();
                    return;
                }
                previous.next = current;
                previous.next = newnode;
            }
            newnode.next = current;
            previous.next = newnode;
        }
        public bool Search(int rollNumber, ref Node previous, ref Node current)/*Seaches for the specofoed node*/
        {
            for (previous = current = LAST.next; current != LAST; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                    return (true); /* return true if the node is found*/
            }
            if (rollNo == LAST.rollNumber) /* if the node is present at the  end*/
                return true;
            else
                return (false); /*return false if the node is not found*/
        }

        public bool listEmpty()
        {
            if (LAST == null)
                return true;
            else
                return false;
        }
        public void traverse() /* Traverses all the nodes of the list */
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecords in the list are : \n");
                Node currentNode;
                currentNode = LAST.next;
                while (currentNode != LAST)
                {
                    Console.Write(currentNode.rollNumber + "" + currentNode.name + "\n");
                    currentNode = currentNode.next;
                }
                Console.Write(LAST.rollNumber + " " + LAST.name + "\n");
            }
        }
        public void firstNode()
        {
            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
                Console.WriteLine("\nThe first record in the list is: \n\n " + LAST.next.rollNumber + "" + LAST.next.name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CircularList obj = new CircularList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. View all the records in the list");
                    Console.WriteLine("2. Search for a record in the list");
                    Console.WriteLine("3. Display the first record in the list");
                    Console.WriteLine("4. Exit");
                    Console.Write("\nEnter your choice (1-4) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nRoll number: " + curr.rollNumber);
                                    Console.WriteLine("\nName: " + curr.name);
                                }
                            }
                            break;
                        case '3':
                            {
                                obj.firstNode();
                            }
                            break;
                        case '4':
                            return;
                        default:
                            {
                                Console.WriteLine("Invalid Option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
