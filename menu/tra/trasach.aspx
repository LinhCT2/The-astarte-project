<%@ Page Title="" Language="C#" MasterPageFile="~/menu/siteMenu.Master" AutoEventWireup="true" CodeBehind="trasach.aspx.cs" Inherits="Library_Management_dev_prc_linh.menu.trasach" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="TraSach.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div>
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>--%>
            <div class="id">
            <asp:Label ID="Label1" runat="server" Text="Trả sách"></asp:Label>
</div>
            <br />
            <br />
            <br />
            <div class="id1">
            <asp:Label ID="Label2" runat="server" Text="Tình trạng sách"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" CssClass="id4"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Số tiền phạt(VNĐ)"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server" CssClass="id4"></asp:TextBox>
</div>
            <br />
            <br />
            <div class="id2">
            <asp:Label ID="Label4" runat="server" Text="ID_Mượn"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server" CssClass="id4"></asp:TextBox>
            <br />
                <br />
            <br />
            <%--<asp:Button ID="Button2" runat="server" Text="Trả Sách" OnClick="Button1_Click" />--%>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Trả Sách" CssClass="id3" />
            <asp:TextBox ID="TextBox4" runat="server" CssClass="id4"></asp:TextBox>
            <%--<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBox4"/>--%>
</div>
            <br />
            <br />

            <div class="grid0">
            <div class="grid">
                <asp:GridView ID="GridView1" runat="server" CssClass="custom-gridview" OnRowCommand="GridView1_RowCommand" >
                    <Columns>
                         <asp:ButtonField ButtonType="Button" Text="choose" CommandName="Select"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
            <br />
        </div>
</asp:Content>
