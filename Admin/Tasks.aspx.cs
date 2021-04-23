using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;
public partial class Admin_Salary : System.Web.UI.Page
{
    SqlCommand com;
    string str;
    SqlCommand cmd;
    SqlConnection con;
    String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
    SqlDataReader rdr;
    protected void Page_Load(object sender, EventArgs e)
    {
         if (!IsPostBack)
        {
             BindProjectName();
        }
    }

    private void BindProjectName()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from ProjectTable", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlProject.DataSource = dt;
                ddlProject.DataTextField = "ProjectName";
                ddlProject.DataValueField = "ProjectName";
                ddlProject.DataBind();
                ddlProject.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddlProject.Items.Clear();
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlConnection con1 = new SqlConnection(CS);
            con1.Open();
            str = "select count(*)from TaskTable where EmployeeId='" + ddlEmployee.SelectedValue + "'";
            com = new SqlCommand(str, con1);
            int count = Convert.ToInt32(com.ExecuteScalar());
            if (count > 0)
            {
                string message = "Employee Id Already Exits In Task Table";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                return;
            }
            else
            {
                string strQuery = "insert into TaskTable(Project,EmployeeId,EmployeeName,TaskDescription,CreatedBy,CreatedOn) values (@Project,@EmployeeId,@EmployeeName,@TaskDescription,@CreatedBy,@CreatedOn)";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@Project", SqlDbType.VarChar).Value = ddlProject.Text;
                cmd.Parameters.Add("@EmployeeId", SqlDbType.NVarChar).Value = ddlEmployee.SelectedValue;
                cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = ddlEmployee.SelectedItem.Text;
                cmd.Parameters.Add("@TaskDescription", SqlDbType.NVarChar).Value = txtTaskDescription.Text;
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "Adam Rice";
                cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = System.DateTime.Now.ToString();
                InsertUpdateData(cmd);
                string message = "Employee Task Saved Successfully!!";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
            }
        }
    }

    private Boolean InsertUpdateData(SqlCommand cmd)
    {
        String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        SqlConnection con = new SqlConnection(strConnString);
        cmd.CommandType = CommandType.Text;
        cmd.Connection = con;
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            Clear();
            return true;
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            return false;
        }
        finally
        {
            con.Close();
            con.Dispose();
        }
    }

    private void Clear()
    {
        txtTaskDescription.Text = "";

    }

    protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from EmployeeTable", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlEmployee.DataSource = dt;
                ddlEmployee.DataTextField = "EmployeeName";
                ddlEmployee.DataValueField = "EmployeeId";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddlEmployee.Items.Clear();
            }
        }
    }

    protected void txtOtherDeduction_TextChanged(object sender, EventArgs e)
    {
        //int val1 = Convert.ToInt32(txtGrossSalary.Text);
        //int val2 = Convert.ToInt32(txtTotalDeduction.Text);
        //int val3 = val1 - val2;
        //txtNetSalary.Text = val3.ToString();
    }
}