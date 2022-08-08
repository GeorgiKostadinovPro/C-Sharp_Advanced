using System;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine()); 
            
            Car[] cars = new Car[n];

            for (int i = 0; i < n; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];

                int engineSpeed = int.Parse(carInfo[1]);
                int enginePower = int.Parse(carInfo[2]);

                int cargoWeight = int.Parse(carInfo[3]);
                string cargoType = carInfo[4];

                double firstTirePressure = double.Parse(carInfo[5]);
                int firstTireAge = int.Parse(carInfo[6]);
                double secondTirePressure = double.Parse(carInfo[7]);
                int secondTireAge = int.Parse(carInfo[8]);
                double thirdTirePressure = double.Parse(carInfo[9]);
                int thirdTireAge = int.Parse(carInfo[10]);
                double fourthTirePressure = double.Parse(carInfo[11]);
                int fourthTireAge = int.Parse(carInfo[12]);

                Engine carEngine = new Engine(engineSpeed, enginePower);
                Cargo carCargo = new Cargo(cargoType, cargoWeight);

                Tire[] carTires = new Tire[4]
                {
                    new Tire(firstTireAge, firstTirePressure),
                    new Tire(secondTireAge, secondTirePressure),
                    new Tire(thirdTireAge, thirdTirePressure),
                    new Tire(fourthTireAge, fourthTirePressure),
                };

                Car car = new Car(model, carEngine, carCargo, carTires);
                cars[i] = car;
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                cars = cars
                    .Where(c => c.Cargo.Type == command && c.Tires.Any(t => t.Pressure < 1))
                    .ToArray();
            }
            else if (command == "flammable")
            {
                cars = cars
                    .Where(c => c.Cargo.Type == command && c.Engine.Power > 250)
                    .ToArray();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
