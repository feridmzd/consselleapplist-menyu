using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp33
{
    public class Room
    {
        private static int nextId = 1;
        public int Id { get; }
        public string Name { get; }
        public double Price { get; }
        public int PersonCapacity { get; }
        public bool IsAvailable { get; set; }

        public Room(string name, double price, int personCapacity)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be null or empty.");

            Id = nextId++;
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
            IsAvailable = true;
        }

        public override string ToString()
        {
            return ShowInfo();
        }

        public string ShowInfo()
        {
            return $"Room ID: {Id}, Name: {Name}, Price: {Price}, Capacity: {PersonCapacity}, Available: {(IsAvailable ? "Yes" : "No")}";
        }
    }
}
