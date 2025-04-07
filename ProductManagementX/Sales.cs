using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductManagementX
{
    public partial class Sales : Form
    {
        SqlConnection connection;
        public Sales()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-RM70GOU\\SQLEXPRESS;Database=StoreXDB;Integrated Security = true;");
            
        }
        private void Sales_Load(object sender, EventArgs e)
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
            FillData2();
            FillDataOrderDetail();
            FillDataMakeOrder();
            GetCategories();
            GetSupplier();
            GetPaymentMethods();
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
        public void FillDataMakeOrder()
        {
            string query = "Select * from [Order]";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dgvMakeOrder.DataSource = dt;
            connection.Close();
        }
        public void FillData2()
        {
            string query = "Select * from Customer";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dgvCustomer.DataSource = dt;
            connection.Close();
        }
        public void FillDataOrderDetail()
        {
            string query = "Select * from OrderDetail";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dgvOrderDetail.DataSource = dt;
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
        public void GetPaymentMethods()
        {
            string query = "SELECT MethodID, MethodName FROM Payment";
            DataTable table = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(query, connection);
            adt.Fill(table);
            cbPaymentMethod.DataSource = table;
            cbPaymentMethod.DisplayMember = "MethodName";
            cbPaymentMethod.ValueMember = "MethodID";
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

        private void btnInsertCustomer_Click(object sender, EventArgs e)
        {
            int error = 0;

            // Kiểm tra các ô TextBox có bị trống hay không
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                error++;
                lbCustomerIDError.Text = "Customer ID cannot be blank!";
                lbCustomerIDError.Visible = true;
            }
            else
            {
                lbCustomerIDError.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                error++;
                lbCustomerNameError.Text = "Customer Name cannot be blank!";
                lbCustomerNameError.Visible = true;
            }
            else
            {
                lbCustomerNameError.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
            {
                error++;
                lbCustomerPhoneError.Text = "Customer Phone cannot be blank!";
                lbCustomerPhoneError.Visible = true;
            }
            else
            {
                lbCustomerPhoneError.Visible = false;
            }

            if (string.IsNullOrWhiteSpace(txtCustomerAddress.Text))
            {
                error++;
                lbCustomerAddressError.Text = "Customer Address cannot be blank!";
                lbCustomerAddressError.Visible = true;
            }
            else
            {
                lbCustomerAddressError.Visible = false;
            }

            // Nếu không có lỗi, tiếp tục thêm dữ liệu vào cơ sở dữ liệu và DataGridView
            if (error == 0)
            {
                string customerID = txtCustomerID.Text.Trim();
                string customerName = txtCustomerName.Text.Trim();
                string customerPhone = txtCustomerPhone.Text.Trim();
                string customerAddress = txtCustomerAddress.Text.Trim();

                // Thêm dữ liệu vào cơ sở dữ liệu
                try
                {
                    string insertQuery = "INSERT INTO Customer (CustomerID, CustomerName, CustomerPhone, CustomerAddress) " +
                                         "VALUES (@CustomerID, @CustomerName, @CustomerPhone, @CustomerAddress)";

                    connection.Open();
                    SqlCommand cmd = new SqlCommand(insertQuery, connection);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    cmd.Parameters.AddWithValue("@CustomerName", customerName);
                    cmd.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                    cmd.Parameters.AddWithValue("@CustomerAddress", customerAddress);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillData2(); // Cập nhật lại DataGridView sau khi thêm
                    }
                    else
                    {
                        MessageBox.Show("Error adding customer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra không bấm vào header của DataGridView
            {
                DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];

                // Lấy dữ liệu từ dòng được chọn và điền vào các TextBox tương ứng
                txtCustomerID.Text = row.Cells["CustomerID"].Value.ToString();
                txtCustomerName.Text = row.Cells["CustomerName"].Value.ToString();
                txtCustomerPhone.Text = row.Cells["CustomerPhone"].Value.ToString();
                txtCustomerAddress.Text = row.Cells["CustomerAddress"].Value.ToString();
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                MessageBox.Show("Please select a customer to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra dữ liệu nhập vào
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerPhone.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerAddress.Text))
            {
                MessageBox.Show("Please fill all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy dữ liệu từ các TextBox
            int customerId = Convert.ToInt32(txtCustomerID.Text); // Giả sử ID là kiểu int
            string customerName = txtCustomerName.Text;
            string customerPhone = txtCustomerPhone.Text;
            string customerAddress = txtCustomerAddress.Text;

            // Cập nhật dữ liệu vào cơ sở dữ liệu
            string updateQuery = "UPDATE Customer SET CustomerName = @name, CustomerPhone = @phone, CustomerAddress = @address WHERE CustomerID = @id";

            try
            {
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    // Thêm tham số
                    cmd.Parameters.AddWithValue("@id", customerId);
                    cmd.Parameters.AddWithValue("@name", customerName);
                    cmd.Parameters.AddWithValue("@phone", customerPhone);
                    cmd.Parameters.AddWithValue("@address", customerAddress);

                    // Mở kết nối và thực thi câu lệnh
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật lại DataGridView với dữ liệu mới từ cơ sở dữ liệu
                        FillData2();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn khách hàng nào từ DataGridView chưa
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                MessageBox.Show("Please select a customer to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int customerId = Convert.ToInt32(txtCustomerID.Text); // Lấy CustomerID từ textbox

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Truy vấn kiểm tra xem khách hàng này có đơn hàng nào hay không
                string checkQuery = @"
            SELECT COUNT(*) 
            FROM [Order] 
            WHERE CustomerID = @CustomerID";

                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@CustomerID", customerId);

                int orderCount = (int)checkCmd.ExecuteScalar(); // Lấy số lượng đơn hàng của khách hàng này

                if (orderCount > 0)
                {
                    // Nếu khách hàng có đơn hàng, không cho phép xóa
                    MessageBox.Show("This customer has related orders and cannot be deleted.", "Delete Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nếu không có đơn hàng, yêu cầu xác nhận xóa
                DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Câu lệnh DELETE khách hàng
                    string deleteQuery = "DELETE FROM Customer WHERE CustomerID = @id";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@id", customerId);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Customer deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật lại DataGridView với dữ liệu mới từ cơ sở dữ liệu
                        FillData2();
                    }
                    else
                    {
                        MessageBox.Show("Customer not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting customer: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            string keyword = string.Empty;

            // Kiểm tra xem người dùng có nhập vào txtCustomerName hoặc txtCustomerPhone không
            if (!string.IsNullOrWhiteSpace(txtCustomerName.Text))
            {
                keyword = txtCustomerName.Text.Trim();
            }
            else if (!string.IsNullOrWhiteSpace(txtCustomerPhone.Text))
            {
                keyword = txtCustomerPhone.Text.Trim();
            }

            // Nếu không có keyword, thông báo cho người dùng
            if (string.IsNullOrEmpty(keyword))
            {
                MessageBox.Show("Please enter a name or phone number to search.", "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Câu truy vấn tìm kiếm
            string query = "SELECT * FROM Customer WHERE CustomerName LIKE @keyword OR CustomerPhone LIKE @keyword";

            // Tạo câu lệnh SqlCommand
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Thực hiện truy vấn và hiển thị kết quả trong DataGridView
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dgvCustomer.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No customers found matching your search.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnCancelCustomer_Click(object sender, EventArgs e)
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
            txtCustomerAddress.Clear();

            // Nếu bạn có bất kỳ lỗi nào hiển thị ở dưới các textbox, bạn cũng có thể ẩn chúng
            lbCustomerIDError.Visible = false;
            lbCustomerNameError.Visible = false;
            lbCustomerPhoneError.Visible = false;
            lbCustomerAddressError.Visible = false;
            FillData2();
        }

        private void btnViewOrderHistory_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn khách hàng nào từ TextBox chưa
            if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
            {
                MessageBox.Show("Please select a customer first!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int customerId = Convert.ToInt32(txtCustomerID.Text); // Lấy CustomerID từ textbox

            // Truy vấn để lấy lịch sử đơn hàng của khách hàng
            string query = @"
SELECT o.OrderID, o.OrderDate, o.EmployeeID, p.MethodName, od.TotalAmount
FROM [Order] o
INNER JOIN Payment p ON o.MethodID = p.MethodID
INNER JOIN OrderDetail od ON o.OrderID = od.OrderID
WHERE o.CustomerID = @CustomerID
ORDER BY o.OrderDate DESC";

            try
            {
                // Sử dụng chuỗi kết nối đúng định dạng
                using (SqlConnection connection = new SqlConnection("Server=DESKTOP-RM70GOU\\SQLEXPRESS;Database=StoreXDB;Integrated Security=true;"))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@CustomerID", customerId);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Kiểm tra nếu không có đơn hàng nào
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("This customer has no order history.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // Hiển thị kết quả lên dgvOrderHistory
                        dgvOrderHistory.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while retrieving order history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnMakeOrder_Click(object sender, EventArgs e)
        {
            int orderID;
            int customerID;
            int employeeID;
            DateTime orderDate = dtpOrderDate.Value;

            if (!int.TryParse(txtOrderID1.Text.Trim(), out orderID) ||
                !int.TryParse(txtCustomerID1.Text.Trim(), out customerID) ||
                !int.TryParse(txtEmployeeID1.Text.Trim(), out employeeID))
            {
                MessageBox.Show("OrderID, CustomerID and EmployeeID must be valid numbers.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment method.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy MethodID tương ứng từ combobox
            DataRowView selectedMethod = cbPaymentMethod.SelectedItem as DataRowView;
            int methodID = Convert.ToInt32(selectedMethod["MethodID"]);

            try
            {
                using (SqlConnection conn = new SqlConnection("Server=DESKTOP-RM70GOU\\SQLEXPRESS;Database=StoreXDB;Integrated Security=true;"))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO [Order] (OrderID, OrderDate, CustomerID, EmployeeID, MethodID) " +
                                         "VALUES (@OrderID, @OrderDate, @CustomerID, @EmployeeID, @MethodID)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                        cmd.Parameters.AddWithValue("@CustomerID", customerID);
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeID);
                        cmd.Parameters.AddWithValue("@MethodID", methodID);
                        cmd.ExecuteNonQuery();
                    }

                    // Cập nhật lại DataGridView với MethodName
                    string selectQuery = @"SELECT o.OrderID, o.OrderDate, o.CustomerID, o.EmployeeID, 
                                          o.MethodID, p.MethodName
                                   FROM [Order] o
                                   INNER JOIN Payment p ON o.MethodID = p.MethodID
                                   ORDER BY o.OrderDate DESC";
                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvMakeOrder.DataSource = dt;

                        // Ẩn cột MethodID nếu bạn chỉ muốn hiển thị MethodName
                        if (dgvMakeOrder.Columns.Contains("MethodID"))
                            dgvMakeOrder.Columns["MethodID"].Visible = false;
                    }
                }

                MessageBox.Show("Order has been created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating order:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMakeOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMakeOrder.Rows[e.RowIndex];

                // Lấy dữ liệu từ các cột và đổ vào textbox, datetimepicker, combobox
                txtOrderID1.Text = row.Cells["OrderID1"].Value.ToString();
                txtCustomerID1.Text = row.Cells["CustomerID1"].Value.ToString();
                txtEmployeeID1.Text = row.Cells["EmployeeID1"].Value.ToString();
                dtpOrderDate.Value = Convert.ToDateTime(row.Cells["OrderDate1"].Value);

                // Xử lý methodID -> methodName trong ComboBox
                int methodID = Convert.ToInt32(row.Cells["MethodID1"].Value);

                // Gán SelectedValue = methodID, combobox sẽ tự hiển thị methodName
                cbPaymentMethod.SelectedValue = methodID;
            }
        }

        private void btnInsertOrderDetail_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu các textbox rỗng
            if (string.IsNullOrWhiteSpace(txtOrderID.Text) || string.IsNullOrWhiteSpace(txtProductID2.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity2.Text) || string.IsNullOrWhiteSpace(txtTotalAmount.Text) ||
                string.IsNullOrWhiteSpace(txtOrderDetailID.Text)) // Kiểm tra thêm txtOrderDetailID
            {
                MessageBox.Show("Please fill all fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderDetailID = Convert.ToInt32(txtOrderDetailID.Text); // Lấy OrderDetailID từ textbox
            int orderID = Convert.ToInt32(txtOrderID.Text);
            int productID = Convert.ToInt32(txtProductID2.Text);
            int quantity = Convert.ToInt32(txtQuantity2.Text);
            decimal totalAmount = Convert.ToDecimal(txtTotalAmount.Text);

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Câu lệnh INSERT có OrderDetailID
                string insertQuery = @"
            INSERT INTO OrderDetail (OrderDetailID, OrderID, ProductID, Quantity, TotalAmount)
            VALUES (@OrderDetailID, @OrderID, @ProductID, @Quantity, @TotalAmount)";

                SqlCommand cmd = new SqlCommand(insertQuery, connection);
                cmd.Parameters.AddWithValue("@OrderDetailID", orderDetailID); // Thêm parameter cho OrderDetailID
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Order detail inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataOrderDetail(); // Cập nhật lại DataGridView
                }
                else
                {
                    MessageBox.Show("Error while inserting order detail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting order detail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnUpdateOrderDetail_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường nhập liệu
            if (string.IsNullOrWhiteSpace(txtOrderDetailID.Text) ||
                string.IsNullOrWhiteSpace(txtOrderID.Text) ||
                string.IsNullOrWhiteSpace(txtProductID2.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity2.Text) ||
                string.IsNullOrWhiteSpace(txtTotalAmount.Text))
            {
                MessageBox.Show("Please fill all fields!", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderDetailID, orderID, productID, quantity;
            double totalAmount;

            // Kiểm tra dữ liệu nhập vào
            if (!int.TryParse(txtOrderDetailID.Text.Trim(), out orderDetailID) ||
                !int.TryParse(txtOrderID.Text.Trim(), out orderID) ||
                !int.TryParse(txtProductID2.Text.Trim(), out productID) ||
                !int.TryParse(txtQuantity2.Text.Trim(), out quantity) ||
                !double.TryParse(txtTotalAmount.Text.Trim(), out totalAmount))
            {
                MessageBox.Show("Please enter valid data for OrderDetailID, OrderID, ProductID, Quantity, and Total Amount.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Truy vấn để cập nhật OrderDetail
                string updateQuery = "UPDATE OrderDetail SET OrderID = @OrderID, ProductID = @ProductID, Quantity = @Quantity, TotalAmount = @TotalAmount " +
                                     "WHERE OrderDetailID = @OrderDetailID";

                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@OrderDetailID", orderDetailID);
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("OrderDetail updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataOrderDetail(); // Cập nhật lại DataGridView sau khi cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Failed to update OrderDetail. Please check the OrderDetailID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating order detail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

        }

        private void btnDeleteOrderDetail_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOrderDetailID.Text))
            {
                MessageBox.Show("Please choose an order detail to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int orderDetailID = Convert.ToInt32(txtOrderDetailID.Text);

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Truy vấn kiểm tra xem OrderDetail có liên quan đến Order nào không
                string checkQuery = "SELECT COUNT(*) FROM OrderDetail WHERE OrderDetailID = @OrderDetailID";
                SqlCommand checkCmd = new SqlCommand(checkQuery, connection);
                checkCmd.Parameters.AddWithValue("@OrderDetailID", orderDetailID);

                int count = (int)checkCmd.ExecuteScalar();
                if (count == 0)
                {
                    MessageBox.Show("OrderDetail ID not found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Đảm bảo OrderDetail không bị khóa hoặc không còn liên kết với các bảng khác
                // Trước khi xoá thì kiểm tra quan hệ với Order có dữ liệu không
                string deleteQuery = "DELETE FROM OrderDetail WHERE OrderDetailID = @OrderDetailID";
                SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                deleteCmd.Parameters.AddWithValue("@OrderDetailID", orderDetailID);

                int rowsAffected = deleteCmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Order Detail deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataOrderDetail();  // Refresh data in DataGridView
                }
                else
                {
                    MessageBox.Show("Failed to delete OrderDetail. It may not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while deleting order detail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void dgvOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ dòng vừa chọn
                DataGridViewRow row = dgvOrderDetail.Rows[e.RowIndex];

                // Đổ dữ liệu vào các textbox tương ứng
                txtOrderDetailID.Text = row.Cells["OrderDetailID"].Value.ToString(); // OrderDetailID
                txtOrderID.Text = row.Cells["OrderID"].Value.ToString();             // OrderID
                txtProductID2.Text = row.Cells["ProductID1"].Value.ToString();        // ProductID
                txtQuantity2.Text = row.Cells["Quantity2"].Value.ToString();          // Quantity
                txtTotalAmount.Text = row.Cells["TotalAmount"].Value.ToString();     // TotalAmount
            }
        }

        private void btnSearchOrderDetail_Click(object sender, EventArgs e)
        {
            string orderDetailID = txtOrderDetailID.Text.Trim();
            string orderID = txtOrderID.Text.Trim();
            string productID = txtProductID2.Text.Trim();
            string quantity = txtQuantity2.Text.Trim();
            string totalAmount = txtTotalAmount.Text.Trim();

            // Câu lệnh SQL với LIKE để tìm kiếm theo phần trùng khớp
            string query = "SELECT * FROM OrderDetail WHERE 1=1";  // 1=1 để dễ dàng thêm điều kiện vào sau

            // Thêm điều kiện tìm kiếm nếu có dữ liệu nhập vào
            if (!string.IsNullOrWhiteSpace(orderDetailID))
            {
                query += " AND OrderDetailID LIKE @OrderDetailID";
            }
            if (!string.IsNullOrWhiteSpace(orderID))
            {
                query += " AND OrderID LIKE @OrderID";
            }
            if (!string.IsNullOrWhiteSpace(productID))
            {
                query += " AND ProductID LIKE @ProductID";
            }
            if (!string.IsNullOrWhiteSpace(quantity))
            {
                query += " AND Quantity LIKE @Quantity";
            }
            if (!string.IsNullOrWhiteSpace(totalAmount))
            {
                query += " AND TotalAmount LIKE @TotalAmount";
            }

            SqlConnection conn = null;
            try
            {
                conn = new SqlConnection("Server=DESKTOP-RM70GOU\\SQLEXPRESS;Database=StoreXDB;Integrated Security=true;");
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Thêm tham số vào câu lệnh với dấu % để tìm kiếm phần trùng khớp
                    if (!string.IsNullOrWhiteSpace(orderDetailID))
                    {
                        cmd.Parameters.AddWithValue("@OrderDetailID", "%" + orderDetailID + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(orderID))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", "%" + orderID + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(productID))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", "%" + productID + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(quantity))
                    {
                        cmd.Parameters.AddWithValue("@Quantity", "%" + quantity + "%");
                    }
                    if (!string.IsNullOrWhiteSpace(totalAmount))
                    {
                        cmd.Parameters.AddWithValue("@TotalAmount", "%" + totalAmount + "%");
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOrderDetail.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching order details:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Đảm bảo kết nối được đóng trong mọi trường hợp
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        private void btnCancelOrderDetail_Click(object sender, EventArgs e)
        {
            txtOrderDetailID.Clear();
            txtOrderID.Clear();
            txtProductID2.Clear();
            txtQuantity2.Clear();
            txtTotalAmount.Clear();  // Nếu có thêm textbox TotalAmount

            // Đặt lại trạng thái của combobox (nếu có)

            cbPaymentMethod.SelectedIndex = -1;  // Nếu có combobox PaymentMethod

            // Hủy bỏ việc chọn dòng trong DataGridView
            if (dgvOrderDetail.SelectedRows.Count > 0)
            {
                dgvOrderDetail.ClearSelection();  // Bỏ chọn dòng đang được chọn trong DataGridView
            }

            // Đặt focus lại cho TextBox đầu tiên hoặc bất kỳ phần tử UI nào mà bạn muốn
            txtOrderDetailID.Focus();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtPrice.Text = "";
            txtQuantity.Text = "";
            lbNameError.Visible = false;
            lbIDError.Visible = false;
            lbQuantityError.Visible = false;
            lbPriceError.Visible = false;
            FillData();
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
    }
}
