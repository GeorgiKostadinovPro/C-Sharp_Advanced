using PokemonTrainer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string line = string.Empty;

            while ((line = Console.ReadLine()) != "Tournament")
            {
                string[] cmdArgs = line
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int pokemonHealth = int.Parse(cmdArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer trainer = trainers
                    .FirstOrDefault(t => t.Name == trainerName);

                if (trainer == null)
                {
                    trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                trainer.Pokemons.Add(pokemon);
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                    }

                    trainer.Pokemons.RemoveAll(p => p.Health <= 0);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine(trainer.ToString());
            }
        }
    }
}
