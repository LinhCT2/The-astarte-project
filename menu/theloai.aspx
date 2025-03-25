<%@ Page Title="" Language="C#" ValidateRequest="false"  MasterPageFile="~/menu/siteMenu.Master" AutoEventWireup="true" CodeBehind="theloai.aspx.cs" Inherits="Library_Management_dev_prc_linh.menu.theloai" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.1/css/all.min.css">
    <link href="theloai.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function triggerSearch(event, buttonId) {
            if (event.keyCode === 13) {
                document.getElementById(buttonId).click();
                return false;
            }
            return true;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Genres</h1>
<div class="search">
    <i class="fa-solid fa-magnifying-glass"></i>
    <asp:TextBox ID="TextBox1" runat="server"  onkeydown="return triggerSearch(event, '<%= ButtonSearch.ClientID %>');" placeholder="Search the loai...." CssClass="textSearch"></asp:TextBox>
    <asp:Button ID="ButtonSearch" runat="server" Text="Search" OnClick="ButtonSearch_Click" style="display:none;" />
</div>

<div class="inf">
    <div class="inf2">
        <nav class="box0">
            <div class="box">
                <p>ID_TheLoai</p>
                <asp:TextBox ID="TextBox2" CssClass="txt" runat="server"></asp:TextBox>
            </div>
            <div class="box">
                <p>TheLoai</p>
                <asp:TextBox ID="TextBox3" CssClass="txt" runat="server"></asp:TextBox>
            </div>
        </nav>

        
    </div>
    <div class="btn">
        <asp:Button ID="Button1" runat="server" CssClass="txtBtn" Text="Add" OnClick="Button1_Click1"  />
        <asp:Button ID="Button2" runat="server" CssClass="txtBtn" Text="Edit" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" CssClass="txtBtn" Text="Delete" OnClick="Button3_Click" />
    </div>
</div>

<div class="grid0">
    <div class="grid">
        <asp:GridView ID="GridView1" runat="server" CssClass="custom-gridview" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="4" OnRowCommand="GridView1_RowCommand" >
            <Columns>
                 <asp:ButtonField ButtonType="Button" Text="Choose" CommandName="Select"/>
            </Columns>
        </asp:GridView>
    </div>
</div>
</asp:Content>
