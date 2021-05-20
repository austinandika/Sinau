<%@ Page Title="Dashboard - SINAU" Language="C#" MasterPageFile="~/View/Teacher/Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Sinau.View.Teacher.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Teacher/DashboardStyle.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/MainStyle.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="greeting">
        <div class="greeting-text">
            <p>
                &#128075;
                <asp:Label Text="Hello, " runat="server" ID="lblGreeting" />
            </p>
        </div>
    </div>

    <div class="content">
        <div class="left-content">
            <div class="information-container">
                <div class="info-image-container">
                    <img src="../Assets/Test-Banner2.png" class="slide" alt="" />
                </div>

                <div class="info-image-container">
                    <img src="../Assets/Test-Banner.jpg" class="slide" alt="" />
                </div>
                

                <a class="prev-button" onclick="plusSlides(-1)">&#10094;</a>
                <a class="next-button" onclick="plusSlides(1)">&#10095;</a>

                <div class="dot-container">
                </div>
            </div>

            <div class="upcoming-assignment-container">
                <div class="inside-container">
                    <div class="title">
                        Upcoming Student Assignment
                    </div>

                    <div class="assignment-table-container">
                        <table>
                            <tr>

                                <td>
                                    <asp:Label Text="Biology" ID="lblSubject" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="DNA Structure" ID="lblAssignmentTitle" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="XII MIPA 1" ID="lblAssignmentClass" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="June 23, 2020" ID="lblDeadline" runat="server" />
                                </td>

                                <td>
                                    <asp:Button ID="btnViewAssignment" Text="View" runat="server" CssClass="view-assignment-button button-design" />
                                </td>
                            </tr>

                            <%-- BATAS --%>

                            <tr>

                                <td>
                                    <asp:Label Text="Biology" ID="Label1" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="Structure of Human Body" ID="Label2" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="XI MIPA 3" ID="Label3" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="June 27, 2020" ID="Label4" runat="server" />
                                </td>

                                <td>
                                    <asp:Button ID="Button3" Text="View" runat="server" CssClass="view-assignment-button button-design" />
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>
            </div>
        </div>

        <div class="right-content">
            <div class="upcoming-course-container">
                <div class="inside-container">
                    <div class="title">
                        Today Course
                    </div>

                    <div class="course-table-container">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label Text="Biology" ID="lblCourseName" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="XII MIPA 1" ID="lblScheduleClass" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="07.00 - 08.30" ID="lblCourseTime" runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button button-design" />
                                </td>
                            </tr>


                            <%-- BATAS --%>
                            <tr>
                                <td>
                                    <asp:Label Text="Biology" ID="Label19" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="XII MIPA 2" ID="Label20" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="09.00 - 10.30" ID="Label21" runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button Text="Join" runat="server" ID="Button2" CssClass="join-class-button button-design" />
                                </td>
                            </tr>


                            <tr>
                                <td>
                                    <asp:Label Text="Biology" ID="Label22" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="X MIPA 1" ID="Label23" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="10.30 - 12.00" ID="Label24" runat="server" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Button Text="Join" runat="server" ID="Button1" CssClass="join-class-button button-design" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../Javascript/Dashboard-Slideshow.js"></script>
</asp:Content>
