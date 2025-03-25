using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_dev_prc_linh.menu
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Context.Items["UserData"] != null)
                {
                    var data = (dynamic)Context.Items["UserData"];
                    lblName.Text = "ID_Muon: " + data.ID_Muon;
                    lblAge.Text = "So luong sach: " + data.SLSach;
                    lblEmail.Text = "gia sach: " + data.GiaSach;
                    lblEmail1.Text = "Date: " + data.Date;
                    lblEmail2.Text = "ID Sach: " + data.ID_Sach;
                }
            }
        }
    }
}