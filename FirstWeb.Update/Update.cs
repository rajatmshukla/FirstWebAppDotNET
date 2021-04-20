using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirstWeb.BizEntities;
using MyFirstWeb.Data;
using System.Configuration;
using System.Data;

namespace FirstWeb.Update
{
    public static class Update
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

        public static int updateData(int empid, int deptno, string depttxt, string emptxt, string saltxt)
        {

            int icount = 0;
            int idept = 0;

            bool isavailable = false;

            icount = int.Parse(DBHelper.ExecuteScalar("SELECT [dbo].[EmpFind]('" + empid + "')").ToString());
            if (depttxt != "")
                isavailable = true;

            if (isavailable)
            {

                idept = int.Parse(DBHelper.ExecuteScalar("SELECT [dbo].[DeptFind]('" + deptno + "') ").ToString());


                if (icount > 0)
                {
                    if (idept > 0)
                    {
                        DBHelper.ExecuteNonQuery("exec EmpUpdate '" + empid + "','" + emptxt + "'");
                        return (1);
                    }
                    else
                    {
                        return (0);
                    }
                }
                else
                {


                    if (idept > 0)
                    {
                        DBHelper.ExecuteNonQuery("exec InsertEmp '" + empid + "', '" + emptxt + "', '" + depttxt + "', '" + saltxt + "'");
                        return (1);
                    }
                    else
                    {
                        return (0);
                    }
                }


            }
            else
            {
                return (2);
            }
        }
    }
}


