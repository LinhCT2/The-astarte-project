<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Library_Management_dev_prc_linh.menu.login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Sign In/Up Form</title>
    <link href="login1.css" rel="stylesheet" type="text/css"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.1/css/all.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <h2>The Astate Project</h2>
        <div class="container" id="container">
            <div class="form-container sign-up-container">
           
                
                
                <%--<div class="social-container">
                    <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
                    <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
                    <a href="#" class="social"><i class="fab fa-linkedin-in"></i></a>
                </div>
                <span>or use your email for registration</span>--%>
               <%-- <input type="text" placeholder="User" />
                <input type="password" placeholder="Old Password" />
                <input type="password" placeholder="New Password" />
                <input type="password" placeholder="Confirm New Password" />--%>
            <form action="#">
                <%-- doan nay HTML khong nhan form nay nen CSS khong chay duoc--%>
                <h1>Change Password</h1>
                <asp:TextBox ID="TextBox1" placeholder="User" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox2" placeholder="Old Password" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox3" placeholder="New Password" runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox4" placeholder="Confirm New Password" runat="server"></asp:TextBox>
                <%--<button>Change Password</button>--%>
                <p><asp:Button ID="Button1" runat="server" CssClass="ghostFA" Text="Change Password" /></p>
            </form>
        </div>
        <div class="form-container sign-in-container">
            <form action="#">
                <%-- nhung form nay thi HTML lai nhan dien duoc--%>
                <h1>Sign in</h1>
                <div class="social-container">
                    <a href="#" class="social"><i class="fab fa-facebook-f"></i></a>
                    <a href="#" class="social"><i class="fab fa-google-plus-g"></i></a>
                    <a href="#" class="social"><i class="fab fa-linkedin-in"></i></a>
                </div>
                <span>or use your account</span>
                <%--<input type="email" placeholder="User" />
                <input type="password" placeholder="Password" />--%>
                <%--<a href="#">Forgot your password?</a>--%>
                <%--<button>Sign In</button>--%>
                <asp:TextBox ID="TextBox5" placeholder="User"  runat="server"></asp:TextBox>
                <asp:TextBox ID="TextBox6" placeholder="Password" runat="server"></asp:TextBox>
                <p><asp:Button ID="Button2" runat="server" CssClass="ghostFA" Text="Sign In" /></p>
            </form>
        </div>
            <div class="overlay-container">
                <div class="overlay">
                    <div class="overlay-panel overlay-left">
                        <h1>Change your password</h1>
                        <p>To keep connected with us please login with your account info</p>
                        <%--<button class="ghost" id="signIn">Sign In</button>--%>
                        <asp:Button ID="signInOverlay" runat="server" Text="Sign In" CssClass="ghost1" OnClientClick="return false;" />
                    </div>
                    <div class="overlay-panel overlay-right">
                        <h1>Hello, Librarian!</h1>
                        <p>Enter your account details and start journey with us</p>
                        <%--<button class="ghost" id="signUp">Sign Up</button>--%>
                       <p><asp:Button ID="signUpOverlay" runat="server" Text="Change Password" CssClass="ghost1" OnClientClick="return false;" /></p> 
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
    <script lang="javascript" type="text/javascript">
        document.addEventListener('DOMContentLoaded', function () {
            const signUpButton = document.getElementById('<%= signUpOverlay.ClientID %>');
            const signInButton = document.getElementById('<%= signInOverlay.ClientID %>');
            const container = document.getElementById('container');
            const signUpForm = document.querySelector('.sign-up-container');
            const signInForm = document.querySelector('.sign-in-container');

            signUpButton.addEventListener('click', () => {
                
                container.classList.add("right-panel-active");
                signUpForm.style.display = "block";
                signInForm.style.display = "none";
            });

            signInButton.addEventListener('click', () => {
                container.classList.remove("right-panel-active");
                
                signInForm.style.display = "block";
            });

            
        });
    </script>
</body>
</html>
