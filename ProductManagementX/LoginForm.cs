using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProductManagementX
{
    public partial class LoginForm : Form
    {
        SqlConnection connection;

        public LoginForm()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-RM70GOU\\SQLEXPRESS;Database=StoreXDB;Integrated Security=true;");
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                MessageBox.Show(this, "Successful connection", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, $"Database connection failed!\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection after checking
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter all required information!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Open the connection if it is closed
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string query = "SELECT RoleID FROM UserAccount WHERE Username = @Username AND Password = @Password";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                object roleID = cmd.ExecuteScalar();

                if (roleID != null)
                {
                    int userRole = Convert.ToInt32(roleID);

                    if (userRole == 1) // If Admin
                    {
                        MessageBox.Show("Login successful! Redirecting to Product Management.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Admin productForm = new Admin();
                        productForm.Show();
                        this.Hide(); // Hide the login form
                    }
                    else if (userRole == 2) // If Sales
                    {
                        MessageBox.Show("Login successful! Redirecting to Sales.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Sales salesForm = new Sales();
                        salesForm.Show();
                        this.Hide(); // Hide the login form
                    }
                    else if (userRole == 3)
                    {
                        MessageBox.Show("Login successful! Redirecting to Warehouse.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Warehouse warehouseForm = new Warehouse(); // Bạn cần phải tạo form Warehouse
                        warehouseForm.Show();
                        this.Hide(); // Ẩn form đăng nhập
                    }    
                    else
                    {
                        MessageBox.Show("You do not have the required access rights!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection error: " + ex.Message, "System Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed after executing the query
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Xác nhận với người dùng trước khi thoát
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Nếu người dùng chọn Yes, thoát ứng dụng
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}