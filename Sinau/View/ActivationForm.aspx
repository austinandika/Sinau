<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivationForm.aspx.cs" Inherits="Sinau.View.ActivationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="CSS/ActivationFormStyle.css" rel="stylesheet" type="text/css" />
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
                        ACTIVATION FORM
                    </div>

                    <div class="activation-validation">
                        <div class="input-command">
                            <asp:Label Text="NISN/NIGN" runat="server" ID="lblUserID" />
                        </div>

                        <div class="input-box">
                            <asp:TextBox ID="txtUserID" runat="server" CssClass="textbox"></asp:TextBox>
                        </div>

                        <div class="input-command">
                            <asp:Label Text="Activation Code" runat="server" ID="lblActivationCode" />
                        </div>

                        <div class="input-box">
                            <asp:TextBox ID="txtActivationCode" runat="server" CssClass="textbox"></asp:TextBox>
                        </div>

                        <div class="validate-button">
                            <asp:Button Text="Validate" runat="server" ID="btnValidate" CssClass="button" />
                        </div>
                    </div>

                    <div class="input-command">
                        <asp:Label Text="Full Name" runat="server" ID="lblFullName" />
                    </div>

                    <div class="input-box">
                        <asp:TextBox ID="txtFullName" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                    </div>

                    <div class="input-command">
                        <asp:Label Text="Email" runat="server" ID="lblEmail" />
                    </div>

                    <div class="input-box">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>

                    <div class="input-command">
                        <asp:Label Text="Password" runat="server" ID="lblPassword" />
                    </div>

                    <div class="input-box">
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>

                    <div class="input-command">
                        <asp:Label Text="Confirm Password" runat="server" ID="lblConfirmPassword" />
                    </div>

                    <div class="input-box">
                        <asp:TextBox ID="TxtConfirmPassword" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>
                </div>

                <div class="activate-button">
                    <asp:Button Text="Activate" runat="server" ID="btnLogin" CssClass="button" />
                </div>

                <div class="login-account">
                    Already activate your account? <a href="#">Login</a>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
