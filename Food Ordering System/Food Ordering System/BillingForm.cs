using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class BillingForm : Form
    {
        public int ReceiveDataId { get; set; }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void ApplyRoundedCorners(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
        }

        public string PaymentMethod { get; set; }

        public BillingForm()
        {
            InitializeComponent();
            ApplyRoundedCorners(this, 50);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void done_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals("") && !textBox2.Text.Equals(""))
            {
                if (guna2Button1.Checked == true || guna2Button2.Checked == true || guna2Button3.Checked == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                } else
                {
                    error.Text = "Please Select A Payment Method.";
                }
            } else
            {
                error.Text = "Please Fill Up The Card Details.";
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            PaymentMethod = "GCash";
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            PaymentMethod = "BDO";
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            PaymentMethod = "Paypal";
        }
    }
}
