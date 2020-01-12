using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Project
{
    public partial class frmTDHV : Form
    {
        public frmTDHV()
        {
            InitializeComponent();
        }

        public SqlConnection getConnection() {
            handleDatabase handleDatabase = new handleDatabase();
            SqlConnection cnn = handleDatabase.getSqlConnection();
            return cnn;
        }

        public void getTDHV() {
            SqlConnection cnn = getConnection();
            DataTable dtTDHV = new DataTable();
            SqlCommand cmdTDHV = new SqlCommand("sp_SelectAllTrinhDoHocVan", cnn);
            SqlDataAdapter daTDHV = new SqlDataAdapter(cmdTDHV);
            daTDHV.Fill(dtTDHV);
            dgvTDHV.DataSource = dtTDHV;
            dgvTDHV.Columns[0].HeaderText = "Mã TDHV";
            dgvTDHV.Columns[1].HeaderText = "Tên TDHV";
            dgvTDHV.Columns[2].HeaderText = "Chuyên nghành";
            cnn.Close();
        }

        public int ThemTDHV(string maTDHV, string tenTDHV, string cNganh) {
            SqlConnection cnn = getConnection();
            int status = 0;
            try
            {
                SqlCommand cmdThem = new SqlCommand("sp_InsertTrinhDoHocVan", cnn);
                cmdThem.CommandText = "sp_InsertTrinhDoHocVan";
                cmdThem.CommandType = CommandType.StoredProcedure;
                cmdThem.Parameters.Add(new SqlParameter("@maTDHV", maTDHV));
                cmdThem.Parameters.Add(new SqlParameter("@tenTDHV", tenTDHV));
                cmdThem.Parameters.Add(new SqlParameter("@cNganh", cNganh));
                if (cmdThem.ExecuteNonQuery() != 0)
                {
                    status = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                cnn.Close();
            }
            return status;
        }

        public int XoaTDHV(string maTDHV) {
            SqlConnection cnn = getConnection();
            int status = 0;
            try
            {
                SqlCommand cmdThem = new SqlCommand("sp_DeleteTrinhDoHocVan", cnn);
                cmdThem.CommandText = "sp_DeleteTrinhDoHocVan";
                cmdThem.CommandType = CommandType.StoredProcedure;
                cmdThem.Parameters.Add(new SqlParameter("@maTDHV", maTDHV));
                if (cmdThem.ExecuteNonQuery() != 0)
                {
                    status = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnn.Close();
            }
            return status;
        }

        public int suaTDHV(string maTDHV, string tenTDHV, string cNganh)
        {
            SqlConnection cnn = getConnection();
           
            int status = 0;
            try
            {
                SqlCommand cmdThem = new SqlCommand("sp_UpdateTrinhDoHocVan", cnn);
                cmdThem.CommandText = "sp_UpdateTrinhDoHocVan";
                cmdThem.CommandType = CommandType.StoredProcedure;
                cmdThem.Parameters.Add(new SqlParameter("@maTDHV", maTDHV));
                cmdThem.Parameters.Add(new SqlParameter("@tenTDHV", tenTDHV));
                cmdThem.Parameters.Add(new SqlParameter("@cNganh", cNganh));
                if (cmdThem.ExecuteNonQuery() != 0)
                {
                    status = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cnn.Close();
            }
            return status;
        }

        public void timTDHVTheoMa(string maTDHV) {
            try
            {
                SqlConnection cnn = getConnection();
               
                DataTable dtTim = new DataTable();
                SqlCommand cmdTim = new SqlCommand("sp_SelectTrinhDoHocVanByMaTDHV", cnn);
                cmdTim.CommandType = CommandType.StoredProcedure;
                cmdTim.Parameters.Add(new SqlParameter("@maTDHV", maTDHV));
                SqlDataAdapter daTim = new SqlDataAdapter(cmdTim);
                daTim.Fill(dtTim);
                dgvTDHV.DataSource = dtTim;
                dgvTDHV.Columns[0].HeaderText = "Mã TDHV";
                dgvTDHV.Columns[1].HeaderText = "Tên TDHV";
                dgvTDHV.Columns[2].HeaderText = "Chuyên nghành";
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmTDHV_Load(object sender, EventArgs e)
        {
            getTDHV();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTDHV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = new DialogResult();
            result = MessageBox.Show(
                "Bạn có muốn thoát chương trình?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void dgvTDHV_Click(object sender, EventArgs e)
        {
            int row = dgvTDHV.CurrentCell.RowIndex;
            txtMaTDHV.Text = dgvTDHV.Rows[row].Cells[0].Value.ToString();
            txtTenTDHV.Text = dgvTDHV.Rows[row].Cells[1].Value.ToString();
            txtChuyenNghanh.Text = dgvTDHV.Rows[row].Cells[2].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           if(txtMaTDHV.Text == string.Empty)
            {
                MessageBox.Show("Chưa nhập mã trình đồ học vấn");
            }
            else
            {
                if (txtTenTDHV.Text == string.Empty)
                {
                    MessageBox.Show("Chưa nhập tên trình đồ học vấn");
                }
                else
                {
                    if(txtChuyenNghanh.Text == string.Empty)
                    {
                        MessageBox.Show("Chưa nhập chuyên ngành của trình đồ học vấn");
                    }
                    else
                    {
                        if (ThemTDHV(txtMaTDHV.Text, txtTenTDHV.Text, txtChuyenNghanh.Text) != 0)
                        {
                            MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            getTDHV();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XoaTDHV(txtMaTDHV.Text) != 0)
            {
                MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getTDHV();
            }
            else
            {
                MessageBox.Show("Xóa thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (suaTDHV(txtMaTDHV.Text, txtTenTDHV.Text, txtChuyenNghanh.Text) != 0)
            {
                MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getTDHV();
            }
            else
            {
                MessageBox.Show("Sửa thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMaTDHV.Text.Length == 0)
            {
                getTDHV();
            }
            else
            {
                timTDHVTheoMa(txtMaTDHV.Text);
            }
        }

    }
}
