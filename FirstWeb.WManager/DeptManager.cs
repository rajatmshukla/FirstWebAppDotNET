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

        private string ConvertDateTimeToString(DataRow row, string fieldName)
        {
            if (row.IsNull(fieldName))
                return null;
            if (row[fieldName].GetType() == typeof(DateTime))
            {
                DateTime dt = (DateTime)row[fieldName];
                return dt.ToString("yyyy-MM-dd hh:mm:ss.fff tt");
            }
            return row.ToString();
        }

        public List<Emp> GetData()
        {
            List<string> lst = new List<string>(); 
            DBHelper.defaultConnectionString = ConfigurationManager.AppSettings["FirstWebDBConn"];


            lst.Add("GetData()" + ConfigurationManager.AppSettings["FirstWebDBConn"]);
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();

            dt1 = DBHelper.ExecuteQuery("select * from EmpOG");
            List<EmpOG> emplist1 = new List<EmpOG>();

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
                            EmpOG emps1 = new EmpOG();
                            emps.EmpID = int.Parse(dt.Rows[i][0].ToString());
                            emps.EmpName = dt.Rows[i][1].ToString();
                            emps.deptno = int.Parse(dt.Rows[i][2].ToString());
                            emps.salary = decimal.Parse(dt.Rows[i][3].ToString());
                            
                            if (dt.Rows[i][4] != null)
                            {
                                if (dt.Rows[i][4].ToString() != "")
                                { 
                                    emps.DateUpdated = ConvertDateTimeToString(dt.Rows[i],"DateUpdated");
                                }
                            }

                            string dateOG = ConvertDateTimeToString(dt1.Rows[i], "DateUpdated");
                            emps.DateResult = dateOG;

                       

                            string date = ConvertDateTimeToString(dt.Rows[i], "DateUpdated");
                            int id = int.Parse(dt1.Rows[i]["EmpID"].ToString());

                            if (string.Compare(dateOG, date) < 0)
                            {
                                DBHelper.ExecuteNonQuery("update Emp set CompareResult='YES' where EmpID= '" + id + "'");
                                emps.CompareResult = "Yes";
                                DBHelper.ExecuteNonQuery("update Emp set DateResult='"+date+"' where EmpID= '" + id + "'");

                            }
                            else if (string.Compare(dateOG, date) == 0)
                            {
                                DBHelper.ExecuteNonQuery("update Emp set CompareResult='Same' where EmpID= '" + id + "'");
                                emps.CompareResult = "Same";
                                DBHelper.ExecuteNonQuery("update Emp set DateResult='" + date + "' where EmpID= '" + id + "'");
                            }
                            else
                            {
                                DBHelper.ExecuteNonQuery("update Emp set CompareResult='NO' where EmpID= '" + id + "'");
                                emps.CompareResult = "No";
                                DBHelper.ExecuteNonQuery("update Emp set DateResult='" + dateOG + "' where EmpID= '" + id + "'");
                            }

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
