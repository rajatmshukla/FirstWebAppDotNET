using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FirstWeb.BizEntities;
using MyFirstWeb.Data;
using System.Configuration;
using System.Data;
using FirstWeb.Logger;

namespace FirstWeb.WManager
{
    public class DeptManager
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

        public List<Emp> GetData()
        {
            List<string> lst = new List<string>(); 
            DBHelper.defaultConnectionString = ConfigurationManager.AppSettings["FirstWebDBConn"];

            lst.Add("GetData()" + ConfigurationManager.AppSettings["FirstWebDBConn"]);
            DataTable dt = new DataTable();

            dt = DBHelper.ExecuteQuery("select * from Emp");
            List<Emp> emplist = new List<Emp>();
            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Emp emps = new Emp();
                            emps.EmpID = int.Parse(dt.Rows[i][0].ToString());
                            emps.EmpName = dt.Rows[i][1].ToString();
                            emps.deptno = int.Parse(dt.Rows[i][2].ToString());
                            emps.Salary = decimal.Parse(dt.Rows[i][3].ToString());
                            emplist.Add(emps);
                            

                            lst.Add(dt.Rows[i][1].ToString());
                            System.IO.File.WriteAllLines("C:\\tempr\\File.txt", lst);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lst.Add("Catch in GetData" + ex.Message.ToString());
                string strexc = string.Join(",", lst);
                Logger.Logger.excep(strexc, "Exception");
            }
            return emplist;


        }
    }
}
