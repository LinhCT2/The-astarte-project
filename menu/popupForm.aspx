<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="popupForm.aspx.cs" Inherits="Library_Management_dev_prc_linh.menu.popupForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <h2>Điền thông tin</h2>
            <asp:Label ID="Label1" runat="server" Text="Tên:"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="SubmitButton" runat="server" Text="Gửi" OnClick="SubmitButton_Click" />
        </div>
    </form>
</body>
</html>
