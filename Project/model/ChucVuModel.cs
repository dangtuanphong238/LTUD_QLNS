using Project.classSupport;
using Project.Exciption;
using System;
using System.Data;

namespace Project.model
{
    class ChucVuModel
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
            DataTable dtResult = this.connSV.getTalbeChucVu();
            if(dtResult != null)
            {
                return dtResult;
            }
            else
            {
                throw new SelectException("Lỗi try cập dữ liệu đến bảng Chức vụ");
            }
        }

        /// <summary>
        /// Tim chuc vu voi ma chuc vu truyen vao
        /// </summary>
        /// <param name="MaCV"> Ma chuc vu muon tim </param>
        /// <returns> DataRow </returns>
        public DataRow find(string ma)
        {
            DataRow drResult = this.connSV.findChucVu(ma);
            if(drResult == null)
            {
                throw new FindException("Không tìm thấy chức vụ với mã là " + ma);
            }
            else
            {
                return drResult;
            }
        }

        /// <summary>
        /// Them chuc vu moi
        /// </summary>
        /// <param name="ma"> ma chuc vu moi muon them vao </param>
        /// <param name="ten"> ten goi chuc vu moi muon them vao </param>
        /// <returns> int </returns>
        public void insert(string ma, string ten)
        {
            //Kiem tra ma chuc vu them vao da ton tai hay chua
            if (!checkMaCV(ma))
            {
                this.connSV.insertChucVu(ma, ten);
            }
            else
            {
                throw new InsertException("Mã chức vụ này đã tồn tại");
            }
        }

        /// <summary>
        /// Kiem tra ma chuc vu do da ton tai chua
        /// </summary>
        /// <param name="maCV"> ma chuc vu muon kiem tra </param>
        /// <returns> 
        ///     true: khi ma chu vu do da co
        ///     false: khi ma chu vu do chua co
        /// </returns>
        public bool checkMaCV(string maCV)
        {
            return this.connSV.findChucVu(maCV) != null;
        }

        /// <summary>
        /// Xoa chuc vu voi ma chu vu truyen vao
        /// </summary>
        /// <param name="ma"> ma chuc vu muon xoa </param>
        public void delete(string ma)
        {
            if (checkMaCV(ma)) {
                this.connSV.deleteChucVu(ma);
            }
            else
            {
                throw new DeleteException("Không tìm thấy chức vụ có mã là " + ma + " để xoá");
            }
        }
    }
}
