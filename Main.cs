using System;
using System.Linq;
using System.Collections.Generic;

public class Program
{
	public static void Main()
	{
		 Filter();
            Ordering();
            Partitioning();
            Custom();
	}
	static void Filter()
        {
            // Find the words in the collection that start with the letter 'L'
           
		    List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };
            IEnumerable<string> LFruits = from fruit in fruits
            where fruit[0] == 'L'
            select fruit;
            Console.WriteLine("1) Fruit's name start with L:");
		    Console.WriteLine();
            foreach (string aFruit in LFruits)
            {
                Console.WriteLine(aFruit);
            }

            // Find multiples of 4 or 6
            List<int> numbers = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };
            IEnumerable<int> fourSixMultiples = numbers.Where(n => n % 4 == 0 || n % 6 == 0).OrderBy(n => n);
            Console.WriteLine();
            Console.WriteLine("2) Multiples of 4 or 6: ");
		    Console.WriteLine();
            foreach (int number in fourSixMultiples)
            {
                Console.WriteLine(number);
            }
        }
        static void Ordering()
        {
            // Find names in descending order (Z to A)
            List<string> names = new List<string>()
            {
                "Heena",
                "James",
                "Xero",
                "Mimy",
                "Babul",
                "Nina",
                "Karma",
                "Sophia",
                "Amir",
                "Devendra",
                "Zoya",
                "Babalu",
                "Tina",
                "William",
                "Seema",
                "Cherry",
                "Yash",
                "Grey",
                "John",
                "Eliana",
                "Vikram",
                "Jacqueline",
                "Farid",
                "Tushar"
            };
            List<string> descend = names.OrderByDescending(n => n).ToList();
            Console.WriteLine();
            Console.WriteLine("3) Names in descending order:");
			Console.WriteLine();
            descend.ForEach(name => Console.WriteLine(name));

            // Find numbers in ascending order
            List<int> numbers = new List<int>()
            {
                15,
                8,
                21,
                24,
                32,
                13,
                30,
                12,
                7,
                54,
                48,
                4,
                49,
                96
            };
            List<int> ascend = numbers.OrderBy(n => n).ToList();
            Console.WriteLine();
            Console.WriteLine("4) Numbers in ascending order:");
			Console.WriteLine();
            ascend.ForEach(num => Console.WriteLine(num));
        }
       
        static void Partitioning()
        {
            List<int> wheresSquaredo = new List<int>()
            {
                66,
                12,
                8,
                27,
                82,
                34,
                7,
                50,
                19,
                46,
                81,
                23,
                30,
                4,
                68,
                14
            };
            /*
                Store each number in the List until a perfect square
                is detected.
               
            */
            List<int> imperfectSquares = wheresSquaredo.TakeWhile(num => Math.Sqrt(num) % 1 != 0).ToList();
			Console.WriteLine();
			Console.WriteLine("5) Numbers that are not perfect square;");
            Console.WriteLine();
            imperfectSquares.ForEach(num => Console.WriteLine(num));
        }
        static void Custom()
        // Find number of customers who are millionaires per bank
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer() { Name = "Bobby Deol", Balance = 80345.66, Bank = "SBI" },
                new Customer() { Name = "John Henry", Balance = 9284756.21, Bank = "HDFC" },
                new Customer() { Name = "Radhe Pandit", Balance = 487233.01, Bank = "CITY" },
                new Customer() { Name = "Piyush Meghe", Balance = 7001449.92, Bank = "CITY" },
                new Customer() { Name = "Mike Johnson", Balance = 790872.12, Bank = "HDFC" },
                new Customer() { Name = "Rowl Paul", Balance = 8374892.54, Bank = "HDFC" },
                new Customer() { Name = "Sid Shain", Balance = 957436.39, Bank = "SBI" },
                new Customer() { Name = "Sara Negi", Balance = 56562389.85, Bank = "SBI" },
                new Customer() { Name = "Tina Dube", Balance = 1000000.00, Bank = "ICIC" },
                new Customer() { Name = "Sid Bonde", Balance = 49582.68, Bank = "ICIC" }
            };
            List<Customer> millionaires = customers.Where(customer => customer.Balance >= 1000000).ToList();
           
            List<Bank> bankMillionaire = (from millionaire in millionaires group millionaire by millionaire.Bank into bankCustomer select new Bank
            {
                Name = bankCustomer.Key,
                    Count = bankCustomer.Count()
            }).ToList();

            Console.WriteLine();
			Console.WriteLine("6) Millionaire Customer per bank:");
			Console.WriteLine();
            bankMillionaire.ForEach(bank => Console.WriteLine(bank.Name+" "+bank.Count));
        }
        public class Customer
        {
            public string Name { get; set; }
            public double Balance { get; set; }
            public string Bank { get; set; }
        }
        public class Bank
        {
            public string Name { get; set; }
            public int Count { get; set; }
        }
}