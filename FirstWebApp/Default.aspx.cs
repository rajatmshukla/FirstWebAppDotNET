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
using FirstWeb.Delete;
using FirstWeb.Update;


namespace FirstWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DeptManager deptData = new DeptManager();
            GridView1.DataSource = deptData.GetData();
            GridView1.DataBind();
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

            int deptno = 0;
            lblError.Visible = false;
            int.TryParse(TxtBoxEmpId.Text.ToString(), out empid);
            int.TryParse(TxtBoxDept.Text.ToString(), out deptno);
            string depttxt = TxtBoxDept.Text.ToString();
            string emptxt = TxtBoxEmpName.Text.ToString();
            string saltxt = TxtBoxSal.Text.ToString();
            int i = Update.updateData(empid, deptno, depttxt, emptxt, saltxt);
            try
            {
                if (i == 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "Invalid Department Number";
                }
                else if (i == 2)
                {
                    lblError.Visible = true;
                    lblError.Text = "Enter Department Number";
                }
                else
                {
                    Gridviewfunc();
                }
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
            
            int.TryParse(TxtBoxEmpId.Text.ToString(), out empid);

            bool datadel = Delete.Datadel(empid);
            
            try
            {
                if (datadel == true)
                {
                    Gridviewfunc();
                }

                else
                {
                    lblError.Visible = true;
                    lblError.Text = "Invalid Employee Id";

                }
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
        }

    }


}