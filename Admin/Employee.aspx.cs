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

public partial class Admin_Employee : System.Web.UI.Page
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
            auto();
            BindDepartment();
        }
    }

    private void auto()
    {
        int Num = 0;
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString);
        con.Open();
        string sql = "SELECT MAX(ID+1) FROM EmployeeTable";
        cmd = new SqlCommand(sql);
        cmd.Connection = con;
        if (Convert.IsDBNull(cmd.ExecuteScalar()))
        {
            Num = 1;
            lblEmployeeId.Text = Convert.ToString(Num);
            txtEmployeeId.Text = Convert.ToString("EMP-" + Num);
        }
        else
        {
            Num = (int)(cmd.ExecuteScalar());
            lblEmployeeId.Text = Convert.ToString(Num);
            txtEmployeeId.Text = Convert.ToString("EMP-" + Num);
        }
        cmd.Dispose();
        con.Close();
        con.Dispose();
    }

    private void BindDepartment()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from DepartmentTable", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddpDepartment.DataSource = dt;
                ddpDepartment.DataTextField = "Department";
                ddpDepartment.DataValueField = "Department";
                ddpDepartment.DataBind();
                ddpDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddpDepartment.Items.Clear();
            }
        }
    }

    protected void ddpDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("select * from DivisionTable where Department='"+ ddpDepartment.Text +"'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddpDivision.DataSource = dt;
                ddpDivision.DataTextField = "Division";
                ddpDivision.DataValueField = "Division";
                ddpDivision.DataBind();
                ddpDivision.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddpDivision.Items.Clear();
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        string gender = string.Empty;
        string filePath = FileUpload1.PostedFile.FileName;
        string filename = Path.GetFileName(filePath);
        string ext = Path.GetExtension(filename);
        string contenttype = String.Empty;
        if (rbMale.Checked)
        {
            gender = "M";
        }
        else if (rbFemale.Checked)
        {
            gender = "F";
        }
        switch (ext)
        {
            case ".jpg":
                contenttype = "image/jpg";
                break;
            case ".png":
                contenttype = "image/png";
                break;
            case ".PNG":
                contenttype = "image/PNG";
                break;
        }
        if (contenttype != String.Empty)
        {
            String CS = ConfigurationManager.ConnectionStrings["MyDatabaseConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlConnection con1 = new SqlConnection(CS);
                con1.Open();
                str = "select count(*)from EmployeeTable where Mail='" + txtEmail.Text + "'";
                com = new SqlCommand(str, con1);
                int count = Convert.ToInt32(com.ExecuteScalar());
                if (count > 0)
                {
                    string message = "Mail Id Already Exits";
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
                    Stream fs = FileUpload1.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                    string strQuery = "insert into EmployeeTable(EmployeeId,EmployeeName,Mail,MobileNo,Address,DateOfJoin,Department,Division,DateOfBirth,Password,UserType,Gender,EmployeeImage,ContentType,CreatedBy,CreatedOn) values (@EmployeeId,@EmployeeName,@Mail,@MobileNo,@Address,@DateOfJoin,@Department,@Division,@DateOfBirth,@Password,@UserType,@Gender,@EmployeeImage,@ContentType,@CreatedBy,@CreatedOn)";
                    SqlCommand cmd = new SqlCommand(strQuery);
                    cmd.Parameters.Add("@EmployeeId", SqlDbType.VarChar).Value = txtEmployeeId.Text;
                    cmd.Parameters.Add("@EmployeeName", SqlDbType.NVarChar).Value = txtFullName.Text;
                    cmd.Parameters.Add("@Mail", SqlDbType.NVarChar).Value = txtEmail.Text;
                    cmd.Parameters.Add("@MobileNo", SqlDbType.NVarChar).Value = txtMobileNo.Text;
                    cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = txtAddress.Text;
                    cmd.Parameters.Add("@DateOfJoin", SqlDbType.Date).Value = txtDateOfJoin.Text;
                    cmd.Parameters.Add("@Department", SqlDbType.NVarChar).Value = ddpDepartment.Text;
                    cmd.Parameters.Add("@Division", SqlDbType.NVarChar).Value = ddpDivision.Text;
                    cmd.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = txtDateOfBirth.Text;
                    cmd.Parameters.Add("@Password", SqlDbType.NVarChar).Value = txtPassword.Text;
                    cmd.Parameters.Add("@UserType", SqlDbType.NVarChar).Value = "Employee";
                    cmd.Parameters.Add("@Gender", SqlDbType.Char).Value = gender;
                    cmd.Parameters.Add("@EmployeeImage", SqlDbType.Binary).Value = bytes;
                    cmd.Parameters.Add("@ContentType", SqlDbType.VarChar).Value = contenttype;
                    cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = "Adam Rice";
                    cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = System.DateTime.Now.ToString();
                    InsertUpdateData(cmd);
                    Clear();
                    string message = "New Employee added successfully!!";
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
        string formatError = "File format not recognised. Upload Image formats";
        System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
        sb1.Append("<script type = 'text/javascript'>");
        sb1.Append("window.onload=function(){");
        sb1.Append("alert('");
        sb1.Append(formatError);
        sb1.Append("')};");
        sb1.Append("</script>");
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
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
            auto();
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
        txtAddress.Text = "";
        txtFullName.Text = "";
        txtDateOfBirth.Text = "";
        txtEmail.Text = "";
        txtMobileNo.Text = "";
        txtDateOfJoin.Text = "";
    }
    
}