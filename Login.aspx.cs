using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from UserTable where Mail='" + txtEmail.Text + "' and Paaword='" + txtPassword.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                Session["USERID"] = dt.Rows[0]["ID"].ToString();
                Session["USERNAME"] = dt.Rows[0]["Name"].ToString();
                Session["USERMAIL"] = dt.Rows[0]["Mail"].ToString();
                Session["EmployeeId"] = dt.Rows[0]["EmployeeId"].ToString();

                string Ulevel;
                Ulevel = dt.Rows[0][8].ToString().Trim();

                if (Ulevel == "Employee")
                {
                    Response.Redirect("~/Employee/Dashboard.aspx");
                }
                if (Ulevel == "Admin")
                {
                    Session["Email"] = txtEmail.Text;
                    Response.Redirect("~/Admin/DashBoard.aspx");
                }

            }
            else
            {
                string message = "Invalid Username or Password !";
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


        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from EmployeeTable where Mail='" + txtEmail.Text + "' and Password='" + txtPassword.Text + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                Session["USERID"] = dt.Rows[0]["ID"].ToString();
                Session["USERNAME"] = dt.Rows[0]["EmployeeName"].ToString();
                Session["USERMAIL"] = dt.Rows[0]["Mail"].ToString();
                Session["EmployeeId"] = dt.Rows[0]["EmployeeId"].ToString();

                string Ulevel;
                Ulevel = dt.Rows[0][11].ToString().Trim();

                if (Ulevel == "Employee")
                {
                    Response.Redirect("~/Employee/Dashboard.aspx");
                }
                if (Ulevel == "Admin")
                {
                    Session["Email"] = txtEmail.Text;
                    Response.Redirect("~/Admin/DashBoard.aspx");
                }

            }
            else
            {
                string message = "Invalid Username or Password !";
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
}