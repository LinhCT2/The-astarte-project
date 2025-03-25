<%@ Page Title="" Language="C#" MasterPageFile="~/menu/siteMenu.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="borrows.aspx.cs" Inherits="Library_Management_dev_prc_linh.menu.borrows" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.1/css/all.min.css">
     <link href="br.css" rel="stylesheet" type="text/css" />
     <title></title>

    <script type="text/javascript">
        function openFormPage() {
            window.open('popupForm.aspx', 'FormWindow', 'width=600,height=400');
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
         <h1>Borrows</h1>
 <div class="search">
     <i class="fa-solid fa-magnifying-glass"></i>
     <asp:TextBox ID="TextBox1" runat="server" placeholder="Search docgia, hoten...." CssClass="textSearch"></asp:TextBox>
 </div>

 <div class="inf">
     <div class="inf2">
         <nav class="box0">
             <div class="box">
                 <p>ID_Muon</p>
                 <asp:TextBox ID="TextBox2" CssClass="txt" runat="server" ReadOnly="True"></asp:TextBox>
             </div>
             <div class="box">
                 <p>Ten Doc Gia</p>
                 <asp:TextBox ID="TextBox3" CssClass="txt" runat="server" ReadOnly="True"></asp:TextBox>
             </div>
         </nav>

         <nav class="box0">
             <div class="box">
                <p>Ten Sach</p>
                 
                <asp:TextBox ID="TextBox4"  CssClass="txt" runat="server" ReadOnly="True"></asp:TextBox>
            </div>
                 <div class="box">
                 <p>Ngay Muon</p>
                 <asp:TextBox ID="TextBox5" CssClass="txt" runat="server"></asp:TextBox>
             </div>
                 <div class="box">
                 <p>Ngay Hen Tra</p>
                 <asp:TextBox ID="TextBox6" CssClass="txt" runat="server"></asp:TextBox>
             </div>
             
         </nav>

         <nav class="box0">
             <div class="box">
                 <p>So Luong</p>
                 <asp:Label ID="lblErrorMessage" runat="server" Text="Label" Visible="False"></asp:Label>
                 <asp:TextBox ID="TextBox8" CssClass="txt" runat="server" ReadOnly="True"></asp:TextBox>
                 <asp:TextBox ID="TextBox9" CssClass="txt" runat="server" Visible="False"></asp:TextBox>
                 
                 <asp:TextBox ID="aisod" runat="server" Visible="False"></asp:TextBox>
             </div>
             
         </nav>
     </div>
     <div class="btn">
         <%--<asp:Button ID="Button1" runat="server" CssClass="txtBtn" Text="MuonSach"  onclientclick="return false;" />--%>
         <a  id="myBtn" class="aBtn" >MuonSach</a>
         <asp:Button ID="Button2" runat="server" CssClass="txtBtn" Text="TraSach" OnClick="Button2_Clickn" />
         <asp:Button ID="Button3" runat="server" CssClass="txtBtn" Text="GiaHan" OnClick="Button3_Click" />
         <asp:Button ID="Button4" runat="server" CssClass="txtBtn" Text="Xoa" OnClick="Button4_Click" />
     </div>
 </div>
    <%-- popUp form --%>
      <%-- <button id="myBtn">Open Modal</button>--%>
       
    <%--<asp:Button ID="myBtn" runat="server" Text="Sign In" OnClientClick="return false;" />--%>

    <div id="myModal" class="modal" >

        <div class="container">
            <!-- Modal content -->
            <div class="modal-content">
                <div class="modal-header">
                    <!-- <span class="close">&times;</span> -->
                    <h2>Phieu Muon</h2>
                </div>
                <div class="modal-body">
    <fieldset id="formMS">
        <label for="idm">ID_Muon</label><br>
        <asp:TextBox ID="idm" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvIDM" runat="server" ControlToValidate="idm"
            ErrorMessage="ID_Muon is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <br>

        <label for="tdg">Ten Doc Gia</label><br>
        <asp:DropDownList ID="tdg" AutoPostBack="false" CssClass="longInput" runat="server">
            
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvTDG" runat="server" ControlToValidate="tdg"
            InitialValue="" ErrorMessage="Ten Doc Gia is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <br>

        <label for="ts">Ten Sach</label><br>
        <asp:DropDownList ID="ts" AutoPostBack="false" CssClass="longInput" runat="server">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvTS" runat="server" ControlToValidate="ts"
            InitialValue="" ErrorMessage="Ten Sach is required." ForeColor="Red"></asp:RequiredFieldValidator>
        <br>

        <label for="nm">Ngay Muon</label><br>     
            <asp:TextBox ID="nm" runat="server"></asp:TextBox>
            
                <asp:RequiredFieldValidator ID="rfvNM" runat="server" ControlToValidate="nm"
                    ErrorMessage="Ngay Muon is required." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator> 
                <asp:RegularExpressionValidator ID="revNM" runat="server" ControlToValidate="nm"
                    ErrorMessage="Invalid date format (dd/MM/yyyy)." ValidationExpression="^\d{2}/\d{2}/\d{4}$" ForeColor="Red" Display="Dynamic" ValidationGroup="Form1Validation"></asp:RegularExpressionValidator>       

       
        <br />
        <label for="nht">Ngay Hen Tra</label><br>
        <asp:TextBox ID="nht" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvNHT" runat="server" ControlToValidate="nht"
                ErrorMessage="Ngay Hen Tra is required." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revNHT" runat="server" ControlToValidate="nht"
                ErrorMessage="Invalid date format (dd/MM/yyyy)." ValidationExpression="^\d{2}/\d{2}/\d{4}$" ForeColor="Red" Display="Dynamic" ValidationGroup="Form1Validation"></asp:RegularExpressionValidator>
        
        <br />
        <label for="slm">So Luong</label><br>
        <asp:TextBox ID="slm" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator ID="rfvSLM" runat="server" ControlToValidate="slm"
                ErrorMessage="So Luong is required." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvSLM" runat="server" ControlToValidate="slm"
                MinimumValue="1" MaximumValue="100" Type="Integer" ErrorMessage="So Luong must be between 1 and 100." ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
       <br />
        
        
    </fieldset>
</div>

                <div class="modal-footer">
                    <%--<button class="btnF">MuonSach</button>--%>
                    <asp:Button ID="Button5" runat="server" CssClass="btnF" Text="MuonSach" OnClick="Button5_Click" />
                    <button class="btnF" id="exit">Cancel</button>
                </div>
            </div>
        </div>

    </div>

 <div class="grid0">
     <div class="grid">
         <asp:GridView ID="GridView1" runat="server" CssClass="custom-gridview" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="2" OnRowDataBound="GridView1_RowDataBound" AllowHorizontalScroll="true" OnRowCommand="GridView1_RowCommand" Width="739px">
             <Columns>
                  <asp:ButtonField ButtonType="Button" Text="Choose" CommandName="Select"/>
             </Columns>
         </asp:GridView>
     </div>
 </div>


     <script>
         // Get the modal
         var modal = document.getElementById("myModal");

         // Get the button that opens the modal
         //var btn = document.getElementById("myBtn");
         <%--var buttonID = '<%= Button1.ClientID %>';--%>
         var btn = document.getElementById("myBtn");

         // Get the <span> element that closes the modal
         // var span = document.getElementsByClassName("close")[0];
         var span = document.getElementById("exit");

         // When the user clicks the button, open the modal 
         btn.onclick = function () {
             modal.style.display = "block";
         }

         // When the user clicks on <span> (x), close the modal
         span.onclick = function () {
             modal.style.display = "none";
         }

         // When the user clicks anywhere outside of the modal, close it
         window.onclick = function (event) {
             if (event.target == modal) {
                 modal.style.display = "none";
             }
         }
     </script>
</asp:Content>
