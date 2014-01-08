using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test : System.Web.UI.Page
{
    lanhnt.LayCVMeCon laycv = new lanhnt.LayCVMeCon();
    lanhnt.Menu mn = new lanhnt.Menu();
    protected void Page_Load(object sender, EventArgs e)
    {
        lblMenu.Text = mn.LoadMenu(0, 0);
    }
    protected void btnLayCV_Click(object sender, EventArgs e)
    {
        
    }
}