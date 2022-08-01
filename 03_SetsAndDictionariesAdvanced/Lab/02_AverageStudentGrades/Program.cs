using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AverageStudentGrades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string studentName = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!students.ContainsKey(studentName))
                {
                    students.Add(studentName, new List<decimal>());
                }

                students[studentName].Add(grade);
            }

            foreach (var student in students)
            {
                Console.WriteLine($"{student.Key} -> {string.Join(' ', student.Value.Select(x => $"{x:f2}"))} (avg: {student.Value.Average():f2})");
            }
        }
    }
}
