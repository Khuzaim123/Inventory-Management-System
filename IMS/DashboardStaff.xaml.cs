using InventoryApp;
using System.Windows;

namespace Inventory_managment
{
    public partial class DashboardStaff : Window
    {
        public DashboardStaff()
        {
            InitializeComponent();
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Report r = new Report();
            r.Show();
        }

        private void ScanBarcode_Click(object sender, RoutedEventArgs e)
        {
            Barcode b = new Barcode();
            b.Show();
        }

        private void HelpAndSupport_Click(object sender, RoutedEventArgs e)
        {
            string message = "Welcome to the Staff Dashboard Help & Support!\n\n" +
                             "For assistance, contact:\n" +
                             "233503@students.au.edu.pk\n" +
                             "233798@students.au.edu.pk\n" +
                             "233587@students.au.edu.pk\n\n" +
                             "Did you know?\n" +
                             "• Effective inventory management can reduce storage costs by up to 40%\n" +
                             "• Real-time inventory tracking can prevent 90% of stockouts";

            MessageBox.Show(message, "Help & Support", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void CustomerInfo_Click(object sender, RoutedEventArgs e)
        {
            CustomerManagement customerManagementWindow = new CustomerManagement();
            customerManagementWindow.Show();
        }
    }
}