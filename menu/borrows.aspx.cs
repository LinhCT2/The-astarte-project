using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Globalization;
using System.Xml;

namespace Library_Management_dev_prc_linh.menu
{
    public partial class borrows : System.Web.UI.Page
    {
        string IDSach;
        int giasach;
        OleDbConnection conn = new OleDbConnection();
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();
            if (!Page.IsPostBack)
            {
                OleDbDataAdapter ad = new OleDbDataAdapter("select * from DocGia", conn);
                DataTable dt = new DataTable();
                ad.Fill(dt);
                tdg.DataSource = dt;
                tdg.DataTextField = "HoTen";
                tdg.DataValueField = "ID_DocGia";
                tdg.DataBind();

                OleDbDataAdapter ad1 = new OleDbDataAdapter("select * from Sach", conn);
                DataTable dt1 = new DataTable();
                ad1.Fill(dt1);
                ts.DataSource = dt1;
                ts.DataTextField = "TenSach";
                ts.DataValueField = "ID_Sach";
                ts.DataBind();

                BindData();
            }
        }

        private void BindData()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();

            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT DocGia.HoTen, Sach.TenSach, MuonSach.NgayMuon, MuonSach.NgayHenTra, MuonSach.SoLuong, MuonSach.ID_Muon, Sach.GiaSach, Sach.ID_Sach\r\n            FROM DocGia INNER JOIN (Sach INNER JOIN MuonSach ON Sach.ID_Sach = MuonSach.ID_Sach) ON DocGia.ID_DocGia = MuonSach.ID_DocGia\r\n            WHERE (((MuonSach.Tra)=No));", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();

           
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = GridView1.Rows[index];

                string slCell = selectedRow.Cells[6].Text;
                string slCell1 = selectedRow.Cells[1].Text;
                string slCell2 = HttpUtility.HtmlDecode(selectedRow.Cells[2].Text);
                string slCell3 = selectedRow.Cells[3].Text;
                string slCell4 = selectedRow.Cells[4].Text;
                string slCell5 = selectedRow.Cells[5].Text; // sl sach
                string slCell6 = selectedRow.Cells[7].Text; // gia sach 
                string slCell7 = selectedRow.Cells[8].Text;


                TextBox2.Text = slCell;
                TextBox3.Text = slCell1;
                TextBox4.Text = slCell2;
                TextBox5.Text = slCell3;
                TextBox6.Text = slCell4;    
                TextBox8.Text = slCell5;

               /* if (slCell6 == "")
                {
                    giasach = 0;
                }
                else
                {
                    
                }*/
                giasach = int.Parse(slCell6);

                IDSach = slCell7;
                TextBox9.Text = giasach.ToString();
                aisod.Text = IDSach;
            }
        }
        


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }

        /*string dateString = dtpGiaHan.Value.Date.ToString("dd/MM/yyyy");*/

        

        public class Data
        {
            public string ID_Muon{ get; set; }
            public string Date { get; set; }
            public int SLSach { get; set; }
            public string GiaSach { get; set; }
            public string ID_Sach { get; set; }
        }

        protected void Button2_Clickn(object sender, EventArgs e) // nut tra sach 
        {
            

                Data data = new Data();

                data.ID_Muon = TextBox2.Text;
                data.Date = TextBox6.Text;
                data.SLSach = int.Parse(TextBox8.Text);
                data.GiaSach = TextBox9.Text;
                data.ID_Sach = aisod.Text;

            int sl = int.Parse(TextBox8.Text);

           
            Response.Redirect("trasach.aspx?ID_Muon="+TextBox2.Text + "&date=" + TextBox6.Text + "&SLSach=" + sl + "&GiaSach=" + TextBox9.Text + "&idSach=" + aisod.Text);

        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
            }
        }

        public Boolean chk_idMuon(String text) //ham kiem tra trung lap ID
        {
            string t1 = text;
            string sql = string.Format(@"select ID_Muon from MuonSach where ID_Muon = '{0}'", t1);

            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    // Check if any rows were returned (meaning a matching ID exists)
                    if (reader.HasRows)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
            }

        }

        protected void Button5_Click(object sender, EventArgs e) //muon sach
        {
 
            Boolean t = chk_idMuon(idm.Text);
            //Boolean t = true;

            if (t == true)
            {
                String sql = string.Format(@"Insert into MuonSach(ID_Muon, ID_DocGia, ID_Sach, NgayMuon, NgayHenTra, SoLuong, Status) values ({0}, {1}, '{2}', '{3}', '{4}', {5}, {6})",
                idm.Text, tdg.SelectedValue.ToString(), ts.SelectedValue, nm.Text, nht.Text, slm.Text, 1);
                OleDbCommand cmd = new OleDbCommand(sql, conn);

                int sl = int.Parse(slm.Text);
                string id_sach = ts.SelectedValue.ToString();

                updateDLSachM(sl, id_sach);

                cmd.ExecuteNonQuery();

                OleDbDataAdapter ad = new OleDbDataAdapter("SELECT DocGia.HoTen, Sach.TenSach, MuonSach.NgayMuon, MuonSach.NgayHenTra, MuonSach.SoLuong, MuonSach.ID_Muon, Sach.GiaSach, Sach.ID_Sach, Sach.ID_NXB, MuonSach.ID_DocGia, MuonSach.Tra, MuonSach.NgayTra, MuonSach.TinhTrang, MuonSach.SoTienPhat\r\n            FROM DocGia INNER JOIN (Sach INNER JOIN MuonSach ON Sach.ID_Sach = MuonSach.ID_Sach) ON DocGia.ID_DocGia = MuonSach.ID_DocGia\r\n            WHERE (((MuonSach.Tra)=No));", conn);
                DataTable tb = new DataTable();
                ad.Fill(tb);
                GridView1.DataSource = tb;
                GridView1.DataBind();


                ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                "alert('Muon sach thanh cong');", true);
            }
            else
            {
                
                ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                "alert('ID cua ban bi trung, hay nhap ID khac');", true);
                idm.Focus();
            }
        }

        public void updateDLSachM(int SLSachMuon, string id_Sach)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();

            string sql = string.Format("UPDATE Sach SET SoBan = SoBan - {0} WHERE ID_Sach = '{1}'", SLSachMuon, id_Sach);

            using (OleDbCommand cmd = new OleDbCommand(sql, conn))
            {
                try
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
               "alert('So luong sach cap nhat thanh cong');", true);
                    }
                    else
                    {
                        
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                "alert('Sach khong tim thay hoac khong co thay doi.');", true);
                    }
                }
                catch (OleDbException ex)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
                "alert('Loi cap nhat so luong sach');", true);
                    //MessageBox.Show("Loi cap nhat so luong sach: " + ex.Message);
                }
            }
        }


        protected void tdg_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();

            OleDbDataAdapter ad = new OleDbDataAdapter("select * from DocGia", conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            tdg.DataSource = dt;
            tdg.DataTextField = "HoTen";
            tdg.DataValueField = "ID_DocGia";
            tdg.DataBind();
        }

        protected void ts_Load(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();
            OleDbDataAdapter ad = new OleDbDataAdapter("select * from Sach", conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            ts.DataSource = dt;
            ts.DataTextField = "TenSach";
            ts.DataValueField = "ID_Sach";
            ts.DataBind();
        }
        

      

        

        protected void Button3_Click(object sender, EventArgs e) // gia han
        {
            String sql = string.Format(@"UPDATE MuonSach SET NgayHenTra ='{1}' WHERE ID_Muon= '{0}' ", TextBox2.Text, TextBox6.Text);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();

            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT DocGia.HoTen, Sach.TenSach, MuonSach.NgayMuon, MuonSach.NgayHenTra, MuonSach.SoLuong, MuonSach.ID_Muon, Sach.GiaSach, Sach.ID_Sach, Sach.ID_NXB, MuonSach.ID_DocGia, MuonSach.Tra, MuonSach.NgayTra, MuonSach.TinhTrang, MuonSach.SoTienPhat\r\n            FROM DocGia INNER JOIN (Sach INNER JOIN MuonSach ON Sach.ID_Sach = MuonSach.ID_Sach) ON DocGia.ID_DocGia = MuonSach.ID_DocGia\r\n            WHERE (((MuonSach.Tra)=No));", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();


            ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
            "alert('Ban da gia han ngay tra sach thanh cong');", true);
        }

        protected void Button4_Click(object sender, EventArgs e) // gia han
        {
            String sql = string.Format(@"Delete from MuonSach where ID_Muon = '{0}'", TextBox2.Text);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT DocGia.HoTen, Sach.TenSach, MuonSach.NgayMuon, MuonSach.NgayHenTra, MuonSach.SoLuong, MuonSach.ID_Muon, Sach.GiaSach, Sach.ID_Sach, Sach.ID_NXB, MuonSach.ID_DocGia, MuonSach.Tra, MuonSach.NgayTra, MuonSach.TinhTrang, MuonSach.SoTienPhat\r\n            FROM DocGia INNER JOIN (Sach INNER JOIN MuonSach ON Sach.ID_Sach = MuonSach.ID_Sach) ON DocGia.ID_DocGia = MuonSach.ID_DocGia\r\n            WHERE (((MuonSach.Tra)=No));", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();

            
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
            "alert('Ban da xoa phieu muon thanh cong');", true);
        }

       
    }
}