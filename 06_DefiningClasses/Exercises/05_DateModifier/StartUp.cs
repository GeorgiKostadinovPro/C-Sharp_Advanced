using System;
using System.Linq;

namespace DateModifier
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier(firstDate, secondDate);
            int daysDifference = dateModifier.GetDaysDifference();

            Console.WriteLine(daysDifference);
        }
    }
}
