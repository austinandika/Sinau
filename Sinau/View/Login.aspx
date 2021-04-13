<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sinau.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/LoginStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="container">
                <div class="logo">
                    <h1>SINAU</h1>
                </div>

                <div class="user-input">
                    <div class="title">
                        LOGIN
                    </div>

                    <div class="input-command">
                        <asp:Label Text="Email" runat="server" ID="lblEmail" />
                    </div>

                    <div class="input-box">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" placeholder="&#xf007;&nbsp;&nbsp;&nbsp;Type your email" ></asp:TextBox>
                    </div>

                    <div class="input-command">
                        <asp:Label Text="Password" runat="server" ID="lblPassword" />
                    </div>

                    <div class="input-box">
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textbox" placeholder="&#xf023;&nbsp;&nbsp;&nbsp;Type your password"></asp:TextBox>
                    </div>
                </div>

                <div class="login-button">
                    <asp:Button Text="Login" runat="server" ID="btnLogin" CssClass="button" />
                </div>

                <div class="activate-account">
                    Haven't activate your account? <a href="#">Activate Now</a>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
