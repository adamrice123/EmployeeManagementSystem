using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Specialized;
using System.Text;
using System.Data.SqlClient;
public partial class Employee_MyProfile : System.Web.UI.Page
{
    SqlCommand cmd, cmd1;
    SqlConnection con;
    String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
    SqlDataReader rdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string sql = "select * from EmployeeTable Where EmployeeId = '" + Session["EmployeeId"].ToString() + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            SqlDataAdapter adpt = new SqlDataAdapter(sql, con.ConnectionString);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            txtEmployeeId.Text = dt.Rows[0]["EmployeeId"].ToString();
            txtFullName.Text = dt.Rows[0]["EmployeeName"].ToString();
            txtEmail.Text = dt.Rows[0]["Mail"].ToString();
            txtMobileNo.Text = dt.Rows[0]["MobileNo"].ToString();
            txtAddress.Text = dt.Rows[0]["Address"].ToString();
            txtDateOfJoin.Text = dt.Rows[0]["DateOfJoin"].ToString();
            txtDepartment.Text = dt.Rows[0]["Department"].ToString();
            txtDivision.Text = dt.Rows[0]["Division"].ToString();
            txtDateOfBirth.Text = dt.Rows[0]["DateOfBirth"].ToString();
            txtGender.Text = dt.Rows[0]["Gender"].ToString();
        }
    }
}