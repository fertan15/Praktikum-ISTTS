namespace MateriW4
{
    partial class adminPage
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.logOutButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pizzaIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releaseDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hargaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toppingsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stokDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TambahStok = new System.Windows.Forms.DataGridViewButtonColumn();
            this.stokBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new MateriW4.DataSet1();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.orderIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tanggalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyTransaksiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.antrianBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.namaBox = new System.Windows.Forms.TextBox();
            this.tipeBox = new System.Windows.Forms.ComboBox();
            this.hargaBox = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.stokBox = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mushroomBox = new System.Windows.Forms.CheckBox();
            this.tunaBox = new System.Windows.Forms.CheckBox();
            this.pepperoniBox = new System.Windows.Forms.CheckBox();
            this.beefBox = new System.Windows.Forms.CheckBox();
            this.cheeseBox = new System.Windows.Forms.CheckBox();
            this.addButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stokBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyTransaksiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.antrianBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hargaBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stokBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(364, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pizza Dashboard";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // logOutButton
            // 
            this.logOutButton.Location = new System.Drawing.Point(929, 12);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(110, 43);
            this.logOutButton.TabIndex = 1;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = true;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pizzaIdDataGridViewTextBoxColumn,
            this.namaDataGridViewTextBoxColumn,
            this.tipeDataGridViewTextBoxColumn,
            this.releaseDateDataGridViewTextBoxColumn,
            this.hargaDataGridViewTextBoxColumn,
            this.toppingsDataGridViewTextBoxColumn,
            this.stokDataGridViewTextBoxColumn,
            this.TambahStok});
            this.dataGridView1.DataSource = this.stokBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1035, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentDoubleClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormatting);
            // 
            // pizzaIdDataGridViewTextBoxColumn
            // 
            this.pizzaIdDataGridViewTextBoxColumn.DataPropertyName = "PizzaId";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            this.pizzaIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.pizzaIdDataGridViewTextBoxColumn.HeaderText = "PizzaId";
            this.pizzaIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.pizzaIdDataGridViewTextBoxColumn.Name = "pizzaIdDataGridViewTextBoxColumn";
            this.pizzaIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.pizzaIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // namaDataGridViewTextBoxColumn
            // 
            this.namaDataGridViewTextBoxColumn.DataPropertyName = "Nama";
            this.namaDataGridViewTextBoxColumn.HeaderText = "Nama";
            this.namaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.namaDataGridViewTextBoxColumn.Name = "namaDataGridViewTextBoxColumn";
            this.namaDataGridViewTextBoxColumn.ReadOnly = true;
            this.namaDataGridViewTextBoxColumn.Width = 125;
            // 
            // tipeDataGridViewTextBoxColumn
            // 
            this.tipeDataGridViewTextBoxColumn.DataPropertyName = "Tipe";
            this.tipeDataGridViewTextBoxColumn.HeaderText = "Tipe";
            this.tipeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tipeDataGridViewTextBoxColumn.Name = "tipeDataGridViewTextBoxColumn";
            this.tipeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipeDataGridViewTextBoxColumn.Width = 125;
            // 
            // releaseDateDataGridViewTextBoxColumn
            // 
            this.releaseDateDataGridViewTextBoxColumn.DataPropertyName = "ReleaseDate";
            this.releaseDateDataGridViewTextBoxColumn.HeaderText = "ReleaseDate";
            this.releaseDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.releaseDateDataGridViewTextBoxColumn.Name = "releaseDateDataGridViewTextBoxColumn";
            this.releaseDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.releaseDateDataGridViewTextBoxColumn.Width = 125;
            // 
            // hargaDataGridViewTextBoxColumn
            // 
            this.hargaDataGridViewTextBoxColumn.DataPropertyName = "Harga";
            this.hargaDataGridViewTextBoxColumn.HeaderText = "Harga";
            this.hargaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hargaDataGridViewTextBoxColumn.Name = "hargaDataGridViewTextBoxColumn";
            this.hargaDataGridViewTextBoxColumn.ReadOnly = true;
            this.hargaDataGridViewTextBoxColumn.Width = 125;
            // 
            // toppingsDataGridViewTextBoxColumn
            // 
            this.toppingsDataGridViewTextBoxColumn.DataPropertyName = "Toppings";
            this.toppingsDataGridViewTextBoxColumn.HeaderText = "Toppings";
            this.toppingsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.toppingsDataGridViewTextBoxColumn.Name = "toppingsDataGridViewTextBoxColumn";
            this.toppingsDataGridViewTextBoxColumn.ReadOnly = true;
            this.toppingsDataGridViewTextBoxColumn.Width = 125;
            // 
            // stokDataGridViewTextBoxColumn
            // 
            this.stokDataGridViewTextBoxColumn.DataPropertyName = "Stok";
            this.stokDataGridViewTextBoxColumn.HeaderText = "Stok";
            this.stokDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.stokDataGridViewTextBoxColumn.Name = "stokDataGridViewTextBoxColumn";
            this.stokDataGridViewTextBoxColumn.ReadOnly = true;
            this.stokDataGridViewTextBoxColumn.Width = 125;
            // 
            // TambahStok
            // 
            this.TambahStok.HeaderText = "Aksi";
            this.TambahStok.MinimumWidth = 6;
            this.TambahStok.Name = "TambahStok";
            this.TambahStok.ReadOnly = true;
            this.TambahStok.Text = "Tambah Stok";
            this.TambahStok.Width = 125;
            // 
            // stokBindingSource
            // 
            this.stokBindingSource.DataMember = "Stok";
            this.stokBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdDataGridViewTextBoxColumn,
            this.usernameDataGridViewTextBoxColumn,
            this.tanggalDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.itemsDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.historyTransaksiBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(4, 256);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(684, 191);
            this.dataGridView2.TabIndex = 3;
            // 
            // orderIdDataGridViewTextBoxColumn
            // 
            this.orderIdDataGridViewTextBoxColumn.DataPropertyName = "OrderId";
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            this.orderIdDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.orderIdDataGridViewTextBoxColumn.HeaderText = "OrderId";
            this.orderIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.orderIdDataGridViewTextBoxColumn.Name = "orderIdDataGridViewTextBoxColumn";
            this.orderIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderIdDataGridViewTextBoxColumn.Width = 125;
            // 
            // usernameDataGridViewTextBoxColumn
            // 
            this.usernameDataGridViewTextBoxColumn.DataPropertyName = "Username";
            this.usernameDataGridViewTextBoxColumn.HeaderText = "Username";
            this.usernameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.usernameDataGridViewTextBoxColumn.Name = "usernameDataGridViewTextBoxColumn";
            this.usernameDataGridViewTextBoxColumn.ReadOnly = true;
            this.usernameDataGridViewTextBoxColumn.Width = 125;
            // 
            // tanggalDataGridViewTextBoxColumn
            // 
            this.tanggalDataGridViewTextBoxColumn.DataPropertyName = "Tanggal";
            this.tanggalDataGridViewTextBoxColumn.HeaderText = "Tanggal";
            this.tanggalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tanggalDataGridViewTextBoxColumn.Name = "tanggalDataGridViewTextBoxColumn";
            this.tanggalDataGridViewTextBoxColumn.ReadOnly = true;
            this.tanggalDataGridViewTextBoxColumn.Width = 125;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalDataGridViewTextBoxColumn.Width = 125;
            // 
            // itemsDataGridViewTextBoxColumn
            // 
            this.itemsDataGridViewTextBoxColumn.DataPropertyName = "Items";
            this.itemsDataGridViewTextBoxColumn.HeaderText = "Items";
            this.itemsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.itemsDataGridViewTextBoxColumn.Name = "itemsDataGridViewTextBoxColumn";
            this.itemsDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemsDataGridViewTextBoxColumn.Width = 125;
            // 
            // historyTransaksiBindingSource
            // 
            this.historyTransaksiBindingSource.DataMember = "HistoryTransaksi";
            this.historyTransaksiBindingSource.DataSource = this.dataSet1;
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.antrianBindingSource;
            this.listBox1.DisplayMember = "View";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(694, 256);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(345, 180);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // antrianBindingSource
            // 
            this.antrianBindingSource.DataMember = "Antrian";
            this.antrianBindingSource.DataSource = this.dataSet1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1, 237);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "History Transaction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(691, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "List Order (Antrian)";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 481);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nama";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 538);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tipe";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 590);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Harga";
            // 
            // namaBox
            // 
            this.namaBox.Location = new System.Drawing.Point(106, 479);
            this.namaBox.Name = "namaBox";
            this.namaBox.Size = new System.Drawing.Size(317, 22);
            this.namaBox.TabIndex = 10;
            // 
            // tipeBox
            // 
            this.tipeBox.FormattingEnabled = true;
            this.tipeBox.Items.AddRange(new object[] {
            "Pan",
            "Thin",
            "Stuffed"});
            this.tipeBox.Location = new System.Drawing.Point(104, 538);
            this.tipeBox.Name = "tipeBox";
            this.tipeBox.Size = new System.Drawing.Size(165, 24);
            this.tipeBox.TabIndex = 11;
            // 
            // hargaBox
            // 
            this.hargaBox.Location = new System.Drawing.Point(106, 590);
            this.hargaBox.Maximum = new decimal(new int[] {
            1874919424,
            2328306,
            0,
            0});
            this.hargaBox.Name = "hargaBox";
            this.hargaBox.Size = new System.Drawing.Size(120, 22);
            this.hargaBox.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(244, 592);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Stok";
            // 
            // stokBox
            // 
            this.stokBox.Location = new System.Drawing.Point(303, 590);
            this.stokBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.stokBox.Name = "stokBox";
            this.stokBox.Size = new System.Drawing.Size(120, 22);
            this.stokBox.TabIndex = 14;
            this.stokBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(284, 540);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Release Date";
            // 
            // dateBox
            // 
            this.dateBox.Location = new System.Drawing.Point(414, 538);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(235, 22);
            this.dateBox.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mushroomBox);
            this.groupBox1.Controls.Add(this.tunaBox);
            this.groupBox1.Controls.Add(this.pepperoniBox);
            this.groupBox1.Controls.Add(this.beefBox);
            this.groupBox1.Controls.Add(this.cheeseBox);
            this.groupBox1.Location = new System.Drawing.Point(667, 472);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 98);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Toppings";
            // 
            // mushroomBox
            // 
            this.mushroomBox.AutoSize = true;
            this.mushroomBox.Location = new System.Drawing.Point(244, 21);
            this.mushroomBox.Name = "mushroomBox";
            this.mushroomBox.Size = new System.Drawing.Size(92, 20);
            this.mushroomBox.TabIndex = 4;
            this.mushroomBox.Text = "Mushroom";
            this.mushroomBox.UseVisualStyleBackColor = true;
            // 
            // tunaBox
            // 
            this.tunaBox.AutoSize = true;
            this.tunaBox.Location = new System.Drawing.Point(122, 57);
            this.tunaBox.Name = "tunaBox";
            this.tunaBox.Size = new System.Drawing.Size(60, 20);
            this.tunaBox.TabIndex = 3;
            this.tunaBox.Text = "Tuna";
            this.tunaBox.UseVisualStyleBackColor = true;
            // 
            // pepperoniBox
            // 
            this.pepperoniBox.AutoSize = true;
            this.pepperoniBox.Location = new System.Drawing.Point(122, 21);
            this.pepperoniBox.Name = "pepperoniBox";
            this.pepperoniBox.Size = new System.Drawing.Size(92, 20);
            this.pepperoniBox.TabIndex = 2;
            this.pepperoniBox.Text = "Pepperoni";
            this.pepperoniBox.UseVisualStyleBackColor = true;
            // 
            // beefBox
            // 
            this.beefBox.AutoSize = true;
            this.beefBox.Location = new System.Drawing.Point(6, 57);
            this.beefBox.Name = "beefBox";
            this.beefBox.Size = new System.Drawing.Size(57, 20);
            this.beefBox.TabIndex = 1;
            this.beefBox.Text = "Beef";
            this.beefBox.UseVisualStyleBackColor = true;
            // 
            // cheeseBox
            // 
            this.cheeseBox.AutoSize = true;
            this.cheeseBox.Location = new System.Drawing.Point(6, 21);
            this.cheeseBox.Name = "cheeseBox";
            this.cheeseBox.Size = new System.Drawing.Size(76, 20);
            this.cheeseBox.TabIndex = 0;
            this.cheeseBox.Text = "Cheese";
            this.cheeseBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cheeseBox.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(667, 576);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(77, 49);
            this.addButton.TabIndex = 18;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(770, 576);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(77, 49);
            this.updateButton.TabIndex = 19;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(869, 576);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(77, 49);
            this.deleteButton.TabIndex = 20;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(962, 576);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(77, 49);
            this.clearButton.TabIndex = 21;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // adminPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 637);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.stokBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.hargaBox);
            this.Controls.Add(this.tipeBox);
            this.Controls.Add(this.namaBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.logOutButton);
            this.Controls.Add(this.label1);
            this.Name = "adminPage";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stokBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.historyTransaksiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.antrianBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hargaBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stokBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button logOutButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource stokBindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource historyTransaksiBindingSource;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.BindingSource antrianBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tanggalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemsDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox namaBox;
        private System.Windows.Forms.ComboBox tipeBox;
        private System.Windows.Forms.NumericUpDown hargaBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown stokBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox beefBox;
        private System.Windows.Forms.CheckBox cheeseBox;
        private System.Windows.Forms.CheckBox mushroomBox;
        private System.Windows.Forms.CheckBox tunaBox;
        private System.Windows.Forms.CheckBox pepperoniBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn pizzaIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn namaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releaseDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hargaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn toppingsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stokDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn TambahStok;
    }
}

