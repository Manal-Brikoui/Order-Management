using System;
using System.Text.RegularExpressions;

namespace OrderManagement.Domain.ValueObjects
{
    public class Address
    {
        public string Street { get; }
        public string City { get; }
        public string State { get; }
        public string Postalcode { get; }
        public string Country { get; }

        
        public Address(string street, string city, string state, string postalcode, string country)
        {
            ValidateNonEmpty(street, "Street");
            ValidateNonEmpty(city, "City");
            ValidateNonEmpty(state, "State");
            ValidateNonEmpty(postalcode, "PostalCode");
            ValidateNonEmpty(country, "Country");

            ValidatePostalCode(postalcode);

            Street = street;
            City = city;
            State = state;
            Postalcode = postalcode;
            Country = country;
        }

   
        private static void ValidateNonEmpty(string value, string fieldName)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException($"{fieldName} is required", fieldName);
        }

        // Validation du format de code postal
        private static void ValidatePostalCode(string postalcode)
        {
           
            string pattern = @"^\d{5}(-\d{4})?$"; // Vous pouvez adapter cette regex selon le format souhaité
            if (!Regex.IsMatch(postalcode, pattern))
                throw new ArgumentException("Invalid PostalCode format", nameof(postalcode));
        }

        // Méthode d'égalité pour comparer deux adresses
        public override bool Equals(object? obj)
        {
            if (obj is Address address)
            {
                return Street == address.Street &&
                       City == address.City &&
                       State == address.State &&
                       Postalcode == address.Postalcode &&
                       Country == address.Country;
            }
            return false;
        }

        // Méthode pour calculer un hashcode basé sur les propriétés de l'adresse
        public override int GetHashCode() =>
            HashCode.Combine(Street, City, State, Postalcode, Country);

        // Retourne l'adresse sous forme de chaîne lisible
        public override string ToString() =>
            $"{Street}, {City}, {State}, {Postalcode}, {Country}";
    }
}
