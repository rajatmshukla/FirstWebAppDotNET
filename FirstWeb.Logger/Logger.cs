using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFirstWeb.Data;
namespace FirstWeb.Logger
{
    public static class Logger
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static void excep(string Msg,string MsgType)
        {
            string strMsg = Msg.Replace("'", "''");
            DBHelper.ExecuteNonQuery("insert into excep (Msg,Msgtype) values ('" + strMsg + "','" + MsgType + "')");
        }

    }
}
