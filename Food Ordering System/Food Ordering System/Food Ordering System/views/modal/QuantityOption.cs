using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace Food_Ordering_System
{
    public partial class QuantityOption : Form
    {
        public Guna2Button selectedCard { get; set; }
        public Label price { get; set; }
        public Label name { get; set; }
        public PictureBox image { get; set; }
        int DefaultNumber = 1;
        public int SelectedNumber { get; set; }
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void ApplyRoundedCorners(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
        }
        public QuantityOption()
        {
            InitializeComponent();
            number.Text = DefaultNumber.ToString();
            ApplyRoundedCorners(this, 50);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            price.BackColor = Color.White;
            name.BackColor = Color.White;
            image.BackColor = Color.White;
            selectedCard.Checked = false;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void minus_Click(object sender, EventArgs e)
        {
            if (DefaultNumber != 0)
            {
                DefaultNumber -= 1;
                number.Text = DefaultNumber.ToString();
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            DefaultNumber += 1;
            number.Text = DefaultNumber.ToString();
        }

        private void done_Click(object sender, EventArgs e)
        {
            if (DefaultNumber == 0)
            {
                price.BackColor = Color.White;
                name.BackColor = Color.White;
                image.BackColor = Color.White;
                selectedCard.Checked = false;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                SelectedNumber = DefaultNumber;
                this.Close();
            }
        }
    }
}
