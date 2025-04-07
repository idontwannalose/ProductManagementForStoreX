namespace ProductManagementX
{
    partial class Admin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.HomeSc = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ManageEmployeeSc = new System.Windows.Forms.TabPage();
            this.lbEmployeePositionError = new System.Windows.Forms.Label();
            this.lbEmployeeNameError = new System.Windows.Forms.Label();
            this.lbEmployeeIDError = new System.Windows.Forms.Label();
            this.btnCancelEmployee = new System.Windows.Forms.Button();
            this.btnDeleteEmployee = new System.Windows.Forms.Button();
            this.btnUpdateEmployee = new System.Windows.Forms.Button();
            this.btnInsertEmployee = new System.Windows.Forms.Button();
            this.dgvEmployee = new System.Windows.Forms.DataGridView();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeePosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearchEmployee = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.txtEmployeePosition = new System.Windows.Forms.TextBox();
            this.txtEmployeeName = new System.Windows.Forms.TextBox();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.ManageCustomerSc = new System.Windows.Forms.TabPage();
            this.lbCustomerNameError = new System.Windows.Forms.Label();
            this.lbCustomerAddressError = new System.Windows.Forms.Label();
            this.lbCustomerPhoneError = new System.Windows.Forms.Label();
            this.lbCustomerIDError = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dgvOrderHistory = new System.Windows.Forms.DataGridView();
            this.btnCancelCustomer = new System.Windows.Forms.Button();
            this.btnViewOrderHistory = new System.Windows.Forms.Button();
            this.btnSearchCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnInsertCustomer = new System.Windows.Forms.Button();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label16 = new System.Windows.Forms.Label();
            this.txtCustomerAddress = new System.Windows.Forms.TextBox();
            this.txtCustomerPhone = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ManageProductSc = new System.Windows.Forms.TabPage();
            this.StatisticSc = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnSearchProduct = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.SupplierID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventoryQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProduct = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.lbIDError = new System.Windows.Forms.Label();
            this.lbNameError = new System.Windows.Forms.Label();
            this.lbQuantityError = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lbPriceError = new System.Windows.Forms.Label();
            this.cbSupplier = new System.Windows.Forms.ComboBox();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.HomeSc.SuspendLayout();
            this.ManageEmployeeSc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).BeginInit();
            this.ManageCustomerSc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.ManageProductSc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.HomeSc);
            this.tabControl1.Controls.Add(this.ManageEmployeeSc);
            this.tabControl1.Controls.Add(this.ManageCustomerSc);
            this.tabControl1.Controls.Add(this.ManageProductSc);
            this.tabControl1.Controls.Add(this.StatisticSc);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1270, 753);
            this.tabControl1.TabIndex = 0;
            // 
            // HomeSc
            // 
            this.HomeSc.Controls.Add(this.btnLogout);
            this.HomeSc.Controls.Add(this.label2);
            this.HomeSc.Controls.Add(this.label1);
            this.HomeSc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeSc.Location = new System.Drawing.Point(4, 25);
            this.HomeSc.Name = "HomeSc";
            this.HomeSc.Padding = new System.Windows.Forms.Padding(3);
            this.HomeSc.Size = new System.Drawing.Size(1262, 724);
            this.HomeSc.TabIndex = 0;
            this.HomeSc.Text = "Home";
            this.HomeSc.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(492, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "You are logged in as ADMIN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, 288);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(587, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Product Management System!";
            // 
            // ManageEmployeeSc
            // 
            this.ManageEmployeeSc.Controls.Add(this.lbEmployeePositionError);
            this.ManageEmployeeSc.Controls.Add(this.lbEmployeeNameError);
            this.ManageEmployeeSc.Controls.Add(this.lbEmployeeIDError);
            this.ManageEmployeeSc.Controls.Add(this.btnCancelEmployee);
            this.ManageEmployeeSc.Controls.Add(this.btnDeleteEmployee);
            this.ManageEmployeeSc.Controls.Add(this.btnUpdateEmployee);
            this.ManageEmployeeSc.Controls.Add(this.btnInsertEmployee);
            this.ManageEmployeeSc.Controls.Add(this.dgvEmployee);
            this.ManageEmployeeSc.Controls.Add(this.btnSearchEmployee);
            this.ManageEmployeeSc.Controls.Add(this.label22);
            this.ManageEmployeeSc.Controls.Add(this.txtEmployeePosition);
            this.ManageEmployeeSc.Controls.Add(this.txtEmployeeName);
            this.ManageEmployeeSc.Controls.Add(this.txtEmployeeID);
            this.ManageEmployeeSc.Controls.Add(this.label21);
            this.ManageEmployeeSc.Controls.Add(this.label20);
            this.ManageEmployeeSc.Controls.Add(this.label19);
            this.ManageEmployeeSc.Controls.Add(this.label18);
            this.ManageEmployeeSc.Location = new System.Drawing.Point(4, 25);
            this.ManageEmployeeSc.Name = "ManageEmployeeSc";
            this.ManageEmployeeSc.Padding = new System.Windows.Forms.Padding(3);
            this.ManageEmployeeSc.Size = new System.Drawing.Size(1262, 724);
            this.ManageEmployeeSc.TabIndex = 1;
            this.ManageEmployeeSc.Text = "ManageEmployee";
            this.ManageEmployeeSc.UseVisualStyleBackColor = true;
            // 
            // lbEmployeePositionError
            // 
            this.lbEmployeePositionError.AutoSize = true;
            this.lbEmployeePositionError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeePositionError.ForeColor = System.Drawing.Color.Red;
            this.lbEmployeePositionError.Location = new System.Drawing.Point(312, 226);
            this.lbEmployeePositionError.Name = "lbEmployeePositionError";
            this.lbEmployeePositionError.Size = new System.Drawing.Size(51, 16);
            this.lbEmployeePositionError.TabIndex = 16;
            this.lbEmployeePositionError.Text = "label25";
            this.lbEmployeePositionError.Visible = false;
            // 
            // lbEmployeeNameError
            // 
            this.lbEmployeeNameError.AutoSize = true;
            this.lbEmployeeNameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeeNameError.ForeColor = System.Drawing.Color.Red;
            this.lbEmployeeNameError.Location = new System.Drawing.Point(312, 177);
            this.lbEmployeeNameError.Name = "lbEmployeeNameError";
            this.lbEmployeeNameError.Size = new System.Drawing.Size(51, 16);
            this.lbEmployeeNameError.TabIndex = 15;
            this.lbEmployeeNameError.Text = "label24";
            this.lbEmployeeNameError.Visible = false;
            // 
            // lbEmployeeIDError
            // 
            this.lbEmployeeIDError.AutoSize = true;
            this.lbEmployeeIDError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmployeeIDError.ForeColor = System.Drawing.Color.Red;
            this.lbEmployeeIDError.Location = new System.Drawing.Point(312, 130);
            this.lbEmployeeIDError.Name = "lbEmployeeIDError";
            this.lbEmployeeIDError.Size = new System.Drawing.Size(51, 16);
            this.lbEmployeeIDError.TabIndex = 14;
            this.lbEmployeeIDError.Text = "label23";
            this.lbEmployeeIDError.Visible = false;
            // 
            // btnCancelEmployee
            // 
            this.btnCancelEmployee.Location = new System.Drawing.Point(742, 270);
            this.btnCancelEmployee.Name = "btnCancelEmployee";
            this.btnCancelEmployee.Size = new System.Drawing.Size(75, 36);
            this.btnCancelEmployee.TabIndex = 13;
            this.btnCancelEmployee.Text = "Cancel";
            this.btnCancelEmployee.UseVisualStyleBackColor = true;
            this.btnCancelEmployee.Click += new System.EventHandler(this.btnCancelEmployee_Click);
            // 
            // btnDeleteEmployee
            // 
            this.btnDeleteEmployee.Location = new System.Drawing.Point(577, 270);
            this.btnDeleteEmployee.Name = "btnDeleteEmployee";
            this.btnDeleteEmployee.Size = new System.Drawing.Size(75, 36);
            this.btnDeleteEmployee.TabIndex = 12;
            this.btnDeleteEmployee.Text = "Delete";
            this.btnDeleteEmployee.UseVisualStyleBackColor = true;
            this.btnDeleteEmployee.Click += new System.EventHandler(this.btnDeleteEmployee_Click);
            // 
            // btnUpdateEmployee
            // 
            this.btnUpdateEmployee.Location = new System.Drawing.Point(400, 270);
            this.btnUpdateEmployee.Name = "btnUpdateEmployee";
            this.btnUpdateEmployee.Size = new System.Drawing.Size(75, 36);
            this.btnUpdateEmployee.TabIndex = 11;
            this.btnUpdateEmployee.Text = "Update";
            this.btnUpdateEmployee.UseVisualStyleBackColor = true;
            this.btnUpdateEmployee.Click += new System.EventHandler(this.btnUpdateEmployee_Click);
            // 
            // btnInsertEmployee
            // 
            this.btnInsertEmployee.Location = new System.Drawing.Point(235, 270);
            this.btnInsertEmployee.Name = "btnInsertEmployee";
            this.btnInsertEmployee.Size = new System.Drawing.Size(75, 36);
            this.btnInsertEmployee.TabIndex = 10;
            this.btnInsertEmployee.Text = "Insert";
            this.btnInsertEmployee.UseVisualStyleBackColor = true;
            this.btnInsertEmployee.Click += new System.EventHandler(this.btnInsertEmployee_Click);
            // 
            // dgvEmployee
            // 
            this.dgvEmployee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID,
            this.EmployeeName,
            this.EmployeePosition});
            this.dgvEmployee.Location = new System.Drawing.Point(82, 347);
            this.dgvEmployee.Name = "dgvEmployee";
            this.dgvEmployee.RowHeadersWidth = 51;
            this.dgvEmployee.RowTemplate.Height = 24;
            this.dgvEmployee.Size = new System.Drawing.Size(1092, 361);
            this.dgvEmployee.TabIndex = 9;
            this.dgvEmployee.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellClick);
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "Employee ID";
            this.EmployeeID.MinimumWidth = 6;
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.Width = 125;
            // 
            // EmployeeName
            // 
            this.EmployeeName.DataPropertyName = "EmployeeName";
            this.EmployeeName.HeaderText = "Name";
            this.EmployeeName.MinimumWidth = 6;
            this.EmployeeName.Name = "EmployeeName";
            this.EmployeeName.Width = 125;
            // 
            // EmployeePosition
            // 
            this.EmployeePosition.DataPropertyName = "Position";
            this.EmployeePosition.HeaderText = "Position";
            this.EmployeePosition.MinimumWidth = 6;
            this.EmployeePosition.Name = "EmployeePosition";
            this.EmployeePosition.Width = 125;
            // 
            // btnSearchEmployee
            // 
            this.btnSearchEmployee.Location = new System.Drawing.Point(899, 270);
            this.btnSearchEmployee.Name = "btnSearchEmployee";
            this.btnSearchEmployee.Size = new System.Drawing.Size(75, 36);
            this.btnSearchEmployee.TabIndex = 8;
            this.btnSearchEmployee.Text = "Search";
            this.btnSearchEmployee.UseVisualStyleBackColor = true;
            this.btnSearchEmployee.Click += new System.EventHandler(this.btnSearchEmployee_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(484, 312);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(246, 32);
            this.label22.TabIndex = 7;
            this.label22.Text = "List Of Employee";
            // 
            // txtEmployeePosition
            // 
            this.txtEmployeePosition.Location = new System.Drawing.Point(312, 201);
            this.txtEmployeePosition.Name = "txtEmployeePosition";
            this.txtEmployeePosition.Size = new System.Drawing.Size(186, 22);
            this.txtEmployeePosition.TabIndex = 6;
            // 
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(312, 152);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Size = new System.Drawing.Size(186, 22);
            this.txtEmployeeName.TabIndex = 5;
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Location = new System.Drawing.Point(312, 102);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(84, 22);
            this.txtEmployeeID.TabIndex = 4;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(258, 104);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(26, 20);
            this.label21.TabIndex = 3;
            this.label21.Text = "ID";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(231, 154);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(53, 20);
            this.label20.TabIndex = 2;
            this.label20.Text = "Name";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(215, 201);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 20);
            this.label19.TabIndex = 1;
            this.label19.Text = "Position";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(467, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(333, 32);
            this.label18.TabIndex = 0;
            this.label18.Text = "Employee Management";
            // 
            // ManageCustomerSc
            // 
            this.ManageCustomerSc.Controls.Add(this.lbCustomerNameError);
            this.ManageCustomerSc.Controls.Add(this.lbCustomerAddressError);
            this.ManageCustomerSc.Controls.Add(this.lbCustomerPhoneError);
            this.ManageCustomerSc.Controls.Add(this.lbCustomerIDError);
            this.ManageCustomerSc.Controls.Add(this.label17);
            this.ManageCustomerSc.Controls.Add(this.dgvOrderHistory);
            this.ManageCustomerSc.Controls.Add(this.btnCancelCustomer);
            this.ManageCustomerSc.Controls.Add(this.btnViewOrderHistory);
            this.ManageCustomerSc.Controls.Add(this.btnSearchCustomer);
            this.ManageCustomerSc.Controls.Add(this.btnDeleteCustomer);
            this.ManageCustomerSc.Controls.Add(this.btnUpdateCustomer);
            this.ManageCustomerSc.Controls.Add(this.btnInsertCustomer);
            this.ManageCustomerSc.Controls.Add(this.dgvCustomer);
            this.ManageCustomerSc.Controls.Add(this.label16);
            this.ManageCustomerSc.Controls.Add(this.txtCustomerAddress);
            this.ManageCustomerSc.Controls.Add(this.txtCustomerPhone);
            this.ManageCustomerSc.Controls.Add(this.txtCustomerName);
            this.ManageCustomerSc.Controls.Add(this.txtCustomerID);
            this.ManageCustomerSc.Controls.Add(this.label15);
            this.ManageCustomerSc.Controls.Add(this.label14);
            this.ManageCustomerSc.Controls.Add(this.label13);
            this.ManageCustomerSc.Controls.Add(this.label12);
            this.ManageCustomerSc.Controls.Add(this.label11);
            this.ManageCustomerSc.Location = new System.Drawing.Point(4, 25);
            this.ManageCustomerSc.Name = "ManageCustomerSc";
            this.ManageCustomerSc.Padding = new System.Windows.Forms.Padding(3);
            this.ManageCustomerSc.Size = new System.Drawing.Size(1262, 724);
            this.ManageCustomerSc.TabIndex = 2;
            this.ManageCustomerSc.Text = "ManageCustomer";
            this.ManageCustomerSc.UseVisualStyleBackColor = true;
            // 
            // lbCustomerNameError
            // 
            this.lbCustomerNameError.AutoSize = true;
            this.lbCustomerNameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomerNameError.ForeColor = System.Drawing.Color.Red;
            this.lbCustomerNameError.Location = new System.Drawing.Point(334, 207);
            this.lbCustomerNameError.Name = "lbCustomerNameError";
            this.lbCustomerNameError.Size = new System.Drawing.Size(49, 16);
            this.lbCustomerNameError.TabIndex = 22;
            this.lbCustomerNameError.Text = "labelxx";
            this.lbCustomerNameError.Visible = false;
            // 
            // lbCustomerAddressError
            // 
            this.lbCustomerAddressError.AutoSize = true;
            this.lbCustomerAddressError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomerAddressError.ForeColor = System.Drawing.Color.Red;
            this.lbCustomerAddressError.Location = new System.Drawing.Point(696, 209);
            this.lbCustomerAddressError.Name = "lbCustomerAddressError";
            this.lbCustomerAddressError.Size = new System.Drawing.Size(49, 16);
            this.lbCustomerAddressError.TabIndex = 21;
            this.lbCustomerAddressError.Text = "labelxx";
            this.lbCustomerAddressError.Visible = false;
            // 
            // lbCustomerPhoneError
            // 
            this.lbCustomerPhoneError.AutoSize = true;
            this.lbCustomerPhoneError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomerPhoneError.ForeColor = System.Drawing.Color.Red;
            this.lbCustomerPhoneError.Location = new System.Drawing.Point(696, 160);
            this.lbCustomerPhoneError.Name = "lbCustomerPhoneError";
            this.lbCustomerPhoneError.Size = new System.Drawing.Size(49, 16);
            this.lbCustomerPhoneError.TabIndex = 20;
            this.lbCustomerPhoneError.Text = "labelxx";
            this.lbCustomerPhoneError.Visible = false;
            // 
            // lbCustomerIDError
            // 
            this.lbCustomerIDError.AutoSize = true;
            this.lbCustomerIDError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomerIDError.ForeColor = System.Drawing.Color.Red;
            this.lbCustomerIDError.Location = new System.Drawing.Point(337, 160);
            this.lbCustomerIDError.Name = "lbCustomerIDError";
            this.lbCustomerIDError.Size = new System.Drawing.Size(49, 16);
            this.lbCustomerIDError.TabIndex = 19;
            this.lbCustomerIDError.Text = "labelxx";
            this.lbCustomerIDError.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(864, 295);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(194, 32);
            this.label17.TabIndex = 18;
            this.label17.Text = "Order History";
            // 
            // dgvOrderHistory
            // 
            this.dgvOrderHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderHistory.Location = new System.Drawing.Point(687, 327);
            this.dgvOrderHistory.Name = "dgvOrderHistory";
            this.dgvOrderHistory.RowHeadersWidth = 51;
            this.dgvOrderHistory.RowTemplate.Height = 24;
            this.dgvOrderHistory.Size = new System.Drawing.Size(558, 394);
            this.dgvOrderHistory.TabIndex = 17;
            // 
            // btnCancelCustomer
            // 
            this.btnCancelCustomer.Location = new System.Drawing.Point(794, 250);
            this.btnCancelCustomer.Name = "btnCancelCustomer";
            this.btnCancelCustomer.Size = new System.Drawing.Size(75, 36);
            this.btnCancelCustomer.TabIndex = 16;
            this.btnCancelCustomer.Text = "Cancel";
            this.btnCancelCustomer.UseVisualStyleBackColor = true;
            this.btnCancelCustomer.Click += new System.EventHandler(this.btnCancelCustomer_Click);
            // 
            // btnViewOrderHistory
            // 
            this.btnViewOrderHistory.Location = new System.Drawing.Point(929, 212);
            this.btnViewOrderHistory.Name = "btnViewOrderHistory";
            this.btnViewOrderHistory.Size = new System.Drawing.Size(99, 77);
            this.btnViewOrderHistory.TabIndex = 15;
            this.btnViewOrderHistory.Text = "View Order History";
            this.btnViewOrderHistory.UseVisualStyleBackColor = true;
            this.btnViewOrderHistory.Click += new System.EventHandler(this.btnViewOrderHistory_Click);
            // 
            // btnSearchCustomer
            // 
            this.btnSearchCustomer.Location = new System.Drawing.Point(646, 250);
            this.btnSearchCustomer.Name = "btnSearchCustomer";
            this.btnSearchCustomer.Size = new System.Drawing.Size(75, 36);
            this.btnSearchCustomer.TabIndex = 14;
            this.btnSearchCustomer.Text = "Search";
            this.btnSearchCustomer.UseVisualStyleBackColor = true;
            this.btnSearchCustomer.Click += new System.EventHandler(this.btnSearchCustomer_Click);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(497, 251);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(75, 36);
            this.btnDeleteCustomer.TabIndex = 13;
            this.btnDeleteCustomer.Text = "Delete";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Location = new System.Drawing.Point(348, 251);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(75, 36);
            this.btnUpdateCustomer.TabIndex = 12;
            this.btnUpdateCustomer.Text = "Update";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);
            // 
            // btnInsertCustomer
            // 
            this.btnInsertCustomer.Location = new System.Drawing.Point(181, 251);
            this.btnInsertCustomer.Name = "btnInsertCustomer";
            this.btnInsertCustomer.Size = new System.Drawing.Size(75, 36);
            this.btnInsertCustomer.TabIndex = 11;
            this.btnInsertCustomer.Text = "Insert";
            this.btnInsertCustomer.UseVisualStyleBackColor = true;
            this.btnInsertCustomer.Click += new System.EventHandler(this.btnInsertCustomer_Click);
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerID,
            this.CustomerName,
            this.CustomerPhone,
            this.CustomerAddress});
            this.dgvCustomer.Location = new System.Drawing.Point(28, 330);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.RowHeadersWidth = 51;
            this.dgvCustomer.RowTemplate.Height = 24;
            this.dgvCustomer.Size = new System.Drawing.Size(621, 391);
            this.dgvCustomer.TabIndex = 10;
            this.dgvCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomer_CellClick);
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "Customer ID";
            this.CustomerID.MinimumWidth = 6;
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Width = 125;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "Name";
            this.CustomerName.MinimumWidth = 6;
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Width = 125;
            // 
            // CustomerPhone
            // 
            this.CustomerPhone.DataPropertyName = "CustomerPhone";
            this.CustomerPhone.HeaderText = "Phone";
            this.CustomerPhone.MinimumWidth = 6;
            this.CustomerPhone.Name = "CustomerPhone";
            this.CustomerPhone.Width = 125;
            // 
            // CustomerAddress
            // 
            this.CustomerAddress.DataPropertyName = "CustomerAddress";
            this.CustomerAddress.HeaderText = "Address";
            this.CustomerAddress.MinimumWidth = 6;
            this.CustomerAddress.Name = "CustomerAddress";
            this.CustomerAddress.Width = 125;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(198, 295);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(241, 32);
            this.label16.TabIndex = 9;
            this.label16.Text = "List Of Customer";
            // 
            // txtCustomerAddress
            // 
            this.txtCustomerAddress.Location = new System.Drawing.Point(699, 184);
            this.txtCustomerAddress.Name = "txtCustomerAddress";
            this.txtCustomerAddress.Size = new System.Drawing.Size(346, 22);
            this.txtCustomerAddress.TabIndex = 8;
            // 
            // txtCustomerPhone
            // 
            this.txtCustomerPhone.Location = new System.Drawing.Point(699, 135);
            this.txtCustomerPhone.Name = "txtCustomerPhone";
            this.txtCustomerPhone.Size = new System.Drawing.Size(170, 22);
            this.txtCustomerPhone.TabIndex = 7;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(337, 182);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(203, 22);
            this.txtCustomerName.TabIndex = 6;
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(337, 135);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(86, 22);
            this.txtCustomerID.TabIndex = 5;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(611, 184);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 20);
            this.label15.TabIndex = 4;
            this.label15.Text = "Address";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(626, 135);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 3;
            this.label14.Text = "Phone";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(177, 182);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Customer Name";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(209, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 20);
            this.label12.TabIndex = 1;
            this.label12.Text = "Customer ID";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(467, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(328, 32);
            this.label11.TabIndex = 0;
            this.label11.Text = "Customer Management";
            // 
            // ManageProductSc
            // 
            this.ManageProductSc.Controls.Add(this.btnSearchProduct);
            this.ManageProductSc.Controls.Add(this.cbSupplier);
            this.ManageProductSc.Controls.Add(this.lbPriceError);
            this.ManageProductSc.Controls.Add(this.txtPrice);
            this.ManageProductSc.Controls.Add(this.label10);
            this.ManageProductSc.Controls.Add(this.label9);
            this.ManageProductSc.Controls.Add(this.lbQuantityError);
            this.ManageProductSc.Controls.Add(this.lbNameError);
            this.ManageProductSc.Controls.Add(this.lbIDError);
            this.ManageProductSc.Controls.Add(this.label8);
            this.ManageProductSc.Controls.Add(this.dgvProduct);
            this.ManageProductSc.Controls.Add(this.cbCategory);
            this.ManageProductSc.Controls.Add(this.txtQuantity);
            this.ManageProductSc.Controls.Add(this.txtProductName);
            this.ManageProductSc.Controls.Add(this.txtProductID);
            this.ManageProductSc.Controls.Add(this.btnCancel);
            this.ManageProductSc.Controls.Add(this.btnDelete);
            this.ManageProductSc.Controls.Add(this.btnUpdate);
            this.ManageProductSc.Controls.Add(this.btnInsert);
            this.ManageProductSc.Controls.Add(this.label7);
            this.ManageProductSc.Controls.Add(this.label6);
            this.ManageProductSc.Controls.Add(this.label5);
            this.ManageProductSc.Controls.Add(this.label4);
            this.ManageProductSc.Controls.Add(this.label3);
            this.ManageProductSc.Location = new System.Drawing.Point(4, 25);
            this.ManageProductSc.Name = "ManageProductSc";
            this.ManageProductSc.Padding = new System.Windows.Forms.Padding(3);
            this.ManageProductSc.Size = new System.Drawing.Size(1262, 724);
            this.ManageProductSc.TabIndex = 3;
            this.ManageProductSc.Text = "ManageProduct";
            this.ManageProductSc.UseVisualStyleBackColor = true;
            // 
            // StatisticSc
            // 
            this.StatisticSc.Location = new System.Drawing.Point(4, 25);
            this.StatisticSc.Name = "StatisticSc";
            this.StatisticSc.Padding = new System.Windows.Forms.Padding(3);
            this.StatisticSc.Size = new System.Drawing.Size(1262, 724);
            this.StatisticSc.TabIndex = 4;
            this.StatisticSc.Text = "Statistic";
            this.StatisticSc.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Product ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Product Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(467, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(303, 32);
            this.label5.TabIndex = 3;
            this.label5.Text = "Product Management";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(749, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(744, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Category";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(198, 256);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(75, 36);
            this.btnInsert.TabIndex = 6;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnSearchProduct
            // 
            this.btnSearchProduct.Location = new System.Drawing.Point(849, 256);
            this.btnSearchProduct.Name = "btnSearchProduct";
            this.btnSearchProduct.Size = new System.Drawing.Size(75, 36);
            this.btnSearchProduct.TabIndex = 28;
            this.btnSearchProduct.Text = "Search";
            this.btnSearchProduct.UseVisualStyleBackColor = true;
            this.btnSearchProduct.Click += new System.EventHandler(this.btnSearchProduct_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(423, 256);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 36);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(652, 256);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 36);
            this.btnDelete.TabIndex = 9;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1013, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 36);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(227, 91);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(176, 22);
            this.txtProductID.TabIndex = 11;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(227, 138);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(249, 22);
            this.txtProductName.TabIndex = 12;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(879, 93);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(109, 22);
            this.txtQuantity.TabIndex = 13;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(879, 140);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(196, 24);
            this.cbCategory.TabIndex = 14;
            // 
            // SupplierID
            // 
            this.SupplierID.DataPropertyName = "SupplierID";
            this.SupplierID.HeaderText = "Supplier ID";
            this.SupplierID.MinimumWidth = 6;
            this.SupplierID.Name = "SupplierID";
            this.SupplierID.Width = 125;
            // 
            // CategoryID
            // 
            this.CategoryID.DataPropertyName = "CategoryID";
            this.CategoryID.HeaderText = "Category ID";
            this.CategoryID.MinimumWidth = 6;
            this.CategoryID.Name = "CategoryID";
            this.CategoryID.Width = 125;
            // 
            // InventoryQuantity
            // 
            this.InventoryQuantity.DataPropertyName = "InventoryQuantity";
            this.InventoryQuantity.HeaderText = "Quantity";
            this.InventoryQuantity.MinimumWidth = 6;
            this.InventoryQuantity.Name = "InventoryQuantity";
            this.InventoryQuantity.Width = 125;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 125;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.MinimumWidth = 6;
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 125;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "Product ID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.Width = 125;
            // 
            // dgvProduct
            // 
            this.dgvProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.Price,
            this.InventoryQuantity,
            this.CategoryID,
            this.SupplierID});
            this.dgvProduct.Location = new System.Drawing.Point(82, 347);
            this.dgvProduct.Name = "dgvProduct";
            this.dgvProduct.RowHeadersWidth = 51;
            this.dgvProduct.RowTemplate.Height = 24;
            this.dgvProduct.Size = new System.Drawing.Size(1092, 361);
            this.dgvProduct.TabIndex = 15;
            this.dgvProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProduct_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(516, 300);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(231, 32);
            this.label8.TabIndex = 16;
            this.label8.Text = "List Of Products";
            // 
            // lbIDError
            // 
            this.lbIDError.AutoSize = true;
            this.lbIDError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIDError.ForeColor = System.Drawing.Color.Red;
            this.lbIDError.Location = new System.Drawing.Point(227, 116);
            this.lbIDError.Name = "lbIDError";
            this.lbIDError.Size = new System.Drawing.Size(106, 16);
            this.lbIDError.TabIndex = 17;
            this.lbIDError.Text = "ID can\'t be blank";
            this.lbIDError.Visible = false;
            // 
            // lbNameError
            // 
            this.lbNameError.AutoSize = true;
            this.lbNameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameError.ForeColor = System.Drawing.Color.Red;
            this.lbNameError.Location = new System.Drawing.Point(227, 166);
            this.lbNameError.Name = "lbNameError";
            this.lbNameError.Size = new System.Drawing.Size(130, 16);
            this.lbNameError.TabIndex = 19;
            this.lbNameError.Text = "Name can\'t be blank";
            this.lbNameError.Visible = false;
            // 
            // lbQuantityError
            // 
            this.lbQuantityError.AutoSize = true;
            this.lbQuantityError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuantityError.ForeColor = System.Drawing.Color.Red;
            this.lbQuantityError.Location = new System.Drawing.Point(876, 118);
            this.lbQuantityError.Name = "lbQuantityError";
            this.lbQuantityError.Size = new System.Drawing.Size(141, 16);
            this.lbQuantityError.TabIndex = 21;
            this.lbQuantityError.Text = "Quantity can\'t be blank";
            this.lbQuantityError.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(82, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Price";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(748, 193);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.TabIndex = 23;
            this.label10.Text = "Supplier";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(227, 193);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(113, 22);
            this.txtPrice.TabIndex = 24;
            // 
            // lbPriceError
            // 
            this.lbPriceError.AutoSize = true;
            this.lbPriceError.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPriceError.ForeColor = System.Drawing.Color.Red;
            this.lbPriceError.Location = new System.Drawing.Point(227, 218);
            this.lbPriceError.Name = "lbPriceError";
            this.lbPriceError.Size = new System.Drawing.Size(51, 16);
            this.lbPriceError.TabIndex = 26;
            this.lbPriceError.Text = "label11";
            this.lbPriceError.Visible = false;
            // 
            // cbSupplier
            // 
            this.cbSupplier.FormattingEnabled = true;
            this.cbSupplier.Location = new System.Drawing.Point(879, 190);
            this.cbSupplier.Name = "cbSupplier";
            this.cbSupplier.Size = new System.Drawing.Size(196, 24);
            this.cbSupplier.TabIndex = 27;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(570, 420);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(79, 37);
            this.btnLogout.TabIndex = 37;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 756);
            this.Controls.Add(this.tabControl1);
            this.Name = "Admin";
            this.Text = "ProductManagement";
            this.Load += new System.EventHandler(this.ProductManagement_Load);
            this.tabControl1.ResumeLayout(false);
            this.HomeSc.ResumeLayout(false);
            this.HomeSc.PerformLayout();
            this.ManageEmployeeSc.ResumeLayout(false);
            this.ManageEmployeeSc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployee)).EndInit();
            this.ManageCustomerSc.ResumeLayout(false);
            this.ManageCustomerSc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.ManageProductSc.ResumeLayout(false);
            this.ManageProductSc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProduct)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage HomeSc;
        private System.Windows.Forms.TabPage ManageEmployeeSc;
        private System.Windows.Forms.TabPage ManageCustomerSc;
        private System.Windows.Forms.TabPage ManageProductSc;
        private System.Windows.Forms.TabPage StatisticSc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtCustomerAddress;
        private System.Windows.Forms.TextBox txtCustomerPhone;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnViewOrderHistory;
        private System.Windows.Forms.Button btnSearchCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnInsertCustomer;
        private System.Windows.Forms.Button btnCancelCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerAddress;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dgvOrderHistory;
        private System.Windows.Forms.Label lbCustomerIDError;
        private System.Windows.Forms.Label lbCustomerPhoneError;
        private System.Windows.Forms.Label lbCustomerNameError;
        private System.Windows.Forms.Label lbCustomerAddressError;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEmployeePosition;
        private System.Windows.Forms.TextBox txtEmployeeName;
        private System.Windows.Forms.TextBox txtEmployeeID;
        private System.Windows.Forms.DataGridView dgvEmployee;
        private System.Windows.Forms.Button btnSearchEmployee;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnUpdateEmployee;
        private System.Windows.Forms.Button btnInsertEmployee;
        private System.Windows.Forms.Button btnCancelEmployee;
        private System.Windows.Forms.Button btnDeleteEmployee;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeePosition;
        private System.Windows.Forms.Label lbEmployeePositionError;
        private System.Windows.Forms.Label lbEmployeeNameError;
        private System.Windows.Forms.Label lbEmployeeIDError;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearchProduct;
        private System.Windows.Forms.ComboBox cbSupplier;
        private System.Windows.Forms.Label lbPriceError;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbQuantityError;
        private System.Windows.Forms.Label lbNameError;
        private System.Windows.Forms.Label lbIDError;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventoryQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierID;
        private System.Windows.Forms.ComboBox cbCategory;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnLogout;
    }
}