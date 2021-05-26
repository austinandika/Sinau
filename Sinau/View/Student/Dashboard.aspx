<%@ Page Title="Dashboard - SINAU" Language="C#" MasterPageFile="~/View/Student/Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Sinau.View.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Student/DashboardStyle.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/MainStyle.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="greeting">
        <div class="greeting-text">
            <p>
                &#128075;
                <asp:Label Text="" runat="server" ID="lblGreeting" />
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
                        Upcoming Assignment
                    </div>

                    <div class="assignment-table-container">

                        <div class="no-assignment-div" id="noAssignment" runat="server">
                            <h3>YEAY. You have no assignment left &#129303</h3>
                        </div>

                        <table>
                            <asp:Repeater ID="rptUpcomingAssignment" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label Text='<%# Eval("_Subject") %>' ID="lblSubject" runat="server" />
                                        </td>

                                        <td>
                                            <asp:Label Text='<%# Eval("_AssignmentTitle") %>' ID="lblAssignmentTitle" runat="server" />
                                        </td>

                                        <td>
                                            <asp:Label Text='<%# Eval("_DueDate") %>' ID="lblDeadline" runat="server" />
                                        </td>

                                        <td>
                                            <asp:Button ID="btnViewAssignment" Text="View" runat="server" CssClass="view-assignment-button button-design" PostBackUrl="~/View/Student/Assignment.aspx" />
                                        </td>
                                    </tr>

                                </ItemTemplate>
                            </asp:Repeater>
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
                        <div class="no-schedule-div" id="noScheduleDay" runat="server">
                            <h3>It's FREE. You have no class schedule for today<br />&#129303</h3>
                        </div>

                        <table>
                            <asp:Repeater ID="rptScheduleToday" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <asp:Label Text='<%# Eval("_SubjectName") %>' ID="lblCourseName" runat="server" />
                                        </td>

                                        <td>
                                            <asp:Label Text='<%# Eval("_TimeStart") + " - " + Eval("_TimeEnd") %>' ID="lblCourseTime" runat="server" />
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button button-design" PostBackUrl='<%# Eval("_LinkVidcon") %>' OnClientClick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);" />
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>

                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="../Javascript/Dashboard-Slideshow.js"></script>


</asp:Content>
