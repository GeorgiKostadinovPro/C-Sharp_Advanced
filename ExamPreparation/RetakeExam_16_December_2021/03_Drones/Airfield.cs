using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private string name;
        private int capacity;
        private double landingStrip;
        private List<Drone> drones;

        public Airfield(string name, int capacity, double landingStrip)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.LandingStrip = landingStrip;

            this.drones = new List<Drone>();
        }
        public ICollection<Drone> Drones => this.drones;

        public double LandingStrip 
        {
            get { return this.landingStrip; }
            set { this.landingStrip = value; }
        }
        public int Capacity
        {
            get { return this.capacity; }
            set { this.capacity = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Count => this.drones.Count;

        public string AddDrone(Drone drone)
        {
            if (string.IsNullOrEmpty(drone.Name))
            {
                return "Invalid drone.";
            }

            if (string.IsNullOrEmpty(drone.Brand))
            {
                return "Invalid drone.";
            }

            if (drone.Range < 5 || drone.Range > 15)
            {
                return "Invalid drone.";
            }

            if (this.drones.Count >= this.Capacity)
            {
                return "Airfield is full.";
            }

            this.drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }

        public bool RemoveDrone(string name)
        {
            Drone drone = this.drones.FirstOrDefault(d => d.Name == name);

            if (drone != null)
            {
                this.drones.Remove(drone);
                return true;
            }
            else 
            {
                return false;
            }
        }

        public int RemoveDroneByBrand(string brand)
        {
            int countBrand = this.drones.Count(d => d.Brand == brand);

            if (countBrand > 0)
            {
                this.drones.RemoveAll(drones => drones.Brand == brand);
                return countBrand;
            }
            else 
            {
                return 0;
            }
        }

        public Drone FlyDrone(string name)
        {
            Drone drone = this.drones.FirstOrDefault(d => d.Name == name);

            if (drone != null)
            {
                  drone.Available = false;
            }

            return drone;
        }

        public List<Drone> FlyDronesByRange(int range)
        { 
            List<Drone> dronesToFly =  this.drones.Where(d => d.Range >= range).ToList();

            foreach (var drone in dronesToFly)
            {
                drone.Available = false;
            }

            return dronesToFly;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Drones available at {this.Name}:");

            foreach (var drone in this.drones.Where(d => d.Available == true))
            {
                sb.AppendLine(drone.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
