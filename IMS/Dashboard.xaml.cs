using System;
using System.Collections.ObjectModel;
using Microsoft.Data.SqlClient;
using System.Windows;
using System.ComponentModel;
using Inventory_managment;

namespace InventoryApp
{
    public partial class Dashboard : Window, INotifyPropertyChanged
    {
        private int totalStock;
        public int TotalStock
        {
            get => totalStock;
            set
            {
                totalStock = value;
                OnPropertyChanged(nameof(TotalStock));
            }
        }

        private int totalSales;
        public int TotalSales
        {
            get => totalSales;
            set
            {
                totalSales = value;
                OnPropertyChanged(nameof(TotalSales));
            }
        }

        private int totalPurchases;
        public int TotalPurchases
        {
            get => totalPurchases;
            set
            {
                totalPurchases = value;
                OnPropertyChanged(nameof(TotalPurchases));
            }
        }

        public ObservableCollection<string> LowStockAlerts { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> Notifications { get; set; } = new ObservableCollection<string>(); // Notifications list

        private string connectionString = "Data Source=Khuzaim-PC;Initial Catalog=project;Integrated Security=True;Trust Server Certificate=True;";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();
            CheckOrderStatusChanges(); // Check for order status changes on load
            this.DataContext = this;
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get total stock
                    string stockQuery = "SELECT SUM(Quantity) FROM IMS_Products";
                    SqlCommand stockCommand = new SqlCommand(stockQuery, connection);
                    TotalStock = Convert.ToInt32(stockCommand.ExecuteScalar());

                    // Check for low stock alerts
                    if (TotalStock < 30) // Adjust the threshold as needed
                    {
                        Notifications.Add($"Warning: Total stock is low ({TotalStock}). Please restock.");
                    }

                    // Query to get total sales
                    string salesQuery = "SELECT SUM(TotalAmount) FROM IMS_SalesOrders";
                    SqlCommand salesCommand = new SqlCommand(salesQuery, connection);
                    TotalSales = Convert.ToInt32(salesCommand.ExecuteScalar());

                    // Query to get total purchases
                    string purchasesQuery = "SELECT SUM(TotalAmount) FROM IMS_PurchaseOrders";
                    SqlCommand purchasesCommand = new SqlCommand(purchasesQuery, connection);
                    TotalPurchases = Convert.ToInt32(purchasesCommand.ExecuteScalar());

                    // Query to get low stock alerts
                    string lowStockQuery = "SELECT Name FROM IMS_Products WHERE Quantity < 10"; // Adjust the threshold as needed
                    SqlCommand lowStockCommand = new SqlCommand(lowStockQuery, connection);
                    SqlDataReader reader = lowStockCommand.ExecuteReader();
                    LowStockAlerts.Clear();

                    while (reader.Read())
                    {
                        LowStockAlerts.Add(reader.GetString(0));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CheckOrderStatusChanges()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // Update the query to use the correct table name
                string query = "SELECT SalesOrderID, Status FROM IMS_SalesOrders WHERE OrderDate >= @LastCheckedDate";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@LastCheckedDate", DateTime.Now.AddMinutes(-5)); // Check for changes in the last 5 minutes

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int orderId = reader.GetInt32(0);
                    string status = reader.GetString(1);

                    // Notify if the order status has changed
                    NotifyOrderStatusChange(orderId, status);
                }
            }
        }

        private void NotifyOrderStatusChange(int orderId, string status)
        {
            Notifications.Add($"Order #{orderId} status has changed to {status}.");
        }

        private void btnInventoryTracking_Click(object sender, RoutedEventArgs e)
        {
            Inventory_Tracking i = new Inventory_Tracking();
            i.StocksUpdated += LoadDashboardData; // Subscribe to the event
            i.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product();
            p.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Order o = new Order();
            o.Show();
        }

        private void ScanBarcode_Click(object sender, RoutedEventArgs e)
        {
            Barcode scanner = new Barcode();
            scanner.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Supplier s = new Supplier();
            s.Show();
        }
    }
}