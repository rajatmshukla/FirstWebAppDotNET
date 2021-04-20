using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FirstWeb.WManager;
using MyFirstWeb.Data;
using FirstWeb.BizEntities;

namespace FirstWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DBHelper.defaultConnectionString = System.Configuration.ConfigurationManager.AppSettings["FirstWebDBConn"];
            lblError.Visible = false;
            DataTable dt = new DataTable();

            dt = DBHelper.ExecuteQuery("exec SelectAllEmp");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            TxtBoxEmpId.Text = GridView1.SelectedRow.Cells[1].Text;
            TxtBoxEmpName.Text = GridView1.SelectedRow.Cells[2].Text;
            TxtBoxDept.Text = GridView1.SelectedRow.Cells[3].Text;
            TxtBoxSal.Text = GridView1.SelectedRow.Cells[4].Text;
            btnAddEdit.Text = "Update";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int empid = 0;
            int icount = 0;
            int idept = 0;
            int deptno = 0;
            lblError.Visible = false;
            int.TryParse(TxtBoxEmpId.Text.ToString(), out empid);
            int.TryParse(TxtBoxDept.Text.ToString(), out deptno);
            try
            {
                icount = int.Parse(DBHelper.ExecuteScalar("SELECT [dbo].[EmpFind]('" + TxtBoxEmpId.Text + "')").ToString());
                idept = int.Parse(DBHelper.ExecuteScalar("SELECT [dbo].[DeptFind]('" + TxtBoxDept.Text + "')").ToString());

                if (icount > 0)
                {
                    if (idept > 0)
                    {
                        DBHelper.ExecuteNonQuery("exec EmpUpdate '" + empid + "','" + TxtBoxEmpName.Text + "'");
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Invalid Department Number";
                    }
                }
                else
                {


                    if (idept > 0)
                    {
                        DBHelper.ExecuteNonQuery("exec InsertEmp '" + empid + "','" + TxtBoxEmpName.Text + "','" + TxtBoxDept.Text + "', '" + TxtBoxSal.Text + "'");
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "Invalid Department Number";
                    }
                }

                Gridviewfunc();
            }

            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = (ex.Message == null) ? "" : "Error is : " + ex.Message;
            }
            ClearAll();


        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int empid = 0;
            int icount = 0;
            DBHelper.defaultConnectionString = System.Configuration.ConfigurationManager.AppSettings["FirstWebDBConn"];
            DataTable dt = new DataTable();
            int.TryParse(TxtBoxEmpId.Text.ToString(), out empid);
            try
            {
                icount = int.Parse(DBHelper.ExecuteScalar("select count(*) from Emp where EmpID = '" + empid + "'").ToString());
                if (icount > 0)
                {
                    dt = DBHelper.ExecuteQuery("exec DeleteEmp '" + empid + "'");
                }

                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Invalid Employee ID";
                }
                Gridviewfunc();
                
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = (ex.Message == null) ? "" : "Error is : " + ex.Message;
            }
            
            ClearAll();
        }
        protected void ClearAll()
        {
            TxtBoxEmpId.Text = String.Empty;
            TxtBoxEmpName.Text = String.Empty;
            TxtBoxDept.Text = String.Empty;
            TxtBoxSal.Text = String.Empty;
        }

        protected void Gridviewfunc()
        {

            DeptManager deptData = new DeptManager();
            GridView1.DataSource = deptData.GetData();
            GridView1.DataBind();

            //DBHelper.defaultConnectionString = System.Configuration.ConfigurationManager.AppSettings["FirstWebDBConn"];

            //DataTable dt = new DataTable();

            //dt = DBHelper.ExecuteQuery("select * from Emp");
            //if (dt != null)
            //{
            //    if (dt.Rows.Count > 0)
            //    {
            //        GridView1.DataSource = dt;
            //        GridView1.DataBind();
            //    }
            //}

        }

    }


}