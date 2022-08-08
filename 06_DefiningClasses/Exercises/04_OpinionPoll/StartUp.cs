using System;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new Family();

            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] memberInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string name = memberInfo[0];
                int age = int.Parse(memberInfo[1]);

                Person person = new Person(name, age);
                family.AddMember(person);
            }

            Person[] peopleWithAgeMoreThan30 = family.Members
                .Where(p => p.Age > 30)
                .OrderBy(p => p.Name)
                .ToArray();

            foreach (var person in peopleWithAgeMoreThan30)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
