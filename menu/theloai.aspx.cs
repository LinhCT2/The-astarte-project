using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_dev_prc_linh.menu
{
    public partial class theloai : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();

            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT * FROM TheLoai", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();
        }
        protected void ButtonSearch_Click(object sender, EventArgs e)
        {

            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();

            string searchTerm = TextBox1.Text.Trim();

            string query = "SELECT * FROM TheLoai";
            if (!string.IsNullOrEmpty(searchTerm))
            {
                query += " WHERE TheLoai LIKE @searchTerm";
            }
            OleDbDataAdapter ad = new OleDbDataAdapter(query, conn);
            if (!string.IsNullOrEmpty(searchTerm))
            {
                ad.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
            }

            DataTable tb = new DataTable();
            ad.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();

            /*BindData();*/
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Handle button click event here
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                // Lấy số dòng (index) của hàng được nhấn
                int index = Convert.ToInt32(e.CommandArgument);

                // Lấy hàng tương ứng trong GridView
                GridViewRow selectedRow = GridView1.Rows[index];

                // Lấy giá trị từ ô đầu tiên (hoặc ô mong muốn)
                string selectedData2 = selectedRow.Cells[1].Text;
                string selectedData1 = selectedRow.Cells[2].Text;
               

                // Hiển thị giá trị trong TextBox
                TextBox2.Text = selectedData2;
                TextBox3.Text = selectedData1;
              
            }
        }

        protected void Button1_Click1(object sender, EventArgs e) //add 
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();
            string sql = string.Format(@"INSERT INTO TheLoai(ID_TheLoai, TheLoai, Status) VALUES('{0}','{1}','{2}')",
                                        TextBox2.Text, TextBox3.Text, "1");
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();

            ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
               "alert('Good');", true);



            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT ID_TheLoai, TheLoai, Status FROM TheLoai", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e) //edit
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();
            string sql = string.Format(@"UPDATE TheLoai SET TheLoai='{0}', Status='{1}' WHERE ID_TheLoai='{2}'",
                              TextBox3.Text, "1",TextBox2.Text);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
               "alert('Good');", true);


            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT ID_TheLoai, TheLoai, Status FROM TheLoai", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e) //delete
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = D:\Library_Management_3rd_Ses2.accdb";
            conn.Open();
            string sql = string.Format(@"DELETE FROM TheLoai WHERE ID_TheLoai='{0}'", TextBox2.Text);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.ExecuteNonQuery();
            ClientScript.RegisterClientScriptBlock(this.GetType(), "ShowMessage",
               "alert('Good');", true);


            OleDbDataAdapter ad = new OleDbDataAdapter("SELECT ID_TheLoai, TheLoai, Status FROM TheLoai", conn);
            DataTable tb = new DataTable();
            ad.Fill(tb);
            GridView1.DataSource = tb;
            GridView1.DataBind();
        }
    }
}