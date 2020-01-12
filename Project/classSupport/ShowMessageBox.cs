using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.classSupport
{
    class ShowMessageBox
    {
        /*
         *  ________________ ERROR ________________
         */
        public static void erorr(string messErro, string title)
        {
            System.Windows.Forms.MessageBox.Show(
                    messErro,
                    title,
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
        }

        public static void erorr(string messErro)
        {
            System.Windows.Forms.MessageBox.Show(
                    messErro,
                    "Lỗi",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Error);
        }

        /*
         *  ________________ INFORMATION ________________
         */
        public static void information(string messErro, string title)
        {
            System.Windows.Forms.MessageBox.Show(
                    messErro,
                    title,
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);
        }

        public static void information(string messErro)
        {
            System.Windows.Forms.MessageBox.Show(
                    messErro,
                    "Thông báo",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Information);
        }

        /*
        *  ________________  ________________
        */

        /*
        *  ________________  ________________
        */

    }
}
