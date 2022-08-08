using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private IList<Car> cars;

        private int capacity;

        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.cars = new List<Car>();
        }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            if (this.cars.Any(c => c.RegistrationNumber.Equals(car.RegistrationNumber)))
            {
                return "Car with that registration number, already exists!";
            }

            if (this.cars.Count >= this.capacity)
            {
                return "Parking is full!";
            }

            this.cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            Car car = this.cars
                .FirstOrDefault(c => c.RegistrationNumber.Equals(registrationNumber));

            if (car == null)
            {
                return "Car with that registration number, doesn't exist!";
            }
            
            this.cars.Remove(car);
            return $"Successfully removed {registrationNumber}";
        }

        public Car GetCar(string registrationNumber)
        { 
            Car car = this.cars
                .FirstOrDefault(c => c.RegistrationNumber.Equals(registrationNumber));

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var registrationNumber in registrationNumbers)
            {
                Car car = this.cars.FirstOrDefault(c => c.RegistrationNumber.Equals(registrationNumber));

                if (car != null)
                {
                    this.cars.Remove(car);
                }
            }
        }
    }
}
