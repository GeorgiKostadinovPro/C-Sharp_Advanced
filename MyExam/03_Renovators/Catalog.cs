using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        private string name;
        private int neededRenovators;
        private string project;
        private List<Renovator> renovators;

        public Catalog(string name, int neededRenovators, string project)
        {
            this.Name = name;
            this.NeededRenovators = neededRenovators;
            this.Project = project;

            this.renovators = new List<Renovator>();
        }

        public string Project
        {
            get { return this.project; }
            set { this.project = value; }
        }

        public int NeededRenovators
        {
            get { return this.neededRenovators; }
            set { this.neededRenovators = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Count => this.renovators.Count;

        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Name))
            {
                return "Invalid renovator's information.";
            }

            if (string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (this.renovators.Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }

        public bool RemoveRenovator(string name)
        {
            Renovator renovator = this.renovators
                .FirstOrDefault(r => r.Name.Equals(name));

            if (renovator == null)
            {
                return false;
            }

            this.renovators.Remove(renovator);
            return true;
        }

        public int RemoveRenovatorBySpecialty(string type)
        {
            int renovatorsToRemoveCount = this.renovators
                .Count(r => r.Type.Equals(type));

            if (renovatorsToRemoveCount <= 0)
            {
                return 0;
            }

            this.renovators.RemoveAll(r => r.Type.Equals(type));
                
            return renovatorsToRemoveCount;
        }

        public Renovator HireRenovator(string name)
        {
            Renovator renovator = this.renovators
               .FirstOrDefault(r => r.Name.Equals(name));

            if (renovator == null)
            {
                return null;
            }

            renovator.Hired = true;
            return renovator;
        }
        public List<Renovator> PayRenovators(int days)
        {
            return this.renovators.Where(r => r.Days >= days).ToList();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Renovators available for Project {this.project}:");

            foreach (var renovator in this.renovators.Where(r => r.Hired == false))
            {
                sb.AppendLine(renovator.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
