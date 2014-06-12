namespace Kitchen
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            Potato potato = this.GetPotato();
            Carrot carrot = this.GetCarrot();

            this.Peel(potato);
            this.Peel(carrot);
                
            this.Cut(potato);
            this.Cut(carrot);

            Bowl bowl = GetBowl();
            bowl.Add(carrot);
            bowl.Add(potato);
        }

        private Bowl GetBowl()
        {
            var bowl = new Bowl();

            return bowl;
        }

        private Carrot GetCarrot()
        {
            var carrot = new Carrot();

            return carrot;
        }

        private Potato GetPotato()
        {
            var potato = new Potato();

            return potato;
        }

        private void Cut(Vegetable potato)
        {
            
        }

        private void Peel(Vegetable vegetable)
        {
            
        }
    }
}
