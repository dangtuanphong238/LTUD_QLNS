using Project.Exciption;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.model
{
    class AdminModel
    {
        private handleDatabase connSV = new handleDatabase();
        public DataRow drAdmin { get; set; }

        /// <summary>
        /// tim admin chuc nang nhu dang nhap
        /// </summary>
        /// <returns></returns>
        public DataRow login(string username, string password)
        {
            DataRow drResult = this.connSV.findAdmin(username);
            if (drResult != null)
            {
                if (drResult[1].Equals(password))
                {
                    return drResult;
                }
                else
                {
                    throw new FindException("Mật khẩu đăng nhập đã sai");
                }
            }
            else
            {
                throw new FindException("Tên đăng nhập đã sai");
            }
        }
    }
}
