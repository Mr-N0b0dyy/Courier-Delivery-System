using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_o4_a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Customercarts = new int[] { 6, 7, 2, 1, 12, 5, 3, 7, 4, 2 }; // Array that holds number of products each customer have in their cart.
            Queue CustomerTransactions = new Queue(Customercarts.Length); // Queue that holds number of products each customer have in their cart.
            foreach (int customer in Customercarts) // Inserts product numbers in Queue
            {
               CustomerTransactions.enque(customer);
            }
            int processtime = 3; // Amount of time that cashier spends for scanning each product
            int SumofTimes = 0; //Total time that pases in this particular checkout
            int SumOfEachcustomertime = 0; //Sum of times each customer spends at checkout
            int Numberofcustomers = CustomerTransactions.Size; 
            for (int i = 0; i < Numberofcustomers; i++)
            {
                int customerCart = CustomerTransactions.deque(); //Number of items this customer have in their cart
                int thisprocesstime = (customerCart * processtime); //Seconds cashier spends scanning this customer's products
                int timethiscustomerspends = thisprocesstime + SumofTimes; // Seconds this customer spends in checkout
                SumofTimes+=thisprocesstime;
                SumOfEachcustomertime += timethiscustomerspends;
                Console.WriteLine((i + 1) + ". customer stayed: " + timethiscustomerspends + " seconds at checkout.");
                
            }
            Console.WriteLine("Average time a customer stays at checkout is: " + (Convert.ToDouble(SumOfEachcustomertime)/Convert.ToDouble(Numberofcustomers)) + (" seconds."));
        }
    }
    class Queue
    {
        private int size;
        private int[] QueueArray;
        private int head, tail;
        private int NumberOfElements;
        public Queue(int s) // Constructor
        {
            size = s;
            QueueArray = new int[size];
            head = 0; tail = -1; NumberOfElements = 0;
        }
        public void enque(int j) // Adds an element to the tail
        {
            if (tail == size - 1) // Possibility of a full circle
                tail = -1;
            QueueArray[++tail] = j; // Increases the tail and adds to the index that tail points
            NumberOfElements++;
        }
        public int deque() // Removes an element from the head
        {
            int temp = QueueArray[head++]; // Gets the element and increases head
            if (head == size) // Possibility of a full circle
                head = 0;
            NumberOfElements--;
            return temp;
        }
        public bool isEmpty() // true, if it is empty
        {
            return (NumberOfElements == 0);
        }
        public int Size { get { return size; } } //For finding the number of neighborhoods easily
    }

}
