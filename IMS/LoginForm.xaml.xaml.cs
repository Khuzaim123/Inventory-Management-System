﻿using Inventory_managment;
using Microsoft.Data.SqlClient;  // Make sure only this is included
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace InventoryApp
{
    public partial class LoginForm : Window
    {  //"Data Source=DESKTOP-GSJ1HJB\\SQLEXPRESS;Initial Catalog=Inventory;Integrated Security=True;Trust Server Certificate=True";
        // Connection string using the appropriate provider
        private string connectionString = "Data Source=Khuzaim-PC;Initial Catalog=project;Integrated Security=True;Trust Server Certificate=True;";


        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Both username and password are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Hash the password for secure comparison with the stored hash
            string hashedPassword = HashPassword(password);

            try
            {
                // Use Microsoft.Data.SqlClient.SqlConnection to connect to the database
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Modify the query to also select the Role
                    string query = "SELECT Role FROM IMS_Users WHERE Username = @Username AND PasswordHash = @PasswordHash";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

                        // Execute the query and retrieve the role
                        var role = command.ExecuteScalar() as string;

                        if (role != null)
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();

                            // Check the role and open the appropriate dashboard
                            if (role == "Admin")
                            {
                                Dashboard dashboard = new Dashboard();
                                dashboard.ShowDialog();
                            }
                            else if (role == "Staff")
                            {
                                DashboardStaff dashboardStaff = new DashboardStaff();
                                dashboardStaff.ShowDialog();
                            }
                            else if (role == "Manager")
                            {
                                ManagerDashboard dashboardStaff = new ManagerDashboard();
                                dashboardStaff.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash); // Return the base64 encoded hash
            }
        }
    }
}