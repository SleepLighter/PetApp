using PetClassLibrary;
using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace PetApp
{
    public partial class AddPetWindow : Window
    {
        public Pet NewPet { get; private set; }

        public AddPetWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Validate and create new pet
                string name = NameTextBox.Text.Trim();
                int mood = int.Parse(MoodTextBox.Text.Trim().TrimEnd('%'));
                double energy = double.Parse(EnergyTextBox.Text);
                double hunger = double.Parse(HungerTextBox.Text);
                double weight = double.Parse(WeightTextBox.Text.Trim().Replace(" kg", ""));
                string fluffiness = (FluffinessComboBox.SelectedItem as System.Windows.Controls.ComboBoxItem).Content.ToString();

                NewPet = new Pet(name, mood, energy, hunger, weight, fluffiness);
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating pet: {ex.Message}", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}