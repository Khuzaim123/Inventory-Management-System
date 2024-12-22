using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.Windows;
using Inventory_managment;

namespace InventoryApp
{
    public partial class Dashboard : Window
    {
        // Properties for data binding
        public int TotalStock { get; set; }
        public int TotalSales { get; set; }
        public int TotalPurchases { get; set; }
        public ObservableCollection<string> LowStockAlerts { get; set; }

        // Database connection string
        private string connectionString = "Data Source=Khuzaim-PC;Initial Catalog=project;Integrated Security=True;Trust Server Certificate=True;";

        public Dashboard()
        {
            InitializeComponent();


            // Initialize data (fetch from DB)
            LoadDashboardData();

            // Bind data to the UI
            this.DataContext = this;
        }

        private void LoadDashboardData()
        {
            // Retrieve data from database
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get total stock
                    string stockQuery = "SELECT SUM(Quantity) FROM IMS_Products";
                    SqlCommand stockCommand = new SqlCommand(stockQuery, connection);
                    TotalStock = Convert.ToInt32(stockCommand.ExecuteScalar());

                    // Query to get total sales (assuming there's a Sales table)
                    string salesQuery = "SELECT SUM(TotalAmount) FROM IMS_SalesOrders    ";
                    SqlCommand salesCommand = new SqlCommand(salesQuery, connection);
                    TotalSales = Convert.ToInt32(salesCommand.ExecuteScalar());

                    // Query to get total purchases (assuming there's a Purchases table)
                    string purchasesQuery = "SELECT SUM(TotalAmount) FROM IMS_PurchaseOrders";
                    SqlCommand purchasesCommand = new SqlCommand(purchasesQuery, connection);
                    TotalPurchases = Convert.ToInt32(purchasesCommand.ExecuteScalar());

                    // Query to get low stock alerts
                    string lowStockQuery = "SELECT Name FROM IMS_Products WHERE Quantity < 10"; // Adjust the threshold as needed
                    SqlCommand lowStockCommand = new SqlCommand(lowStockQuery, connection);

                    SqlDataReader reader = lowStockCommand.ExecuteReader();
                    LowStockAlerts = new ObservableCollection<string>();

                    while (reader.Read())
                    {
                        LowStockAlerts.Add(reader.GetString(0)); // Assuming the column is 'ProductName'
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product();
            p.Show();
        }
    }
}