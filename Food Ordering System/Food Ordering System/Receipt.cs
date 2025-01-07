using Food_Ordering_System.src.main.appl.model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class Receipt : Form
    {
        private string connectionString = "Server=localhost;Database=db_food_ordering_system;UserId=root;Password=jaydev;";

        public int ReceiveDataId { get;  set; }

        public Boolean IsDineIn {  get; set; }

        public string PaymentMethod { get; set; }

        public Cart cart {  get; set; }

        public Receipt()
        {
            InitializeComponent();
        }

        private void UpdateReceipt()
        {
            flp_Receipt.Controls.Clear(); // Clear existing items

            List<Item> items = cart.GetItems();

            int itemPanelHeight = 80; // Height for item panels
            int summaryPanelHeight = 45; // Height for summary panel
            int buttonPanelHeight = 60; // Height for button panel
            int alternateColor = 0;
            Color color1 = Color.FromArgb(245, 245, 245);
            Color color2 = Color.FromArgb(245, 245, 245);


            // Add each item to the receipt
            foreach (var item in items)
            {
                // Create a Guna2 panel for each item
                if (alternateColor == 0)
                {
                    color1 = Color.FromArgb(218, 218, 218);
                    color2 = Color.WhiteSmoke;
                    alternateColor = 1;
                }
                else
                {
                    color1 = Color.White;
                    color2 = Color.White;
                    alternateColor = 0;
                }
                var itemPanel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Size = new Size(flp_Receipt.Width - 30, itemPanelHeight), // Reduced width for better spacing
                    BackColor = color2,
                    BorderRadius = 8, // Rounded edges for a softer look
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    BorderColor = color1,
                    BorderThickness = 2
                };

                // Item Name Label
                var lblName = new Label
                {
                    Text = item.FoodName,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 3)
                };


                // Price Label
                var lblPrice = new Label
                {
                    Text = string.Format(new CultureInfo("es-PH"), "{0:C}", item.Price * item.Quantity),
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Bottom,
                    Margin = new Padding(0, 0, 0, 0)
                };
                var lblQuantity = new Label
                {
                    Text = "(" + item.Quantity + "x)",
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    TextAlign = ContentAlignment.MiddleRight,
                    Dock = DockStyle.Right,
                    Margin = new Padding(0, 0, 0, 0)
                };

                // Add labels to the panel
                itemPanel.Controls.Add(lblQuantity);
                itemPanel.Controls.Add(lblName);
                itemPanel.Controls.Add(lblPrice);


                // Add item panel to the receipt
                flp_Receipt.Controls.Add(itemPanel);
            }

            // Add summary section
            var summaryPanel = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = new Size(flp_Receipt.Width - 30, summaryPanelHeight),
                BackColor = Color.WhiteSmoke,
                BorderRadius = 8,
                Padding = new Padding(10),
                Margin = new Padding(5, 10, 5, 5),
                BorderColor = Color.FromArgb(218, 218, 218),
                BorderThickness = 2
            };

            // Total
            var lblTotal = new Label
            {
                Text = string.Format("Total: {0:C}", cart.GetTotalPrice()),
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Black,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Bottom,
                Margin = new Padding(0, 5, 0, 0)
            };
            summaryPanel.Controls.Add(lblTotal);

            // Add summary panel to the receipt
            flp_Receipt.Controls.Add(summaryPanel);
        }

        private void InsertSaleRecord()
        {
            try
            {
                string currentDate = DateTime.Now.ToString("MMMM d, yyyy");
                string currentTime = DateTime.Now.ToString("h:mm tt");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    // Step 1: Iterate through cart items
                    foreach (var item in cart.GetItems())
                    {
                        string insertSalesQuery = @"
                    INSERT INTO tbl_sales (account_id, product_id, date, time, amount)
                    VALUES (@account_id, @product_id, @date, @time, @amount)";

                        using (MySqlCommand insertCommand = new MySqlCommand(insertSalesQuery, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@account_id", ReceiveDataId);
                            insertCommand.Parameters.AddWithValue("@product_id", item.ProductId);
                            insertCommand.Parameters.AddWithValue("@date", currentDate);
                            insertCommand.Parameters.AddWithValue("@time", currentTime);
                            insertCommand.Parameters.AddWithValue("@amount", item.Price * item.Quantity);

                            insertCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                // Handle database-specific exceptions
                MessageBox.Show($"Database error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show($"Error inserting sale records: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void Receipt_Load(object sender, EventArgs e)
        {
            Console.WriteLine(ReceiveDataId);
            UpdateReceipt();
            InsertSaleRecord();
            if(IsDineIn)
            {
                lblisDineIn.Text = "Order Type: Dine In";
            } else
            {
                lblisDineIn.Text = "Order Type: Take Out";
            }
            lblPM.Text = "Payment Method: " + PaymentMethod.ToString();
        }
    }
}
