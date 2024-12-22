using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace Inventory_managment
{
    public partial class Product : Window
    {
        private string connectionString = "Data Source=Khuzaim-PC;Initial Catalog=project;Integrated Security=True;";

        public Product()
        {
            InitializeComponent();
            LoadCategories();
            LoadProducts();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "INSERT INTO IMS_Products (Name, SKU, Category, UnitPrice, Quantity) VALUES (@Name, @SKU, @Category, @UnitPrice, @Quantity)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Name", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@SKU", txtSKU.Text);
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.Text);
                    cmd.Parameters.AddWithValue("@UnitPrice", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product added successfully.");
                    ClearFields();
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding product: {ex.Message}");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProducts.SelectedItem == null)
                {
                    MessageBox.Show("Please select a product to update.");
                    return;
                }

                DataRowView row = (DataRowView)dgProducts.SelectedItem;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "UPDATE IMS_Products SET Name = @Name, SKU = @SKU, Category = @Category, UnitPrice = @UnitPrice, Quantity = @Quantity WHERE ProductID = @ProductID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@Name", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@SKU", txtSKU.Text);
                    cmd.Parameters.AddWithValue("@Category", cmbCategory.Text);
                    cmd.Parameters.AddWithValue("@UnitPrice", txtPrice.Text);
                    cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@ProductID", row["ProductID"]);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product updated successfully.");
                    ClearFields();
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating product: {ex.Message}");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dgProducts.SelectedItem == null)
                {
                    MessageBox.Show("Please select a product to delete.");
                    return;
                }

                DataRowView row = (DataRowView)dgProducts.SelectedItem;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "DELETE FROM IMS_Products WHERE ProductID = @ProductID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@ProductID", row["ProductID"]);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product deleted successfully.");
                    ClearFields();
                    LoadProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtProductName.Clear();
            txtSKU.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            cmbCategory.SelectedIndex = -1;
            dgProducts.SelectedItem = null;
        }

        private void LoadProducts(string category = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT ProductID, Name, SKU, Category, UnitPrice, Quantity FROM IMS_Products";

                    if (!string.IsNullOrEmpty(category))
                    {
                        query += " WHERE Category = @Category";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);

                    if (!string.IsNullOrEmpty(category))
                    {
                        cmd.Parameters.AddWithValue("@Category", category);
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgProducts.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }
        private void LoadCategories()
        {
            try
            {
                cmbCategory.Items.Clear();
                cmbFilterCategory.Items.Clear();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT DISTINCT Category FROM IMS_Products";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string category = reader["Category"].ToString();
                        cmbCategory.Items.Add(category);
                        cmbFilterCategory.Items.Add(category);
                    }

                    cmbFilterCategory.Items.Insert(0, "All");
                    cmbFilterCategory.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }


        private void cmbFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFilterCategory.SelectedItem != null)
            {
                string selectedCategory = cmbFilterCategory.SelectedItem.ToString();
                LoadProducts(selectedCategory == "All" ? null : selectedCategory);
            }
        }

    }
}