<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Sinau.View.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - SINAU</title>
    <link href="CSS/LoginStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
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

                    <div class="error-server-container" id="errorServerContainer" runat="server">
                        <asp:Label Text="" runat="server" ID="lblErrorServer" />
                    </div>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Email" runat="server" ID="lblEmail" />
                        </div>

                        <div class="input-box">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" placeholder="Type your email"></asp:TextBox>
                            <i class="fa fa-user"></i>
                        </div>

                        <div class="error-container">
                            <asp:Label Text="" runat="server" CssClass="lbl-error" ID="lblErrorEmail" />
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Password" runat="server" ID="lblPassword" />
                        </div>

                        <div class="input-box">
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textbox" placeholder="Type your password"></asp:TextBox>
                            <i class="fa fa-lock"></i>
                        </div>

                        <div class="error-container">
                            <asp:Label Text="" runat="server" CssClass="lbl-error" ID="lblErrorPassword" />
                        </div>
                    </div>



                    <div class="login-button">
                        <asp:Button Text="Login" runat="server" ID="btnLogin" CssClass="button" OnClientClick="return validateLogin();" OnClick="btnLogin_Click" />
                    </div>

                    <div class="activate-account">
                        Haven't activate your account? <a href="ActivationForm.aspx">Activate Now</a>
                    </div>

                </div>
            </div>
        </div>
    </form>
</body>

<script src="Javascript/Login-Validation.js"></script>
</html>
