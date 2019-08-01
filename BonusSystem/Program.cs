using System;
using System.Collections.Generic;
using System.Linq;

namespace BonusSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsCount = int.Parse(Console.ReadLine());

            var lecturesCount = int.Parse(Console.ReadLine());

            var initialBonus = int.Parse(Console.ReadLine());

            var students = new List<int>();

            for (int i = 0; i < studentsCount; i++)
            {
                students.Add(int.Parse(Console.ReadLine()));
            }

            var max = students.Max();

            double bonus = (double)max / (double)lecturesCount * (5.0 + (double)initialBonus);

            var final = Math.Ceiling(bonus);

            Console.WriteLine($"The maximum bonus score for this course is {final}.The student has attended {max} lectures.");
        }
    }
}
