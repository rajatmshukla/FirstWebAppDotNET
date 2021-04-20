using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirstWeb.BizEntities;
using MyFirstWeb.Data;
using System.Configuration;
using System.Data;
namespace FirstWeb.Delete
{
    public static class Delete
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static bool Datadel(int empid)
        {
           
            int icount = 0;
            DBHelper.defaultConnectionString = System.Configuration.ConfigurationManager.AppSettings["FirstWebDBConn"];
            DataTable dt = new DataTable();
                icount = int.Parse(DBHelper.ExecuteScalar("select count(*) from Emp where EmpID = '" + empid + "'").ToString());
                if (icount > 0)
                {
                    dt = DBHelper.ExecuteQuery("exec DeleteEmp '" + empid + "'");
                return true;
                }

                else
                {
                    return false;
                }
            }
            
        }
    }
