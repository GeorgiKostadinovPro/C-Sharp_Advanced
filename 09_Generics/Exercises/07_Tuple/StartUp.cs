using System;
using System.Linq;

namespace Tuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personAndAddress = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string personFullName = personAndAddress[0] + " " + personAndAddress[1];
            string personAddress = personAndAddress[2];

            string[] personAndBeer = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string personName = personAndBeer[0];
            int personAmountOfBeer = int.Parse(personAndBeer[1]);

            string[] integerAndDouble = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int integer = int.Parse(integerAndDouble[0]);
            double @double = double.Parse(integerAndDouble[1]);

            Tuple<string, string> personWithAddress = new Tuple<string, string>(personFullName, personAddress);
            Tuple<string, int> personAndAmountOfBeer = new Tuple<string, int>(personName, personAmountOfBeer);
            Tuple<int, double> numbers = new Tuple<int, double>(integer, @double);

            Console.WriteLine(personWithAddress.ToString());
            Console.WriteLine(personAndAmountOfBeer.ToString());
            Console.WriteLine(numbers.ToString());
        }
    }
}
