using Project.classSupport;
using Project.Exciption;
using Project.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class frmChucVu : Form
    {
        //Variable
        private handleDatabase connSV = new handleDatabase();
        private ChucVuModel chucVu = new ChucVuModel();
        private bool dangNhap = false;

        /*
        * ________ LOAD FORM ________
        */

        //Constructor
        public frmChucVu()
        {
            InitializeComponent();
        }

        //Load form NhanVien main
        private void frmChucVu_Load(object sender, EventArgs e)
        {
            try
            {
                loadTableChucVu();
            }
            catch (SelectException cvSeEx)
            {
                ShowMessageBox.erorr(cvSeEx.Message, "Lỗi nghiêm trọng");
                //Khoa tat cac nut function khi gap loi
                enbledAllBtnFunctuinMain();
            }
            catch (Exception ex)
            {
                ShowMessageBox.erorr(ex.Message, "Lỗi nghiêm trọng");
                //Khoa tat cac nut function khi gap loi
                enbledAllBtnFunctuinMain();
            }
        }

        //Load all table NhanVien
        private void loadTableChucVu()
        {
            dgvChucVu.DataSource = connSV.getTalbeChucVu();
            setNameColumsDataGirdView();
        }

        private int search(string maCV)
        {
            for (int i = 0; i < dgvChucVu.Rows.Count - 1; i++)
            {
                if (dgvChucVu.Rows[i].Cells[0].Value.ToString().Equals(maCV))
                {
                    return i;
                }
            }
            return -1;
        }


        /*
        * ________ FUNCTION CLEAR OR SUPPORT MORE ________
        */
        private void clearTxtInput()
        {
            txtMaCV.Text = "";
            txtTenCV.Text = "";
        }

        private void setTxtDefault()
        {
            txtMaCV.Text = "mã chức vụ...";
            txtTenCV.Text = "tên chức vụ...";
        }

        private void enbledAllBtnFunctuinMain()
        {
            btnSearch.Enabled = false;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnAdd.Enabled = false;
            dgvChucVu.Enabled = false;
        }

        private void restartAllBtnFunctuinMain()
        {
            //Turn on comeback
            txtMaCV.Enabled = false;
            txtTenCV.Enabled = false;
            btnAdd.Enabled = true;
            btnSearch.Enabled = true;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            dgvChucVu.Enabled = true;

            clearTxtInput();
        }

        private void setNameColumsDataGirdView()
        {
            dgvChucVu.Columns[0].HeaderText = "Mã";
            dgvChucVu.Columns[1].HeaderText = "Tên chức vụ";
        }

        /*
        * ________ FUNCTION CHECK ________
        */
        private bool isTxtEmpty()
        {
            if (txtMaCV.Text == string.Empty)
            {
                errorTxt.SetError(txtMaCV, "Dữ liệu còn thiếu");
                MessageBox.Show("Dữ liệu Mã Chức Vụ đang còn trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                errorTxt.Clear();
                if (txtTenCV.Text == string.Empty)
                {
                    errorTxt.SetError(txtTenCV, "Dữ liệu còn thiếu");
                    MessageBox.Show("Dữ liệu Tên Chức Vụ đang còn trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return true;
                }
                else
                {
                    errorTxt.Clear();
                }
            }
            return false;
        }



        /*
        * ________ EVENT TEXT CHANGED ________
        */
        private void txtMaCV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaCV.Text == string.Empty)
            {
                errorTxt.SetError(txtMaCV, "Dữ liệu còn thiếu");
            }
            else
            {
                errorTxt.Clear();
            }
        }

        private void txtTenCV_TextChanged(object sender, EventArgs e)
        {
            if (txtTenCV.Text == string.Empty)
            {
                errorTxt.SetError(txtTenCV, "Dữ liệu còn thiếu");
            }
            else
            {
                errorTxt.Clear();
            }
        }

        private void txtMaCVTim_TextChanged(object sender, EventArgs e)
        {
            this.AcceptButton = btnSearch;
        }



        /*
         * ________ EVENT CLICK ________
         */
        private void txtMaCVTim_Click(object sender, EventArgs e)
        {
            txtMaCVTim.Text = string.Empty;
            this.AcceptButton = btnSearch;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this.dangNhap)
            {
                DialogResult result = new DialogResult();

                result = MessageBox.Show(
                        "Bạn có muốn thoát khi dữ liệu chưa hoàn thành thao tác?",
                        "Thông báo",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );
                if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!isTxtEmpty())
            {
                this.dangNhap = true;
                txtTenCV.Enabled = true;
                btnUpdateSub.Visible = true;
                this.btnCancelAdd.Visible = true;

                //Enabled don't need
                txtTenCV.Enabled = true;
                enbledAllBtnFunctuinMain();

                this.AcceptButton = btnUpdateSub;
            }
            else
            {
                MessageBox.Show("Dữ liệu Mã Chức Vụ đang còn trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdateSub_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.connSV.updateChucVu(txtMaCV.Text, txtTenCV.Text) != 0)
                {
                    MessageBox.Show("Sửa thông tin thành công",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    //Tai thong tin moi len bang
                    loadTableChucVu();

                    this.dangNhap = false;
                    txtTenCV.Enabled = false;
                    btnUpdateSub.Visible = false;
                    this.btnCancelAdd.Visible = false;
                    restartAllBtnFunctuinMain();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin không thành công",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chương trình đang gặp lỗi \n" + ex.Message,
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMaCVTim.Text != string.Empty || txtMaCVTim.Text.Equals("nhập mã chức vụ tìm..."))
            {
                try
                {
                    DataRow CVSearch = this.chucVu.find(txtMaCVTim.Text);

                    if (CVSearch != null)
                    {
                        txtMaCV.Text = CVSearch[0].ToString();
                        txtTenCV.Text = CVSearch[1].ToString();
                        txtMaCVTim.Text = "nhập mã chức vụ tìm...";
                    }
                    else
                    {
                        ShowMessageBox.erorr("Không tìm thấy chức vụ có mã là " + txtMaCVTim.Text, "Thông báo");
                        txtMaCVTim.Focus();
                    }
                }
                catch (Exception ex)
                {
                    ShowMessageBox.erorr(ex.Message, "Lỗi");
                }
            }
            else
            {
                errorTxt.SetError(txtMaCVTim, "Chưa nhập dữ liệu để tìm");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Remove btnAdd and after that add btnCancelAdd
            this.btnCancelAdd.Visible = true;
            this.btnAddSub.Visible = true;
            setTxtDefault();

            //Xac nhan dang nhap thong tin de neu co dong form thi se hoi nguoi dung xac nhan 
            this.dangNhap = true;

            //Enabled don't need
            txtMaCV.Enabled = true;
            txtTenCV.Enabled = true;
            enbledAllBtnFunctuinMain();

            this.AcceptButton = btnAddSub;

            txtMaCV.Focus();
        }

        private void btnCancelAdd_Click(object sender, EventArgs e)
        {
            //Remove btnCancelAdd and after that add btnAdd
            this.btnCancelAdd.Visible = false;
            this.btnAddSub.Visible = false;
            this.btnUpdateSub.Visible = false;

            this.dangNhap = false;

            //Turn on comeback
            restartAllBtnFunctuinMain();
        }

        private void btnAddSub_Click(object sender, EventArgs e)
        {
            try
            {
                this.chucVu.insert(this.txtMaCV.Text, this.txtTenCV.Text);
                ShowMessageBox.information("Thêm thành công");
                loadTableChucVu();//Load lai bang chuc vu
            }
            catch (InsertException CVEx)
            {
                ShowMessageBox.erorr(CVEx.Message, "Lỗi");
            }
            catch (Exception ex)
            {
                ShowMessageBox.erorr(ex.Message, "Lỗi");
            }

            //Reload table ChucVu
            loadTableChucVu();

            //Remove btnCancelAdd and after that add btnAdd
            this.btnCancelAdd.Visible = false;
            this.btnAddSub.Visible = false;
            //Turn on comeback
            restartAllBtnFunctuinMain();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!isTxtEmpty())
            {

                DialogResult result = new DialogResult();

                result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xoá Chức Vụ " + txtTenCV.Text + " không?",
                    "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        //Thuc thu xoa chuc vu
                        this.chucVu.delete(txtMaCV.Text);

                        //reload table chuc vu
                        loadTableChucVu();
                        ShowMessageBox.information("Xoá thành công");

                        clearTxtInput();
                    }
                    catch (DeleteException cvDelEx)
                    {
                        ShowMessageBox.erorr(cvDelEx.Message);
                    }
                    catch (Exception ex)
                    {
                        ShowMessageBox.erorr(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Dữ liệu Mã Chức Vụ đang còn trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvChucVu_Click(object sender, EventArgs e)
        {
            int r = dgvChucVu.CurrentCell.RowIndex;

            txtMaCV.Text = dgvChucVu.Rows[r].Cells[0].Value.ToString();
            txtTenCV.Text = dgvChucVu.Rows[r].Cells[1].Value.ToString();
        }
    }
}
