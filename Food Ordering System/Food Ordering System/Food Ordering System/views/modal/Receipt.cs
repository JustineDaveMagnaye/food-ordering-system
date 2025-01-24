using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Food_Ordering_System.src.main.appl.facade.sales.impl;
using Food_Ordering_System.src.main.appl.facade.sales;
using Food_Ordering_System.src.main.appl.model;
using Food_Ordering_System.src.main.data.sales.dao.impl;
using Food_Ordering_System.src.main;
using System.Drawing.Printing;

namespace Food_Ordering_System
{
    public partial class Receipt : Form
    {
        private salesFacade salesFacade;

        private SalesInfoMgtApplication appl = new SalesInfoMgtApplication();

        public int ReceiveDataId { get; set; } 
        public bool IsDineIn { get; set; } 
        public string PaymentMethod { get; set; } 
        public Cart cart { get; set; } 

        public Receipt()
        {
            InitializeComponent();

            salesFacade = appl.GetSalesFacade();
        }

        private void UpdateReceipt()
        {
            flp_Receipt.Controls.Clear();

            List<Item> items = cart.GetItems();

            int itemPanelHeight = 80;
            int summaryPanelHeight = 45;
            int alternateColor = 0;
            Color color1 = Color.FromArgb(245, 245, 245);
            Color color2 = Color.FromArgb(245, 245, 245);

            foreach (var item in items)
            {
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
                    Size = new Size(flp_Receipt.Width - 30, itemPanelHeight),
                    BackColor = color2,
                    BorderRadius = 8,
                    Padding = new Padding(10),
                    Margin = new Padding(5),
                    BorderColor = color1,
                    BorderThickness = 2
                };

                var lblName = new Label
                {
                    Text = item.FoodName,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    ForeColor = Color.Black,
                    AutoSize = true,
                    Margin = new Padding(0, 0, 0, 3)
                };

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

                itemPanel.Controls.Add(lblQuantity);
                itemPanel.Controls.Add(lblName);
                itemPanel.Controls.Add(lblPrice);

                flp_Receipt.Controls.Add(itemPanel);
            }

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

            flp_Receipt.Controls.Add(summaryPanel);
        }

        private void Receipt_Load(object sender, EventArgs e)
        {
            UpdateReceipt();
            try
            {
                salesFacade.InsertSalesRecord(cart, ReceiveDataId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error recording sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            lblisDineIn.Text = IsDineIn ? "Order Type: Dine In" : "Order Type: Take Out";
            lblPM.Text = "Payment Method: " + PaymentMethod;
            lbl_orderNumber.Text = salesFacade.GenerateOrderNumber().ToString();
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings.PaperSize = new PaperSize("Receipt", 280, 600);
            printDocument.PrintPage += new PrintPageEventHandler(PrintReceipt);
            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = printDocument
            };
            previewDialog.ShowDialog();
        }

        private void PrintReceipt(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font titleFont = new Font("Courier New", 12, FontStyle.Bold);
            Font font = new Font("Courier New", 9);
            Font boldFont = new Font("Courier New", 10, FontStyle.Bold);
            float yPos = 10;
            int leftMargin = 10;
            int rightMargin = 200;

            g.DrawString("Ejay & Ashley", titleFont, Brushes.Black, leftMargin + 55, yPos);

            yPos += 15;

            g.DrawString("Bulalohan", titleFont, Brushes.Black, leftMargin + 75, yPos);

            yPos += 15;

            g.DrawString("Sizzling Steakhouse", titleFont, Brushes.Black, leftMargin + 30, yPos);


            yPos += 25;

            g.DrawString("POS: POS 1", font, Brushes.Black, leftMargin, yPos);
            yPos += 15;
            g.DrawString("-----------------------------------", font, Brushes.Black, leftMargin, yPos);
            yPos += 15;
            g.DrawString(IsDineIn ? "Dine In" : "Take Out", font, Brushes.Black, leftMargin, yPos);
            yPos += 15;
            g.DrawString("-----------------------------------", font, Brushes.Black, leftMargin, yPos);
            yPos += 15;

            foreach (var item in cart.GetItems())
            {
                g.DrawString(item.FoodName, font, Brushes.Black, leftMargin, yPos);
                g.DrawString($"₱{item.Price * item.Quantity:0.00}", font, Brushes.Black, rightMargin, yPos);
                yPos += 15;
                g.DrawString($"{item.Quantity} x ₱{item.Price:0.00}", font, Brushes.Black, leftMargin, yPos);
                yPos += 15;
            }

            g.DrawString("-----------------------------------", font, Brushes.Black, leftMargin, yPos);
            yPos += 15;

            g.DrawString("Total", boldFont, Brushes.Black, leftMargin, yPos);
            g.DrawString($"₱{cart.GetTotalPrice():0.00}", boldFont, Brushes.Black, rightMargin, yPos);
            yPos += 20;

            g.DrawString(DateTime.Now.ToString("MM/dd/yy hh:mm tt"), font, Brushes.Black, leftMargin, yPos);
            yPos += 15;
            g.DrawString($"#{salesFacade.GenerateOrderNumber()}", font, Brushes.Black, rightMargin, yPos);
        }
    }
}
