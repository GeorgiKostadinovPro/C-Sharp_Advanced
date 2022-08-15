using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.data = new List<Racer>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Racer Racer)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(Racer);
            }
        }

        public bool Remove(string name)
        {
            Racer racer = this.data.FirstOrDefault(r => r.Name == name);

            if (racer != null)
            {
                this.data.Remove(racer);
                return true;
            }
            else 
            {
                return false;
            }
        }

        public Racer GetOldestRacer() 
            => this.data.OrderByDescending(r => r.Age).FirstOrDefault();

        public Racer GetRacer(string name)
            => this.data.FirstOrDefault(r => r.Name == name);

        public Racer GetFastestRacer()
            => this.data.OrderByDescending(r => r.Car.Speed).FirstOrDefault();

        public int Count => this.data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Racers participating at {this.Name}:");

            foreach (var racer in this.data)
            {
                sb.AppendLine(racer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
