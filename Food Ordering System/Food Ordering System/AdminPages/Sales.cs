using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Food_Ordering_System.AdminPages
{
    public partial class Sales : UserControl
    {
        private string connectionString = "Server=localhost;Database=db_food_ordering_system;UserId=root;Password=jaydev;";

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

        public Sales()
        {
            InitializeComponent();
            PopulateSalesTable();
            ApplyRoundedCorners();  
        }

        private void ApplyRoundedCorners()
        {
            tbl_sales.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, tbl_sales.Width, tbl_sales.Height, 20, 20));
            panel2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel2.Width, panel2.Height, 20, 20));
        }

        private void PopulateSalesTable()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = @"
            SELECT 
                e.full_name, 
                p.food_name,
                s.date, 
                s.time, 
                s.amount
            FROM 
                tbl_sales s
            JOIN 
                tbl_product p ON s.product_id = p.product_id
            JOIN 
                tbl_account a ON s.account_id = a.account_id
            JOIN
                tbl_employee e ON s.account_id = e.account_id";

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                    {
                        // Clear any existing data in the DataGridView
                        tbl_sales.DataSource = null;
                        tbl_sales.Rows.Clear();
                        tbl_sales.Columns.Clear();
                        tbl_sales.BackgroundColor = Color.FromArgb(53, 70, 92); // Set background color

                        DataTable salesDataTable = new DataTable();
                        adapter.Fill(salesDataTable);

                        // Set the DataTable as the DataSource of the DataGridView
                        tbl_sales.DataSource = salesDataTable;

                        // Customizing the header appearance (optional)
                        tbl_sales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(35, 40, 45);
                        tbl_sales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        tbl_sales.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

                        // Optional: Set alignment for header text
                        foreach (DataGridViewColumn column in tbl_sales.Columns)
                        {
                            column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error populating sales table: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void tbl_sales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
