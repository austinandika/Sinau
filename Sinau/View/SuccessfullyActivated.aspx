<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuccessfullyActivated.aspx.cs" Inherits="Sinau.View.SuccessfullyActivated" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS/SuccessfullyRegisteredStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="container">
                <div class="icon-success">
                    <i class="fa fa-check-circle" aria-hidden="true"></i>
                </div>

                <div class="title">
                    <h1>Activated Successfully</h1>
                </div>

                <div class="description">
                    <p>
                        You are successfully activated your account.<br />
                        Please login to access your account!
                    </p>
                </div>

                <div class="login-button">
                    <asp:Button Text="Login" runat="server" ID="btnLogin" CssClass="button" OnClick="btnLogin_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
