﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage2 : System.Web.UI.MasterPage
{
    lanhnt.ChucNang cn = new lanhnt.ChucNang();
    protected void Page_Load(object sender, EventArgs e)
    {
        Menu.Text = cn.LoadMenu(0, 0);
    }
}
