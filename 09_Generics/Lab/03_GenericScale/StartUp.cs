using System;

namespace GenericScale
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string firstStr = "George";
            string secondStr = "Lyubo";

            EqualityScale<string> equalityScale 
                = new EqualityScale<string>(firstStr, secondStr);

            bool areEqual = equalityScale.AreEqual();

            Console.WriteLine(areEqual);
        }
    }
}
