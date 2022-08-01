using System;
using System.Collections.Generic;

namespace _07_ParkingLot
{

    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<string> parkingLot = new HashSet<string>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "END")
            {
                string[] cmdArgs = line
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];
                string carNumber = cmdArgs[1];

                if (cmd == "IN")
                {
                    parkingLot.Add(carNumber);
                }
                else if (cmd == "OUT")
                {
                    parkingLot.Remove(carNumber);
                }
            }

            string result = parkingLot.Count > 0 ? string.Join(Environment.NewLine, parkingLot) : "Parking Lot is Empty";

            Console.WriteLine(result);
       }
    }
}
