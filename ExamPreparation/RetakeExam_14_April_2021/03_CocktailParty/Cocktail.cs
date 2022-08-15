using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;

            this.Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {
            if (this.Ingredients.Count < this.Capacity)
            {
                this.Ingredients.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            Ingredient ingredient = this.Ingredients.FirstOrDefault(i => i.Name == name);

            if (ingredient != null)
            {
                this.Ingredients.Remove(ingredient);
                return true;
            }
            else 
            {
                return false;
            }
        }

        public Ingredient FindIngredient(string name)
            => this.Ingredients.FirstOrDefault(i => i.Name == name);

        public Ingredient GetMostAlcoholicIngredient()
            => this.Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();

        public int CurrentAlcoholLevel => this.Ingredients.Sum(i => i.Alcohol);

        public string Report()
        {
            StringBuilder sb = new StringBuilder(0);

            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");

            foreach (var ingredient in this.Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
