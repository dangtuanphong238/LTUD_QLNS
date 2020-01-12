using Project.classSupport;
using Project.Exciption;
using Project.model;
using System;
using System.Data;
using System.Windows.Forms;

namespace Project
{
    public partial class frmNhanVien : Form
    {
        //Variable
        private handleDatabase db = new handleDatabase();
        private NhanVienModel nhanVienM = new NhanVienModel();
        private bool dangThaoTac = false;



        /*
         * ________ LOAD FORM ________
         */

        //Constructor form
        public frmNhanVien()
        {
            //Show funtion and display form
            InitializeComponent();

        }

        //Load form NhanVien main
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            //show data NHANVIEN on dataGridView NHANVIEN
            loadTableNhanVien();
            setNameColumsDataGirdView();
            loadAllComboBox();
        }

        //Load tablle NhanVien 
        private void loadTableNhanVien()
        {
            dgvNhanVien.DataSource = nhanVienM.getAllTable();
        }

        //Load all comboBox
        private void loadAllComboBox()
        {
            loadComboBoxChucVu();
            loadComboBoxPhongBan();
            loadComboBoxTrinhDoHocVan();
            loadComboBoxHopDong();
            loadComboBoxGioTinh();
            loadComboBoxLuong();
        }

        //Load information text input form
        private void loadAllTxt(DataRow dataRow)
        {
            //Gan thong tin nhan vien tim duoc vao trong form
            txtMaNV.Text = dataRow[0].ToString();
            txtHoTen.Text = dataRow[1].ToString();
            txtSDT.Text = dataRow[2].ToString();
            dtpNgaySinh.Text = dataRow[4].ToString();
            txtDanToc.Text = dataRow[5].ToString();
            txtQueQuan.Text = dataRow[6].ToString();
            txtDiaChi.Text = dataRow[7].ToString();
            txtCMND.Text = dataRow[8].ToString();

            /*
             * set comboBox and value
             */
            //Gioi tinh
            if (dataRow[3].ToString().Equals(true.ToString()))
            {
                cbGioTinh.Text = "Nam";
                cbGioTinh.FindStringExact("Nam");
            }
            else
            {
                cbGioTinh.Text = "Nữ";
                cbGioTinh.FindStringExact("Nữ");
            }

            //Phong ban
            cbPhongBan.Text = dataRow[9].ToString();
            cbPhongBan.FindStringExact(dataRow[9].ToString());

            //Chuc vu
            cbChucVu.Text = dataRow[10].ToString();
            cbChucVu.FindStringExact(dataRow[10].ToString());

            //Trinh do hoc van
            cbTrinhDoHocVan.Text = dataRow[11].ToString();
            cbTrinhDoHocVan.FindStringExact(dataRow[11].ToString());

            //Luong
            cbLuong.Text = dataRow[12].ToString();
            cbLuong.FindStringExact(dataRow[12].ToString());

            //Loai hop dong
            cbLoaiHopDong.Text = dataRow[13].ToString();
            cbLoaiHopDong.FindStringExact(dataRow[13].ToString());
        }

        //Form closing
        private void frmNhanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dangThaoTac == true)
            {
                DialogResult result = new DialogResult();

                result = MessageBox.Show(
                    "Chưa hoàn thành thao tác\nBạn có muốn thoát khỏi form không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
            }
        }



        /*
        * ________ FUNCTION CLEAR OR SUPPORT MORE ________
        */
        private void setNameColumsDataGirdView()
        {
            dgvNhanVien.Columns[0].HeaderText = "Mã";
            dgvNhanVien.Columns[1].HeaderText = "Họ tên";
            dgvNhanVien.Columns[2].HeaderText = "SĐT";
            dgvNhanVien.Columns[3].HeaderText = "Giới tính";
            dgvNhanVien.Columns[4].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[5].HeaderText = "Dân tộc";
            dgvNhanVien.Columns[6].HeaderText = "Quê quán";
            dgvNhanVien.Columns[7].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns[8].HeaderText = "CMND";
            dgvNhanVien.Columns[9].HeaderText = "Phòng ban";
            dgvNhanVien.Columns[10].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[11].HeaderText = "TĐ học vấn";
            dgvNhanVien.Columns[12].HeaderText = "Lương";
            dgvNhanVien.Columns[13].HeaderText = "Loại hợp đồng";
        }

        private void resetAllButton()
        {
            //Enabled
            btnSearch.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnExit.Enabled = true;
            dgvNhanVien.Enabled = true;

            //Visible true
            btnSearch.Visible = true;
            btnAdd.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            btnExit.Visible = true;

            //Visible false
            btnAddSub.Visible = false;
            btnCancelAdd.Visible = false;

            //set 
            dangThaoTac = false;
        }

        private void clearAllInput()
        {
            txtMaNV.Text = txtHoTen.Text = txtSDT.Text = txtDanToc.Text = txtQueQuan.Text = txtDiaChi.Text = txtCMND.Text = string.Empty;

            cbGioTinh.SelectedIndex = -1;
            cbGioTinh.Text = "Giới tính...";

            cbPhongBan.SelectedIndex = -1;
            cbPhongBan.Text = "Phòng ban...";

            cbChucVu.SelectedIndex = -1;
            cbChucVu.Text = "Chức vụ...";

            cbTrinhDoHocVan.SelectedIndex = -1;
            cbTrinhDoHocVan.Text = "Trình độ học vấn...";

            cbLuong.SelectedIndex = -1;
            cbLuong.Text = "Lương...";

            cbLoaiHopDong.SelectedIndex = -1;
            cbLoaiHopDong.Text = "Loại hợp đồng...";
        }

        private void enabledAll()
        {
            //Enabled
            btnSearch.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnExit.Enabled = false;
            dgvNhanVien.Enabled = false;

            //Visible false
            btnAddSub.Visible = true;
            btnCancelAdd.Visible = true;

            //set 
            dangThaoTac = true;
        }


        /*
        * ________ FUNCTION CHECK TEXT AND COMBOBOX________
        */

        /// <summary>
        /// Kiem tra cac comboBox da duoc con 
        /// </summary>
        /// <returns> bool </returns>
        private bool isComboBoxSelected()
        {
            try
            {
                (cbGioTinh.SelectedItem as ComboboxItem).Value.ToString();
                (cbPhongBan.SelectedItem as ComboboxItem).Value.ToString();
                (cbChucVu.SelectedItem as ComboboxItem).Value.ToString();
                (cbTrinhDoHocVan.SelectedItem as ComboboxItem).Value.ToString();
                (cbLuong.SelectedItem as ComboboxItem).Value.ToString();
                (cbLoaiHopDong.SelectedItem as ComboboxItem).Value.ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }

        private bool isTextBoxWirite()
        {
            bool result = true;
            string title = "thông tin không được trống";

            if (txtMaNV.Text == string.Empty)
            {
                result = false;
                errorTxt.SetError(txtMaNV, title);
            }
            else
            {
                if (txtHoTen.Text == string.Empty)
                {
                    result = false;
                    errorTxt.SetError(txtHoTen, title);
                }
                else
                {
                    if (txtSDT.Text == string.Empty)
                    {
                        result = false;
                        errorTxt.SetError(txtSDT, title);
                    }
                    else
                    {
                        if (txtDanToc.Text == string.Empty)
                        {
                            result = false;
                            errorTxt.SetError(txtDanToc, title);
                        }
                        else
                        {
                            if (txtDiaChi.Text == string.Empty)
                            {
                                result = false;
                                errorTxt.SetError(txtDiaChi, title);
                            }
                            else
                            {
                                if (txtCMND.Text == string.Empty)
                                {
                                    result = false;
                                    errorTxt.SetError(txtCMND, title);
                                }
                            }
                        }
                    }
                }
            }

            if (result) errorTxt.Clear();
            return result;
        }

        private bool inputAllNotEmpty()
        {
            return isComboBoxSelected() && isTextBoxWirite();
        }

        /*
         * ________ LOAD COMBOBOX ________
         */
        private void loadComboBoxChucVu()
        {
            //Variable
            ChucVuModel chucVu = new ChucVuModel();
            DataTable td = new DataTable();
            ComboboxItem comboboxItem = new ComboboxItem();

            td = chucVu.getAllTable();
            foreach (DataRow row in td.Rows)
            {
                comboboxItem = new ComboboxItem();
                comboboxItem.Text = row[1].ToString();//Gan ten chuc vu
                comboboxItem.Value = row[0].ToString();//Gan ma chuc vu

                cbChucVu.Items.Add(comboboxItem);//Add item moi vao trong comboBox
            }
        }

        private void loadComboBoxPhongBan()
        {
            //Variable
            PhongBanModel phongBan = new PhongBanModel();
            DataTable td = new DataTable();
            ComboboxItem comboboxItem = new ComboboxItem();

            td = phongBan.getAllTable();
            foreach (DataRow row in td.Rows)
            {
                comboboxItem = new ComboboxItem();
                comboboxItem.Text = row[1].ToString();//Gan ten chuc vu
                comboboxItem.Value = row[0].ToString();//Gan ma chuc vu

                cbPhongBan.Items.Add(comboboxItem);//Add item moi vao trong comboBox
            }
        }

        private void loadComboBoxTrinhDoHocVan()
        {
            //Variable
            TrinhDoHocVanModel tdhvModel = new TrinhDoHocVanModel();
            DataTable td = new DataTable();
            ComboboxItem comboboxItem = new ComboboxItem();

            td = tdhvModel.getAllTable();
            foreach (DataRow row in td.Rows)
            {
                comboboxItem = new ComboboxItem();
                comboboxItem.Text = row[1].ToString();//Gan ten chuc vu
                comboboxItem.Value = row[0].ToString();//Gan ma chuc vu

                cbTrinhDoHocVan.Items.Add(comboboxItem);//Add item moi vao trong comboBox
            }
        }

        private void loadComboBoxHopDong()
        {
            //Variable
            HopDongModel hopDong = new HopDongModel();
            DataTable td = new DataTable();
            ComboboxItem comboboxItem = new ComboboxItem();

            td = hopDong.getAllTable();
            foreach (DataRow row in td.Rows)
            {
                comboboxItem = new ComboboxItem();
                comboboxItem.Text = row[1].ToString();//Gan ten chuc vu
                comboboxItem.Value = row[0].ToString();//Gan ma chuc vu

                cbLoaiHopDong.Items.Add(comboboxItem);//Add item moi vao trong comboBox
            }
        }

        private void loadComboBoxGioTinh()
        {
            ComboboxItem comboboxItemNam = new ComboboxItem();
            comboboxItemNam.Text = "Nam";
            comboboxItemNam.Value = 1;

            ComboboxItem comboboxItemNu = new ComboboxItem();
            comboboxItemNu.Text = "Nữ";
            comboboxItemNu.Value = 0;

            cbGioTinh.Items.Add(comboboxItemNam);
            cbGioTinh.Items.Add(comboboxItemNu);
        }

        private void loadComboBoxLuong()
        {
            //Variable
            LuongModel luongM = new LuongModel();
            DataTable td = new DataTable();
            ComboboxItem comboboxItem = new ComboboxItem();

            td = luongM.getAllTable();
            foreach (DataRow row in td.Rows)
            {
                comboboxItem = new ComboboxItem();
                comboboxItem.Text = row[1].ToString();//Gan ten chuc vu
                comboboxItem.Value = row[0].ToString();//Gan ma chuc vu

                cbLuong.Items.Add(comboboxItem);//Add item moi vao trong comboBox
            }
        }




        /*
         * ________ EVENT CLICK ________
         */
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;

            int r = dgvNhanVien.CurrentCell.RowIndex;

            //set text box
            txtMaNV.Text = dgvNhanVien.Rows[r].Cells[0].Value.ToString();
            txtHoTen.Text = dgvNhanVien.Rows[r].Cells[1].Value.ToString();
            txtSDT.Text = dgvNhanVien.Rows[r].Cells[2].Value.ToString();
            dtpNgaySinh.Text = dgvNhanVien.Rows[r].Cells[4].Value.ToString();
            txtDanToc.Text = dgvNhanVien.Rows[r].Cells[5].Value.ToString();
            txtQueQuan.Text = dgvNhanVien.Rows[r].Cells[6].Value.ToString();
            txtDiaChi.Text = dgvNhanVien.Rows[r].Cells[7].Value.ToString();
            txtCMND.Text = dgvNhanVien.Rows[r].Cells[8].Value.ToString();

            /*
             * set comboBox and value
             */
            //Gioi tinh
            if (dgvNhanVien.Rows[r].Cells[3].Value.ToString().Equals(true.ToString()))
            {
                cbGioTinh.Text = "Nam";
                cbGioTinh.FindStringExact("Nam");
            }
            else
            {
                cbGioTinh.Text = "Nữ";
                cbGioTinh.FindStringExact("Nữ");
            }

            //Phong ban
            cbPhongBan.Text = dgvNhanVien.Rows[r].Cells[9].Value.ToString();
            cbPhongBan.FindStringExact(dgvNhanVien.Rows[r].Cells[9].Value.ToString());

            //Chuc vu
            cbChucVu.Text = dgvNhanVien.Rows[r].Cells[10].Value.ToString();
            cbChucVu.FindStringExact(dgvNhanVien.Rows[r].Cells[10].Value.ToString());

            //Trinh do hoc van
            cbTrinhDoHocVan.Text = dgvNhanVien.Rows[r].Cells[11].Value.ToString();
            cbTrinhDoHocVan.FindStringExact(dgvNhanVien.Rows[r].Cells[11].Value.ToString());

            //Luong
            cbLuong.Text = dgvNhanVien.Rows[r].Cells[12].Value.ToString();
            cbLuong.FindStringExact(dgvNhanVien.Rows[r].Cells[12].Value.ToString());

            //Loai hop dong
            cbLoaiHopDong.Text = dgvNhanVien.Rows[r].Cells[13].Value.ToString();
            cbLoaiHopDong.FindStringExact(dgvNhanVien.Rows[r].Cells[13].Value.ToString());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //AcceptButton
            this.AcceptButton = btnAddSub;

            //Focus
            txtMaNV.Focus();

            //clear
            clearAllInput();

            //set
            this.dangThaoTac = true;

            //Visible
            btnAddSub.Visible = true;
            btnCancelAdd.Visible = true;
            btnAdd.Visible = false;

            //Enabled
            btnSearch.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            dgvNhanVien.Enabled = false;
            txtMaNV.Enabled = true;
        }

        private void txtMaNVTim_TextChanged(object sender, EventArgs e)
        {
            if (txtMaNVTim.Text == string.Empty)
            {
                errorTxt.SetError(txtMaNVTim, "Chưa nhập mã nhân viên muốn tìm");
            }
            else
            {
                errorTxt.Clear();
            }
        }

        private void txtMaNVTim_Click(object sender, EventArgs e)
        {
            txtMaNVTim.Text = string.Empty;
            this.AcceptButton = btnSearch;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow drResulut = this.nhanVienM.find(txtMaNVTim.Text);

                //Load du lieu len tren form khi tim thay nhanvien voi ma truyen vao
                loadAllTxt(drResulut);
                txtMaNV.Enabled = false;
            }
            catch (FindException findEx)
            {
                ShowMessageBox.erorr(findEx.Message);
            }
        }

        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            resetAllButton();
            clearAllInput();
        }

        private void btnAddSub_Click(object sender, EventArgs e)
        {
            if (inputAllNotEmpty())//Kiem tra tat ca thong tin da duoc nhap
            {
                int maGioiTinh = int.Parse((cbGioTinh.SelectedItem as ComboboxItem).Value.ToString());
                string maPB = (cbPhongBan.SelectedItem as ComboboxItem).Value.ToString();
                string maCV = (cbChucVu.SelectedItem as ComboboxItem).Value.ToString();
                string maTDHV = (cbTrinhDoHocVan.SelectedItem as ComboboxItem).Value.ToString();
                int bacLuong = int.Parse((cbLuong.SelectedItem as ComboboxItem).Value.ToString());
                string maHD = (cbLoaiHopDong.SelectedItem as ComboboxItem).Value.ToString();
                string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd"); ;

                try
                {
                    //Insert
                    this.nhanVienM.insert(txtMaNV.Text, txtHoTen.Text, txtSDT.Text, maGioiTinh, ngaySinh, txtDanToc.Text, txtQueQuan.Text,
                    txtDiaChi.Text, txtCMND.Text, maPB, maCV, maTDHV, bacLuong, maHD);

                    ShowMessageBox.information("Thêm nhân viên có mã là " + txtMaNV.Text + " thành công", "Thông báo");

                    //Reset table NhanVien
                    loadTableNhanVien();
                    //reset all button function main
                    resetAllButton();
                    //clear
                    clearAllInput();
                }
                catch (InsertException insertEx)
                {
                    ShowMessageBox.erorr(insertEx.Message);
                }
                catch (Exception ex)
                {
                    ShowMessageBox.erorr(ex.Message);
                }
            }
            else
            {
                ShowMessageBox.erorr("ComboBox dữ liệu chưa được bạn chọn \nHoặc còn thiếu một số thông tin", "Lỗi");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != string.Empty)
            {
                DialogResult result = new DialogResult();
                result = MessageBox.Show("Bạn có muốn xoá nhân viên có mã là " + txtMaNV.Text + " không?",
                    "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.No)
                {
                    try
                    {
                        nhanVienM.delete(txtMaNV.Text);

                        //Thong bao
                        ShowMessageBox.information("Xoá thông tin của nhân viên thông");

                        //reload table NhanVien
                        loadTableNhanVien();

                        //Clear
                        clearAllInput();
                    }
                    catch (DeleteException delEx)
                    {
                        ShowMessageBox.erorr(delEx.Message);
                    }
                    catch (Exception ex)
                    {
                        ShowMessageBox.erorr(ex.Message);
                    }
                }
            }
            else
            {
                ShowMessageBox.erorr("Vui lòng nhập thông tin mã Nhân Viên muốn xoá", "Thông tin thiếu");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != string.Empty)
            {
                try
                {
                    DataRow dtResult = nhanVienM.find(txtMaNV.Text);
                    //set
                    this.dangThaoTac = true;

                    //Visible
                    btnSubUpdate.Visible = true;
                    btnCancelUpdate.Visible = true;
                    btnUpdate.Visible = false;

                    //Enabled
                    btnSearch.Enabled = false;
                    btnDelete.Enabled = false;
                    btnAdd.Enabled = false;
                    dgvNhanVien.Enabled = false;
                    txtMaNV.Enabled = false;

                    //Tai thong tin nhan vien mua sua vao form
                    loadAllTxt(dtResult);
                }
                catch (FindException findEx)
                {
                    ShowMessageBox.erorr(findEx.Message);
                }
                catch (Exception ex)
                {
                    ShowMessageBox.erorr(ex.Message);
                }
            }
            else
            {
                ShowMessageBox.erorr("Vui lòng chọn hoặc nhập thông tin nhân viên cần cập nhật", "Thông tin thiếu");
            }
        }

        private void btnCancelUpdate_Click(object sender, EventArgs e)
        {
            //set
            this.dangThaoTac = false;

            //Visible
            btnSubUpdate.Visible = false;
            btnCancelUpdate.Visible = false;
            btnUpdate.Visible = true;

            //Enabled
            btnSearch.Enabled = true;
            btnDelete.Enabled = true;
            btnAdd.Enabled = true;
            dgvNhanVien.Enabled = true;
            txtMaNV.Enabled = true;

            //clear
            clearAllInput();
        }

        private void btnSubUpdate_Click(object sender, EventArgs e)
        {
            if (inputAllNotEmpty())//Kiem tra tat ca thong tin nhan vien muon cap nhat da nhap day du
            {
                this.AcceptButton = btnSubUpdate;//set acceptButton

                int maGioiTinh = int.Parse((cbGioTinh.SelectedItem as ComboboxItem).Value.ToString());
                string maPB = (cbPhongBan.SelectedItem as ComboboxItem).Value.ToString();
                string maCV = (cbChucVu.SelectedItem as ComboboxItem).Value.ToString();
                string maTDHV = (cbTrinhDoHocVan.SelectedItem as ComboboxItem).Value.ToString();
                int bacLuong = int.Parse((cbLuong.SelectedItem as ComboboxItem).Value.ToString());
                string maHD = (cbLoaiHopDong.SelectedItem as ComboboxItem).Value.ToString();
                string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd"); ;

                try
                {
                    //Insert
                    this.nhanVienM.update(txtMaNV.Text, txtHoTen.Text, txtSDT.Text, maGioiTinh, ngaySinh, txtDanToc.Text, txtQueQuan.Text,
                    txtDiaChi.Text, txtCMND.Text, maPB, maCV, maTDHV, bacLuong, maHD);

                    ShowMessageBox.information("Cập nhật thông tin nhân viên có mã là " + txtMaNV.Text + " thành công", "Thông báo");

                    //Reset table NhanVien
                    loadTableNhanVien();
                    //reset all button function main
                    resetAllButton();
                    //clear
                    clearAllInput();

                    txtMaNV.Enabled = true;

                    //visible
                    btnSubUpdate.Visible = false;
                    btnCancelUpdate.Visible = false;
                }
                catch (InsertException insertEx)
                {
                    ShowMessageBox.erorr(insertEx.Message);
                }
                catch (Exception ex)
                {
                    ShowMessageBox.erorr(ex.Message);
                }
            }
            else
            {
                ShowMessageBox.erorr("ComboBox dữ liệu chưa được bạn chọn \nHoặc còn thiếu một số thông tin", "Lỗi");
            }
        }
    }
}
