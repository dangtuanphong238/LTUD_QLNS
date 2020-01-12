using Project.Exciption;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.model
{
    class NhanVienModel
    {
        //Variable
        private handleDatabase connSV = new handleDatabase();

        /*
         *  _________ METHOD _______
         */
        /// <summary>
        /// Lay tat ca thong tin o bang Chuc Vu
        /// </summary>
        /// <returns></returns>
        public DataTable getAllTable()
        {
            DataTable dtResult = this.connSV.getTableNhanVien();
            if (dtResult != null)
            {
                return dtResult;
            }
            else
            {
                throw new SelectException("Lỗi try cập dữ liệu đến bảng Nhân Viên");
            }
        }

        /// <summary>
        /// Tim chuc vu voi ma chuc vu truyen vao
        /// </summary>
        /// <param name="MaCV"> Ma chuc vu muon tim </param>
        /// <returns> DataRow </returns>
        public DataRow find(string ma)
        {
            DataRow drResult = this.connSV.findNhanVien(ma);
            if (drResult == null)
            {
                throw new FindException("Không tìm thấy nhân viên với mã là " + ma);
            }
            else
            {
                return drResult;
            }
        }

        /// <summary>
        /// Them thong tin cua 1 nhan vien moi vao trong du lieu
        /// </summary>
        /// <param name="MaNV"> Ma nhan vien </param>
        /// <param name="tenNV"> Ten Nhan Vien</param>
        /// <param name="sdt">So dien thoai Nhan Vien</param>
        /// <param name="gioiTinh"> Gioi tinh  
        /// <param name="maHD">ma hop dong lao dong</param>
        public void insert(string MaNV, string tenNV, string sdt, int gioiTinh, string ngaySinh, string danToc, string queQuan, string diaChi,
            string cmnd, string maPB, string maCV, string maTDHV, int bacLuong, string maHD)
        {
            //Kiem tra ma chuc vu them vao da ton tai hay chua
            if (!checkMaNV(MaNV))
            {
                this.connSV.insertNhanVien(MaNV, tenNV, sdt, gioiTinh, ngaySinh, danToc, queQuan, diaChi, cmnd, maPB, maCV, maTDHV, bacLuong, maHD);
            }
            else
            {
                throw new InsertException("Mã nhân viên này đã tồn tại");
            }
        }

        /// <summary>
        /// Kiem tra ma chuc vu do da ton tai chua
        /// </summary>
        /// <param name="maNV"> ma nhan vien muon kiem tra </param>
        /// <returns> 
        ///     true: khi ma nhan vien do da co
        ///     false: khi ma cnhan vien do chua co
        /// </returns>
        public bool checkMaNV(string maNV)
        {
            return this.connSV.findNhanVien(maNV) != null;
        }

        public void delete(string ma)
        {
            if (checkMaNV(ma))
            {
                this.connSV.deleteNhanVien(ma);
            }
            else
            {
                throw new DeleteException("Không tìm thấy chức vụ có mã là " + ma + " để xoá");
            }
        }

        /// <summary>
        /// Them thong tin cua 1 nhan vien moi vao trong du lieu
        /// </summary>
        /// <param name="MaNV"> Ma nhan vien </param>
        /// <param name="tenNV"> Ten Nhan Vien</param>
        /// <param name="sdt">So dien thoai Nhan Vien</param>
        /// <param name="gioiTinh"> Gioi tinh  
        /// <param name="maHD">ma hop dong lao dong</param>
        public void update(string MaNV, string tenNV, string sdt, int gioiTinh, string ngaySinh, string danToc, string queQuan, string diaChi,
            string cmnd, string maPB, string maCV, string maTDHV, int bacLuong, string maHD)
        {
            //Kiem tra ma chuc vu them vao da ton tai hay chua
            if (checkMaNV(MaNV))
            {
                this.connSV.updateNhanVien(MaNV, tenNV, sdt, gioiTinh, ngaySinh, danToc, queQuan, diaChi, cmnd, maPB, maCV, maTDHV, bacLuong, maHD);
            }
            else
            {
                throw new InsertException("Mã nhân viên này chưa tồn tại");
            }
        }
    }
}
