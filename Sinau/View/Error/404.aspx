<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="Sinau.View.Error.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error 404</title>
    <link href="../CSS/Error/ErrorStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="container">
                <div class="icon-error">
                    <img src="../Assets/Error/404.png" alt="Error 404" />
                </div>

                <div class="title">
                    <h1>404</h1>
                    <h3>Page Not Found</h3>
                </div>

                <div class="description">
                    <p>
                        Oops! Sorry about that, we couldn't find the page you are looking for
                    </p>
                </div>

                <div class="home-button">
                    <asp:Button Text="Back to Home" runat="server" ID="btnHome" CssClass="button" OnClick="btnHome_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
