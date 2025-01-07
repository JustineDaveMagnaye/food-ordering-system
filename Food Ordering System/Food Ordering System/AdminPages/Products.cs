using Food_Ordering_System.src.main;
using Food_Ordering_System.src.main.appl.facade.product;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Food_Ordering_System.AdminPages
{
    public partial class Products : UserControl
    {
        private productFacade productFacade;
        ProductInfoMgtApplication appl = new ProductInfoMgtApplication();
        private const string ConnectionString = "Server=localhost;Database=db_food_ordering_system;UserId=root;Password=jaydev;";

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        private const string PlaceholderText = "Search products...";

        private void SetPlaceholderText(TextBox textBox)
        {
            textBox.Text = PlaceholderText;
            textBox.ForeColor = Color.Gray; 
        }

        private void txt_search_Enter(object sender, EventArgs e)
        {
            if (txt_search.Text == PlaceholderText)
            {
                txt_search.Text = "";
                txt_search.ForeColor = Color.Black;
            }
        }

        private void txt_search_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_search.Text))
            {
                SetPlaceholderText(txt_search);
            }
        }

        public Products()
        {
            InitializeComponent();
            ApplyRoundedCorners();
            ApplyFilters(); 
            SetPlaceholderText(txt_search);

            txt_search.Enter += txt_search_Enter;
            txt_search.Leave += txt_search_Leave;
        }


        private void ApplyRoundedCorners()
        {
            flpProducts.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, flpProducts.Width, flpProducts.Height, 20, 20));
            flowLayoutPanel2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, flowLayoutPanel2.Width, flowLayoutPanel2.Height, 20, 20));
            panel2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
            panel3.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            checkBox1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, checkBox1.Width, checkBox1.Height, 20, 20));
            Unavailable.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Unavailable.Width, Unavailable.Height, 20, 20));
            outOfStock.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, outOfStock.Width, outOfStock.Height, 20, 20));


        }

        private void ApplyFilters(string category = "")
        {
            string search = txt_search.Text.Trim(); 
            if(search.Equals("Search products..."))
            {
                search = "";
            }
            bool isAvailableChecked = checkBox1.Checked; 
            bool isUnavailableChecked = Unavailable.Checked;
            bool isOutOfStockChecked = outOfStock.Checked;

            string statusFilter = null;
            if (isAvailableChecked && !isUnavailableChecked && !isOutOfStockChecked)
            {
                statusFilter = "available";
            }
            else if (!isAvailableChecked && isUnavailableChecked && !isOutOfStockChecked)
            {
                statusFilter = "unavailable";
              
            }
            else if (!isAvailableChecked && !isUnavailableChecked && isOutOfStockChecked)
            {
                statusFilter = "out of stock";
            }
            LoadProducts(search, statusFilter, category);
        }


        private void LoadProducts(string search = "", string statusFilter = null, string category = "")
        {
            try
            {
                flpProducts.Controls.Clear();

                Panel addProductCard = new Panel
                {
                    Size = new Size(160, 280),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.FromArgb(34, 45, 59),
                    Margin = new Padding(10)
                };
                addProductCard.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, addProductCard.Width, addProductCard.Height, 35, 35));

                Button btnAddProduct = new Button
                {
                    Text = "+ Add Product",
                    Size = new Size(150, 40),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    BackColor = Color.FromArgb(53, 70, 92),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Location = new Point(4, 120)
                };
                btnAddProduct.Click += BtnAddProduct_Click;
                addProductCard.Controls.Add(btnAddProduct);
                flpProducts.Controls.Add(addProductCard);

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT product_id, food_name, price, img, status, category FROM tbl_product WHERE 1=1";

                    if (!string.IsNullOrEmpty(search))
                    {
                        query += " AND food_name LIKE @search";
                    }
                    if (!string.IsNullOrEmpty(statusFilter))
                    {
                        query += " AND status = @status";
                    }
                    if (!string.IsNullOrEmpty(category))
                    {
                        query += " AND category = @category";
                    }

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(search))
                        {
                            command.Parameters.AddWithValue("@search", $"%{search}%");
                        }
                        if (!string.IsNullOrEmpty(statusFilter))
                        {
                            command.Parameters.AddWithValue("@status", statusFilter);
                        }
                        if (!string.IsNullOrEmpty(category))
                        {
                            command.Parameters.AddWithValue("@category", category);
                        }

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Panel productCard = CreateProductCard(
                                    reader["product_id"].ToString(),
                                    reader["food_name"].ToString(),
                                    Convert.ToDecimal(reader["price"]),
                                    reader["img"] as byte[],
                                    reader["status"].ToString(),
                                    reader["category"].ToString()
                                );

                                flpProducts.Controls.Add(productCard);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddProduct addProduct = new AddProduct();
            addProduct.ShowDialog();
        }

        private Panel CreateProductCard(string productId, string name, decimal price, byte[] imgData, string status, string category)
        {
            Panel card = new Panel
            {
                Size = new Size(160, 280),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(34, 45, 59),
                Margin = new Padding(10, 10, 10, 20)
            };
            card.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, card.Width, card.Height, 35, 35));

            PictureBox pbImage = new PictureBox
            {
                Size = new Size(140, 120),
                Image = imgData != null ? ByteArrayToImage(imgData) : Properties.Resources.No_Image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point((card.Width - 140) / 2, 10)
            };
            card.Controls.Add(pbImage);

            Label lblStatus = new Label
            {
                Text = $"Status: {status}",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = status.ToLower() == "available" ? Color.Green : Color.Red,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(card.Width, 20),
                Location = new Point(0, pbImage.Bottom + 10)
            };
            card.Controls.Add(lblStatus);

            Label lblName = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(card.Width, 20),
                Location = new Point(0, lblStatus.Bottom + 5)
            };
            card.Controls.Add(lblName);

            Label lblCategory = new Label
            {
                Text = $"Category: {category}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(card.Width, 20),
                Location = new Point(0, lblName.Bottom + 5)
            };
            card.Controls.Add(lblCategory);

            Label lblPrice = new Label
            {
                Text = $"Price: {price:C}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Size = new Size(card.Width, 20),
                Location = new Point(0, lblCategory.Bottom + 5)
            };
            card.Controls.Add(lblPrice);

            Button btnDelete = new Button
            {
                Text = "Delete",
                BackColor = Color.Red,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(card.Width - 20, 35),
                Location = new Point(10, card.Height - 45)
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += (s, e) => DeleteProduct(productId);
            card.Controls.Add(btnDelete);

            return card;
        }

        private void DeleteProduct(string productId)
        {
            try
            {
                productFacade = appl.getProductFacade();
                productFacade.DeleteProduct(productId);

                MessageBox.Show("Product deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream memoryStream = new MemoryStream(byteArray))
            {
                return Image.FromStream(memoryStream);
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            ApplyFilters(); 
        }

        private void MainDish_Click(object sender, EventArgs e)
        {
            ApplyFilters(category: "Main Dish");
        }

        private void Appetizer_Click(object sender, EventArgs e)
        {
            ApplyFilters(category: "Appetizer");
        }

        private void Dessert_Click(object sender, EventArgs e)
        {
            ApplyFilters(category: "Dessert");
        }

        private void Drinks_Click(object sender, EventArgs e)
        {
            ApplyFilters(category: "Drinks");
        }

        private void Others_Click(object sender, EventArgs e)
        {
            ApplyFilters(category: "Others");
        }

        bool categoryfilterExpand = true;

        private void categoryfilterTimer_Tick(object sender, EventArgs e)
        {
            if (categoryfilterExpand)
            {
                categoryFilter.Height += 10;

                if (categoryFilter.Height >= categoryFilter.MaximumSize.Height)
                {
                    categoryFilter.Height = categoryFilter.MaximumSize.Height;
                    categoryfilterExpand = false;
                    categoryfilterTimer.Stop();
                }
            }
            else
            {
                categoryFilter.Height -= 10;

                if (categoryFilter.Height <= categoryFilter.MinimumSize.Height)
                {
                    categoryFilter.Height = categoryFilter.MinimumSize.Height;
                    categoryfilterExpand = true;
                    categoryfilterTimer.Stop();
                }
            }
        }
        private void FilterButton_Click_1(object sender, EventArgs e)
        {
            categoryfilterTimer.Start();
        }

        private void Unavailable_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
            outOfStock.Checked = false;
            ApplyFilters();
        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            Unavailable.Checked = false;
            outOfStock.Checked = false;
            ApplyFilters();
            
        }

        private void all_Click(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void outOfStock_CheckedChanged(object sender, EventArgs e)
        {
            Unavailable.Checked = false;
            checkBox1.Checked = false;
            ApplyFilters();
        }
    }
}
