namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;

            this.furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get 
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentOutOfRangeException("Name cannot be empty, null or with less than 5 symbols.");
                }
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber; 
            }
            private set
            {
                if (!ValidateRegistrationNumber(value))
                {
                    throw new ArgumentOutOfRangeException
                        ("Registration number must be exactly 10 symbols and must contain only digits!");
                }
                this.registrationNumber = value;
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get 
            {
                return this.furnitures;
            }
        }

        public void Add(IFurniture furniture)
        {
            this.furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            foreach (var furniture in this.Furnitures)
            {
                if (furniture.Model.ToLower() == model.ToLower())
                {
                    return furniture;
                }
            }
            
            return null;
        }

        public string Catalog()
        {
            var output = new StringBuilder();

            output.AppendFormat("{0} - {1} - {2} {3}",
                this.Name, this.RegistrationNumber,
                this.Furnitures.Count != 0 ? this.Furnitures.Count.ToString() : "no",
                this.Furnitures.Count != 1 ? "furnitures" : "furniture");

            if (this.Furnitures.Count > 0)
            {
                var sortedFurnitures = from furniture in this.Furnitures
                                       orderby furniture.Price, furniture.Model
                                       select furniture;

                output.Append(Environment.NewLine);
                output.AppendFormat("{0}", string.Join(Environment.NewLine, sortedFurnitures));
            }

            return output.ToString();
        }

        private bool ValidateRegistrationNumber(string registrationNumber)
        {
            if (registrationNumber.Length != 10)
            {
                return false;
            }

            foreach (char symbol in registrationNumber)
            {
                if (!char.IsDigit(symbol))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
