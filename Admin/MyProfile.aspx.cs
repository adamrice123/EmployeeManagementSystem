using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_MyProfile : System.Web.UI.Page
{
    SqlCommand com;
    string str;
    SqlCommand cmd;
    SqlConnection con;
    SqlDataReader rdr;
    public static String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string sql = "select * from UserTable where ID='" + Session["USERID"].ToString() + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            SqlDataAdapter adpt = new SqlDataAdapter(sql, con.ConnectionString);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            txtFullName.Text = dt.Rows[0]["Name"].ToString();
            txtEmail.Text = dt.Rows[0]["Mail"].ToString();
            txtPassword.Text = dt.Rows[0]["Paaword"].ToString();
            txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            txtDateOfBirth.Text = dt.Rows[0]["DateOfBirth"].ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
            
        string name = "Update UserTable Set Name='" + txtFullName.Text  + "' where ID='" + Session["USERID"].ToString() + "'";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        SqlDataAdapter Name = new SqlDataAdapter(name, con.ConnectionString);
        DataTable dtName = new DataTable();
        Name.Fill(dtName);

        string dateofbirth = "Update UserTable Set DateOfBirth='" + txtDateOfBirth.Text + "' where ID='" + Session["USERID"].ToString() + "'";
        con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        SqlDataAdapter Dateofbirth = new SqlDataAdapter(dateofbirth, con.ConnectionString);
        DataTable dtDateofbirth = new DataTable();
        Dateofbirth.Fill(dtDateofbirth);

        string mail = "Update UserTable Set Mail='" + txtEmail.Text + "' where ID='" + Session["USERID"].ToString() + "'";
        con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        SqlDataAdapter Email = new SqlDataAdapter(mail, con.ConnectionString);
        DataTable dtEmail = new DataTable();
        Email.Fill(dtEmail);

        string mobile = "Update UserTable Set MobileNo='" + txtMobileNo.Text + "' where ID='" + Session["USERID"].ToString() + "'";
        con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        SqlDataAdapter Mobile = new SqlDataAdapter(mobile, con.ConnectionString);
        DataTable dtMobile = new DataTable();
        Mobile.Fill(dtMobile);

        string password = "Update UserTable Set Paaword='" + txtPassword.Text + "' where ID='" + Session["USERID"].ToString() + "'";
        con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        SqlDataAdapter Password = new SqlDataAdapter(password, con.ConnectionString);
        DataTable dtPassword = new DataTable();
        Password.Fill(dtPassword);
        Response.Redirect("~/Admin/MyProfile.aspx");


    }
}