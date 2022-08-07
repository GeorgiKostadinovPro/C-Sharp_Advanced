using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<List<Tire>> tires = new List<List<Tire>>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string tireLines = string.Empty;

            while ((tireLines = Console.ReadLine()) != "No more tires")
            {
                string[] tireArgs = tireLines
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<Tire> tiresPerCar = new List<Tire>();

                for (int i = 0; i < tireArgs.Length - 1; i+=2)
                {
                    int year = int.Parse(tireArgs[i]);
                    double pressure = double.Parse(tireArgs[i + 1]); 
                    
                    Tire tire = new Tire(year, pressure);

                    tiresPerCar.Add(tire);
                } 
                
                tires.Add(tiresPerCar);
            }

            string engineLines = string.Empty;

            while ((engineLines = Console.ReadLine()) != "Engines done")
            {
                string[] engineArgs = engineLines
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineArgs[0]);
                double cubicCapacity = double.Parse(engineArgs[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            string carLines = string.Empty;

            while ((carLines = Console.ReadLine()) != "Show special")
            {
                string[] carArgs = carLines
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = carArgs[0];
                string model = carArgs[1];
                int year = int.Parse(carArgs[2]);
                double fuelQuantity = double.Parse(carArgs[3]);
                double fuelConsumption = double.Parse(carArgs[4]);
                int engineIndex = int.Parse(carArgs[5]);
                int tiresIndex = int.Parse(carArgs[6]);

                Engine engine = engines[engineIndex];
                Tire[] carTires = tires[tiresIndex].ToArray();

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, carTires);
                cars.Add(car);
            }

            cars = cars
                .Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10)
                .ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.WhoAmI());
            }
        }
    }
}
