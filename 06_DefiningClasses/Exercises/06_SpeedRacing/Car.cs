using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        private Car()
        {
            this.TravelledDistance = 0;
        }

        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
            : this()
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }

        public string Model
        {
            get { return this.model; }
            private set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            private set { this.fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return this.fuelConsumptionPerKilometer; }
            private set { this.fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return this.travelledDistance; }
            private set { this.travelledDistance = value; }
        }

        public void Drive(double amountOfKm)
        {
            double fuelLeft = this.FuelAmount - (this.FuelConsumptionPerKilometer * amountOfKm);

            if (fuelLeft < 0)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }

            this.FuelAmount = fuelLeft;
            this.TravelledDistance += amountOfKm;
        }

        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:f2} {this.TravelledDistance}";
        }
    }
}
