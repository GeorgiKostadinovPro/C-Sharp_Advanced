﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        private Clinic()
        {
            this.data = new List<Pet>();
        }

        public Clinic(int capacity) : this()
        {
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }

        public int Count => this.data.Count;

        public void Add(Pet pet)
        {
            if(this.data.Count + 1 <= this.Capacity)
            {
                this.data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = this.data.FirstOrDefault(p => p.Name == name);

            if(pet != null)
            {
                this.data.Remove(pet);
                return true;
            }

            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = this.data.FirstOrDefault(p => p.Name == name && p.Owner == owner);

            return pet;
        }

        public Pet GetOldestPet()
        {
            Pet pet = this.data.OrderByDescending(p => p.Age).FirstOrDefault();

            return pet;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            for (int i = 0; i < this.data.Count; i++)
            {
                sb.AppendLine($"Pet {this.data[i].Name} with owner: {this.data[i].Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
