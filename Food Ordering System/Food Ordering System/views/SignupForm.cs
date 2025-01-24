using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Food_Ordering_System.src.main;
using Food_Ordering_System.src.main.appl.facade.account;
using Food_Ordering_System.src.main.appl.facade.employee;
using Food_Ordering_System.src.main.appl.model;

namespace Food_Ordering_System
{
    public partial class SignupForm : Form
    {

        private accountFacade accountFacade;

        private employeeFacade employeeFacade;

        AccountInfoMgtApplication appl = new AccountInfoMgtApplication();

        EmployeeInfoMgtApplication emp = new EmployeeInfoMgtApplication();
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private void ApplyRoundedCorners(Control control, int radius)
        {
            control.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius));
        }

        private void InsertDataIntoTable(string fullname, string username, string password)
        {
            try
            {
                accountFacade = appl.GetAccountFacade();
                employeeFacade = emp.getEmployeeFacade();
                Account newAccount = new Account();
                Employee newEmployee = new Employee();
                newEmployee.FullName = fullname;
                newAccount.Username = username;
                newAccount.Password = password;
                newAccount.Role = "User";
                Account currentUser = accountFacade.Register(newAccount);
                newEmployee.AccountId = currentUser.Id;
                Employee currentEmployee = employeeFacade.AddEmployee(newEmployee);


                MessageBox.Show("Account created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoginForm login = new LoginForm();
                this.Visible = false;
                login.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public SignupForm()
        {
            InitializeComponent();
            HookEvents();
            ApplyRoundedCorners(this, 50);

        }


        private Image ResizeImage(Image image, Size size)
        {
            return new Bitmap(image, size);
        }

        private void lbl_signup_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            this.Visible = false;
            login.Show();
        }

        private void lbl_exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit this app?", "Exit Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }


        private void HookEvents()
        {

            txt_fullname.GotFocus += (s, e) =>
            {
                txt_fullname.FillColor = System.Drawing.Color.White;
                txt_fullname.PlaceholderForeColor = System.Drawing.Color.FromArgb(255, 65, 51);
                txt_fullname.ForeColor = System.Drawing.Color.FromArgb(255, 65, 51);
            };
            txt_fullname.LostFocus += (s, e) =>
            {
                txt_fullname.FillColor = System.Drawing.Color.FromArgb(255, 65, 51);
                txt_fullname.PlaceholderForeColor = Color.White;
                txt_fullname.ForeColor = Color.White;
            };

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
            };
            txt_password.LostFocus += (s, e) =>
            {
                txt_password.FillColor = System.Drawing.Color.FromArgb(255, 65, 51);
                txt_password.PlaceholderForeColor = Color.White;
                txt_password.ForeColor = Color.White;
            };
            txt_confirmPassword.GotFocus += (s, e) =>
            {
                txt_confirmPassword.FillColor = System.Drawing.Color.White;
                txt_confirmPassword.PlaceholderForeColor = System.Drawing.Color.FromArgb(255, 65, 51);
                txt_confirmPassword.ForeColor = System.Drawing.Color.FromArgb(255, 65, 51);
            };
            txt_confirmPassword.LostFocus += (s, e) =>
            {
                txt_confirmPassword.FillColor = System.Drawing.Color.FromArgb(255, 65, 51);
                txt_confirmPassword.PlaceholderForeColor = Color.White;
                txt_confirmPassword.ForeColor = Color.White;
            };
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            if (txt_fullname.Text.Length < 1)
            {
                errorname.Text = "Please Input Your Full Name.";
            }
            else
            {
                errorname.Text = "";
            }
            if (txt_username.Text.Length < 1)
            {
                errorusername.Text = "Please Input Your Username.";
            }
            else
            {
                errorusername.Text = "";
            }
            if (txt_password.Text.Length < 1)
            {
                errorpassword.Text = "Please Input Your Password.";
            }
            else
            {
                errorpassword.Text = "";
            }
            if (txt_confirmPassword.Text.Length < 1)
            {
                errorconfirmpass.Text = "Please Input Your Confirm Password.";
            }
            else
            {
                errorconfirmpass.Text = "";
            }
            if (txt_confirmPassword.Text.Equals(txt_password.Text) && !txt_confirmPassword.Text.Equals("") && EvaluatePasswordStrength(txt_password.Text) != "Very Weak")
            {
                if (!txt_fullname.Text.Equals("") && !txt_username.Text.Equals("") && !txt_password.Text.Equals("") && !txt_confirmPassword.Text.Equals(""))
                {
                    accountFacade = appl.GetAccountFacade();
                    Account account = accountFacade.GetAccountByUsername(txt_username.Text);
                    if (account != null)
                    {
                        errorusername.Text = "Username Already Exists!";
                    }
                    else
                    {
                        string HashPass = BCrypt.Net.BCrypt.HashPassword(txt_password.Text);
                        InsertDataIntoTable(txt_fullname.Text, txt_username.Text, HashPass);
                    }
                }
            }
            else if (EvaluatePasswordStrength(txt_password.Text) == "Very Weak")
            {
                errorpassword.Text = "Password is too weak!";
            }
            else if (!txt_confirmPassword.Text.Equals(""))
            {
                errorconfirmpass.Text = "Password Mismatch!";
            }
        }

        private void txt_password_TextChanged(object sender, EventArgs e)
        {
            string password = txt_password.Text;
            string strength = EvaluatePasswordStrength(password);
            errorpassword.Text = "Password Strength: " + strength;

            if (strength == "Very Strong")
            {
                errorpassword.ForeColor = Color.LightGreen;
            }
            else if (strength == "Strong")
            {
                errorpassword.ForeColor = Color.LightBlue; 
            }
            else if (strength == "Medium")
            {
                errorpassword.ForeColor = Color.LightYellow;
            }
            else
            {
                errorpassword.ForeColor = Color.White; 
            }

        }
        private string EvaluatePasswordStrength(string password)
        {
            int score = 0;
            if (password.Length >= 8) score++;
            if (password.Any(char.IsUpper)) score++;
            if (password.Any(char.IsLower)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (password.Any(ch => "!@#$%^&*()_+[]{}|;:,.<>?".Contains(ch))) score++;
            switch (score)
            {
                case 5:
                    return "Very Strong";
                case 4:
                    return "Strong";
                case 3:
                    return "Medium";
                case 2:
                    return "Weak";
                default:
                    return "Very Weak";
            }
        }

        private void lbl_signup_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
