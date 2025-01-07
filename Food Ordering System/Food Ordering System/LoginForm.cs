using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Food_Ordering_System.AdminPages;
using Food_Ordering_System.src.main;
using Food_Ordering_System.src.main.appl.facade.account;
using Food_Ordering_System.src.main.appl.model;

namespace Food_Ordering_System
{
    public partial class LoginForm : Form
    {
        private accountFacade accountFacade;
        private AccountInfoMgtApplication appl = new AccountInfoMgtApplication();
        private bool isPasswordVisible = false;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public LoginForm()
        {
            InitializeComponent();
            InitializeCustomUI();
            HookEvents();
            Dashboard dashboard = new Dashboard();
        }

        private void InitializeCustomUI()
        {
            ApplyRoundedCorners(panel6, 20);
            ApplyRoundedCorners(this, 100);

        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
        }

        private void HookEvents()
        {

            txt_username.GotFocus += (s, e) =>
            {
                txt_username.FillColor = System.Drawing.Color.White;
                txt_username.PlaceholderForeColor = System.Drawing.Color.FromArgb(255, 65, 51);
                txt_username.ForeColor = System.Drawing.Color.FromArgb(255, 65, 51); 
            };
            txt_username.LostFocus += (s, e) =>
            {
                txt_username.FillColor = System.Drawing.Color.FromArgb(255, 65, 51);
                txt_username.PlaceholderForeColor = Color.White;
                txt_username.ForeColor = Color.White;
            };

            txt_password.GotFocus += (s, e) =>
            {
                txt_password.FillColor = System.Drawing.Color.White;
                txt_password.PlaceholderForeColor = System.Drawing.Color.FromArgb(255, 65, 51);
                txt_password.ForeColor = System.Drawing.Color.FromArgb(255, 65, 51);
                pictureBox2.BackColor = Color.White;
            };
            txt_password.LostFocus += (s, e) =>
            {
                txt_password.FillColor = System.Drawing.Color.FromArgb(255, 65, 51);
                txt_password.PlaceholderForeColor = Color.White;
                txt_password.ForeColor = Color.White;
                pictureBox2.BackColor = System.Drawing.Color.FromArgb(255, 65, 51);
            };
        }

        private void CheckAccount(string username, string password)
        {
            try
            {
                accountFacade = appl.GetAccountFacade();
                var currentUser = accountFacade.GetAccountByUsername(username);

                if (currentUser == null)
                {
                    ShowError(errorUser, "Username not found!");
                    return;
                }

                ClearError(errorUser);
                if (!BCrypt.Net.BCrypt.Verify(password, currentUser.Password))
                {
                    ShowError(errorPass, "Incorrect Password!");
                    return;
                }

                ClearError(errorPass);
                NavigateToNextPage(currentUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowError(Label label, string message)
        {
            label.ForeColor = Color.White;
            label.Text = message;
        }

        private void ClearError(Label label)
        {
            label.Text = "";
        }

        private void NavigateToNextPage(Account user)
        {
            try
            {
                Form nextPage;
                if (user.Role == "Admin")
                {
                    nextPage = new AdminPage { ReceiveDataId = user.Id };
                }
                else
                {
                    nextPage = new DinningOption { ReceiveDataId = user.Id };
                }

                this.Hide();

                nextPage.FormClosed += (s, e) => this.Close(); 
                nextPage.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error navigating to the next page: {ex.Message}", "Navigation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignupForm().Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            txt_password.PasswordChar = isPasswordVisible ? '\0' : '●';
            pictureBox2.Image = isPasswordVisible ? Resource1.eye : Resource1.eyebrow;
        }

        private void btn_login_Click_1(object sender, EventArgs e)
        {
            CheckAccount(txt_username.Text, txt_password.Text);
        }
    }
}
