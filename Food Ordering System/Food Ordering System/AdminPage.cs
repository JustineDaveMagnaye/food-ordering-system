using Food_Ordering_System.AdminPages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Ordering_System
{
    public partial class AdminPage : Form
    {
        bool sidebarExpand = true;

        public int ReceiveDataId { get; set; }
        public AdminPage()
        {
            InitializeComponent();
            Dashboard dashboard = new Dashboard();
            dashboard.Size = new Size(800, 600);
            addUserControl(dashboard);
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            contentPane.Controls.Clear();
            contentPane.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit this app?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private int targetWidth = 0; 
        private int targetFormWidth = 0; 
        private int easingStep = 15; 

        private void sidebarTimer_Tick(object sender, EventArgs e)
        {
            int currentSidebarWidth = sidebar.Width;
            int currentFormWidth = this.ClientSize.Width;

            if (sidebarExpand && currentSidebarWidth > sidebar.MinimumSize.Width)
            {
                sidebar.Width = Math.Max(currentSidebarWidth - easingStep, sidebar.MinimumSize.Width);
            }
            else if (!sidebarExpand && currentSidebarWidth < sidebar.MaximumSize.Width)
            {
                sidebar.Width = Math.Min(currentSidebarWidth + easingStep, sidebar.MaximumSize.Width);
            }

            if (sidebarExpand && currentFormWidth > targetFormWidth)
            {
                this.ClientSize = new System.Drawing.Size(Math.Max(currentFormWidth - easingStep, targetFormWidth), this.ClientSize.Height);
            }
            else if (!sidebarExpand && currentFormWidth < targetFormWidth)
            {
                this.ClientSize = new System.Drawing.Size(Math.Min(currentFormWidth + easingStep, targetFormWidth), this.ClientSize.Height);
            }

            if ((sidebarExpand && sidebar.Width == sidebar.MinimumSize.Width && this.ClientSize.Width == targetFormWidth) ||
                (!sidebarExpand && sidebar.Width == sidebar.MaximumSize.Width && this.ClientSize.Width == targetFormWidth))
            {
                sidebarTimer.Stop();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sidebarExpand = !sidebarExpand;
            targetWidth = sidebarExpand ? sidebar.MinimumSize.Width : sidebar.MaximumSize.Width;
            targetFormWidth = sidebarExpand ? 862 : 952;
            sidebarTimer.Start();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            addUserControl(products);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Sales sales = new Sales();
            addUserControl(sales);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to continue to POS System?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                contentPane.Controls.Clear();
                DinningOption option = new DinningOption{ ReceiveDataId = ReceiveDataId};
                this.Visible = false;
                option.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard sales = new Dashboard();
            addUserControl(sales);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you wish to logout?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                contentPane.Controls.Clear();
                LoginForm loginForm = new LoginForm();
                this.Visible = false;
                loginForm.Show();
            }
        }
    }
}
