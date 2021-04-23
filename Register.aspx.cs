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
public partial class Register : System.Web.UI.Page
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
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlConnection con1 = new SqlConnection(CS);
            con1.Open();
            str = "select count(*)from EmployeeTable where Mail='" + txtEmail.Text + "' And EmployeeId='"+ txtEmployeeId.Text +"' And MobileNo='" + txtphone.Text + "'";
            com = new SqlCommand(str, con1);
            int count = Convert.ToInt32(com.ExecuteScalar());
            if (count > 0)
            {
                SqlConnection con2 = new SqlConnection(CS);
                con2.Open();
                str = "select count(*)from UserTable where Mail='" + txtEmail.Text + "' Or EmployeeId='" + txtEmployeeId.Text + "' Or MobileNo='" + txtphone.Text + "'";
                com = new SqlCommand(str, con2);
                int count1 = Convert.ToInt32(com.ExecuteScalar());
                if (count1 > 0)
                {
                    string message = "Employee Id, Email And Phone Already Exist";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    txtEmail.Text = "";
                    return;
                }
                else 
                {
                    string strQuery = "insert into UserTable(Name,EmployeeId,Mail,Paaword,MobileNo,UserType) values (@Name,@EmployeeId,@Mail,@Paaword,@MobileNo,@UserType)";
                    SqlCommand cmd = new SqlCommand(strQuery);
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = txtFullname.Text;
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.VarChar).Value = txtEmployeeId.Text;
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@Paaword", SqlDbType.NVarChar).Value = txtPassword.Text;
                    cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtphone.Text;
                    cmd.Parameters.Add("@UserType", SqlDbType.NVarChar).Value = "E";
                    InsertUpdateData(cmd);
                    Clear();
                    string message = "Register Successfully!!";
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
            else
            {

                string message = "Employee Id, Email And Phone Not Exist";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type = 'text/javascript'>");
                sb.Append("window.onload=function(){");
                sb.Append("alert('");
                sb.Append(message);
                sb.Append("')};");
                sb.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                txtEmail.Text = "";
                return;
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
        txtFullname.Text = "";
        txtEmail.Text = "";
        txtPassword.Text = "";
        txtphone.Text = "";
        txtEmployeeId.Text = "";
    }
}