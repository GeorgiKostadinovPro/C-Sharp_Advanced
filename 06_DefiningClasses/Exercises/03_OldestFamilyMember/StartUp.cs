using System;

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

                Person member = new Person(name, age);
                family.AddMember(member);
            }

            Person oldestMember = family.GetOldestMember();

            Console.WriteLine(oldestMember.ToString());
        }
    }
}
