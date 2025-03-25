using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Library_Management_dev_prc_linh.menu.borrows;

namespace Library_Management_dev_prc_linh.menu
{
    public partial class trasach : System.Web.UI.Page
    {
        OleDbConnection conn = new OleDbConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Library_Management_3rd_Ses2.accdb";
                conn.Open();
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT MuonSach.ID_Muon, MuonSach.NgayMuon, MuonSach.NgayHenTra, MuonSach.NgayTra, MuonSach.TinhTrang, MuonSach.SoTienPhat FROM MuonSach WHERE (((MuonSach.Tra)=Yes))", conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                GridView1.DataSource = tb;
                GridView1.DataBind();
                conn.Close();

                string id= Request.QueryString["ID_Muon"];
                TextBox3.Text = id;

                
            }
        }

        public void updateDLSachT(int SLSachMuon, string id_Sach)
        {
            string sql = string.Format("UPDATE Sach SET SoBan = SoBan + {0} WHERE ID_Sach = '{1}'", SLSachMuon, id_Sach);
            using (OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Library_Management_3rd_Ses2.accdb"))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sql, conn))
                {
                    try
                    {
                        int rowsAffected = cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        // Handle exception
                    }
                }
                conn.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
           /* ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
            "alert('That bai');", true);*/

            string gs = Request.QueryString["GiaSach"];
            string date = Request.QueryString["date"];
            string slS = Request.QueryString["SLSach"];
            string idS = Request.QueryString["idSach"];


            int giasach = int.Parse(gs);
            int sls = int.Parse(slS);
            int num = 0;

            DateTime dateValue;
            string dateString1 = "25/01/2024";

            dateValue = DateTime.ParseExact(date, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine("Converted '{0}' to {1}.", date, dateValue);

            string dateString = TextBox4.Text;

          /*  string desiredFormat = "dd/MM/yyyy";
          

            DateTime originalDate = DateTime.ParseExact(dateString, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            // 2. Convert the DateTime object to the desired format string
            string newDateString = originalDate.ToString(desiredFormat);*/

            DateTime dval = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
         


            

            TimeSpan t = dval - dateValue;
            int p = string.IsNullOrEmpty(TextBox2.Text) ? 0 : int.Parse(TextBox2.Text);

            if (t.Days > 0)
            {
                num = ((int)(giasach * 0.1) * t.Days) + p;
            }

            string demo = "Yes";
            string sql = string.Format(@"UPDATE MuonSach SET SoTienPhat = {4}, TinhTrang = '{3}', NgayTra = '{2}' ,Tra = {1} WHERE ID_Muon= '{0}'",
                TextBox3.Text, demo, TextBox4.Text, TextBox1.Text, num);

            using (OleDbConnection conn = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Library_Management_3rd_Ses2.accdb"))
            {
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                updateDLSachT(sls, idS);

                cmd.ExecuteNonQuery();
                
                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT MuonSach.ID_Muon, MuonSach.NgayMuon, MuonSach.NgayHenTra, MuonSach.NgayTra, MuonSach.TinhTrang, MuonSach.SoTienPhat FROM MuonSach WHERE (((MuonSach.Tra)=Yes))", conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                GridView1.DataSource = tb;
                GridView1.DataBind();

                ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                "alert('Tra sach thanh cong');", true);

                
                conn.Close();
            }
           

            
            }
            /*  }
              ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                  "alert('That bai');", true);*/
        

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // Lấy số dòng (index) của hàng được nhấn
                int index = Convert.ToInt32(e.CommandArgument);

                // Lấy hàng tương ứng trong GridView
                GridViewRow selectedRow = GridView1.Rows[index];

                // Lấy giá trị từ ô đầu tiên (hoặc ô mong muốn)
                string selectedData2 = selectedRow.Cells[5].Text;
                string selectedData1 = selectedRow.Cells[1].Text;
                string selectedData3 = selectedRow.Cells[6].Text;
                string selectedData4 = selectedRow.Cells[4].Text;

                // Hiển thị giá trị trong TextBox
                TextBox1.Text = selectedData2;
                TextBox3.Text = selectedData1;
                TextBox2.Text = selectedData3;
                TextBox4.Text = selectedData4;
            }
        }
    }
}
