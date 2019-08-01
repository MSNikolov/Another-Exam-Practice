using System;
using System.Collections.Generic;
using System.Linq;

namespace NascarQualifications
{
    class Program
    {
        static void Main(string[] args)
        {
            var racers = Console.ReadLine().Split().ToList();

            var command = Console.ReadLine();

            while (command != "end")
            {
                var commands = command.Split();

                switch(commands[0])
                {
                    case "Race":
                        if (!racers.Contains(commands[1]))
                        {
                            racers.Add(commands[1]);
                        }
                        break;
                    case "Accident":
                        if (racers.Contains(commands[1]))
                        {
                            racers.Remove(commands[1]);
                        }
                        break;
                    case "Box":
                        if (racers.Contains(commands[1]) && racers.Last() != commands[1])
                        {
                            var ind = racers.IndexOf(commands[1]);

                            var overtaking = racers[ind + 1];

                            racers[ind] = overtaking;

                            racers[ind + 1] = commands[1];
                        }
                        break;
                    case "Overtake":
                        var newPos = racers.IndexOf(commands[1]) - int.Parse(commands[2]);
                        if (racers.Contains(commands[1]) && newPos >= 0)
                        {
                            var overtaken = new List<string>();
                            for (int i = newPos; i < newPos + int.Parse(commands[2]); i++)
                            {
                                overtaken.Add(racers[i]);
                            }
                            var count = 0;
                            for (int i = newPos+1; i <= newPos+int.Parse(commands[2]); i++)
                            {
                                racers[i] = overtaken[count];
                                count++;
                            }
                            racers[newPos] = commands[1];
                        }
                        break;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(" ~ ", racers));
        }
    }
}
