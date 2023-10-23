using System;
using _23_10_23.Models;

namespace _23_10_23
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1 V1

            List<Person> peopleList = new List<Person>
            {
                new Person { Name = "Ryan", Surname = "Gosling", Age = 41 },
                new Person { Name = "Dorati", Surname = "Antal", Age = 22 },
                new Person { Name = "Nova", Surname = "Novakova", Age = 30 },
                new Person { Name = "John", Surname = "Wick", Age = 35 },
                new Person(){Name = "Eichmann", Surname="Novakov", Age = 31}
            };

            var searchedPerson = peopleList.FindAll(person => person.Name.ToLower() == "ryan");
            Console.WriteLine("People with the name Ryan:");
            foreach (var person in searchedPerson)
            {
                Console.WriteLine($"Name: {person.Name} Surname: {person.Surname}, Age: {person.Age}");
            }

            var matchingPeople = peopleList.FindAll(person => person.Surname.ToLower().EndsWith("ova", StringComparison.OrdinalIgnoreCase) || person.Surname.ToLower().EndsWith("ov", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("\nStudents with matching last names:");
            foreach (var person in matchingPeople)
            {
                Console.WriteLine($"Name:{person.Name}, Surname: {person.Surname}, Age: {person.Age}");
            }

            var olderPeople = peopleList.FindAll(person => person.Age >= 20);
            Console.WriteLine("\nPeople aged 20 or older:");
            foreach (var person in olderPeople)
            {
                Console.WriteLine($"Name: {person.Name}, Surname: {person.Surname}, Age: {person.Age}");
            }

            #endregion

            Console.WriteLine();

            #region Task 1 V2

            List<Person> peopleList2 = new List<Person>
            {
                new Person { Name = "Ryan", Surname = "Gosling", Age = 41 },
                new Person { Name = "Dorati", Surname = "Antal", Age = 22 },
                new Person { Name = "Nova", Surname = "Novakova", Age = 30 },
                new Person { Name = "John", Surname = "Wick", Age = 35 },
                new Person(){Name = "Eichmann", Surname="Novakov", Age = 31}
            };

            Console.WriteLine("People with the name Ryan:");
            foreach (var person in peopleList2)
            {
                if (person.Name.ToLower() == "ryan")
                {
                    Console.WriteLine($"Name: {person.Name}, Surname: {person.Surname}, Age: {person.Age}");
                }
            }

            Console.WriteLine("\nStudents with matching last names:");
            foreach (var person in peopleList2)
            {
                if (person.Surname.ToLower().EndsWith("ova", StringComparison.OrdinalIgnoreCase) || person.Surname.ToLower().EndsWith("ov", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Name: {person.Name}, Surname: {person.Surname}, Age: {person.Age}");
                }
            }

            Console.WriteLine("\nPeople aged 20 or older:");
            foreach (var person in peopleList2)
            {
                if (person.Age >= 20)
                {
                    Console.WriteLine($"Name: {person.Name}, Surname: {person.Surname}, Age: {person.Age}");
                }
            }

            #endregion

            Console.WriteLine();

            #region Task2 V1

            List<Exam> exams = new List<Exam>();

            exams.Add(new Exam { Subject = "Math", ExamDuration = 3, StartDate = DateTime.Now.AddHours(-1) });
            exams.Add(new Exam { Subject = "History", ExamDuration = 2, StartDate = DateTime.Now.AddHours(-5) });
            exams.Add(new Exam { Subject = "Chemistry", ExamDuration = 1, StartDate = DateTime.Now.AddHours(1) });
            exams.Add(new Exam { Subject = "Physics", ExamDuration = 4, StartDate = DateTime.Now.AddHours(-2) });

            Console.WriteLine("Exams due in the last 1 week:");
            FilteredExams(exams, exam => exam.EndDate >= DateTime.Now && exam.EndDate <= DateTime.Now.AddDays(7));

            Console.WriteLine("\nExams lasting more than 2 hours:");
            FilteredExams(exams, exam => exam.ExamDuration > 2);

            Console.WriteLine("\nOngoing exams:");
            FilteredExams(exams, exam => exam.StartDate <= DateTime.Now && exam.EndDate > DateTime.Now);

            #endregion

            Console.WriteLine();

            #region Task 2 V2 
            List<Exam> exams2 = new List<Exam>();

            exams.Add(new Exam { Subject = "Math", ExamDuration = 3, StartDate = DateTime.Now.AddHours(-1) });
            exams.Add(new Exam { Subject = "History", ExamDuration = 2, StartDate = DateTime.Now.AddHours(-5) });
            exams.Add(new Exam { Subject = "Chemistry", ExamDuration = 1, StartDate = DateTime.Now.AddHours(1) });
            exams.Add(new Exam { Subject = "Physics", ExamDuration = 4, StartDate = DateTime.Now.AddHours(-2) });

            Console.WriteLine("Exams due in the last 1 week:");
            foreach (var exam in exams2)
            {
                if (exam.EndDate >= DateTime.Now && exam.EndDate <= DateTime.Now.AddDays(7))
                {
                    DisplayExam(exam);
                }
            }

            Console.WriteLine("\nExams lasting more than 2 hours:");
            foreach (var exam in exams2)
            {
                if (exam.ExamDuration > 2)
                {
                    DisplayExam(exam);
                }
            }

            Console.WriteLine("\nOngoing exams:");
            foreach (var exam in exams2)
            {
                if (exam.StartDate <= DateTime.Now && exam.EndDate > DateTime.Now)
                {
                    DisplayExam(exam);
                }
            }

            #endregion
        }

        #region Task 2 Metods

        static void FilteredExams(List<Exam> exams, Func<Exam, bool> filter)
        {
            foreach (var exam in exams)
            {
                if (filter(exam))
                {
                    DisplayExam(exam);
                }
            }
        }

        static void DisplayExam(Exam exam)
        {
            Console.WriteLine($"Subject: {exam.Subject}, Duration: {exam.ExamDuration} hours");
        }

        #endregion
    }
}