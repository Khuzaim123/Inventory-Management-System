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
            this.DataContext = this;
        }

        private void LoadDashboardData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string stockQuery = "SELECT SUM(Quantity) FROM IMS_Products";
                    SqlCommand stockCommand = new SqlCommand(stockQuery, connection);
                    TotalStock = Convert.ToInt32(stockCommand.ExecuteScalar());

                    string salesQuery = "SELECT SUM(TotalAmount) FROM IMS_SalesOrders";
                    SqlCommand salesCommand = new SqlCommand(salesQuery, connection);
                    TotalSales = Convert.ToInt32(salesCommand.ExecuteScalar());

                    string purchasesQuery = "SELECT SUM(TotalAmount) FROM IMS_PurchaseOrders";
                    SqlCommand purchasesCommand = new SqlCommand(purchasesQuery, connection);
                    TotalPurchases = Convert.ToInt32(purchasesCommand.ExecuteScalar());

                    string lowStockQuery = "SELECT Name FROM IMS_Products WHERE Quantity < 10";
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

        private void ScanBarcode_Click(object sender, RoutedEventArgs e)
        {
            Barcode b = new Barcode();
            b.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Order o = new Order();
            o.Show();
        }
    }
}