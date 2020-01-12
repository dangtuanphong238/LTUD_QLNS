using Project.Exciption;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.model
{
    class LuongModel
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
            DataTable dtResult = this.connSV.getTalbeLuong();
            if (dtResult != null)
            {
                return dtResult;
            }
            else
            {
                throw new SelectException("Lỗi try cập dữ liệu đến bảng Chức vụ");
            }
        }
    }
}
