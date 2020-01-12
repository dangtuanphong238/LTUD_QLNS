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
    public partial class frmHopDongLaoDong : Form
    {
        public frmHopDongLaoDong()
        {
            InitializeComponent();
        }

        //khởi tạo clsKetNoiDB
        clsKetNoiDB ketnoi = new clsKetNoiDB();
        
        //GET HOPDONGLAODONG
        public void getHopDongLaoDong()
        {
            dgvHDLD.DataSource = ketnoi.LayDSHopDong();
            dgvHDLD.Columns[0].HeaderText = "Mã Hợp Đồng";
            dgvHDLD.Columns[1].HeaderText = "Loại Hợp Đồng";
            dgvHDLD.Columns[2].HeaderText = "Từ Ngày";
            dgvHDLD.Columns[3].HeaderText = "Đến Ngày";
        }

        //form load event
        private void FrmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            getHopDongLaoDong();
        }

        //hàm thoát
        private void exit()
        {
            try
            {
                if (MessageBox.Show("Do you want exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        //button exit click event
        private void BtnExit_Click(object sender, EventArgs e)
        {
            exit();
        }

        //hàm dùng để hiện thị dữ liệu từ dgv lên control
        private void DgvHDLD_Click(object sender, EventArgs e)
        {
            //lay dòng vừa click
            int row = dgvHDLD.CurrentCell.RowIndex;
            txtMaHD.Text = dgvHDLD.Rows[row].Cells[0].Value.ToString();
            txtLoaiHD.Text = dgvHDLD.Rows[row].Cells[1].Value.ToString();
            dtStart.Text = dgvHDLD.Rows[row].Cells[2].Value.ToString();
            dtEnd.Text = dgvHDLD.Rows[row].Cells[3].Value.ToString();
        }

        //button search click event
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Length == 0)
            {
                getHopDongLaoDong();
            }
            else
            {
                dgvHDLD.DataSource = ketnoi.SelectHopDongByMaHD(txtMaHD.Text);
            }
        }

        //button add click event
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            //goi thuc thi
            try
            {
                if(txtMaHD.Text != string.Empty && txtLoaiHD.Text != string.Empty && dtStart.Text != string.Empty && dtEnd.Text != string.Empty)
                {
                    if (ketnoi.ThemHopDong(txtMaHD.Text, txtLoaiHD.Text, dtStart.Text, dtEnd.Text) == 1)
                    {
                        MessageBox.Show("Đã thêm thành công", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getHopDongLaoDong();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Hãy nhập đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }


        //button delete click event
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string maHD = txtMaHD.Text;
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (ketnoi.XoaHopDong(maHD) != 0)
                    {
                        MessageBox.Show("Xóa Thành Công", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getHopDongLaoDong();
                    }
                    else
                    {
                        MessageBox.Show("Xóa Không Thành Công", "Xóa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }

        //button update click event
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //goi thuc thi
            try
            {
                if (ketnoi.SuaHopDong(txtMaHD.Text, txtLoaiHD.Text, dtStart.Text, dtEnd.Text) == 1)
                {
                    MessageBox.Show("Đã sửa thành công", "Sửa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getHopDongLaoDong();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại", "Thêm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }
    }
}
