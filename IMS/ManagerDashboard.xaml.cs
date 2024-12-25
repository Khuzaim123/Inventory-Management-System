using InventoryApp;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Inventory_managment
{
    public partial class ManagerDashboard : Window, INotifyPropertyChanged
    {
        private string connectionString = "Data Source=KHUZAIM-PC;Initial Catalog=master;Integrated Security=True;TrustServerCertificate=True;";

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

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ManagerDashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Fetch Total Stock
                    string stockQuery = "SELECT SUM(Quantity) FROM IMS_Products";
                    using (SqlCommand stockCommand = new SqlCommand(stockQuery, connection))
                    {
                        TotalStock = Convert.ToInt32(stockCommand.ExecuteScalar());
                    }

                    // Fetch Total Sales
                    string salesQuery = "SELECT SUM(TotalAmount) FROM IMS_SalesOrders";
                    using (SqlCommand salesCommand = new SqlCommand(salesQuery, connection))
                    {
                        TotalSales = Convert.ToInt32(salesCommand.ExecuteScalar());
                    }

                    // Fetch Total Purchases
                    string purchasesQuery = "SELECT SUM(TotalAmount) FROM IMS_PurchaseOrders";
                    using (SqlCommand purchasesCommand = new SqlCommand(purchasesQuery, connection))
                    {
                        TotalPurchases = Convert.ToInt32(purchasesCommand.ExecuteScalar());
                    }

                    // Low Stock Query
                    string lowStockQuery = "SELECT Name, Quantity FROM IMS_Products WHERE Quantity < 10";
                    using (SqlCommand lowStockCommand = new SqlCommand(lowStockQuery, connection))
                    {
                        using (SqlDataReader reader = lowStockCommand.ExecuteReader())
                        {
                            LowStockAlerts.Clear();
                            while (reader.Read())
                            {
                                string productName = reader.GetString(0);
                                int quantity = reader.GetInt32(1);
                                LowStockAlerts.Add($"{productName}: Only {quantity} left in stock!");
                            }
                        }
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
            // Navigate to Products page
            Product p = new Product();
            p.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Navigate to Orders page
            Order o = new Order();
            o.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Navigate to Suppliers page
            Supplier o = new Supplier();
            o.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Navigate to Reports page
            Report report = new Report();
            report.Show();
        }

        private void btnInventoryTracking_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Inventory Tracking page
            Inventory_Tracking inventory_Tracking = new Inventory_Tracking();
            inventory_Tracking.Show();
        }

        private void CustomerInfo_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Customer Info page
            CustomerManagement customerManagement = new CustomerManagement();
            customerManagement.Show();
        }

        private void HelpAndSupport_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Help and Support page
            HelpAndSupport helpAndSupport = new HelpAndSupport();
            helpAndSupport.Show();
        }

        private void AuditLog_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Audit Log page
            Audit a = new Audit();
            a.Show();
        }
    }
}