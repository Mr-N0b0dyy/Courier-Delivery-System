using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_o4_b
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Customercarts = new int[] { 6, 7, 2, 1, 12, 5, 3, 7, 4, 2 }; // Array that holds number of products each customer have in their cart.
            PriorityQueue CustomerTransactions = new PriorityQueue(); // Queue that holds number of products each customer have in their cart.
            foreach (int customer in Customercarts) // Inserts product numbers in Queue
            {
                CustomerTransactions.enque(customer);
            }
            int processtime = 3; // Amount of time that cashier spends for scanning each product
            int SumofTimes = 0; //Total time that pases in this particular checkout
            int SumOfEachcustomertime = 0; //Sum of times each customer spends at checkout
            int Numberofcustomers = CustomerTransactions.Elemnum();
            for (int i = 0; i < Numberofcustomers; i++)
            {
                int customerCart = CustomerTransactions.deque(); //Number of items this customer have in their cart
                int thisprocesstime = (customerCart * processtime); //Seconds cashier spends scanning this customer's products
                int timethiscustomerspends = thisprocesstime + SumofTimes; // Seconds this customer spends in checkout
                SumofTimes += thisprocesstime;
                SumOfEachcustomertime += timethiscustomerspends;
                Console.WriteLine((i + 1) + ". customer stayed: " + timethiscustomerspends + " seconds at checkout.");
                
            }
            Console.WriteLine("Average time a customer stays at checkout is: " + (Convert.ToDouble(SumOfEachcustomertime) / Convert.ToDouble(Numberofcustomers)) + (" seconds."));
        }
    }
    class PriorityQueue
    {
        private List<int> QueueList; // List that holds integers.
        public PriorityQueue() // Constructor
        {
            QueueList = new List<int>();
        }
        public void enque(int j) //Just adds the new integer to the list.
        {
            QueueList.Add(j);
        }
        public int deque() // After finding the integer which corresponds to the customer that has lowest number of products in their cart  by comparing them to a temprary value it prints that integer and removes it from the list.
        {
            int temp = 0;
            int max = int.MaxValue;
            foreach (int m in QueueList)
            {
                if (m <= max)
                {
                    max = m;
                    temp = m;
                }
            }
            QueueList.Remove(temp);
            return temp;
        }
        public bool isEmpty() // true, if it is empty
        {
            return (QueueList.Count == 0);
        }
        public int Elemnum() { return QueueList.Count; } //For finding the number of integers easily.

    }
}
