using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProductManagementX
{
    public partial class Warehouse : Form
    {
        SqlConnection connection;
        public Warehouse()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-RM70GOU\\SQLEXPRESS;Database=StoreXDB;Integrated Security = true;");
            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Show the login form again
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                this.Close(); // Close the current form
            }
        }

        private void Warehouse_Load(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                MessageBox.Show(this, "Successful connection", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(this, $"Database connection failed!\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FillData();
            GetCategories();
            GetSupplier();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int error = 0;
            String id = txtProductID.Text;
            if (id.Equals(""))
            {
                error = error + 1;
                lbIDError.Text = "ID can't be blank";
                lbIDError.Visible = true;
            }
            else
            {
                lbIDError.Text = "";

            }
            string name = txtProductName.Text;
            if (name.Equals(""))
            {
                error = error + 1;
                lbNameError.Text = "Name can't be blank";
                lbNameError.Visible = true;
            }
            else
            {
                lbNameError.Text = "";

            }
            string price = txtPrice.Text;
            if (price.Equals(""))
            {
                error = error + 1;
                lbPriceError.Text = "Price can't be blank";
                lbPriceError.Visible = true;
            }
            else
            {
                lbPriceError.Text = "";

            }
            string quantity = txtQuantity.Text;
            if (quantity.Equals(""))
            {
                error = error + 1;
                lbQuantityError.Text = "Quantity can't be blank";
                lbQuantityError.Visible = true;
            }
            else
            {

                string query = "select * from Product where ProductID = @id";
                if (connection.State == ConnectionState.Closed)
                    connection.Open();
                SqlCommand cmdCheck = new SqlCommand(query, connection);
                cmdCheck.Parameters.Add("@id", SqlDbType.Int);
                cmdCheck.Parameters["@id"].Value = id;
                SqlDataReader reader = cmdCheck.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbIDError.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lbQuantityError.Text = "";
                }
                connection.Close();
            }
            string catid = cbCategory.SelectedValue.ToString();
            string supplierid = cbSupplier.SelectedValue.ToString();
            if (error == 0)
            {
                string insert = "insert into Product values (@id,@name,@price,@quantity,@catid,@supplierid)";
                connection.Open();
                SqlCommand cmd = new SqlCommand(insert, connection);
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = id;
                cmd.Parameters.Add("@name", SqlDbType.VarChar);
                cmd.Parameters["@name"].Value = name;
                cmd.Parameters.Add("@price", SqlDbType.Float);
                cmd.Parameters["@price"].Value = price;
                cmd.Parameters.Add("@quantity", SqlDbType.Int);
                cmd.Parameters["@quantity"].Value = quantity;
                cmd.Parameters.Add("@catid", SqlDbType.Int);
                cmd.Parameters["@catid"].Value = catid;
                cmd.Parameters.Add("@supplierid", SqlDbType.Int);
                cmd.Parameters["@supplierid"].Value = supplierid;
                cmd.ExecuteNonQuery();
                FillData();
                MessageBox.Show(this, "Insert Successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Please choose product to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id, quantity;
            double price;

            if (!int.TryParse(txtProductID.Text, out id) ||
                !double.TryParse(txtPrice.Text, out price) ||
                !int.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Please enter correct data format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = txtProductName.Text.Trim();
            int catid = Convert.ToInt32(cbCategory.SelectedValue);
            int supplierid = Convert.ToInt32(cbSupplier.SelectedValue);

            DialogResult result = MessageBox.Show("Do you want to update this product?",
                                                  "Question",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string query = "UPDATE Product SET ProductName = @name, Price = @price, InventoryQuantity = @quantity, " +
                               "CategoryID = @catid, SupplierID = @supplierid WHERE ProductID = @id";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@price", price);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    cmd.Parameters.AddWithValue("@catid", catid);
                    cmd.Parameters.AddWithValue("@supplierid", supplierid);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Update successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillData(); // Load lại dữ liệu sau khi cập nhật
                    }
                    else
                    {
                        MessageBox.Show("Could not find the product!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductID.Text))
            {
                MessageBox.Show("Please choose a product to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId = Convert.ToInt32(txtProductID.Text);

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Truy vấn lấy danh sách các OrderID có chứa ProductID này
                string checkQuery = @"
            SELECT DISTINCT o.OrderID
            FROM OrderDetail od
            JOIN [Order] o ON od.OrderID = o.OrderID
            WHERE od.ProductID = @ProductID";

                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@ProductID", productId);

                SqlDataReader reader = checkCmd.ExecuteReader();

                List<int> relatedOrders = new List<int>();
                while (reader.Read())
                {
                    relatedOrders.Add(reader.GetInt32(0));
                }
                reader.Close();

                if (relatedOrders.Count > 0)
                {
                    string orderList = string.Join(", ", relatedOrders);
                    MessageBox.Show(
                        $"This product is currently included in order(s): {orderList}. You cannot delete it.",
                        "Delete Denied",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                DialogResult result = MessageBox.Show("Do you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string deleteQuery = "DELETE FROM Product WHERE ProductID = @id";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@id", productId);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Product deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillData(); // Refresh data
                    }
                    else
                    {
                        MessageBox.Show("Product not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during deletion: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra không bấm vào header
            {
                DataGridViewRow row = dgvProduct.Rows[e.RowIndex];

                txtProductID.Text = row.Cells["ProductID"].Value.ToString();
                txtProductName.Text = row.Cells["ProductName"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
                txtQuantity.Text = row.Cells["InventoryQuantity"].Value.ToString();
                cbCategory.SelectedValue = row.Cells["CategoryID"].Value;
                cbSupplier.SelectedValue = row.Cells["SupplierID"].Value;
            }
        }

        private void btnSearchProduct_Click(object sender, EventArgs e)
        {
            string keyword = txtProductName.Text.Trim(); // Lấy từ khóa tìm kiếm từ ô txtProductName

            if (!string.IsNullOrEmpty(keyword)) // Nếu người dùng nhập từ khóa
            {
                SearchProductByName(keyword); // Gọi phương thức tìm kiếm với từ khóa
            }
            else
            {
                MessageBox.Show("Please enter a keyword to search!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void SearchProductByName(string keyword)
        {
            string query = "SELECT * FROM Product WHERE ProductName LIKE @keyword"; // Tìm kiếm theo tên sản phẩm

            // Mở kết nối với cơ sở dữ liệu
            connection.Open();

            // Sử dụng SqlCommand để thực hiện truy vấn
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%"); // Tìm kiếm sản phẩm có tên chứa từ khóa

            // Tạo đối tượng DataTable để chứa kết quả
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            // Cập nhật lại DataGridView với kết quả tìm kiếm
            dgvProduct.DataSource = dt;

            // Đóng kết nối
            connection.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            FillData();
        }
        public void FillData()
        {
            string query = "Select * from Product";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dgvProduct.DataSource = dt;
            connection.Close();
        }
        public void GetCategories()
        {
            String query = "Select categoryID, categoryName from Category";
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(query, connection);
            adt.Fill(table);
            cbCategory.DataSource = table;
            cbCategory.DisplayMember = "categoryName";
            cbCategory.ValueMember = "categoryID";
        }
        public void GetSupplier()
        {
            String query = "Select supplierID, supplierName from Supplier";
            DataTable table2 = new DataTable();
            SqlDataAdapter adt2 = new SqlDataAdapter(query, connection);
            adt2.Fill(table2);
            cbSupplier.DataSource = table2;
            cbSupplier.DisplayMember = "supplierName";
            cbSupplier.ValueMember = "supplierID";
        }

        private void btnExportProduct_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("Excel is not properly installed!");
                return;
            }

            // Tạo workbook và worksheet mới
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Sheets[1];
            worksheet.Name = "Product Data";

            // Xuất tiêu đề cột
            for (int col = 0; col < dgvProduct.Columns.Count; col++)
            {
                worksheet.Cells[1, col + 1] = dgvProduct.Columns[col].HeaderText;
            }

            // Xuất dữ liệu từ dgvProduct
            for (int row = 0; row < dgvProduct.Rows.Count; row++)
            {
                for (int col = 0; col < dgvProduct.Columns.Count; col++)
                {
                    var cellValue = dgvProduct.Rows[row].Cells[col].Value;
                    if (cellValue != null)
                    {
                        worksheet.Cells[row + 2, col + 1] = cellValue.ToString();
                    }
                    else
                    {
                        worksheet.Cells[row + 2, col + 1] = "";  // Gán giá trị trống nếu cell là null
                    }
                }
            }

            // Lưu tệp Excel
            try
            {
                string filePath = @"C:\Users\PC\Documents\ProductsExport\ProductData_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";
                workbook.SaveAs(filePath);
                workbook.Close();
                excelApp.Quit();
                MessageBox.Show("Data exported successfully!\nFile saved to: " + filePath, "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while exporting: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
