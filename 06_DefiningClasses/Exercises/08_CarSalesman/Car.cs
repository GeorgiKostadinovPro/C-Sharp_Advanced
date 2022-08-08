using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        private string model;
        private Engine engine;
        private int? weight;
        private string color;

        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight) : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color) : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color) : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public Engine Engine
        {
            get { return this.engine; }
            private set { this.engine = value; }
        }

        public int? Weight
        {
            get { return this.weight; }
            private set { this.weight = value; }
        }

        public string? Color
        {
            get { return this.color; }
            private set { this.color = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine(this.Engine.ToString());

            string weight = this.Weight != null ? this.Weight.ToString() : "n/a";
            string color = this.Color != null ? this.Color : "n/a";

            sb.AppendLine($"  Weight: {weight}");
            sb.AppendLine($"  Color: {color}");

            return sb.ToString().TrimEnd();
        }
    }
}
