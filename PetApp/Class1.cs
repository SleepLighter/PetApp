using System;
using System.Text.RegularExpressions;

namespace PetClassLibrary
{
    public class Pet
    {
        private string _name;
        private int _mood;
        private double _energy;
        private double _hunger;
        private double _weight;
        private string _fluffiness;

        public string Name
        {
            get => _name;
            set
            {
                if (IsValidName(value))
                    _name = value;
                else
                    throw new ArgumentException("Invalid name format");
            }
        }

        public int Mood
        {
            get => _mood;
            set
            {
                if (value >= 1 && value <= 100)
                    _mood = value;
                else
                    throw new ArgumentException("Mood must be between 1 and 100");
            }
        }

        public double Energy
        {
            get => _energy;
            set
            {
                if (value > 0)
                    _energy = Math.Round(value, 2);
                else
                    throw new ArgumentException("Energy must be positive");
            }
        }

        public double Hunger
        {
            get => _hunger;
            set
            {
                if (value > 0)
                    _hunger = Math.Round(value, 2);
                else
                    throw new ArgumentException("Hunger must be positive");
            }
        }

        public double Weight
        {
            get => _weight;
            set
            {
                if (value > 0)
                    _weight = Math.Round(value, 2);
                else
                    throw new ArgumentException("Weight must be positive");
            }
        }

        public string Fluffiness
        {
            get => _fluffiness;
            set => _fluffiness = value;
        }

        public bool IsSelected { get; set; }

        public Pet(string name, int mood, double energy, double hunger, double weight, string fluffiness)
        {
            Name = name;
            Mood = mood;
            Energy = energy;
            Hunger = hunger;
            Weight = weight;
            Fluffiness = fluffiness;
            IsSelected = false;
        }

        private bool IsValidName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            var pattern = @"^([A-Z][a-z]+)(\s[A-Z][a-z]+)*$";
            return Regex.IsMatch(name, pattern);
        }

        public void Play()
        {
            Random rnd = new Random();
            Mood = Math.Min(100, Mood + rnd.Next(5, 15));
            Energy = Math.Max(0.1, Energy - rnd.Next(5, 15));
            Hunger = Math.Min(100, Hunger + rnd.Next(5, 15));
        }

        public void Feed()
        {
            Random rnd = new Random();
            Hunger = Math.Max(0, Hunger - rnd.Next(10, 25));
            Energy = Math.Min(100, Energy + rnd.Next(5, 10));
            Weight = Math.Round(Weight + 0.1, 2);
        }

        public void Rest()
        {
            Random rnd = new Random();
            Energy = Math.Min(100, Energy + rnd.Next(15, 25));
            Mood = Math.Min(100, Mood + rnd.Next(5, 10));
        }

        public override string ToString()
        {
            return $"{Name} (Mood: {Mood}%, Energy: {Energy}, Hunger: {Hunger}, Weight: {Weight} kg, Fluffiness: {Fluffiness})";
        }
    }
}