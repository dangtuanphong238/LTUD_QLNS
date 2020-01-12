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
    public partial class frmLuong : Form
    {
        public frmLuong()
        {
            InitializeComponent();
        }

        public SqlConnection getConnection()
        {
            handleDatabase handleDatabase = new handleDatabase();
            SqlConnection cnn = handleDatabase.getSqlConnection();
            return cnn;
        }

        public bool isEmptyTxt()
        {
            string notification = string.Empty;
            if (this.txtBacLuong.Text.Equals(string.Empty))
            {
                notification = "Bậc lương";
            }
            else
            {
                if (this.txtHSLuong.Text.Equals(string.Empty))
                {
                    notification = "Hệ số lương";
                }
                else
                {
                    if (txtHSPhuCap.Text.Equals(string.Empty))
                    {
                        notification = "Hệ số phụ cấp";
                    }
                    else
                    {
                        if (txtLuongCB.Text.Equals(string.Empty))
                        {
                            notification = "Lương cơ bản";
                        }
                    }
                }
            }

            if (notification.Equals(string.Empty))
            {
                return false;
            }
            else
            {
                MessageBox.Show("Thông tin của " + notification + " bạn chưa nhập\n Vui lòng nhập đẩy đủ thông tin");
                return false;
            }
        }

        public void getLuong()
        {
            SqlConnection cnn = getConnection();
            DataTable dtLuong = new DataTable();
            SqlCommand cmdLuong = new SqlCommand("[dbo].[sp_SelectAllLuong]", cnn);
            SqlDataAdapter daLuong = new SqlDataAdapter(cmdLuong);
            daLuong.Fill(dtLuong);
            dgvLuong.DataSource = dtLuong;
            dgvLuong.Columns[0].HeaderText = "Bậc lương";
            dgvLuong.Columns[1].HeaderText = "Lương Cơ bản";
            dgvLuong.Columns[2].HeaderText = "Hệ số Lương";
            dgvLuong.Columns[3].HeaderText = "Hệ số Phụ cấp";
            cnn.Close();
        }

        public int ThemLuong(int bacLuong, int luongCB, int hsLuong, int hsPhuCap)
        {
            SqlConnection cnn = getConnection();
            SqlCommand cmdThem = new SqlCommand("sp_InsertLuong", cnn);
            cmdThem.CommandText = "sp_InsertLuong";
            cmdThem.CommandType = CommandType.StoredProcedure;
            cmdThem.Parameters.Add(new SqlParameter("@batluong", bacLuong));
            cmdThem.Parameters.Add(new SqlParameter("@luongCB", luongCB));
            cmdThem.Parameters.Add(new SqlParameter("@HSLuong", hsLuong));
            cmdThem.Parameters.Add(new SqlParameter("@HSPhuCap", hsPhuCap));
            if (cmdThem.ExecuteNonQuery() != 0)
            {
                cnn.Close();
                return 1;
            }
            else
            {
                cnn.Close();
                return 0;
            }
        }

        public int XoaLuong(int bacLuong)
        {
            SqlConnection cnn = getConnection();
            SqlCommand cmdXoa = new SqlCommand("sp_DeleteLuong", cnn);
            cmdXoa.CommandText = "sp_DeleteLuong";
            cmdXoa.CommandType = CommandType.StoredProcedure;
            cmdXoa.Parameters.Add(new SqlParameter("@bacLuong", bacLuong));
            if (cmdXoa.ExecuteNonQuery() != 0)
            {
                cnn.Close();
                return 1;
            }
            else
            {
                cnn.Close();
                return 0;
            }
        }

        public int SuaLuong(int bacLuong, int luongCB, int hsLuong, int hsPhuCap)
        {
            SqlConnection cnn = getConnection();
            SqlCommand cmdSua = new SqlCommand("sp_UpdateLuong", cnn);
            cmdSua.CommandText = "sp_UpdateLuong";
            cmdSua.CommandType = CommandType.StoredProcedure;
            cmdSua.Parameters.Add(new SqlParameter("@batluong", bacLuong));
            cmdSua.Parameters.Add(new SqlParameter("@luongCB", luongCB));
            cmdSua.Parameters.Add(new SqlParameter("@HSLuong", hsLuong));
            cmdSua.Parameters.Add(new SqlParameter("@HSPhuCap", hsPhuCap));
            if (cmdSua.ExecuteNonQuery() != 0)
            {
                cnn.Close();
                return 1;
            }
            else
            {
                cnn.Close();
                return 0;
            }
        }

        public void timLuongTheoBacLuong(int bacLuong)
        {
            SqlConnection cnn = getConnection();
            DataTable dtTim = new DataTable();
            SqlCommand cmdTim = new SqlCommand("sp_SelectLuongByBacLuong", cnn);
            cmdTim.CommandType = CommandType.StoredProcedure;
            cmdTim.Parameters.Add(new SqlParameter("@bacLuong", bacLuong));
            SqlDataAdapter daTim = new SqlDataAdapter(cmdTim);
            daTim.Fill(dtTim);
            dgvLuong.DataSource = dtTim;
            dgvLuong.Columns[0].HeaderText = "Bậc lương";
            dgvLuong.Columns[1].HeaderText = "Lương Cơ bản";
            dgvLuong.Columns[2].HeaderText = "Hệ số Lương";
            dgvLuong.Columns[3].HeaderText = "Hệ số Phụ cấp";
            cnn.Close();
        }

        private void frmLuong_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvLuong_Click(object sender, EventArgs e)
        {
            int row = dgvLuong.CurrentCell.RowIndex;
            txtBacLuong.Text = dgvLuong.Rows[row].Cells[0].Value.ToString();
            txtLuongCB.Text = dgvLuong.Rows[row].Cells[1].Value.ToString();
            txtHSLuong.Text = dgvLuong.Rows[row].Cells[2].Value.ToString();
            txtHSPhuCap.Text = dgvLuong.Rows[row].Cells[3].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!isEmptyTxt())
            {
                int bacLuong = int.Parse(txtBacLuong.Text);
                int luongCB = int.Parse(txtLuongCB.Text);
                int hsLuong = int.Parse(txtHSLuong.Text);
                int hsPhuCap = int.Parse(txtHSPhuCap.Text);
                if (ThemLuong(bacLuong, luongCB, hsLuong, hsPhuCap) != 0)
                {
                    MessageBox.Show("Thêm thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getLuong();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!isEmptyTxt())
            {
                int bacLuong = int.Parse(txtBacLuong.Text);
                if (XoaLuong(bacLuong) != 0)
                {
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getLuong();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!isEmptyTxt())
            {
                int bacLuong = int.Parse(txtBacLuong.Text);
                int luongCB = int.Parse(txtLuongCB.Text);
                int hsLuong = int.Parse(txtHSLuong.Text);
                int hsPhuCap = int.Parse(txtHSPhuCap.Text);
                if (SuaLuong(bacLuong, luongCB, hsLuong, hsPhuCap) != 0)
                {
                    MessageBox.Show("Sửa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getLuong();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtBacLuong.Text.Length == 0)
            {
                getLuong();
            }
            else
            {
                if (txtBacLuong.Text.Equals(string.Empty))
                {
                    MessageBox.Show("Thông tin bậc lương bạn muốn tìm còn trống");
                }
                else
                {
                    try
                    {
                        int bacLuong = int.Parse(txtBacLuong.Text);
                        timLuongTheoBacLuong(bacLuong);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            getLuong();
        }
    }
}
