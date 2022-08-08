using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTrainer
{
    public class Trainer
    {
        private string name; 
        private int numberOfBadges;
        private List<Pokemon> pokemons;

        private Trainer()
        {    
            this.NumberOfBadges = 0;

            this.pokemons = new List<Pokemon>();
        }

        public Trainer(string name)
            : this()
        {
            this.Name = name;
        }

        public List<Pokemon> Pokemons
        {
            get { return this.pokemons; }
            set { this.pokemons = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public int NumberOfBadges
        {
            get { return this.numberOfBadges; }
            set { this.numberOfBadges = value; }
        }

        public override string ToString()
        {
            return $"{this.Name} {this.NumberOfBadges} {this.Pokemons.Count}";
        }
    }
}
