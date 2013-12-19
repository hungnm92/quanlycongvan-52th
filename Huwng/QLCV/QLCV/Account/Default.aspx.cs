using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QLCV.Account
{
    public partial class Default1 : System.Web.UI.Page
    {
        UserN u = new UserN();
        protected void Page_Load(object sender, EventArgs e)
        {
            lblSession.Text = Session["Email"].ToString();
        }
    }
}