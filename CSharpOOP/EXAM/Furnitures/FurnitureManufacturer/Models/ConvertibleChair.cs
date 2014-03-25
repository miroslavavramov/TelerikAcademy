namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair
    {
        private readonly decimal initialHeight;
        private const decimal HeightWhenConverted = 0.10M;

        private bool isConverted;

        public ConvertibleChair(string model, string material, decimal price, decimal height, int numberOfLegs) 
            : base(model, material, price, height, numberOfLegs)
        {
            this.isConverted = false;
            this.initialHeight = height;
        }

        public bool IsConverted
        {
            get 
            {
                return this.isConverted;
            }
        }

        public void Convert()
        {
            if (this.IsConverted)
            {
                this.isConverted = false;
                this.Height = initialHeight;
            }
            else
            {
                this.isConverted = true;
                this.Height = HeightWhenConverted;
            }
        }

        public override string ToString()
        {
            var output = new System.Text.StringBuilder(base.ToString());

            output.AppendFormat(", State: {0}", this.IsConverted ? "Converted" : "Normal");

            return output.ToString();
        }
    }
}
