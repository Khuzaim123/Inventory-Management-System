using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Data.SqlClient;

namespace InventoryApp
{
    public partial class Signupform : Window
    {
        // Use the correct connection string for your database setup
        private string connectionString = "Data Source=Khuzaim-PC;Initial Catalog=project;Integrated Security=True;Trust Server Certificate=True;";


        public Signupform()
        {
            InitializeComponent();
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // This method can be used to perform any specific actions when the role is selected
        }

        private void SignupButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Check for empty fields
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Hash the password using SHA256
            var hashedPassword = HashPassword(password);

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Prepare the SQL query with parameterized input to avoid SQL injection
                    string query = "INSERT INTO IMS_Users (Username, PasswordHash, Role, CreatedAt) VALUES (@Username, @PasswordHash, @Role, @CreatedAt)";
                    using (var command = new SqlCommand(query, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                        command.Parameters.AddWithValue("@Role", role);
                        command.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                        // Execute the query and check the result
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Signup successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();

                            // After successful sign up, navigate to the Dashboard
                            MainWindow dashboard = new MainWindow();
                            dashboard.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Signup failed. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Display error message if something goes wrong
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to hash the password using SHA256
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}