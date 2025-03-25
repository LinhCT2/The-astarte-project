<%@ Page Title="" Language="C#" MasterPageFile="~/menu/siteMenu.Master" AutoEventWireup="true" CodeBehind="readers.aspx.cs" Inherits="Library_Management_dev_prc_linh.minh.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.1/css/all.min.css">
     <link href="DocGia2.css" rel="stylesheet" type="text/css" />
     <title></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Readers</h1>
 <div class="search">
     <i class="fa-solid fa-magnifying-glass"></i>
     <asp:TextBox ID="TextBox1" runat="server" placeholder="Search docgia, hoten...." CssClass="textSearch"></asp:TextBox>
 </div>

 <div class="inf">
     <div class="inf2">
         <nav class="box0">
             <div class="box">
                 <p>ID_DocGia</p>
                 <asp:TextBox ID="TextBox2" CssClass="txt" runat="server"></asp:TextBox>
             </div>
             <div class="box">
                 <p>HoTen</p>
                 <asp:TextBox ID="TextBox3" CssClass="txt" runat="server"></asp:TextBox>
             </div>
         </nav>

         <nav class="box0">
             <div class="box">
                 <p>NgaySinh</p>
                 <asp:TextBox ID="TextBox4" CssClass="txt" runat="server"></asp:TextBox>
             </div>
                 <div class="box">
                 <p>CongViec</p>
                 <asp:TextBox ID="TextBox5" CssClass="txt" runat="server"></asp:TextBox>
             </div>
                 <div class="box">
                 <p>DiaChi</p>
                 <asp:TextBox ID="TextBox6" CssClass="txt" runat="server"></asp:TextBox>
             </div>
             <div class="box">
                 <p>CCCD</p>
                 <asp:TextBox ID="TextBox7" CssClass="txt" runat="server"></asp:TextBox>
             </div>
         </nav>

         <nav class="box0">
             <div class="box">
                 <p>NgayCap</p>
                 <asp:TextBox ID="TextBox8" CssClass="txt" runat="server"></asp:TextBox>
             </div>
             <div class="box">
                 <p>NgayHetHan</p>
                 <asp:TextBox ID="TextBox9" CssClass="txt" runat="server"></asp:TextBox>
              </div>
             <div class="box">
                 <p>SoSachMuon</p> 
                 <asp:TextBox ID="TextBox10" CssClass="txt" runat="server"></asp:TextBox>
             </div>
                 <div class="box">
                 <p>Status</p>
                 <asp:TextBox ID="TextBox11" CssClass="txt" runat="server"></asp:TextBox>
             </div>
         </nav>
     </div>
     <div class="btn">
         <asp:Button ID="Button1" runat="server" CssClass="txtBtn" Text="Add" OnClick="Button1_Click" />
         <asp:Button ID="Button2" runat="server" CssClass="txtBtn" Text="Edit" />
         <asp:Button ID="Button3" runat="server" CssClass="txtBtn" Text="Delete" />
     </div>
 </div>

 <div class="grid0">
     <div class="grid">
         <asp:GridView ID="GridView1" runat="server" CssClass="custom-gridview" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="2">
             <Columns>
                  <asp:ButtonField ButtonType="Button" Text="choose"/>
             </Columns>
         </asp:GridView>
     </div>
 </div>
</asp:Content>
