using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Food_Ordering_System.src.main.appl.model;
using Google.Protobuf;
using Guna.UI2.WinForms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Food_Ordering_System
{
    public partial class MainOptions : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void ApplyRoundedCorners(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
        }

        private const string ConnectionString = "Server=localhost;Database=db_food_ordering_system;UserId=root;Password=jaydev;";

        Cart cart = new Cart();

        public Boolean IsDineIn { get; set; }

        public int ReceiveDataId { get; set; }

        public string paymentMethod { get; set; }


        private string selectedCategory = ""; // Tracks the currently selected category

        public MainOptions()
        {
            InitializeComponent();
            ApplyRoundedCorners(this, 100);
            LoadProducts(category: "Main Dish");
            ApplyRoundedCorners(flowLayoutPanel1, 20);
            UpdateReceipt();
        }

        private void UpdateDiningOption(Boolean IsDineIn)
        {
            if (IsDineIn)
            {
                Console.WriteLine(IsDineIn);
                btnDineIn.Checked = true;

            } else
            {
                btnTakeOut.Checked = true;
            }
        }

        private void LoadProducts(string search = "", string statusFilter = null, string category = "")
        {
            try
            {
                flp_Products.Controls.Clear();

                using (MySqlConnection connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT product_id, food_name, price, img, status, category FROM tbl_product WHERE 1=1";

                    if (!string.IsNullOrEmpty(search))
                        query += " AND food_name LIKE @search";
                    if (!string.IsNullOrEmpty(statusFilter))
                        query += " AND status = @status";
                    if (!string.IsNullOrEmpty(category))
                        query += " AND category = @category";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (!string.IsNullOrEmpty(search))
                            command.Parameters.AddWithValue("@search", $"%{search}%");
                        if (!string.IsNullOrEmpty(statusFilter))
                            command.Parameters.AddWithValue("@status", statusFilter);
                        if (!string.IsNullOrEmpty(category))
                            command.Parameters.AddWithValue("@category", category);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var productCard = CreateProductCard(
                                    reader["product_id"].ToString(),
                                    reader["food_name"].ToString(),
                                    Convert.ToDouble(reader["price"]),
                                    reader["img"] as byte[],
                                    reader["status"].ToString(),
                                    reader["category"].ToString()
                                );

                                flp_Products.Controls.Add(productCard);
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


        private Guna2Button CreateProductCard(string productId, string name, double price, byte[] imgData, string status, string category)
        {
            // Check if the product is already in the cart
            bool isChecked = cart.GetItems().Any(item => item.FoodName == name);

            var card = new Guna2Button
            {
                Size = new Size(140, 190), // Keeping the original size
                FillColor = Color.White,
                BorderColor = Color.LightGray,
                ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.ToogleButton,
                CheckedState =
        {
            FillColor = Color.FromArgb(255, 208, 204),
            BorderColor = Color.FromArgb(255, 113, 102)
        },
                HoverState =
        {
            FillColor = Color.FromArgb(255, 208, 204),
            BorderColor = Color.FromArgb(255, 113, 102)
        },
                PressedDepth = 3,
                BorderThickness = 3,
                BorderRadius = 20,
                BackColor = Color.WhiteSmoke,
                Margin = new Padding(0, 10, 10, 20),
                Checked = isChecked // Set the initial checked state based on the cart
            };

            // Image
            var pbImage = new PictureBox
            {
                Size = new Size(120, 80), // Maximize within the card
                Image = imgData != null && imgData.Length > 0 ? ByteArrayToImage(imgData) : Properties.Resources.No_Image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point((card.Width - 120) / 2, 10), // Centered
                Enabled = false // Prevents intercepting click events
            };
            card.Controls.Add(pbImage);

            // Name Label
            var lblName = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 9, FontStyle.Bold), // Adjust font size to fit
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                MaximumSize = new Size(card.Width - 10, 40), // Max width with word wrap
                Size = new Size(card.Width - 20, 40), // Fixed height for multi-line text
                Location = new Point(10, pbImage.Bottom + 5),
                BackColor = Color.White,
                Enabled = false // Prevents intercepting click events
            };
            lblName.Text = WrapText(lblName, name);
            card.Controls.Add(lblName);

            // Price Label
            var lblPrice = new Label
            {
                Text = $"Price: {price.ToString("C", new CultureInfo("es-PH"))}",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false,
                Size = new Size(card.Width - 20, 20),
                Location = new Point(10, lblName.Bottom + 5),
                BackColor = Color.White,
                Enabled = false // Prevents intercepting click events
            };
            card.Controls.Add(lblPrice);

            // Hover and Click Events
            card.MouseEnter += (sender, e) =>
            {
                lblPrice.BackColor = Color.FromArgb(255, 208, 204);
                lblName.BackColor = Color.FromArgb(255, 208, 204);
                pbImage.BackColor = Color.FromArgb(255, 208, 204);
            };

            card.MouseLeave += (sender, e) =>
            {
                if (!card.Checked)
                {
                    lblPrice.BackColor = Color.White;
                    lblName.BackColor = Color.White;
                    pbImage.BackColor = Color.White;
                }
            };

            card.Click += (sender, e) =>
            {
                if (card.Checked)
                {
                    lblPrice.BackColor = Color.FromArgb(255, 208, 204);
                    lblName.BackColor = Color.FromArgb(255, 208, 204);
                    pbImage.BackColor = Color.FromArgb(255, 208, 204);
                    SelectProductQuantity(card, lblPrice, lblName, pbImage, price, category, productId);
                }
                else
                {
                    RemoveItemFromCart(name);
                }
            };

            return card;
        }



        // Utility for Wrapping Text
        private string WrapText(Label label, string text)
        {
            using (Graphics g = label.CreateGraphics())
            {
                StringBuilder sb = new StringBuilder();
                string[] words = text.Split(' ');
                string line = "";

                foreach (string word in words)
                {
                    string testLine = line + word + " ";
                    SizeF size = g.MeasureString(testLine, label.Font);

                    if (size.Width > label.MaximumSize.Width)
                    {
                        sb.AppendLine(line.Trim());
                        line = word + " ";
                    }
                    else
                    {
                        line = testLine;
                    }
                }

                sb.Append(line.Trim());
                return sb.ToString();
            }
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
                if(alternateColor == 0)
                {
                    color1 = Color.FromArgb(218,218,218);
                    color2 = Color.WhiteSmoke;
                    alternateColor = 1;
                } else
                {
                    color1 = Color.White;
                    color2 = Color.White;
                    alternateColor = 0;
                }
                var itemPanel = new Guna.UI2.WinForms.Guna2Panel
                {
                    Size = new Size(flp_Receipt.Width - 5, itemPanelHeight), // Reduced width for better spacing
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

                // Category Label
                var lblCategory = new Label
                {
                    Text = item.Category,
                    Font = new Font("Segoe UI", 10, FontStyle.Regular),
                    BackColor = GetCategoryColor(item.Category),
                    ForeColor = Color.White,
                    AutoSize = true,
                    Dock = DockStyle.Bottom,
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
                itemPanel.Controls.Add(lblCategory);
                

                // Add item panel to the receipt
                flp_Receipt.Controls.Add(itemPanel);
            }

            // Add summary section
            var summaryPanel = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = new Size(flp_Receipt.Width - 5, summaryPanelHeight),
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
                Text = string.Format(new CultureInfo("es-PH"), "Total: {0:C}", cart.GetTotalPrice()),
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

            // Add buttons
            var buttonPanel = new Guna.UI2.WinForms.Guna2Panel
            {
                Size = new Size(flp_Receipt.Width - 5, buttonPanelHeight),
                BackColor = Color.WhiteSmoke,
                BorderRadius = 8,
                Padding = new Padding(10),
                Margin = new Padding(5, 10, 5, 5),
                BorderColor = Color.FromArgb(218, 218, 218),
                BorderThickness = 2
            };

            var btnGCash = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Gcash",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BorderRadius = 10,
                FillColor = Color.FromArgb(10,127,255),
                Size = new Size(100, 35),
                Dock = DockStyle.Left,
                Margin = new Padding(5)
            };

            btnGCash.Click += (sender, e) =>
            {
                if (items.Count > 0 )
                {
                    BillingForm form = new BillingForm();
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        paymentMethod = form.PaymentMethod;
                        DinningOption dinningOption = new DinningOption();
                        dinningOption.Show();
                        Receipt receipt = new Receipt();
                        receipt.cart = cart;
                        receipt.IsDineIn = IsDineIn;
                        receipt.PaymentMethod = paymentMethod;
                        this.Close();
                        receipt.ReceiveDataId = ReceiveDataId;
                        receipt.ShowDialog();
                    }
                    else
                    {
                        Console.WriteLine("Canceled Successfully!");
                    }
                }
            };
            var btnCash = new Guna.UI2.WinForms.Guna2Button
            {
                Text = "Cash",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BorderRadius = 10,
                FillColor = Color.FromArgb(0,207,49),
                Size = new Size(100, 35),
                Dock = DockStyle.Right,
                Margin = new Padding(5)
            };
            btnCash.Click += (sender, e) =>
            {
                if (items.Count > 0)
                {
                    DinningOption dinningOption = new DinningOption();
                    dinningOption.Show();
                    Receipt receipt = new Receipt();
                    receipt.cart = cart;
                    receipt.IsDineIn = IsDineIn;
                    receipt.PaymentMethod = "Cash";
                    this.Close();
                    receipt.ReceiveDataId = ReceiveDataId;
                    receipt.ShowDialog();
                }
            };


            // Add buttons to the button panel
            btnGCash.Location = new Point(10, (buttonPanelHeight - btnGCash.Height) / 2);
            btnCash.Location = new Point(btnGCash.Right + 10, (buttonPanelHeight - btnCash.Height) / 2);
            buttonPanel.Controls.Add(btnGCash);
            buttonPanel.Controls.Add(btnCash);

            // Add button panel to the receipt
            flp_Receipt.Controls.Add(buttonPanel);
        }


        private Color GetCategoryColor(string category)
        {
            // Updated to visually pleasing colors
            switch (category)
            {
                case "Appetizer":
                    return Color.FromArgb(255, 84, 25);  // Tomato red
                case "Main Course":
                    return Color.FromArgb(255, 84, 25);   // Red-Orange
                case "Dessert":
                    return Color.FromArgb(255, 103, 51); // Deep Pink
                default:
                    return Color.FromArgb(255, 122, 77);    // Dark Red
            }

        }

        private void RemoveItemFromCart(string itemName)
        {
            // Find the item in the cart and remove it
            Item itemToRemove = cart.GetItems().FirstOrDefault(item => item.FoodName == itemName);
            if (itemToRemove != null)
            {
                cart.RemoveItem(itemToRemove);
                UpdateReceipt(); // Refresh the receipt
            }
        }



        private void SelectProductQuantity(Guna2Button card, Label price, Label name, PictureBox image, double dbprice, string category, string productId)
        {
            using (QuantityOption quantity = new QuantityOption())
            {
                quantity.price = price;
                quantity.name = name;
                quantity.image = image;
                quantity.selectedCard = card;
                if (quantity.ShowDialog(this) == DialogResult.OK)
                {
                    int num = quantity.SelectedNumber;
                    Item newItem = new Item(productId, name.Text, dbprice, category, num);
                    cart.AddItem(newItem);

                    // Update the receipt after adding an item
                    UpdateReceipt();
                }
                else
                {
                    Console.WriteLine("Canceled Successfully!");
                }
            }
        }



        private Image ByteArrayToImage(byte[] byteArray)
        {
            try
            {
                using (var memoryStream = new MemoryStream(byteArray))
                {
                    return Image.FromStream(memoryStream);
                }
            }
            catch
            {
                return Properties.Resources.No_Image; // Default image on error
            }
        }

        private void MainOptions_Load(object sender, EventArgs e)
        {
            UpdateDiningOption(IsDineIn);
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = ((Guna.UI2.WinForms.Guna2TextBox)sender).Text;
            LoadProducts(search: searchQuery, category: selectedCategory);
        }

        private void btn_maindish_Click(object sender, EventArgs e)
        {
            selectedCategory = "Main Dish";
            LoadProducts(category: selectedCategory);
        }

        private void btn_appetizer_Click(object sender, EventArgs e)
        {
            selectedCategory = "Appetizer";
            LoadProducts(category: selectedCategory);
        }

        private void btn_dessert_Click(object sender, EventArgs e)
        {
            selectedCategory = "Dessert";
            LoadProducts(category: selectedCategory);
        }

        private void btn_drinks_Click(object sender, EventArgs e)
        {
            selectedCategory = "Drinks";
            LoadProducts(category: selectedCategory);
        }

        private void btn_others_Click(object sender, EventArgs e)
        {
            selectedCategory = null;
            LoadProducts(category: selectedCategory);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DinningOption dinningOption = new DinningOption();
            dinningOption.Show();
            this.Close();
        }

        private void btnDineIn_Click(object sender, EventArgs e)
        {
            IsDineIn = true;
        }

        private void btnTakeOut_Click(object sender, EventArgs e)
        {
            IsDineIn = false;
        }
    }
}
