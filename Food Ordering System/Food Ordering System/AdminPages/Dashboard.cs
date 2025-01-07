using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;
using System.Runtime.InteropServices;
using Food_Ordering_System.src.main.appl.facade.product;
using Food_Ordering_System.src.main;
using Food_Ordering_System.src.main.appl.facade.account;
using LiveCharts.Wpf;
using LiveCharts;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Food_Ordering_System.src.main.appl.facade.sales;
using Food_Ordering_System.src.main.appl.facade.account;

namespace Food_Ordering_System.AdminPages
{
    public partial class Dashboard : UserControl
    {
        
        private productFacade productFacade;
        private accountFacade accountFacade;
        private salesFacade salesFacade;

        ProductInfoMgtApplication appl = new ProductInfoMgtApplication();
        AccountInfoMgtApplication app = new AccountInfoMgtApplication();
        SalesInfoMgtApplication ap = new SalesInfoMgtApplication();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public Dashboard()
        {
            InitializeComponent();
            ApplyRoundedCorners();
            FetchAndSetProductCount();
            FetchAndSetTotalSalesAmount();
            FetchAndSetEmployeeCount();
        }

        private void ApplyRoundedCorners()
        {
            panel6.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel6.Width, panel6.Height, 20, 20));
            panel5.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel5.Width, panel5.Height, 20, 20));
            panel4.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 20, 20));
            panel3.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 20, 20));
            flowLayoutPanel1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, flowLayoutPanel1.Width, flowLayoutPanel1.Height, 20, 20));
        }

        private void Dashboard_Resize(object sender, EventArgs e)
        {
            ApplyRoundedCorners();
        }

        private void FetchAndSetProductCount()
        {
            try
            {
                productFacade = appl.getProductFacade();

                lbl_products.Text = productFacade.GetProductCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching product count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchAndSetTotalSalesAmount()
        {
            try
            {
                salesFacade = ap.GetSalesFacade();
                lbl_sales.Text = salesFacade.getTotalSalesAmount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching total sales amount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FetchAndSetEmployeeCount()
        {
            try
            {
                accountFacade = app.GetAccountFacade();
                lbl_employees.Text = accountFacade.GetAccountCount().ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching employee count: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            LoadSalesChart(0);
            LoadPieChart();
            LoadBestSellingProduct();
            solidGauge1.BackColor = Color.Transparent;
            cartesianChart2.BackColor = Color.FromArgb(53, 70, 92);
            pieChart1.BackColor = Color.FromArgb(53, 70, 92);
        }

        private void LoadSalesChart(int selectedMonth = 0)
        {
            try
            {
                salesFacade = ap.GetSalesFacade();
                var productSales = salesFacade.GetSalesData(selectedMonth);
                var seriesCollection = new SeriesCollection();
                var salesMonths = new List<string>();

                if (selectedMonth == 0)
                {
                    lblmonth.Text = "Sales Revenue";
                }
                else
                {
                    lblmonth.Text = $"Sales Revenue ({new DateTime(2024, selectedMonth, 1):MMMM})";
                }

                foreach (var product in productSales)
                {
                    var salesValues = new ChartValues<double>();

                    for (int month = 1; month <= 12; month++)
                    {
                        var sale = product.Value.FirstOrDefault(s => s.Key == month);
                        salesValues.Add(sale.Equals(default(KeyValuePair<int, double>)) ? 0 : sale.Value);

                        if (!salesMonths.Contains(new DateTime(2024, month, 1).ToString("MMMM")))
                        {
                            salesMonths.Add(new DateTime(2024, month, 1).ToString("MMMM"));
                        }
                    }

                    seriesCollection.Add(new LineSeries
                    {
                        Title = product.Key,
                        Values = salesValues,
                        PointGeometry = null,
                        LineSmoothness = 0
                    });
                }

                cartesianChart2.Series = seriesCollection;

                cartesianChart2.AxisX.Clear();
                cartesianChart2.AxisX.Add(new Axis
                {
                    Title = "Month",
                    Labels = salesMonths
                });

                cartesianChart2.AxisY.Clear();
                cartesianChart2.AxisY.Add(new Axis
                {
                    Title = "Sales Amount",
                    LabelFormatter = value => $"₱{value:N2}"
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading sales chart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPieChart()
        {
            try
            {
                salesFacade = ap.GetSalesFacade();
                var categoryCounts = salesFacade.GetProductCountByCategory();

                SeriesCollection pieSeries = new SeriesCollection();
                Random random = new Random();

                foreach (var categoryCount in categoryCounts)
                {
                    string category = categoryCount.Key;
                    int count = categoryCount.Value;

                    System.Windows.Media.Color pieColor = System.Windows.Media.Color.FromRgb(
                        (byte)random.Next(0, 256),
                        (byte)random.Next(0, 256),
                        (byte)random.Next(0, 256)
                    );

                    String check = category;
                    if (check.Equals("Main Dish"))
                    {
                        check = "maindish";
                    }

                    Control[] foundControlsLabel = this.Controls.Find(check, true);
                    Control[] foundControlsPanel = this.Controls.Find("p" + check, true);

                    if (foundControlsLabel.Length > 0 && foundControlsLabel[0] is Label label)
                    {
                        label.Text = count.ToString();
                    }
                    else
                    {
                        Console.WriteLine($"Label with name {category} not found.");
                    }

                    if (foundControlsPanel.Length > 0 && foundControlsPanel[0] is Panel panel)
                    {
                        panel.BackColor = System.Drawing.Color.FromArgb(pieColor.R, pieColor.G, pieColor.B);
                    }
                    else
                    {
                        Console.WriteLine($"Panel with name {category} not found.");
                    }

                    pieSeries.Add(new PieSeries
                    {
                        Title = category,
                        Values = new ChartValues<int> { count },
                        DataLabels = true,
                        Fill = new System.Windows.Media.SolidColorBrush(pieColor)
                    });
                }

                pieChart1.Series = pieSeries;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pie chart: {ex.Message}");
            }
        }
        private void LoadBestSellingProduct()
        {
            try
            {
                salesFacade = ap.GetSalesFacade();
                string bestSellingProduct = salesFacade.GetBestSellingProduct();

                if (bestSellingProduct != null)
                {
                    lblBestSellingProduct.Text = bestSellingProduct;

                    decimal totalSales = salesFacade.GetTotalSalesForProduct(bestSellingProduct);

                    solidGauge1.Value = (double)totalSales;
                    solidGauge1.ForeColor = Color.White;
                }
                else
                {
                    solidGauge1.Value = 0;
                    lblBestSellingProduct.Text = "No sales data available";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading best-selling product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        bool datefilterExpand = true;

        private void datefilterTimer_Tick(object sender, EventArgs e)
        {
            if (datefilterExpand)
            {
                dateFilter.Height += 10;
                if (dateFilter.Height >= dateFilter.MaximumSize.Height)
                {
                    FilterButton.Width = FilterButton.MinimumSize.Width;
                    dateFilter.Height = dateFilter.MaximumSize.Height;
                    dateFilter.AutoScroll = true;
                    datefilterExpand = false;
                    datefilterTimer.Stop();
                }
            }
            else
            {
                dateFilter.Height -= 10;

                if (dateFilter.Height <= dateFilter.MinimumSize.Height)
                {
                    FilterButton.Width = FilterButton.MaximumSize.Width;
                    dateFilter.Height = dateFilter.MinimumSize.Height;
                    dateFilter.AutoScroll = false;
                    datefilterExpand = true;
                    datefilterTimer.Stop();
                }
            }
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            datefilterTimer.Start();
        }

        private void January_Click(object sender, EventArgs e)
        {
            LoadSalesChart(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadSalesChart(2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadSalesChart(3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadSalesChart(4);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadSalesChart(5);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadSalesChart(6);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadSalesChart(7);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadSalesChart(8);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadSalesChart(9);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadSalesChart(10);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoadSalesChart(11);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            LoadSalesChart(12);
        }
    }
}
