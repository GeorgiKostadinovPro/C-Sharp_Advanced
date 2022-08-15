using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public string Type { get; set; }

        public int Capacity { get; set; }

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.data = new List<Car>();
        }

        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if(this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            Car car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            bool isRemoved = false;

            if(car != null)
            {
                this.data.Remove(car);
                isRemoved = true;
            }

            return isRemoved;
        }

        public Car GetLatestCar()
        {
            Car latestCar = this.data.OrderByDescending(c => c.Year).FirstOrDefault();
            return latestCar;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = this.data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            return car;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            for (int i = 0; i < this.data.Count; i++)
            {
                sb.AppendLine(this.data[i].ToString());
            }
                
            return sb.ToString().TrimEnd();
        }
    }
}
