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
    public partial class frmLogin : Form
    {
        //Varible
        AdminModel adminM = new AdminModel();

        /*
         * ________________ CONSTRUCTOR ________________
         */
        public frmLogin()
        {
            InitializeComponent();
        }




        /*
         * ________________ FUNCTION CHECK OR SUOPPORT ________________
         */
        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text == string.Empty)
            {
                erpTxt.SetError(txtUsername, "Chưa nhập dữ liệu");
            }
            else
            {
                erpTxt.Clear();
            }
        }




        /*
         *  ________________ EVENT CLICK ________________
         */
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                this.adminM.drAdmin = adminM.login(txtUsername.Text, txtPassword.Text);
                ShowMessageBox.information("Đăng nhập thành công", "Xin chào");
                this.Close();
            }
            catch (FindException findEx)
            {
                ShowMessageBox.erorr(findEx.Message, "Đăng nhập thất bại");
            }
        }
    }
}
