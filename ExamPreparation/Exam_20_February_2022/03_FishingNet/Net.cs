using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;
        private string material;
        private int capacity;

        public Net(string material, int capacity)
        {
            this.Material = material;
            this.Capacity = capacity;

            this.fish = new List<Fish>();
        }

        public int Count => this.fish.Count;

        public List<Fish> Fish
        {
            get { return this.fish; }
        }
        
        public string Material
        {
            get { return this.material; }
            set { this.material = value; }
        }
        
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }

            if (fish.Length <= 0)
            {
                return "Invalid fish.";
            }

            if (fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (this.fish.Count >= this.Capacity)
            {
                return "Fishing net is full.";
            }

            if (!this.fish.Contains(fish))
            {
                this.fish.Add(fish);
            }

            return $"Successfully added {fish.FishType} to the fishing net.";
        }

        public bool ReleaseFish(double weight)
        {
            Fish fish = this.fish.FirstOrDefault(f => f.Weight == weight);

            if (fish != null)
            {
                this.fish.Remove(fish);
                return true;
            }
            else 
            { 
               return false;
            }
        }

        public Fish GetFish(string fishType)
            => this.fish.FirstOrDefault(f => f.FishType == fishType);

        public Fish GetBiggestFish()
            => this.fish.OrderByDescending(f => f.Length).FirstOrDefault();

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {this.Material}:");

            foreach (var fish in this.fish.OrderByDescending(f => f.Length))
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
