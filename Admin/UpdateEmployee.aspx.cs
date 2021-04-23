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
using System.Data.SqlClient;
using System.IO;

public partial class Admin_UpdateEmployee : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {

            string Id = Request.QueryString["Id"].ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from EmployeeTable where Id='" + Id + "'", con);
            cmd.ExecuteNonQuery(); ;

        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {

            string Id = Request.QueryString["Id"].ToString();
            con.Open();
            SqlCommand name = new SqlCommand("Update EmployeeTable Set EmployeeName='" + txtEmployeeName.Text + "' where Id='" + Id + "'", con);
            SqlCommand email= new SqlCommand("Update EmployeeTable Set Mail='" + txtEmployeeEmail.Text + "' where Id='" + Id + "'", con);
            SqlCommand mobile = new SqlCommand("Update EmployeeTable Set MobileNo='" + txtEmployeeMobile.Text + "' where Id='" + Id + "'", con);
            SqlCommand address = new SqlCommand("Update EmployeeTable Set Address='" + txtEmployeeAddress.Text + "' where Id='" + Id + "'", con);
            name.ExecuteNonQuery(); ;
            email.ExecuteNonQuery(); ;
            mobile.ExecuteNonQuery(); ;
            address.ExecuteNonQuery(); ;
            Response.Redirect("~/Admin/ViewEmployee.aspx");
        }
    }
}