using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public int Laps { get; set; }

        public int Capacity { get; set; }

        public int MaxHorsePower { get; set; }

        public IList<Car> Participants { get; set; }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            this.Name = name;
            this.Type = type;
            this.Laps = laps;
            this.Capacity = capacity;
            this.MaxHorsePower = maxHorsePower;

            this.Participants = new List<Car>();
        }

        public int Count => this.Participants.Count;

        public void Add(Car car)
        {
            if (!this.Participants.Any(c => c.LicensePlate.Equals(car.LicensePlate)) 
                && this.Count < this.Capacity
                && car.HorsePower <= this.MaxHorsePower)
            {
                this.Participants.Add(car);
            }
        }

        public bool Remove(string licensePlate)
        {
            Car car = this.Participants.FirstOrDefault(c => c.LicensePlate.Equals(licensePlate));

            if (car != null)
            {
                this.Participants.Remove(car);
                return true;
            }
            else 
            {
                return false;
            }
        }

        public Car FindParticipant(string licensePlate)
        {
            return this.Participants.FirstOrDefault(c => c.LicensePlate.Equals(licensePlate));
        }

        public Car GetMostPowerfulCar()
        {
            return this.Participants.OrderByDescending(c => c.HorsePower).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Race: {this.Name} - Type: {this.Type} (Laps: {this.Laps})");

            foreach (var car in this.Participants)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
