using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> skis;

        public SkiRental(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.skis = new List<Ski>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Ski ski)
        {
            if (!this.skis.Contains(ski) && this.skis.Count < this.Capacity)
            {
                this.skis.Add(ski);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Ski ski = this.skis.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);

            if (ski != null)
            {
                this.skis.Remove(ski);
                return true;
            }
            else 
            {
                return false;
            }
        }

        public Ski GetNewestSki()
            => this.skis.OrderByDescending(s => s.Year).FirstOrDefault();

        public Ski GetSki(string manufacturer, string model)
            => this.skis.FirstOrDefault(s => s.Manufacturer == manufacturer && s.Model == model);

        public int Count => this.skis.Count;

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The skis stored in {this.Name}:");

            foreach (var ski in this.skis)
            {
                sb.AppendLine(ski.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
