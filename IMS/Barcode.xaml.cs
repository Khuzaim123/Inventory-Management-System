using System;
using System.Windows;
using Microsoft.Data.SqlClient;

namespace Inventory_managment
{
    public partial class Barcode : Window
    {
        private string connectionString = "Data Source=Khuzaim-PC;Initial Catalog=project;Integrated Security=True;Trust Server Certificate=True;";

        public Barcode()
        {
            InitializeComponent();
        }

        private void SearchBarcode_Click(object sender, RoutedEventArgs e)
        {
            string barcode = txtBarcode.Text;

            if (string.IsNullOrWhiteSpace(barcode))
            {
                MessageBox.Show("Please enter a barcode number.", "Input Required", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Name, SKU, Category, UnitPrice, Quantity , Barcode FROM IMS_Products WHERE Barcode = @Barcode";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Barcode", barcode);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string productDetails = $"Product Name: {reader.GetString(0)}\n" +
                                                $"SKU: {reader.GetString(1)}\n" +
                                                $"Category: {reader.GetString(2)}\n" +
                                                $"Unit Price: {reader.GetDecimal(3):C}\n" +
                                                $"Quantity: {reader.GetInt32(4)}";
                        MessageBox.Show(productDetails, "Product Details", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("No product found for the given barcode.", "Not Found", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while searching for the product: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
