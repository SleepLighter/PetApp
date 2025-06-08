using PetClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PetApp
{
    public partial class MainWindow : Window
    {
        private List<Pet> pets = new List<Pet>();

        public MainWindow()
        {
            InitializeComponent();
            LoadSamplePets();
            RefreshDataGrid();
        }

        private void LoadSamplePets()
        {
            pets.Add(new Pet("Fluffy", 75, 80.5, 30.2, 4.5, "Very Fluffy"));
            pets.Add(new Pet("Whiskers", 60, 65.0, 45.7, 3.8, "Medium"));
            pets.Add(new Pet("Shadow", 85, 90.2, 20.1, 5.2, "Slightly Fluffy"));
            pets.Add(new Pet("Mittens", 45, 50.5, 60.3, 3.2, "Extra Fluffy"));
        }

        private void RefreshDataGrid()
        {
            PetsDataGrid.ItemsSource = null;
            PetsDataGrid.ItemsSource = pets;
        }

        private void AddPet_Click(object sender, RoutedEventArgs e)
        {
            var addPetWindow = new AddPetWindow();
            if (addPetWindow.ShowDialog() == true)
            {
                pets.Add(addPetWindow.NewPet);
                RefreshDataGrid();
                StatusText.Text = "Pet added successfully!";
            }
        }

        private void PlayRandom_Click(object sender, RoutedEventArgs e)
        {
            var selectedPets = pets.Where(p => p.IsSelected).ToList();

            if (selectedPets.Count == 0)
            {
                StatusText.Text = "Please select at least one pet to play with!";
                return;
            }

            Random rnd = new Random();
            var randomPet = selectedPets[rnd.Next(selectedPets.Count)];

            randomPet.Play();
            RefreshDataGrid();
            StatusText.Text = $"You played with {randomPet.Name}! Their mood improved but they're more hungry now.";
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            pets.Clear();
            LoadSamplePets();
            RefreshDataGrid();
            StatusText.Text = "All pets have been reset to their initial state.";
        }
    }
}