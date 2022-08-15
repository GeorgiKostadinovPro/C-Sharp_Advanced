using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.Capacity = capacity;

            this.students = new List<Student>();
        }

        public int Capacity { get; set; }
        public int Count => this.students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.students.Count >= this.Capacity)
            {
                return "No seats in the classroom";
            }

            this.students.Add(student);
            return $"Added student {student.FirstName} {student.LastName}";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student student = this.students
                .FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);

            if (student == null)
            {
                return "Student not found";
            }

            this.students.Remove(student);
            return $"Dismissed student {student.FirstName} {student.LastName}";
        }

        public string GetSubjectInfo(string subject)
        {
            if (!this.students.Any(s => s.Subject == subject))
            {
                return "No students enrolled for the subject";
            }
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");

            foreach (var student in this.students)
            {
                if (student.Subject == subject)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetStudentsCount() => $"{this.Count}";

        public Student GetStudent(string firstName, string lastName)
            => this.students.FirstOrDefault(s => s.FirstName == firstName && s.LastName == lastName);
    }
}
