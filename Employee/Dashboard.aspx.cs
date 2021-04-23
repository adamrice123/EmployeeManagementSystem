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

public partial class Employee_Dashboard : System.Web.UI.Page
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
            User();
            Employee();
            Department();
            Division();
        }
    }

    private void User()
    {
        con = new SqlConnection(CS);
        con.Open();
        cmd = con.CreateCommand();
        cmd.CommandText = "Select Count(*) from UserTable Where UserType='Admin'";
        rdr = cmd.ExecuteReader();
        if (rdr.Read())
            lblUser.Text = rdr.GetValue(0).ToString();
        else
            lblUser.Text = "0";
        if ((rdr != null))
            rdr.Close();
        if (con.State == ConnectionState.Open)
            con.Close();
    }

    private void Employee()
    {
        con = new SqlConnection(CS);
        con.Open();
        cmd = con.CreateCommand();
        cmd.CommandText = "Select Count(*) from EmployeeTable";
        rdr = cmd.ExecuteReader();
        if (rdr.Read())
            lblEmployee.Text = rdr.GetValue(0).ToString();
        else
            lblEmployee.Text = "0";
        if ((rdr != null))
            rdr.Close();
        if (con.State == ConnectionState.Open)
            con.Close();
    }

    private void Department()
    {
        con = new SqlConnection(CS);
        con.Open();
        cmd = con.CreateCommand();
        cmd.CommandText = "Select Count(*) from DepartmentTable";
        rdr = cmd.ExecuteReader();
        if (rdr.Read())
            lblDepartment.Text = rdr.GetValue(0).ToString();
        else
            lblDepartment.Text = "0";
        if ((rdr != null))
            rdr.Close();
        if (con.State == ConnectionState.Open)
            con.Close();
    }
    private void Division()
    {
        con = new SqlConnection(CS);
        con.Open();
        cmd = con.CreateCommand();
        cmd.CommandText = "Select Count(*) from DivisionTable";
        rdr = cmd.ExecuteReader();
        if (rdr.Read())
            lblDivision.Text = rdr.GetValue(0).ToString();
        else
            lblDivision.Text = "0";
        if ((rdr != null))
            rdr.Close();
        if (con.State == ConnectionState.Open)
            con.Close();
    }
}