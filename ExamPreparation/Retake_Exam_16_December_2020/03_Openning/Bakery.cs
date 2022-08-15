using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private IList<Employee> data;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.data = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public void Add(Employee employee)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            Employee employee = this.data.FirstOrDefault(e => e.Name == name);

            if (employee != null)
            {
                this.data.Remove(employee); 
                return true;
            }
            else 
            { 
                return false;
            }
        }

        public Employee GetOldestEmployee()
            => this.data.OrderByDescending(e => e.Age).FirstOrDefault();

        public Employee GetEmployee(string name)
            =>this.data.FirstOrDefault(e => e.Name == name);

        public int Count => this.data.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in this.data)
            {
                sb.AppendLine(employee.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
