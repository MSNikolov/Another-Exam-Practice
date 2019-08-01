using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InternationalSoftUniada
{
    class Program
    {
        static void Main(string[] args)
        {
            var standing = new Dictionary<string, Dictionary<string, int>>();

            var input = Console.ReadLine();

            while (input != "END")
            {
                var command = input.Split(" -> ").ToArray();

                var country = command[0];

                var paraolimpian = command[1];

                var points = int.Parse(command[2]);

                if (!standing.ContainsKey(country))
                {
                    standing.Add(country, new Dictionary<string, int>());
                }

                if (!standing[country].ContainsKey(paraolimpian))
                {
                    standing[country].Add(paraolimpian, 0);
                }

                standing[country][paraolimpian] += points;

                input = Console.ReadLine();
            }

            standing = standing.OrderByDescending(c => c.Value.Sum(p => p.Value)).ToDictionary(c => c.Key, c => c.Value);

            foreach (var land in standing)
            {
                Console.WriteLine($"{land.Key}: {land.Value.Sum(p => p.Value)}");

                foreach (var man in land.Value)
                {
                    Console.WriteLine($"-- {man.Key} -> {man.Value}");
                }
            }
        }
    }
}
