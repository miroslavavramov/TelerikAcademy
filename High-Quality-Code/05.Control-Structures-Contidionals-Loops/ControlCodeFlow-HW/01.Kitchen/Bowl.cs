namespace Kitchen
{
    using System.Collections.Generic;

    public class Bowl
    {
        private readonly List<Vegetable> Ingredients;

        public Bowl()
        {
            this.Ingredients = new List<Vegetable>();
        }

        public void Add(Vegetable vegetable)
        {
            this.Ingredients.Add(vegetable);
        }
    }
}
