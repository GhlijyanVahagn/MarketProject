﻿using MarketHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MarketProject
{
    public partial class WebFormXXXX : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            displayTxt.Text = Session[MarketSessions.PopupMessage].ToString();
        }
    }
}