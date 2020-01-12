using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    class clsKetNoiDB
    {
        //KHỞI TẠO ư
        handleDatabase handleDatabase = new handleDatabase();
        SqlConnection conn;

        //CONSTRUCTOR
        public clsKetNoiDB()
        {
            try
            {
                this.conn = this.handleDatabase.getSqlConnection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi " + ex.Message);
            }
        }

        //SET DATA TO COMBOBOX
        public void setComboboxData(String spName, ComboBox cb, String sValue)
        {
            this.conn = this.handleDatabase.getSqlConnection();
            try
            {
                DataTable DT = new DataTable();
                SqlCommand cmd = new SqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter SA = new SqlDataAdapter(cmd);
                SA.Fill(DT);
                cb.DataSource = DT;
                cb.ValueMember = sValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //I.PHONGBAN
        //SELECT ALL ROW OF TABLE PHONGBAN
        public DataTable LayDSPhongBan()
        {
            this.conn = this.handleDatabase.getSqlConnection();
            DataTable dtPhongBan = new DataTable();
            string spName = "[dbo].[sp_SelectAllPhongBan]";
            SqlCommand cmdPhongBan = new SqlCommand(spName, conn);
            cmdPhongBan.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daPhongBan = new SqlDataAdapter(cmdPhongBan);
            daPhongBan.Fill(dtPhongBan);
            return dtPhongBan;

        }

        //SelectPhongBanByMaPB
        public DataTable SelectPhongBanByMaPB(string maPB)
        {
            this.conn = this.handleDatabase.getSqlConnection();
            DataTable dtPhongBan = new DataTable();
            string spName = "[dbo].[sp_SelectPhongBanByMaPB]";
            SqlCommand cmdTim = new SqlCommand(spName, conn);
            cmdTim.CommandType = CommandType.StoredProcedure;
            cmdTim.Parameters.Add(new SqlParameter("@maPB", maPB));
            SqlDataAdapter daPhongBan = new SqlDataAdapter(cmdTim);
            daPhongBan.Fill(dtPhongBan);
            return dtPhongBan;
        }

        //ADD FUNCTION
        public int ThemPhongBan(string maPB, string tenPB, string diaChi, string maTP)
        {
            this.conn = this.handleDatabase.getSqlConnection();
            string spName = "[dbo].[sp_InsertPhongBan]";
            SqlCommand cmdThem = new SqlCommand(spName, conn);
            cmdThem.CommandText = spName;
            cmdThem.CommandType = CommandType.StoredProcedure;
            cmdThem.Parameters.Add(new SqlParameter("@maPB", maPB));
            cmdThem.Parameters.Add(new SqlParameter("@tenPB", tenPB));
            cmdThem.Parameters.Add(new SqlParameter("@diaChi", diaChi));
            cmdThem.Parameters.Add(new SqlParameter("@maTrgPhong", maTP));
            if (cmdThem.ExecuteNonQuery() != 0)
            {
                conn.Close();
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }

        //DELETE FUNCTION
        public int XoaPhongBan(string maPB)
        {
            this.conn = this.handleDatabase.getSqlConnection();
            string spName = "[dbo].[sp_DeletePhongBan]";
            SqlCommand cmdXoa = new SqlCommand(spName, conn);
            cmdXoa.CommandText = spName;
            cmdXoa.CommandType = CommandType.StoredProcedure;
            cmdXoa.Parameters.Add(new SqlParameter("@maPB", maPB));
            if (cmdXoa.ExecuteNonQuery() != 0)
            {
                conn.Close();
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }

        //UPDATE FUNCTION
        public int SuaPhongBan(string maPB, string tenPB, string diaChi, string maTP)
        {
            this.conn = this.handleDatabase.getSqlConnection();
            string spName = "[dbo].[sp_UpdatePhongBan]";
            SqlCommand cmdSua = new SqlCommand(spName, conn);
            cmdSua.CommandText = spName;
            cmdSua.CommandType = CommandType.StoredProcedure;
            cmdSua.Parameters.Add(new SqlParameter("@maPB", maPB));
            cmdSua.Parameters.Add(new SqlParameter("@tenPB", tenPB));
            cmdSua.Parameters.Add(new SqlParameter("@diaChi", diaChi));
            cmdSua.Parameters.Add(new SqlParameter("@maTrgPhong", maTP));
            if (cmdSua.ExecuteNonQuery() != 0)
            {
                conn.Close();
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }

        //II.HOPDONGLAODONG
        //SELECT ALL ROW OF TABLE HOPDONGLAODONG
        public DataTable LayDSHopDong()
        {
            this.conn = this.handleDatabase.getSqlConnection();
            DataTable dtHopDong = new DataTable();
            string spName = "[dbo].[sp_SelectAllHopDongLaoDong]";
            SqlCommand cmdHopDong = new SqlCommand(spName, conn);
            cmdHopDong.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daPhongBan = new SqlDataAdapter(cmdHopDong);
            daPhongBan.Fill(dtHopDong);
            return dtHopDong;
        }

        //SelectHopDongByMaHD
        public DataTable SelectHopDongByMaHD(string maHD)
        {
            this.conn = this.handleDatabase.getSqlConnection();
            DataTable dtHopDong = new DataTable();
            string spName = "[dbo].[sp_SelectHopDongLaoDongByMaHD]";
            SqlCommand cmdTim = new SqlCommand(spName, conn);
            cmdTim.CommandType = CommandType.StoredProcedure;
            cmdTim.Parameters.Add(new SqlParameter("@maHD", maHD));
            SqlDataAdapter daHopDong = new SqlDataAdapter(cmdTim);
            daHopDong.Fill(dtHopDong);
            return dtHopDong;
        }

        //ADD ThemHopDong FUNCTION
        public int ThemHopDong(string maHD, string loaiHD, string tuNgay, string denNgay)
        {
            this.conn = this.handleDatabase.getSqlConnection();
            string spName = "[dbo].[sp_InsertHopDongLaoDong]";
            SqlCommand cmdThem = new SqlCommand(spName, conn);
            cmdThem.CommandText = spName;
            cmdThem.CommandType = CommandType.StoredProcedure;
            cmdThem.Parameters.Add(new SqlParameter("@maHD", maHD));
            cmdThem.Parameters.Add(new SqlParameter("@loaiHD", loaiHD));
            cmdThem.Parameters.Add(new SqlParameter("@tuNgay", tuNgay));
            cmdThem.Parameters.Add(new SqlParameter("@denNgay", denNgay));
            if (cmdThem.ExecuteNonQuery() != 0)
            {
                conn.Close();
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }

        //DELETE XoaHopDong FUNCTION
        public int XoaHopDong(string maHD)
        {
            this.conn = this.handleDatabase.getSqlConnection();
            string spName = "[dbo].[sp_DeleteHopDongLaoDong]";
            SqlCommand cmdXoa = new SqlCommand(spName, conn);
            cmdXoa.CommandText = spName;
            cmdXoa.CommandType = CommandType.StoredProcedure;
            cmdXoa.Parameters.Add(new SqlParameter("@maHD", maHD));
            if (cmdXoa.ExecuteNonQuery() != 0)
            {
                conn.Close();
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }

        //UPDATE SuaHopDong FUNCTION
        public int SuaHopDong(string maHD, string loaiHD, string tuNgay, string denNgay)
        {
            this.conn = this.handleDatabase.getSqlConnection();
            string spName = "[dbo].[sp_UpdateHopDongLaoDong]";
            SqlCommand cmdSua = new SqlCommand(spName, conn);
            cmdSua.CommandText = spName;
            cmdSua.CommandType = CommandType.StoredProcedure;
            cmdSua.Parameters.Add(new SqlParameter("@maHD", maHD));
            cmdSua.Parameters.Add(new SqlParameter("@loaiHD", loaiHD));
            cmdSua.Parameters.Add(new SqlParameter("@tuNgay", tuNgay));
            cmdSua.Parameters.Add(new SqlParameter("@denNgay", denNgay));
            if (cmdSua.ExecuteNonQuery() != 0)
            {
                conn.Close();
                return 1;
            }
            else
            {
                conn.Close();
                return 0;
            }
        }


    }
}
