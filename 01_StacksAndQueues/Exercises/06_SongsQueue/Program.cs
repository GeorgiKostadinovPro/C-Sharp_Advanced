using System;
using System.Collections.Generic;
using System.Linq;

namespace _06_SongsQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<string> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string[] cmdArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string cmd = cmdArgs[0];

                string[] songsInfo = cmdArgs.Skip(1).ToArray();

                string song = string.Join(" ", songsInfo);

                switch (cmd)
                {
                    case "Play":
                        songs.Dequeue();
                        break;
                    case "Add":
                        if (!songs.Contains(song))
                        {
                            songs.Enqueue(song);
                        }
                        else
                        {
                            Console.WriteLine($"{song} is already contained!");
                        }
                        break;
                    case "Show":
                        Console.WriteLine(string.Join(", ", songs));
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
