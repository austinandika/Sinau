<%@ Page Title="" Language="C#" MasterPageFile="~/View/Teacher/Master.Master" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="Sinau.View.Teacher.Assignment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Teacher/AssignmentStyle.css" rel="stylesheet" />
    <link href="../CSS/MainStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="title-container">
        <div class="vertical-line">
        </div>

        <div class="title-name">
            <h2>Assignment</h2>
        </div>
    </div>

    <div class="upper-container">
        <div class="assignment-filter-container">
            <table>
                <tr>
                    <td>Class</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlClass" CssClass="ddl">
                            <asp:ListItem Text="All" />
                            <asp:ListItem Text="XII MIPA 1" />
                            <asp:ListItem Text="XI MIPA 2" />
                            <asp:ListItem Text="XI MIPA 3" />
                        </asp:DropDownList>
                    </td>

                    <td>Subject</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSubjectFilter" CssClass="ddl">
                            <asp:ListItem Text="All" />
                            <asp:ListItem Text="Biology" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>

        <div class="edit-score-container">
            <asp:Button Text="Add Assignment" ID="btnAddAssignment" CssClass="btn-add-assignment button-design" OnClientClick="return false;" runat="server" />
        </div>
    </div>


    <div class="assignment-table-container">
        <div class="assignment-table-header">
            <div class="subject-column">Subject</div>
            <div class="title-column">Title</div>
            <div class="download-question-column"></div>
            <div class="date-column">Assign Date</div>
            <div class="date-column">Due Date</div>
            <div class="status-column">Status</div>
            <div class="action-column">Action</div>
        </div>

        <div class="assignment-table-content">
            <div class="subject-column">
                <asp:Label Text="Biology" runat="server" ID="lblSubject" />
            </div>

            <div class="title-column">
                <asp:Label Text="DNA Structure" runat="server" ID="lblAssignmentTitle" />
            </div>

            <div class="download-question-column">
                <asp:LinkButton ID="btnDownloadQuestion" runat="server">
                    <div class="btn-download-question">
                        <i class="fa fa-floppy-o" aria-hidden="true" title="Download the assignment question"></i>
                    </div>
                </asp:LinkButton>
            </div>

            <%-- Assign Date --%>
            <div class="date-column">
                <asp:Label Text="May 1, 2021" runat="server" ID="lblAssignDate" />
            </div>

            <%-- Due Date --%>
            <div class="date-column">
                <asp:Label Text="May 7, 2021" runat="server" ID="lblDueDate" />
            </div>

            <div class="status-column">
                <asp:Label Text="Waiting" runat="server" ID="lblStatus" />
            </div>

            <div class="action-column">
                <asp:LinkButton ID="btnDownloadAnswer" runat="server">
                    <div class="btn-download-answer">
                        <i class="fa fa-download" aria-hidden="true" title="Download all of the students answer"></i>
                    </div>
                </asp:LinkButton>
            </div>
        </div>

        <div class="assignment-table-content">
            <div class="subject-column">
                <asp:Label Text="Biology" runat="server" ID="Label1" />
            </div>

            <div class="title-column">
                <asp:Label Text="RNA Multiplication" runat="server" ID="Label2" />
            </div>

            <div class="download-question-column">
                <asp:LinkButton ID="LinkButton1" runat="server">
                    <div class="btn-download-question">
                        <i class="fa fa-floppy-o" aria-hidden="true"></i>
                    </div>
                </asp:LinkButton>
            </div>

            <%-- Assign Date --%>
            <div class="date-column">
                <asp:Label Text="May 2, 2021" runat="server" ID="Label3" />
            </div>

            <%-- Due Date --%>
            <div class="date-column">
                <asp:Label Text="May 7, 2021" runat="server" ID="Label4" />
            </div>

            <div class="status-column">
                <asp:Label Text="Submitted" runat="server" ID="Label6" />
            </div>

            <div class="action-column">
                <asp:LinkButton ID="LinkButton2" runat="server">
                    <div class="btn-download-answer">
                        <i class="fa fa-download" aria-hidden="true" title="Download all of the students answer"></i>
                    </div>
                </asp:LinkButton>
            </div>
        </div>

        <div class="assignment-table-content">
            <div class="subject-column">
                <asp:Label Text="Computer" runat="server" ID="Label7" />
            </div>

            <div class="title-column">
                <asp:Label Text="Powerpoint Effects" runat="server" ID="Label8" />
            </div>

            <div class="download-question-column">
                <asp:LinkButton ID="LinkButton3" runat="server">
                    <div class="btn-download-question">
                        <i class="fa fa-floppy-o" aria-hidden="true"></i>
                    </div>
                </asp:LinkButton>
            </div>

            <%-- Assign Date --%>
            <div class="date-column">
                <asp:Label Text="May 1, 2021" runat="server" ID="Label9" />
            </div>

            <%-- Due Date --%>
            <div class="date-column">
                <asp:Label Text="June 5, 2021" runat="server" ID="Label10" />
            </div>

            <div class="status-column">
                <asp:Label Text="Waiting" runat="server" ID="Label12" />
            </div>

            <div class="action-column">
                <asp:LinkButton ID="LinkButton4" runat="server">
                    <div class="btn-download-answer">
                        <i class="fa fa-download" aria-hidden="true" title="Download all of the students answer"></i>
                    </div>
                </asp:LinkButton>
            </div>
        </div>
    </div>


    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlAddAssignment" TargetControlID="btnAddAssignment"
        CancelControlID="btnCancel" BackgroundCssClass="popup-background">
    </cc1:ModalPopupExtender>

    <asp:Panel ID="pnlAddAssignment" runat="server" align="center" Style="display: none">
        <div class="popup-container">
            <div class="user-input">
                <div class="title">
                    <h1>Add Assignment</h1>
                </div>

                <div class="form-table">
                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Class" runat="server" ID="lblClass" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:DropDownList runat="server" ID="DropDownList1" CssClass="ddl">
                                    <asp:ListItem Text="XII MIPA 1" />
                                    <asp:ListItem Text="XI MIPA 2" />
                                    <asp:ListItem Text="XI MIPA 1" />
                                </asp:DropDownList>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="lblErrorClass" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Subject" runat="server" ID="Label5" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:DropDownList runat="server" ID="ddlSubject" CssClass="ddl">
                                    <asp:ListItem Text="Biology" />
                                </asp:DropDownList>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="lblErrorSubject" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Assignment Title" runat="server" ID="Label11" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:TextBox ID="txtAssignmentTitle" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="lblErrorAssignmentTitle" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Assign Date" runat="server" ID="Label13" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:TextBox ID="txtAssignDate" CssClass="textbox" runat="server" placeholder="dd/MM/yyyy"></asp:TextBox>
                                <AjaxControlToolkit:CalendarExtender runat="server" ID="ajCalendarAssignDate" PopupButtonID="txtAssignDate" TargetControlID="txtAssignDate" Format="dd/MM/yyyy"></AjaxControlToolkit:CalendarExtender>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="lblErrorAssignDate" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Due Date" runat="server" ID="Label14" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:TextBox ID="txtDueDate" CssClass="textbox" runat="server" placeholder="dd/MM/yyyy"></asp:TextBox>
                                <AjaxControlToolkit:CalendarExtender runat="server" ID="ajCalendarDueDate" PopupButtonID="txtDueDate" TargetControlID="txtDueDate" Format="dd/MM/yyyy"></AjaxControlToolkit:CalendarExtender>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="lblErrorDueDate" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Add File" runat="server" ID="lblQuestionFile" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:FileUpload ID="fuQuestionFile" runat="server" />
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="lblErrorQuestionFile" />
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
</asp:Content>
