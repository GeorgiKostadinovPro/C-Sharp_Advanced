using System;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int enginesCount = int.Parse(Console.ReadLine()); 
            
            Engine[] engines = new Engine[enginesCount];
            

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = engineInfo[0];
                int power = int.Parse(engineInfo[1]);

                Engine engine = null;

                if (engineInfo.Length == 2)
                {
                    engine = new Engine(model, power);
                }
                if (engineInfo.Length == 3)
                {
                    bool isNumber = int.TryParse(engineInfo[2], out int result);
                    
                    if (isNumber)
                    {
                         int displacement = int.Parse(engineInfo[2]);
                         engine = new Engine(model, power, displacement);
                    }
                    else
                    { 
                         string efficiency = engineInfo[2];
                         engine = new Engine(model, power, efficiency);
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    int displacement = int.Parse(engineInfo[2]);
                    string efficiency = engineInfo[3];
                    engine = new Engine(model, power, displacement, efficiency);
                }

                engines[i] = engine;
            }

            int carsCount = int.Parse(Console.ReadLine());
            
            Car[] cars = new Car[carsCount];

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carInfo[0];
                string engineModel = carInfo[1];

                Engine engine = engines
                    .FirstOrDefault(e => e.Model == engineModel);

                Car car = null;

                if (carInfo.Length == 2)
                {
                    car = new Car(model, engine);
                }
                if (carInfo.Length == 3)
                {
                    bool isNumber = int.TryParse(carInfo[2], out int result);

                    if (isNumber)
                    {
                        int weight =  int.Parse(carInfo[2]); 
                        car = new Car(model, engine, weight);
                    }
                    else 
                    { 
                        string color = carInfo[2];
                        car = new Car(model, engine, color);
                    }
                }
                else if (carInfo.Length == 4)
                {
                    int displacement = int.Parse(carInfo[2]);
                    string color = carInfo[3];
                    car = new Car(model, engine, displacement, color);
                }

                cars[i] = car;
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
