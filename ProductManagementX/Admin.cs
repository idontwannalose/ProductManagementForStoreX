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
    public partial class Admin : Form
    {
        SqlConnection connection;
        public Admin()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-RM70GOU\\SQLEXPRESS;Database=StoreXDB;Integrated Security = true;");
        }

        private void ProductManagement_Load(object sender, EventArgs e)
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
            FillDataEmployee();
            GetCategories();
            GetSupplier();
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
        public void FillData2()
        {
            string query = "Select * from Customer";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dgvCustomer.DataSource = dt;
            connection.Close();
        }
        public void FillDataEmployee()
        {
            string query = "Select * from Employee";
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(dt);
            dgvEmployee.DataSource = dt;
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
            catch (Exception ex)
            {
                MessageBox.Show($"Error while retrieving order history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnInsertEmployee_Click(object sender, EventArgs e)
        {
            int error = 0;

            // Kiểm tra các trường nhập vào
            string employeeID = txtEmployeeID.Text;
            if (string.IsNullOrWhiteSpace(employeeID))
            {
                error++;
                lbEmployeeIDError.Text = "Employee ID can't be blank!";
                lbEmployeeIDError.Visible = true;
            }
            else
            {
                lbEmployeeIDError.Visible = false;
            }

            string employeeName = txtEmployeeName.Text;
            if (string.IsNullOrWhiteSpace(employeeName))
            {
                error++;
                lbEmployeeNameError.Text = "Employee Name can't be blank!";
                lbEmployeeNameError.Visible = true;
            }
            else
            {
                lbEmployeeNameError.Visible = false;
            }

            string employeePosition = txtEmployeePosition.Text;
            if (string.IsNullOrWhiteSpace(employeePosition))
            {
                error++;
                lbEmployeePositionError.Text = "Employee Position can't be blank!";
                lbEmployeePositionError.Visible = true;
            }
            else
            {
                lbEmployeePositionError.Visible = false;
            }

            // Nếu không có lỗi, kiểm tra xem EmployeeID đã tồn tại chưa
            if (error == 0)
            {
                string queryCheck = "SELECT * FROM Employee WHERE EmployeeID = @employeeID";
                SqlCommand cmdCheck = new SqlCommand(queryCheck, connection);
                cmdCheck.Parameters.AddWithValue("@employeeID", employeeID);

                connection.Open();
                SqlDataReader reader = cmdCheck.ExecuteReader();

                if (reader.Read())
                {
                    error++;
                    MessageBox.Show("Employee ID already exists. Please choose another.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();

                if (error == 0)
                {
                    // Thực hiện Insert Employee vào database
                    string insertQuery = "INSERT INTO Employee (EmployeeID, EmployeeName, Position) VALUES (@employeeID, @employeeName, @employeePosition)";
                    SqlCommand cmdInsert = new SqlCommand(insertQuery, connection);

                    cmdInsert.Parameters.AddWithValue("@employeeID", employeeID);
                    cmdInsert.Parameters.AddWithValue("@employeeName", employeeName);
                    cmdInsert.Parameters.AddWithValue("@employeePosition", employeePosition);

                    int rowsAffected = cmdInsert.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FillDataEmployee(); // Cập nhật lại DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Error inserting employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                connection.Close();
            }
        }

        private void btnUpdateEmployee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                MessageBox.Show("Please select an employee to update!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string employeeID = txtEmployeeID.Text;
            string employeeName = txtEmployeeName.Text;
            string employeePosition = txtEmployeePosition.Text;

            if (string.IsNullOrWhiteSpace(employeeName))
            {
                MessageBox.Show("Employee Name can't be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(employeePosition))
            {
                MessageBox.Show("Position can't be blank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string updateQuery = "UPDATE Employee SET EmployeeName = @employeeName, Position = @employeePosition WHERE EmployeeID = @employeeID";
                SqlCommand cmd = new SqlCommand(updateQuery, connection);
                cmd.Parameters.AddWithValue("@employeeID", employeeID);
                cmd.Parameters.AddWithValue("@employeeName", employeeName);
                cmd.Parameters.AddWithValue("@employeePosition", employeePosition);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                connection.Close();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Employee updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillDataEmployee(); // Refresh employee data grid
                }
                else
                {
                    MessageBox.Show("Employee not found or no changes made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Kiểm tra xem người dùng có bấm vào một dòng dữ liệu hợp lệ không
            {
                DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];

                // Gán giá trị từ các ô của dòng đã chọn vào các TextBox
                txtEmployeeID.Text = row.Cells["EmployeeID"].Value.ToString();
                txtEmployeeName.Text = row.Cells["EmployeeName"].Value.ToString();
                txtEmployeePosition.Text = row.Cells["EmployeePosition"].Value.ToString();
            }
        }

        private void btnDeleteEmployee_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn nhân viên nào từ DataGridView chưa
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
            {
                MessageBox.Show("Please select an employee to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int employeeId = Convert.ToInt32(txtEmployeeID.Text); // Lấy EmployeeID từ textbox

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Kiểm tra xem nhân viên này có đơn hàng nào không
                string checkOrderQuery = @"
            SELECT COUNT(*) 
            FROM [Order] 
            WHERE EmployeeID = @EmployeeID";

                SqlCommand checkOrderCmd = new SqlCommand(checkOrderQuery, connection);
                checkOrderCmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                int relatedOrderCount = (int)checkOrderCmd.ExecuteScalar(); // Kiểm tra số lượng đơn hàng liên quan đến nhân viên

                if (relatedOrderCount > 0)
                {
                    // Nếu nhân viên có đơn hàng đang xử lý, không cho phép xóa
                    MessageBox.Show("This employee is currently handling orders and cannot be deleted.", "Delete Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra xem nhân viên này có liên kết trong bảng UserAccount không
                string checkUserAccountQuery = @"
            SELECT COUNT(*) 
            FROM UserAccount 
            WHERE EmployeeID = @EmployeeID";

                SqlCommand checkUserAccountCmd = new SqlCommand(checkUserAccountQuery, connection);
                checkUserAccountCmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                int relatedUserAccountCount = (int)checkUserAccountCmd.ExecuteScalar(); // Kiểm tra số lượng bản ghi trong bảng UserAccount

                if (relatedUserAccountCount > 0)
                {
                    // Nếu có bản ghi liên quan trong bảng UserAccount, không cho phép xóa
                    MessageBox.Show("This employee is associated with user accounts and cannot be deleted.", "Delete Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Nếu không có đơn hàng và không có liên kết trong bảng UserAccount, yêu cầu xác nhận xóa
                DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Câu lệnh DELETE nhân viên
                    string deleteQuery = "DELETE FROM Employee WHERE EmployeeID = @id";
                    SqlCommand deleteCmd = new SqlCommand(deleteQuery, connection);
                    deleteCmd.Parameters.AddWithValue("@id", employeeId);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Employee deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Cập nhật lại DataGridView với dữ liệu mới từ cơ sở dữ liệu
                        FillDataEmployee(); // Thay thế bằng phương thức cập nhật DataGridView của bạn
                    }
                    else
                    {
                        MessageBox.Show("Employee not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting employee: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void btnCancelEmployee_Click(object sender, EventArgs e)
        {
            // Xóa tất cả dữ liệu trong các textbox
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtEmployeePosition.Text = "";

            // Nếu cần, làm mới DataGridView (tùy chọn)
            FillDataEmployee(); // Cập nhật lại DataGridView nếu cần
            lbEmployeeIDError.Visible = false;
            lbEmployeeNameError.Visible = false;
            lbEmployeePositionError.Visible = false;
        }

        private void btnSearchEmployee_Click(object sender, EventArgs e)
        {
            string employeeName = txtEmployeeName.Text.Trim(); // Lấy tên nhân viên từ textbox

            // Kiểm tra xem người dùng có nhập gì không
            if (string.IsNullOrEmpty(employeeName))
            {
                MessageBox.Show("Please enter an employee name to search!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                // Truy vấn SQL tìm kiếm nhân viên theo tên
                string searchQuery = "SELECT * FROM Employee WHERE EmployeeName LIKE @employeeName";

                SqlCommand searchCmd = new SqlCommand(searchQuery, connection);
                searchCmd.Parameters.AddWithValue("@employeeName", "%" + employeeName + "%"); // Thêm dấu % để tìm kiếm theo mẫu

                SqlDataAdapter adapter = new SqlDataAdapter(searchCmd);
                DataTable resultTable = new DataTable();
                adapter.Fill(resultTable);

                if (resultTable.Rows.Count > 0)
                {
                    dgvEmployee.DataSource = resultTable; // Hiển thị kết quả tìm kiếm vào DataGridView
                }
                else
                {
                    MessageBox.Show("No employees found matching your search criteria.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
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
    }
}
