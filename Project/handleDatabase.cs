using Project.classSupport;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class handleDatabase
    {
        //Variable
        readonly SqlConnection connSV = new SqlConnection();
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();

        /// <summary>
        /// Constructor 
        /// Connect Database and open this
        /// </summary>
        public handleDatabase()
        {
            this.connSV.ConnectionString = "Data Source=.;Initial Catalog=QLNS;Integrated Security=True";
            this.connSV.Open();
        }

        /// <summary>
        /// Kiem tra bien connSV da co ket noi hay chua. Neu chua thi tien hang ket noi vao mo
        /// </summary>
        public void setConnSVOpen()
        {
            if (this.connSV.State != ConnectionState.Open)
            {
                this.connSV.Open();
            }
        }


        /*
         *  _____ GET ____
         */
         public SqlConnection getSqlConnection()
        {
            setConnSVOpen();
            return this.connSV;
        }


        /*
         * _______________ FUNTION NHAN VIEN _______________
         */

        /// <summary>
        /// Lay tat ca du lieu co trong bang NHANVIEN
        /// </summary> 
        public DataTable getTableNhanVien()
        {

            setConnSVOpen();
            DataTable dataTable = new DataTable();
            this.cmd = new SqlCommand(@"[dbo].[sp_SelectAllNhanVien]", connSV);
            this.dataAdapter = new SqlDataAdapter(this.cmd);
            this.dataAdapter.Fill(dataTable);

            this.connSV.Close();
            return dataTable;
        }


        /// <summary>
        /// Lay tat ca du lieu co trong bang NhanVien
        /// </summary>
        public DataRow findNhanVien(string MaNhanVien)
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();

            string query = string.Format(@"[dbo].[sp_SelectNhanVienByMaNV] '{0}'", MaNhanVien);
            this.cmd = new SqlCommand(query, connSV);
            this.dataAdapter = new SqlDataAdapter(this.cmd);
            this.dataAdapter.Fill(dataTable);
            this.connSV.Close();

            if (dataTable.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return dataTable.Rows[0];
            }
        }

        /// <summary>
        /// Them du lieu vao trong bang Chuc Vu
        /// </summary>
        /// <param name="MaCV">Ma chuc vu them</param>
        /// <param name="tenCV">Ten chuc vu them</param>
        /// <returns> int </returns>
        public int insertNhanVien(string MaNV, string tenNV, string sdt, int gioiTinh, string ngaySinh, string danToc, string queQuan, string diaChi,
            string cmnd, string maPB, string maCV, string maTDHV, int bacLuong, string maHD)
        {
            int result = 0;
            setConnSVOpen();

            this.cmd = new SqlCommand("sp_InsertNhanVien", connSV);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@MaNV", MaNV);
            this.cmd.Parameters.AddWithValue("@TenNV", tenNV);
            this.cmd.Parameters.AddWithValue("@SDT", sdt);
            this.cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
            this.cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
            this.cmd.Parameters.AddWithValue("@danToc", danToc);
            this.cmd.Parameters.AddWithValue("@queQuan", queQuan);
            this.cmd.Parameters.AddWithValue("@diaChi", diaChi);
            this.cmd.Parameters.AddWithValue("@CMND", cmnd);
            this.cmd.Parameters.AddWithValue("@maPB", maPB);
            this.cmd.Parameters.AddWithValue("@maCV", maCV);
            this.cmd.Parameters.AddWithValue("@maTDHV", maTDHV);
            this.cmd.Parameters.AddWithValue("@bacLuong", bacLuong);
            this.cmd.Parameters.AddWithValue("@maHD", maHD);

            //Exec query
            result = this.cmd.ExecuteNonQuery();
            this.connSV.Close();
            return result;
        }

        /// <summary>
        /// Xoa thong tin tin 1 nhan vien voi ma nhan vien truyen vao
        /// </summary>
        /// <param name="maNV">Ma chu vu muon xoa</param>
        /// <returns> int </returns>
        public int deleteNhanVien(string maNV)
        {
            int result = 0;
            setConnSVOpen();

            this.cmd = new SqlCommand("sp_DeleteNhanVien", this.connSV);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@maNV", maNV);

            //Exec query
            result = this.cmd.ExecuteNonQuery();
            this.connSV.Close();
            return result;
        }

        /// <summary>
        /// Them du lieu vao trong bang Chuc Vu
        /// </summary>
        /// <param name="MaCV">Ma chuc vu them</param>
        /// <param name="tenCV">Ten chuc vu them</param>
        /// <returns> int </returns>
        public int updateNhanVien(string MaNV, string tenNV, string sdt, int gioiTinh, string ngaySinh, string danToc, string queQuan, string diaChi,
            string cmnd, string maPB, string maCV, string maTDHV, int bacLuong, string maHD)
        {
            int result = 0;
            setConnSVOpen();

            this.cmd = new SqlCommand("sp_UpdateNhanVien", connSV);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@MaNV", MaNV);
            this.cmd.Parameters.AddWithValue("@TenNV", tenNV);
            this.cmd.Parameters.AddWithValue("@SDT", sdt);
            this.cmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
            this.cmd.Parameters.AddWithValue("@ngaySinh", ngaySinh);
            this.cmd.Parameters.AddWithValue("@danToc", danToc);
            this.cmd.Parameters.AddWithValue("@queQuan", queQuan);
            this.cmd.Parameters.AddWithValue("@diaChi", diaChi);
            this.cmd.Parameters.AddWithValue("@CMND", cmnd);
            this.cmd.Parameters.AddWithValue("@maPB", maPB);
            this.cmd.Parameters.AddWithValue("@maCV", maCV);
            this.cmd.Parameters.AddWithValue("@maTDHV", maTDHV);
            this.cmd.Parameters.AddWithValue("@bacLuong", bacLuong);
            this.cmd.Parameters.AddWithValue("@maHD", maHD);

            //Exec query
            result = this.cmd.ExecuteNonQuery();
            this.connSV.Close();
            return result;
        }


        /*
         * _______________ FUNTION CHUC V   U _______________
         */

        /// <summary>
        /// Lay tat ca du lieu co trong bang Chuc Vu
        /// </summary>
        public DataTable getTalbeChucVu()
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();
            this.cmd = new SqlCommand(@"sp_SelectAllChucVu", connSV);
            this.dataAdapter = new SqlDataAdapter(this.cmd);

            this.dataAdapter.Fill(dataTable);
            this.connSV.Close();
            return dataTable;
        }

        /// <summary>
        /// Them du lieu vao trong bang Chuc Vu
        /// </summary>
        /// <param name="MaCV">Ma chuc vu them</param>
        /// <param name="tenCV">Ten chuc vu them</param>
        /// <returns> int </returns>
        public int insertChucVu(string MaCV, string tenCV)
        {
            int result = 0;
            setConnSVOpen();

            this.cmd = new SqlCommand("sp_InsertChucVu", connSV);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@MaCV", MaCV);
            this.cmd.Parameters.AddWithValue("@TenCV", tenCV);

            //Exec query
            result = this.cmd.ExecuteNonQuery();
            this.connSV.Close();
            return result;
        }

        /// <summary>
        /// Xoa cua vu voi MaCV
        /// </summary>
        /// <param name="MaCV">Ma chu vu muon xoa</param>
        /// <returns> int </returns>
        public int deleteChucVu(string MaCV)
        {
            int result = 0;
            setConnSVOpen();

            this.cmd = new SqlCommand("sp_DeleteChucVu", this.connSV);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@maCV", MaCV);

            //Exec query
            result = this.cmd.ExecuteNonQuery();
            this.connSV.Close();
            return result;
        }

        /// <summary>
        /// Cap nhat thong tin Chuc vu voi MaCV
        /// </summary>
        /// <param name="MaCV"></param>
        /// <param name="tenCV"></param>
        /// <returns></returns>
        public int updateChucVu(string MaCV, string tenCV)
        {

            int result = 0;
            setConnSVOpen();

            this.cmd = new SqlCommand("sp_UpdateChucVu", connSV);
            this.cmd.CommandType = CommandType.StoredProcedure;
            this.cmd.Parameters.AddWithValue("@MaCV", MaCV);
            this.cmd.Parameters.AddWithValue("@TenCV", tenCV);

            //Exec query
            result = this.cmd.ExecuteNonQuery();
            this.connSV.Close();
            return result;

        }

        /// <summary>
        /// Lay tat ca du lieu co trong bang Chuc Vu
        /// </summary>
        public DataRow findChucVu(string MaCV)
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();

            string query = string.Format(@"sp_SelectChucVuByMaCV '{0}'", MaCV);
            this.cmd = new SqlCommand(query, connSV);
            this.dataAdapter = new SqlDataAdapter(this.cmd);
            this.dataAdapter.Fill(dataTable);
            this.connSV.Close();

            if (dataTable.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return dataTable.Rows[0];
            }
        }



        /*
         * _______________ FUNTION PHONG BAN _______________
         */
        /// <summary>
        /// Lay tat ca du lieu co trong bang NHANVIEN
        /// </summary> 
        public DataTable getTalbePhongBan()
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();
            this.cmd = new SqlCommand(@"sp_SelectAllPhongBan", connSV);
            this.dataAdapter = new SqlDataAdapter(this.cmd);

            this.dataAdapter.Fill(dataTable);
            this.connSV.Close();
            return dataTable;
        }






        /*
         * _______________ FUNTION TRINH DO HOC VAN _______________
         */
        /// <summary>
        /// Lay tat ca du lieu co trong bang NHANVIEN
        /// </summary> 
        public DataTable getTalbeTrinhDoHocVan()
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();
            this.cmd = new SqlCommand(@"sp_SelectAllTrinhDoHocVan", connSV);
            this.dataAdapter = new SqlDataAdapter(this.cmd);

            this.dataAdapter.Fill(dataTable);
            this.connSV.Close();
            return dataTable;
        }






        /*
         * _______________ FUNTION HOP DONG _______________
         */
        /// <summary>
        /// Lay tat ca du lieu co trong bang NHANVIEN
        /// </summary> 
        public DataTable getTalbeHopDong()
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();
            this.cmd = new SqlCommand(@"sp_SelectAllHopDongLaoDong", connSV);
            this.dataAdapter = new SqlDataAdapter(this.cmd);

            this.dataAdapter.Fill(dataTable);
            this.connSV.Close();
            return dataTable;
        }



        /*
        * _______________ FUNTION LUONG _______________
        */
        /// <summary>
        /// Lay tat ca du lieu co trong bang NHANVIEN
        /// </summary> 
        public DataTable getTalbeLuong()
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();
            this.cmd = new SqlCommand(@"sp_SelectAllLuong", connSV);
            this.dataAdapter = new SqlDataAdapter(this.cmd);

            this.dataAdapter.Fill(dataTable);
            this.connSV.Close();
            return dataTable;
        }




        /*
        * _______________ FUNTION ADMIN _______________
        */
        /// <summary>
        /// Lay tat ca du lieu co trong bang NHANVIEN
        /// </summary> 
        public DataRow findAdmin(string maNV)
        {
            setConnSVOpen();
            DataTable dataTable = new DataTable();

            string query = string.Format(@"[dbo].[sp_SelectTaiKhoanByMaNV] '{0}'", maNV);
            this.cmd = new SqlCommand(query, connSV);
            this.dataAdapter = new SqlDataAdapter(this.cmd);
            this.dataAdapter.Fill(dataTable);
            this.connSV.Close();

            if (dataTable.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return dataTable.Rows[0];
            }
        }
    }
}
