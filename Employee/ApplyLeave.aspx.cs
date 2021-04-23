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

public partial class Employee_ApplyLeave : System.Web.UI.Page
{
    SqlCommand com;
    string str;
    SqlCommand cmd;
    SqlConnection con;
    String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
    SqlDataReader rdr;
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlConnection con1 = new SqlConnection(CS);
            con1.Open();
            str = "select count(*)from LeaveTable where EmployeeId='" + Session["EmployeeId"].ToString() + "' And StartDate='" + txtStartDate.Text + "' And EndDate='" + txtEndDate.Text + "'";
            com = new SqlCommand(str, con1);
            int count = Convert.ToInt32(com.ExecuteScalar());
            if (count > 0)
            {
                string message = "This Date Leave Applied Already.";
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
                string strQuery = "insert into LeaveTable(EmployeeId,EmployeeName,LeaveCategory,StartDate,EndDate,Reason,ApplyOn,Status) values (@EmployeeId,@EmployeeName,@LeaveCategory,@StartDate,@EndDate,@Reason,@ApplyOn,@Status)";
                SqlCommand cmd = new SqlCommand(strQuery);
                cmd.Parameters.Add("@EmployeeId", SqlDbType.VarChar).Value = Session["EmployeeId"].ToString();
                cmd.Parameters.Add("@EmployeeName", SqlDbType.VarChar).Value = Session["USERNAME"].ToString();
                cmd.Parameters.Add("@LeaveCategory", SqlDbType.VarChar).Value = ddlLeaveCategory.Text;
                cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = txtStartDate.Text;
                cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = txtEndDate.Text;
                cmd.Parameters.Add("@Reason", SqlDbType.VarChar).Value = txtReason.Text;
                cmd.Parameters.Add("@ApplyOn", SqlDbType.Date).Value = System.DateTime.Now.ToString();
                cmd.Parameters.Add("@Status", SqlDbType.VarChar).Value = "Pending"; 
                InsertUpdateData(cmd);
                Clear();
                string message = "Leave Applied Successfully!!";
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

    private void Clear()
    {
        txtEndDate.Text = "";
        txtReason.Text = "";
        txtStartDate.Text = "";
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
}