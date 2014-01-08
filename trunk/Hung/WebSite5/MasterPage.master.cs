using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    lanhnt.Menu mn = new lanhnt.Menu();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Ma"] == null)
            Response.Redirect("~/Login.aspx");
        //lblMenu.Text = mn.LoadMenu(0, 0);
        //lblUser.Text = "Xin chào " + Session["HoTenNV"].ToString() + ".";
        //lblMenu.Text = mn.LoadMenu(0, 0);
    }
    
}
