using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Admin
{
    public partial class New_Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshValues();
        }

        private void RefreshValues()
        {
            SetPanelsTrue();
            CheckApanels();
         
        }

        private void SetPanelsTrue()
        {
            Panel_Attribute1.Visible = true;
            Panel_Attribute2.Visible = true;
            Panel_Attribute3.Visible = true;
            Panel_Attribute4.Visible = true;
        }

        private void CheckApanels()
        {
            if (Label_Attribute1.Text == "")
            {
                Panel_Attribute1.Visible = false;
            }
            if (Label_Attribute2.Text == "")
            {
                Panel_Attribute2.Visible = false;
            }
            if (Label_Attribute3.Text == "")
            {
                Panel_Attribute3.Visible = false;
            }
            if (Label_Attribute4.Text == "")
            {
                Panel_Attribute4.Visible = false;
            }
        }
    }
}