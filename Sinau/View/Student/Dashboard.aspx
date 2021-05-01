﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Student/Master.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Sinau.View.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Student/DashboardStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="greeting">
        <div class="greeting-text">
            <p>
                &#128075;
                <asp:Label Text="Hello, Austin!" runat="server" ID="lblGreeting" />
            </p>
        </div>
    </div>

    <div class="content">
        <div class="left-content">
            <div class="information-container">
                <div class="info-image-container">
                    <img src="../Assets/Test-Banner2.png" alt="" />
                </div>

                <div class="info-image-container">
                    <img src="../Assets/Test-Banner.jpg" alt="" />
                </div>
                

                <a class="prev-button" onclick="plusSlides(-1)">&#10094;</a>
                <a class="next-button" onclick="plusSlides(1)">&#10095;</a>

                <div class="dot-container">
                    <span class="slideshow-dot" onclick="currentSlide(1)"></span>
                    <span class="slideshow-dot" onclick="currentSlide(2)"></span>
                </div>
            </div>

            <div class="upcoming-assignment-container">
                <div class="inside-container">
                    <div class="title">
                        Upcoming Assignment
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
                                    <asp:Label Text="June 23, 2020" ID="lblDeadline" runat="server" />
                                </td>

                                <td>
                                    <asp:Button ID="btnViewAssignment" Text="View" runat="server" CssClass="view-assignment-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="Biology" ID="Label1" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="RNA Multiplication" ID="Label13" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="June 24, 2020" ID="Label2" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="View" runat="server" CssClass="view-assignment-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="Physics" ID="Label3" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="Newton's Law" ID="Label14" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="June 25, 2020" ID="Label4" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="View" runat="server" CssClass="view-assignment-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="Chemistry" ID="Label5" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="Periodic Table" ID="Label15" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="June 30, 2020" ID="Label6" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="View" runat="server" CssClass="view-assignment-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="Physics" ID="Label7" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="Newton's 2 Law" ID="Label16" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="July 1, 2020" ID="Label8" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="View" runat="server" CssClass="view-assignment-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="Physics" ID="Label9" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="Newton's 1 Law" ID="Label17" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="July 5, 2020" ID="Label10" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="View" runat="server" CssClass="view-assignment-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="Physics" ID="Label11" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="Newton's 3 Law" ID="Label18" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="July 10, 2020" ID="Label12" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="View" runat="server" CssClass="view-assignment-button" />
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
                                    <asp:Label Text="07.00 - 08.30" ID="lblCourseTime" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="Biology" ID="Label19" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="08.30 - 10.00" ID="Label20" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="Social Studies" ID="Label21" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="10.00 - 11.30" ID="Label22" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="English" ID="Label23" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="12.00 - 13.30" ID="Label24" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button" />
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <asp:Label Text="Mathematics" ID="Label25" runat="server" />
                                </td>

                                <td>
                                    <asp:Label Text="13.30 - 15.00" ID="Label26" runat="server" />
                                </td>

                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button" />
                                </td>
                            </tr>

                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        // SLIDESHOW
        var slideIndex = 1;
        var timer = null;
        showSlides(slideIndex);

        function plusSlides(n) {
            clearTimeout(timer);
            showSlides(slideIndex += n);
        }

        function currentSlide(n) {
            clearTimeout(timer);
            showSlides(slideIndex = n);
        }

        function showSlides(n) {
            var i;
            var slides = document.getElementsByClassName("info-image-container");
            var dots = document.getElementsByClassName("slideshow-dot");
            if (n == undefined) { n = ++slideIndex }
            if (n > slides.length) { slideIndex = 1 }
            if (n < 1) { slideIndex = slides.length }
            for (i = 0; i < slides.length; i++) {
                slides[i].style.display = "none";
            }
            for (i = 0; i < dots.length; i++) {
                dots[i].className = dots[i].className.replace(" active", "");
            }
            slides[slideIndex - 1].style.display = "block";
            dots[slideIndex - 1].className += " active";
            timer = setTimeout(showSlides, 5000);   // Change image every 5 seconds
        } 
    </script>


</asp:Content>