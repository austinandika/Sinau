<%@ Page Title="" Language="C#" MasterPageFile="~/View/Student/Master.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="Sinau.View.Student.Forum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Student/ForumStyle.css" rel="stylesheet" />
    <link href="../CSS/MainStyle.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="error-main" runat="server" id="errorMain">
        <i class="fa fa-check-circle-o" id="successIcon" runat="server" aria-hidden="true"></i>
        <i class="fa fa-times-circle-o" id="errorIcon" runat="server" aria-hidden="true"></i>
        <div class="divtext-error-main" runat="server" id="divErrorMain"></div>
        <asp:Label Text="" CssClass="lbl-error-main" ID="lblErrorMain" runat="server" Visible="false" />
    </div>

    <div class="title-container">
        <div class="vertical-line">
        </div>

        <div class="title-name">
            <h2>Forum</h2>
        </div>


    </div>

    <div class="search-bar-container">
        <asp:TextBox runat="server" ID="txtSearch" CssClass="txt-search" placeholder="Search for Topics" />
        <i class="fa fa-search"></i>
    </div>

    <div class="forum-filter-container">
        <table>
            <tr>
                <td>Class</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlClass" CssClass="ddl" AutoPostBack="true">
                    </asp:DropDownList>
                </td>

                <td>Subject</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSubjectFilter" AutoPostBack="true" CssClass="ddl">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>

    <div class="forum-container">
        <div class="left-thread-container">
            <a href="#" class="thread-text">
                <div class="row selected">
                    <div class="left-thread">
                        <img src="../Assets/ForumDiscussion.png" alt="Forum Discussion" />
                    </div>

                    <div class="right-thread">
                        <div class="top-side">
                            <div class="thread-writer">
                                <asp:Label Text="Austin Andika Tanujaya" ID="lblThreadWriter" runat="server" />
                            </div>
                            <div class="thread-time">
                                <asp:Label Text="3h ago" ID="lblThreadCreatedTime" runat="server" />
                            </div>
                        </div>
                        <div class="middle-side">
                            <asp:Label Text="Question about gravity topics" ID="lblThreadTitle" runat="server" />
                        </div>
                        <div class="bottom-side">
                            <div class="count-reply">
                                <i class="fa fa-comment-o" aria-hidden="true"></i>
                                <asp:Label Text="20" ID="lblCountReply" runat="server" />
                            </div>
                            <div class="thread-subject">
                                <asp:Label Text="Physics" ID="lblThreadSubject" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </a>


        </div>

        <div class="right-forum-container">
            <div class="thread-content">

            </div>
        </div>
    </div>
</asp:Content>
