using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p2_o3
{
    internal class Program
    {
        static Random r = new Random(); //Defines a random value.
        static string[] Food =
        {"Pizza","Hamburger","Cheeseburger","Köfte","Tavuk şiş", "Kuzu şiş", "Pirzola", "Kanat Kova", "Kebap", "Lahmacun"}; // A random list of foods that could be used later. (Could be increased without tmepering with anything else)
        static void Main(string[] args)
        {
            // Names of neighborhoods and orders of said neighborhoods they could be increased withoud tempering with anything else however they need to be the same size at all times.
            string[] MahalleAdi =
                { "Özkanlar", "Evka 3", "Atatürk", "Erzene", "Kazımdirik", "Mevlana", "Doğanlar", "Ergene"};
            int[] TeslimatSayisi = { 5, 2, 7, 2, 7, 3, 0, 1 };
            PriorityQueue neighborhoods = Compounddatastructure(MahalleAdi, TeslimatSayisi); // Queue gets defined.
            int ordersSum = 0; // Counter for  number of total orders
            int nNeighbor = neighborhoods.Elemnum();// Since we clear the list in the middle we assign Number of neighborhoods that we get from the compound data structure to a temporary value.
            //Prints the compound data structure
            for (int i = 0; i < MahalleAdi.Length; i++)
            {
                Mahalle a = neighborhoods.deque();
                Console.Write(a.Nname + ": ");
                foreach (teslimat b in a.Deliverylist)
                {
                    Console.Write("|" + b.Fname + ", " + b.Fnumber + "|");
                    ordersSum++;
                }
                Console.WriteLine(" ");
            }
            // Prints the requirements of 1.c
            Console.WriteLine("Number of neighborhoods: " + nNeighbor);
            Console.WriteLine("Total amount of orders: " + ordersSum);
        }

        //Inserts everything in the compound data structure in its place
        static PriorityQueue Compounddatastructure(string[] MahalleAdi, int[] TeslimatSayisi)
        {
            PriorityQueue neigborhoods = new PriorityQueue(); 
            for (int a = 0; a < MahalleAdi.Length; a++)
            {
                string temp = MahalleAdi[a]; // Temporary string that holds current neighborhood name
                Mahalle New = new Mahalle(temp); // Neighborhood gets created
                for (int b = 0; b < TeslimatSayisi[a]; b++) // Inserts random food names and numbers in Neigborhood's Generic list.
                {
                    int food = r.Next(0, Food.Length);
                    string foodname = Food[food];
                    int foodnumber = r.Next(1, 10);
                    New.Deliverylist.Add(new teslimat(foodname, foodnumber));
                }
                neigborhoods.enque(New); // New neighborhood gets added to the queue
            }
            
            return neigborhoods;
        }
    }
    public class Mahalle
    {
        private string nname; // Name of the neighborhood
        private List<teslimat> deliverylist = new List<teslimat>(); // List that holds orders of the said neighborhood
        public Mahalle(string nname) //Constructor
        {
            this.nname = nname;
        }
        //Getters
        public string Nname
        {
            get { return nname; }
        }
        public List<teslimat> Deliverylist
        {
            get { return deliverylist; }
        }
    }
    public class teslimat
    {
        private string fname; // Name of the food
        private int fnumber; // Number of said food

        public teslimat(string fname, int fnumber) //Constructor
        {
            this.fname = fname;
            this.fnumber = fnumber;
        }
        //Getters
        public string Fname
        {
            get { return fname; }
        }
        public int Fnumber
        {
            get { return fnumber; }
        }
    }

    class PriorityQueue
    {
        private List<Mahalle> QueueList; // List that holds neighborhoods
        public PriorityQueue() // Constructor
        {
            QueueList = new List<Mahalle>();
         }
        public void enque(Mahalle j) //Just adds the new neighborhood to the list.
        {
            QueueList.Add(j); 
        }
        public Mahalle deque() // After finding the neighborhood which highest number of orders came from by comparing them to a temprary value it prints that neighborhood and removes it from the list.
        {
            Mahalle temp = null;
            int min = -1; // Since there could be 0 orders...
            foreach (Mahalle m in QueueList)
            {
                if (m.Deliverylist.Count >= min)
                {
                    min = m.Deliverylist.Count;
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
        public int Elemnum() { return QueueList.Count; } //For finding the number of neighborhoods easily

    }
}
