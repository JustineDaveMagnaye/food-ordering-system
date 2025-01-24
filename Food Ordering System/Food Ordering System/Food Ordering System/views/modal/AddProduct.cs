using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Food_Ordering_System.src.main;
using Food_Ordering_System.src.main.appl.facade.product;

namespace Food_Ordering_System
{
    public partial class AddProduct : Form
    {
        private productFacade productFacade;

        ProductInfoMgtApplication appl = new ProductInfoMgtApplication();

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public AddProduct()
        {
            InitializeComponent();
            ApplyRoundedCorners();
        }
        private void ApplyRoundedCorners()
        {
            panel4.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel4.Width, panel4.Height, 50, 50));

            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 90, 90));

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                ImageFormat format = ImageFormat.Jpeg;
                if (image.RawFormat.Equals(ImageFormat.Jpeg))
                    format = ImageFormat.Jpeg;
                else if (image.RawFormat.Equals(ImageFormat.Png))
                    format = ImageFormat.Png;
                else if (image.RawFormat.Equals(ImageFormat.Gif))
                    format = ImageFormat.Gif;
                else if (image.RawFormat.Equals(ImageFormat.Bmp))
                    format = ImageFormat.Bmp;

                image.Save(memoryStream, format);

                return memoryStream.ToArray();
            }
        }

        private bool IsValidPrice(string price)
        {
            decimal parsedPrice;
            return decimal.TryParse(price, out parsedPrice);
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ProductID.Text) ||
                cb_Category.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txt_FoodName.Text) ||
                !IsValidPrice(txt_Price.Text) ||
                cb_Status.SelectedIndex == -1 ||
                lbl_Icon.Image == null)
            {
                MessageBox.Show("Please fill in all the fields and ensure they are valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                productFacade = appl.getProductFacade();
                byte[] imageData = ImageToByteArray(lbl_Icon.Image);
                productFacade.AddProduct(txt_ProductID.Text, cb_Category.SelectedItem.ToString(), txt_FoodName.Text, txt_Price.Text, cb_Status.SelectedItem.ToString(), imageData);
                MessageBox.Show("Product added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txt_ProductID.Clear();
                cb_Category.SelectedIndex = -1;
                txt_FoodName.Clear();
                txt_Price.Clear();
                cb_Status.SelectedIndex = -1;


                this.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Generate_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            string generatedNumber = $"{random.Next(100, 999)}-{random.Next(100, 999)}-{random.Next(10, 99)}";

            txt_ProductID.Text = generatedNumber;
        }

        private void btn_Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All Files|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string selectedFileName = openFileDialog.FileName;
                    lbl_Icon.Image = ResizeImage(Image.FromFile(selectedFileName), 189, 145);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
