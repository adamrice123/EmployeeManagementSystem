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

public partial class Admin_Leave : System.Web.UI.Page
{
    SqlCommand cmd, cmd1;
    SqlConnection con;
    String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
    SqlDataReader rdr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string Id = Request.QueryString["Id"].ToString();
            string sql = "select * from LeaveTable Where Id = '" + Id + "'";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            SqlDataAdapter adpt = new SqlDataAdapter(sql, con.ConnectionString);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            txtEmployeeId.Text = dt.Rows[0]["EmployeeId"].ToString();
            txtEmployeeName.Text = dt.Rows[0]["EmployeeName"].ToString();
            txtLeaveCategory.Text = dt.Rows[0]["LeaveCategory"].ToString();
            txtStartDate.Text = dt.Rows[0]["StartDate"].ToString();
            txtEndDate.Text = dt.Rows[0]["EndDate"].ToString();
            txtApplyOn.Text = dt.Rows[0]["ApplyOn"].ToString();
            txtReason.Text = dt.Rows[0]["Reason"].ToString();
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            string Id = Request.QueryString["Id"].ToString();
            con.Open();
            if (ddlStatus.Text == "Approve")
            {

                SqlCommand cmd = new SqlCommand("Update LeaveTable Set Status ='" + ddlStatus.Text + "d" + "' where Id='" + Id + "'", con);
                cmd.ExecuteNonQuery(); ;
                Response.Redirect("~/Admin/ViewLeave.aspx");
            }
            else if (ddlStatus.Text == "Reject")
            {

                SqlCommand cmd = new SqlCommand("Update LeaveTable Set Status ='" + ddlStatus.Text + "ed" + "' where Id='" + Id + "'", con);
                cmd.ExecuteNonQuery(); ;
                Response.Redirect("~/Admin/ViewLeave.aspx");
            }
            else
            {
                SqlCommand cmd = new SqlCommand("Update LeaveTable Set Status ='" + ddlStatus.Text + "' where Id='" + Id + "'", con);
                cmd.ExecuteNonQuery(); ;
                Response.Redirect("~/Admin/ViewLeave.aspx");
            }
        }
    }
}