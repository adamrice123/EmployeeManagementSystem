using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employee_HomeMasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USERNAME"] != null)
        {
            lblUserName.Text = Session["USERNAME"].ToString();
            lblMailId.Text = Session["USERMAIL"].ToString();
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }
}
