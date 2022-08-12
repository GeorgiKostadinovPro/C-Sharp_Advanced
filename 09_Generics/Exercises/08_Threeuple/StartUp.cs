using System;
using System.Linq;

namespace Threeuple
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] personsAddressAndTown = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string personFullName = personsAddressAndTown[0] + " " + personsAddressAndTown[1];
            string personAddress = personsAddressAndTown[2];
            string personTown = personsAddressAndTown[3];

            string[] personAndBeer = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string personName = personAndBeer[0];
            int personAmountOfBeer = int.Parse(personAndBeer[1]);
            bool isDrunk = personAndBeer[2] == "drunk" ? true : false;

            string[] personBankBalanceAndBankName = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string personWithBankBalanceName = personBankBalanceAndBankName[0];
            double personBankBalance = double.Parse(personBankBalanceAndBankName[1]);
            string personBankName = personBankBalanceAndBankName[2];

            Threeuple<string, string, string> personBankBalanceAndBank =
                 new Threeuple<string, string, string>(personFullName, personAddress, personTown);
            
            Threeuple<string, int, bool> personWithBeer =
                 new Threeuple<string, int, bool>(personName, personAmountOfBeer, isDrunk);

            Threeuple<string, double, string> personWithBankBalance =
                 new Threeuple<string, double, string>(personWithBankBalanceName, personBankBalance, personBankName);

            Console.WriteLine(personBankBalanceAndBank);
            Console.WriteLine(personWithBeer);
            Console.WriteLine(personWithBankBalance);
        }
    }
}
