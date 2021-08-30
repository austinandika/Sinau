<%@ Page Title="" Language="C#" MasterPageFile="~/View/Teacher/Master.Master" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="Sinau.View.Teacher.Forum" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Teacher/ForumStyle.css" rel="stylesheet" />
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

    <div class="upper-container">
        <div class="forum-filter-container">
            <table>
                <tr>
                    <td>Class</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlClass" CssClass="ddl" AutoPostBack="true">
                            <asp:ListItem Text="XII SCIENCE 1" />
                            <asp:ListItem Text="XII SCIENCE 2" />
                            <asp:ListItem Text="XII SOCIAL 1" />
                            <asp:ListItem Text="XII SOCIAL 2" />
                        </asp:DropDownList>
                    </td>

                    <td>Subject</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSubjectFilter" AutoPostBack="true" CssClass="ddl">
                            <asp:ListItem Text="Mathematics For XII" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>

        <div class="add-thread-container">
            <asp:Button Text="Add Thread" ID="btnAddThread" CssClass="btn-add-thread button-design" OnClientClick="return false;" runat="server" />
        </div>
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
                                <asp:Label Text="Brian Samuel" ID="lblThreadWriterMain" runat="server" />
                                <div class="role teacher">
                                    <asp:Label Text="Teacher" ID="lblRoleMain" runat="server" />
                                </div>
                            </div>
                            <div class="thread-time">
                                <asp:Label Text="3h ago" ID="lblThreadCreatedTimeMain" runat="server" />
                            </div>
                        </div>
                        <div class="middle-side">
                            <asp:Label Text="Question about gravity topics" ID="lblThreadTitleMain" runat="server" />
                        </div>
                        <div class="bottom-side">
                            <div class="count-reply">
                                <i class="fa fa-comment-o" aria-hidden="true"></i>
                                <asp:Label Text="3" ID="lblCountReplyMain" runat="server" />
                            </div>
                            <div class="thread-subject">
                                <asp:Label Text="Physics" ID="lblThreadSubjectMain" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </a>

            <%-- BATASSSSS --%>
            <a href="#" class="thread-text">
                <div class="row">
                    <div class="left-thread">
                        <img src="../Assets/ForumDiscussion.png" alt="Forum Discussion" />
                    </div>

                    <div class="right-thread">
                        <div class="top-side">
                            <div class="thread-writer">
                                <asp:Label Text="Brian Samuel" ID="Label9" runat="server" />
                                <div class="role teacher">
                                    <asp:Label Text="Teacher" ID="Label10" runat="server" />
                                </div>
                            </div>
                            <div class="thread-time">
                                <asp:Label Text="3h ago" ID="Label11" runat="server" />
                            </div>
                        </div>
                        <div class="middle-side">
                            <asp:Label Text="Question about gravity topics" ID="Label12" runat="server" />
                        </div>
                        <div class="bottom-side">
                            <div class="count-reply">
                                <i class="fa fa-comment-o" aria-hidden="true"></i>
                                <asp:Label Text="3" ID="Label17" runat="server" />
                            </div>
                            <div class="thread-subject">
                                <asp:Label Text="Physics" ID="Label18" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </a>

            <a href="#" class="thread-text">
                <div class="row">
                    <div class="left-thread">
                        <img src="../Assets/ForumDiscussion.png" alt="Forum Discussion" />
                    </div>

                    <div class="right-thread">
                        <div class="top-side">
                            <div class="thread-writer">
                                <asp:Label Text="Brian Samuel" ID="Label25" runat="server" />
                                <div class="role teacher">
                                    <asp:Label Text="Teacher" ID="Label26" runat="server" />
                                </div>
                            </div>
                            <div class="thread-time">
                                <asp:Label Text="3h ago" ID="Label27" runat="server" />
                            </div>
                        </div>
                        <div class="middle-side">
                            <asp:Label Text="Question about gravity topics" ID="Label28" runat="server" />
                        </div>
                        <div class="bottom-side">
                            <div class="count-reply">
                                <i class="fa fa-comment-o" aria-hidden="true"></i>
                                <asp:Label Text="2" ID="Label29" runat="server" />
                            </div>
                            <div class="thread-subject">
                                <asp:Label Text="Physics" ID="Label30" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </a>

            <a href="#" class="thread-text">
                <div class="row">
                    <div class="left-thread">
                        <img src="../Assets/ForumDiscussion.png" alt="Forum Discussion" />
                    </div>

                    <div class="right-thread">
                        <div class="top-side">
                            <div class="thread-writer">
                                <asp:Label Text="Brian Samuel" ID="Label19" runat="server" />
                                <div class="role teacher">
                                    <asp:Label Text="Teacher" ID="Label20" runat="server" />
                                </div>
                            </div>
                            <div class="thread-time">
                                <asp:Label Text="3h ago" ID="Label21" runat="server" />
                            </div>
                        </div>
                        <div class="middle-side">
                            <asp:Label Text="Question about gravity topics" ID="Label22" runat="server" />
                        </div>
                        <div class="bottom-side">
                            <div class="count-reply">
                                <i class="fa fa-comment-o" aria-hidden="true"></i>
                                <asp:Label Text="2" ID="Label23" runat="server" />
                            </div>
                            <div class="thread-subject">
                                <asp:Label Text="Physics" ID="Label24" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </a>
        </div>

        <div class="right-forum-container">
            <div class="thread-content">
                <div class="top-side">
                    <div class="thread-writer">
                        <asp:Label Text="Brian Samuel" ID="lblThreadWriter" runat="server" />
                        <div class="role teacher">
                            <asp:Label Text="Teacher" ID="lblRole" runat="server" />
                        </div>
                    </div>
                    <div class="thread-time">
                        <asp:Label Text="3h ago" ID="lblThreadCreatedTime" runat="server" />
                    </div>
                </div>
                <div class="middle-side">
                    <asp:Label Text="Question about gravity topics" ID="lblThreadTitle" runat="server" />
                    <div class="thread-description">
                        <asp:Label Text="A woman stands on the edge of a cliff and drops two rocks, one of mass m and one of 3m, from the same height. Which one experiences the greater acceleration?" ID="lblThreadDescription" runat="server" />
                    </div>
                </div>
                <div class="bottom-side">
                    <div class="count-reply">
                        <i class="fa fa-comment-o" aria-hidden="true"></i>
                        <asp:Label Text="2" ID="lblCountReply" runat="server" />
                    </div>
                    <div class="thread-subject">
                        <asp:Label Text="Physics" ID="lblThreadSubject" runat="server" />
                    </div>
                    <div class="thread-reply">
                        <asp:LinkButton runat="server" ID="btnThreadReply" CssClass="btn-reply-thread">
                            <asp:Label Text="Reply" runat="server" />
                            <i class="fa fa-reply" aria-hidden="true" style="transform: rotateX(180deg)"></i>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>


            <%-- DISCUSSION --%>
            <div class="discussion-content other-reply">
                <div class="top-side">
                    <div class="discussion-writer">
                        <asp:Label Text="Austin Andika Tanujaya" ID="lblDiscussionWriter" runat="server" />
                        <div class="role">
                            <asp:Label Text="Student" ID="lblDiscussionRole" runat="server" />
                        </div>
                    </div>
                    <div class="discussion-time">
                        <asp:Label Text="3h ago" ID="lblDiscussionTime" runat="server" />
                    </div>
                </div>
                <div class="middle-side">
                    <asp:Label Text="My answer" ID="lblDiscussionTitle" runat="server" />
                    <div class="discussion-description">
                        <asp:Label Text="Weight measures the force of gravity pulling downward on an object. The SI unit for weight, like other forces, is the Newton (N).<br>Even though the rocks have different masses, the acceleration on both will be g, the acceleration due to gravity. So, they experience the same acceleration" ID="lblDiscussionDescription" runat="server" />
                    </div>
                </div>
                <div class="bottom-side">
                    <div class="discussion-reply">
                        <asp:LinkButton runat="server" ID="btnDiscussionReply" CssClass="btn-reply-discussion">
                            <asp:Label Text="Reply" runat="server" />
                            <i class="fa fa-reply" aria-hidden="true" style="transform: rotateX(180deg)"></i>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>


            <%-- BATASSSS --%>
            <div class="discussion-content other-reply">
                <div class="top-side">
                    <div class="discussion-writer">
                        <asp:Label Text="Santi Sinta" ID="Label1" runat="server" />
                        <div class="role">
                            <asp:Label Text="Student" ID="Label2" runat="server" />
                        </div>
                    </div>
                    <div class="discussion-time">
                        <asp:Label Text="3h ago" ID="Label3" runat="server" />
                    </div>
                </div>
                <div class="middle-side">
                    <asp:Label Text="My answer" ID="Label4" runat="server" />
                    <div class="discussion-description">
                        <asp:Label Text="Weight measures the force of gravity pulling downward on an object. The SI unit for weight, like other forces, is the Newton (N).<br>Even though the rocks have different masses, the acceleration on both will be g, the acceleration due to gravity. So, they experience the same acceleration" ID="Label5" runat="server" />
                    </div>
                </div>
                <div class="bottom-side">
                    <div class="discussion-reply">
                        <asp:LinkButton runat="server" ID="LinkButton1" CssClass="btn-reply-discussion">
                            <asp:Label Text="Reply" runat="server" />
                            <i class="fa fa-reply" aria-hidden="true" style="transform: rotateX(180deg)"></i>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>

            <div class="discussion-content my-reply">
                <div class="top-side">
                    <div class="discussion-writer">
                        <asp:Label Text="Brian Samuel" ID="Label31" runat="server" />
                        <div class="role teacher">
                            <asp:Label Text="Teacher" ID="Label32" runat="server" />
                        </div>
                    </div>
                    <div class="discussion-time">
                        <asp:Label Text="3h ago" ID="Label33" runat="server" />
                    </div>
                </div>
                <div class="middle-side">
                    <asp:Label Text="Thankyou" ID="Label34" runat="server" />
                    <div class="discussion-description">
                        <asp:Label Text="Thankyou all for you answer." ID="Label35" runat="server" />
                    </div>
                </div>
                <div class="bottom-side">
                    <div class="discussion-reply">
                        <asp:LinkButton runat="server" ID="LinkButton2" CssClass="btn-reply-discussion">
                            <asp:Label Text="Reply" runat="server" />
                            <i class="fa fa-reply" aria-hidden="true" style="transform: rotateX(180deg)"></i>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <%-- POPUP ADD THREAD --%>
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlAddThread" TargetControlID="btnAddThread"
        CancelControlID="btnCancel" BackgroundCssClass="popup-background">
    </cc1:ModalPopupExtender>


    <asp:Panel ID="pnlAddThread" runat="server" align="center" Style="display: none">

        <div class="popup-container">
            <div class="user-input">
                <div class="title">
                    <h1>Add Thread</h1>
                </div>

                <div class="error-server-container">
                    <asp:Label Text="" runat="server" ID="lblErrorServer" />
                </div>


                <div class="form-table">
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="Class" runat="server" ID="lblClassPopup" />
                                </div>


                                <div class="input-error-box">
                                    <div class="input-box">

                                        <asp:DropDownList runat="server" ID="ddlClassPopup" CssClass="ddl" AutoPostBack="true">
                                        </asp:DropDownList>

                                    </div>

                                    <div class="error-box">
                                        <asp:Label Text="" runat="server" ID="lblErrorPopup" />
                                    </div>
                                </div>
                            </div>



                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="Subject" runat="server" ID="lblSubjectPopup" />
                                </div>

                                <div class="input-error-box">
                                    <div class="input-box">
                                        <asp:DropDownList runat="server" ID="ddlSubjectPopup" CssClass="ddl">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="error-box">
                                        <asp:Label Text="" runat="server" ID="lblErrorSubject" />
                                    </div>
                                </div>
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClassPopup" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Thread Title" runat="server" ID="lblThreadPopup" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:TextBox ID="txtThreadTitle" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="lblErrorThreadTitle" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Description" runat="server" ID="Label6" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:TextBox ID="txtThreadDescription" CssClass="textbox" runat="server" TextMode="MultiLine" Height="150px"></asp:TextBox>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="Label7" />
                            </div>
                        </div>
                    </div>
                </div>


                <div class="button-container">
                    <asp:Button Text="Cancel" runat="server" ID="btnCancel" CssClass="button-create button-design" />
                    <asp:Button Text="Create" runat="server" ID="btnCreate" CssClass="button-create button-design" />
                </div>
            </div>
        </div>

    </asp:Panel>



    <%-- POPUP REPLY THREAD --%>
    <cc1:ModalPopupExtender ID="mp2" runat="server" PopupControlID="pnlAddReply" TargetControlID="btnThreadReply"
        CancelControlID="btnCancel" BackgroundCssClass="popup-background">
    </cc1:ModalPopupExtender>

    <cc1:ModalPopupExtender ID="mp3" runat="server" PopupControlID="pnlAddReply" TargetControlID="btnDiscussionReply"
        CancelControlID="btnCancel" BackgroundCssClass="popup-background">
    </cc1:ModalPopupExtender>

    <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlAddReply" TargetControlID="LinkButton1"
        CancelControlID="btnCancel" BackgroundCssClass="popup-background">
    </cc1:ModalPopupExtender>

    <cc1:ModalPopupExtender ID="mp4" runat="server" PopupControlID="pnlAddReply" TargetControlID="LinkButton2"
        CancelControlID="btnCancel" BackgroundCssClass="popup-background">
    </cc1:ModalPopupExtender>


    <asp:Panel ID="pnlAddReply" runat="server" align="center" Style="display: none">

        <div class="popup-container">
            <div class="user-input">
                <div class="title">
                    <h1>Add Reply</h1>
                </div>

                <div class="error-server-container">
                    <asp:Label Text="" runat="server" ID="Label8" />
                </div>


                <div class="form-table">
                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Title" runat="server" ID="Label13" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:TextBox ID="TextBox1" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="Label14" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Description" runat="server" ID="Label15" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:TextBox ID="TextBox2" CssClass="textbox" runat="server" TextMode="MultiLine" Height="150px"></asp:TextBox>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="Label16" />
                            </div>
                        </div>
                    </div>
                </div>


                <div class="button-container">
                    <asp:Button Text="Cancel" runat="server" ID="btnCancel2" CssClass="button-create button-design" />
                    <asp:Button Text="Reply" runat="server" ID="Button2" CssClass="button-create button-design" />
                </div>
            </div>
        </div>

    </asp:Panel>
</asp:Content>
