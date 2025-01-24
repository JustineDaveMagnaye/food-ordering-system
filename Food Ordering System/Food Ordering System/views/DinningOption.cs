using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class DinningOption : Form
    {

        public int ReceiveDataId { get; set; } 

        public DinningOption()
        {
            InitializeComponent();
            ApplyRoundedCorners(pnl_dinein, 25);
            ApplyRoundedCorners(pnl_takeaway, 25);
            ApplyRoundedCorners(btn_back, 27);
        }



        private void ApplyRoundedCorners(Panel panel, int cornerRadius)
        {
            Rectangle bounds = new Rectangle(0, 0, panel.Width, panel.Height);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            panel.Region = new Region(path);
        }

        private void ApplyRoundedCorners(Button button, int cornerRadius)
        {
            Rectangle bounds = new Rectangle(0, 0, button.Width, button.Height);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(bounds.X, bounds.Y, cornerRadius, cornerRadius, 180, 90);
            path.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y, cornerRadius, cornerRadius, 270, 90);
            path.AddArc(bounds.X + bounds.Width - cornerRadius, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            button.Region = new Region(path);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pnl_takeaway_Paint(object sender, PaintEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MainOptions menu = new MainOptions { IsDineIn = true, ReceiveDataId = ReceiveDataId };
            this.Visible = false;
            menu.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainOptions menu = new MainOptions { IsDineIn = false, ReceiveDataId = ReceiveDataId };
            this.Visible = false;
            menu.Show();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                this.Visible = false;
                loginForm.Show();
            }
        }
    }
}
