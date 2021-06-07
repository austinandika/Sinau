<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivationForm.aspx.cs" Inherits="Sinau.View.ActivationForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Activate Account - SINAU</title>

    <link href="CSS/ActivationFormStyle.css" rel="stylesheet" type="text/css" />
    <script src="Javascript/jquery-3.5.1.min.js"></script>
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

                    <div class="error-server-container" id="errorServerContainer" runat="server">
                        <asp:Label Text="" runat="server" ID="lblErrorServer" />
                    </div>

                    <div class="validation-container">
                        <asp:Panel runat="server" ID="pnlValidateBtn" DefaultButton="btnValidate">
                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="NISN/NIGN" runat="server" ID="lblUserID" />
                                </div>

                                <div class="input-box">
                                    <asp:TextBox ID="txtUserID" runat="server" CssClass="textbox"></asp:TextBox>
                                </div>

                                <div class="error-container">
                                    <asp:Label Text="" runat="server" CssClass="lbl-error" ID="lblErrorID" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="Activation Code" runat="server" ID="lblActivationCode" />
                                </div>

                                <div class="input-box">
                                    <asp:TextBox ID="txtActivationCode" runat="server" CssClass="textbox"></asp:TextBox>
                                </div>

                                <div class="error-container">
                                    <asp:Label Text="" runat="server" CssClass="lbl-error" ID="lblErrorActivationCode" />
                                </div>
                            </div>

                            <div class="validate-button">
                                <asp:Button Text="Validate" runat="server" ID="btnValidate" CssClass="button" OnClientClick="return validateUserValidation();" OnClick="btnValidate_Click" />
                            </div>
                        </asp:Panel>
                    </div>

                    <div class="activation-container" id="activationContainer" runat="server">
                        <asp:Panel runat="server" ID="pnlActivationBtn" DefaultButton="btnActivate">
                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="Full Name" runat="server" ID="lblFullName" />
                                </div>

                                <div class="input-box">
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="Email" runat="server" ID="lblEmail" />
                                </div>

                                <div class="input-box">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox"></asp:TextBox>
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
                                    <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox>
                                </div>

                                <div class="error-container">
                                    <asp:Label Text="" runat="server" CssClass="lbl-error" ID="lblErrorPassword" />
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="Confirm Password" runat="server" ID="lblConfirmPassword" />
                                </div>

                                <div class="input-box">
                                    <asp:TextBox ID="TxtConfirmPassword" TextMode="Password" runat="server" CssClass="textbox"></asp:TextBox>
                                </div>

                                <div class="error-container">
                                    <asp:Label Text="" runat="server" CssClass="lbl-error" ID="lblErrorConfirmPassword" />
                                </div>
                            </div>

                            <div class="activate-button">
                                <asp:Button Text="Activate" OnClientClick="return validateUserActivation();" OnClick="btnActivate_Click" runat="server" ID="btnActivate" CssClass="button" />
                            </div>
                        </asp:Panel>
                    </div>

                    <div class="login-account">
                        Already activate your account? <a href="Login.aspx">Login</a>
                    </div>

                </div>
            </div>
        </div>

    </form>
</body>

<script src="Javascript/ActivationForm-Validation.js"></script>
</html>
