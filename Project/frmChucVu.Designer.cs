namespace Project
{
    partial class frmChucVu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChucVu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMaCVTim = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnUpdateSub = new System.Windows.Forms.Button();
            this.btnCancelAdd = new System.Windows.Forms.Button();
            this.txtTenCV = new System.Windows.Forms.TextBox();
            this.btnAddSub = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaCV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvChucVu = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.errorTxt = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucVu)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorTxt)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtMaCVTim);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1188, 119);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 30F);
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(489, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chức vụ";
            // 
            // txtMaCVTim
            // 
            this.txtMaCVTim.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.txtMaCVTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.8F);
            this.txtMaCVTim.Location = new System.Drawing.Point(808, 76);
            this.txtMaCVTim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaCVTim.Name = "txtMaCVTim";
            this.txtMaCVTim.Size = new System.Drawing.Size(352, 27);
            this.txtMaCVTim.TabIndex = 8;
            this.txtMaCVTim.Text = "nhập mã chức vụ tìm...";
            this.txtMaCVTim.Click += new System.EventHandler(this.txtMaCVTim_Click);
            this.txtMaCVTim.TextChanged += new System.EventHandler(this.txtMaCVTim_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnUpdateSub);
            this.panel2.Controls.Add(this.btnCancelAdd);
            this.panel2.Controls.Add(this.txtTenCV);
            this.panel2.Controls.Add(this.btnAddSub);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtMaCV);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.dgvChucVu);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 119);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1188, 506);
            this.panel2.TabIndex = 1;
            // 
            // btnUpdateSub
            // 
            this.btnUpdateSub.AccessibleDescription = "Thoát khỏi form nhân viên";
            this.btnUpdateSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateSub.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdateSub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateSub.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateSub.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateSub.Image")));
            this.btnUpdateSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateSub.Location = new System.Drawing.Point(444, 167);
            this.btnUpdateSub.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateSub.Name = "btnUpdateSub";
            this.btnUpdateSub.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnUpdateSub.Size = new System.Drawing.Size(196, 53);
            this.btnUpdateSub.TabIndex = 9;
            this.btnUpdateSub.Text = "&Sửa";
            this.btnUpdateSub.UseVisualStyleBackColor = false;
            this.btnUpdateSub.Visible = false;
            this.btnUpdateSub.Click += new System.EventHandler(this.btnUpdateSub_Click);
            // 
            // btnCancelAdd
            // 
            this.btnCancelAdd.AccessibleDescription = "Thoát khỏi form nhân viên";
            this.btnCancelAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelAdd.Font = new System.Drawing.Font("Cambria", 11.8F);
            this.btnCancelAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelAdd.Image")));
            this.btnCancelAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelAdd.Location = new System.Drawing.Point(197, 167);
            this.btnCancelAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelAdd.Name = "btnCancelAdd";
            this.btnCancelAdd.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnCancelAdd.Size = new System.Drawing.Size(196, 53);
            this.btnCancelAdd.TabIndex = 8;
            this.btnCancelAdd.Text = "&Huỷ";
            this.btnCancelAdd.UseVisualStyleBackColor = true;
            this.btnCancelAdd.Visible = false;
            this.btnCancelAdd.Click += new System.EventHandler(this.btnCancelAdd_Click);
            // 
            // txtTenCV
            // 
            this.txtTenCV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTenCV.Enabled = false;
            this.txtTenCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.txtTenCV.Location = new System.Drawing.Point(197, 128);
            this.txtTenCV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTenCV.Name = "txtTenCV";
            this.txtTenCV.Size = new System.Drawing.Size(443, 30);
            this.txtTenCV.TabIndex = 2;
            this.txtTenCV.TextChanged += new System.EventHandler(this.txtTenCV_TextChanged);
            // 
            // btnAddSub
            // 
            this.btnAddSub.AccessibleDescription = "Thoát khỏi form nhân viên";
            this.btnAddSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSub.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddSub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSub.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSub.Image = ((System.Drawing.Image)(resources.GetObject("btnAddSub.Image")));
            this.btnAddSub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddSub.Location = new System.Drawing.Point(444, 167);
            this.btnAddSub.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddSub.Name = "btnAddSub";
            this.btnAddSub.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnAddSub.Size = new System.Drawing.Size(196, 53);
            this.btnAddSub.TabIndex = 7;
            this.btnAddSub.Text = "Th&êm";
            this.btnAddSub.UseVisualStyleBackColor = false;
            this.btnAddSub.Visible = false;
            this.btnAddSub.Click += new System.EventHandler(this.btnAddSub_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label3.Location = new System.Drawing.Point(39, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên chức vụ:";
            // 
            // txtMaCV
            // 
            this.txtMaCV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMaCV.Enabled = false;
            this.txtMaCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.txtMaCV.Location = new System.Drawing.Point(197, 68);
            this.txtMaCV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaCV.Name = "txtMaCV";
            this.txtMaCV.Size = new System.Drawing.Size(443, 30);
            this.txtMaCV.TabIndex = 1;
            this.txtMaCV.TextChanged += new System.EventHandler(this.txtMaCV_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.8F);
            this.label2.Location = new System.Drawing.Point(39, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã chức vụ: ";
            // 
            // dgvChucVu
            // 
            this.dgvChucVu.AllowUserToAddRows = false;
            this.dgvChucVu.AllowUserToDeleteRows = false;
            this.dgvChucVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChucVu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChucVu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvChucVu.Location = new System.Drawing.Point(0, 239);
            this.dgvChucVu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvChucVu.Name = "dgvChucVu";
            this.dgvChucVu.ReadOnly = true;
            this.dgvChucVu.RowTemplate.Height = 24;
            this.dgvChucVu.Size = new System.Drawing.Size(936, 267);
            this.dgvChucVu.TabIndex = 1;
            this.dgvChucVu.Click += new System.EventHandler(this.dgvChucVu_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnDelete);
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Controls.Add(this.btnSearch);
            this.panel3.Controls.Add(this.btnAdd);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(936, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(252, 506);
            this.panel3.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.AccessibleDescription = "Thoát khỏi form nhân viên";
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Cambria", 11.8F);
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(9, 387);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnExit.Size = new System.Drawing.Size(235, 81);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Th&oát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.AccessibleDescription = "Thoát khỏi form nhân viên";
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Font = new System.Drawing.Font("Cambria", 11.8F);
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(9, 197);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnDelete.Size = new System.Drawing.Size(235, 81);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "&Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleDescription = "Thoát khỏi form nhân viên";
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdate.Font = new System.Drawing.Font("Cambria", 11.8F);
            this.btnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Image")));
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdate.Location = new System.Drawing.Point(9, 292);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnUpdate.Size = new System.Drawing.Size(235, 81);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "&Sửa";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.AccessibleDescription = "Thoát khỏi form nhân viên";
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Cambria", 11.8F);
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(9, 7);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(235, 81);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "&Tìm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleDescription = "Thoát khỏi form nhân viên";
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Font = new System.Drawing.Font("Cambria", 11.8F);
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(9, 102);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.btnAdd.Size = new System.Drawing.Size(235, 81);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "T&hêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errorTxt
            // 
            this.errorTxt.ContainerControl = this;
            // 
            // frmChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 625);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "frmChucVu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chức vụ";
            this.Load += new System.EventHandler(this.frmChucVu_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChucVu)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorTxt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvChucVu;
        private System.Windows.Forms.TextBox txtTenCV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaCV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMaCVTim;
        private System.Windows.Forms.Button btnCancelAdd;
        private System.Windows.Forms.Button btnAddSub;
        private System.Windows.Forms.ErrorProvider errorTxt;
        private System.Windows.Forms.Button btnUpdateSub;
    }
}