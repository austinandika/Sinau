<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Page Title="Assignment - SINAU" Language="C#" MasterPageFile="~/View/Student/Master.Master" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="Sinau.View.Student.Assignmennt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Student/AssignmentStyle.css" rel="stylesheet" />
    <link href="../CSS/MainStyle.css" rel="stylesheet" type="text/css" />
    <script src="../Javascript/jquery-3.5.1.min.js" defer></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="title-container">
        <div class="vertical-line">
        </div>

        <div class="title-name">
            <h2>Assignment</h2>
        </div>
    </div>

    <div class="assignment-filter-container">
        <table>
            <tr>
                <td>Class</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlClass" CssClass="ddl" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>

                <td>Subject</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSubjectFilter" OnSelectedIndexChanged="ddlSubjectFilter_SelectedIndexChanged" AutoPostBack="true" CssClass="ddl">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>

    <div class="assignment-table-container">
        <div class="assignment-table-header">
            <div class="subject-column">Subject</div>
            <div class="title-column">Title</div>
            <div class="download-question-column"></div>
            <div class="date-column">Assign Date</div>
            <div class="date-column">Due Date</div>
            <div class="date-column">Submission Date</div>
            <div class="status-column">Status</div>
            <div class="action-column">Action</div>
        </div>

        <div class="assignment-table-content no-assignment" id="noScheduleDiv" runat="server" visible="false">You have no assignment</div>

        <asp:Repeater runat="server" ID="rptStudentAssignment" OnItemDataBound="rptStudentAssignment_ItemDataBound">
            <ItemTemplate>
                <%-- <div class="assignment-table-content" runat="server" visible='<%# Eval("_Status").ToString() != "Waiting" %>'> --%>
                <div class="assignment-table-content">

                    <asp:HiddenField Value='<%# Eval("_ClassSubAssignID") %>' ID="lblClassSubAssignID" runat="server" />

                    <div class="subject-column">
                        <asp:Label Text='<%# Eval("_Subject") %>' runat="server" ID="lblSubject" />
                    </div>

                    <div class="title-column">
                        <asp:Label Text='<%# Eval("_AssignmentTitle") %>' runat="server" ID="lblAssignmentTitle" />
                    </div>

                    <div class="download-question-column">
                        <asp:LinkButton ID="btnDownloadQuestion" runat="server" OnClick="btnDownloadQuestion_Click">
                    <div class="btn-download-question">
                        <i class="fa fa-floppy-o" aria-hidden="true" title="Download the assignment question"></i>
                    </div>
                        </asp:LinkButton>
                    </div>

                    <%-- Assign Date --%>
                    <div class="date-column">
                        <asp:Label Text='<%# Eval("_AssignDate") %>' runat="server" ID="lblAssignDate" />
                    </div>

                    <%-- Due Date --%>
                    <div class="date-column">
                        <asp:Label Text='<%# Eval("_DueDate") %>' runat="server" ID="lblDueDate" />
                    </div>

                    <%-- Submission Date --%>
                    <div class="date-column">
                        <asp:Label Text='<%# Eval("_SubmissionDate") %>' runat="server" ID="lblSubmissionDate" />
                    </div>

                    <div class="status-column">
                        <asp:Label Text='<%# Eval("_Status") %>' runat="server" ID="lblStatus" />
                    </div>

                    <div class="action-column">
                        <asp:LinkButton ID="btnUploadAnswer" runat="server" OnClientClick="return false;" Visible="false">
                            <label class="upload-answer">
                                <i class="fa fa-upload" aria-hidden="true" title="Upload your answer"></i>
                                <%--<asp:FileUpload ID="fuAnswer" runat="server" />--%>
                            </label>
                        </asp:LinkButton>

                        <asp:LinkButton ID="btnDownloadAnswer" runat="server" OnClick="btnDownloadAnswer_Click" Visible="false">
                            <div class="btn-download-answer">
                                <i class="fa fa-download" aria-hidden="true" title="Download your last submitted answer"></i>
                            </div>
                        </asp:LinkButton>
                    </div>
                </div>

                <%-- POPUP ADD ASSIGNMENT --%>
                <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlAddAssignment" TargetControlID="btnUploadAnswer"
                    CancelControlID="btnCancel" BackgroundCssClass="popup-background">
                </cc1:ModalPopupExtender>

                <asp:Panel ID="pnlAddAssignment" runat="server" align="center" Style="display: none">

                    <div class="popup-container">
                        <div class="user-input">
                            <div class="title">
                                <h1>Add Answer File</h1>
                            </div>

                            <div class="error-server-container">
                                <asp:Label Text="" runat="server" ID="lblErrorServer" />
                            </div>


                            <div class="form-table">
                                <div class="row">
                                    <div class="input-command">
                                        <asp:Label Text="Add File" runat="server" ID="lblAnswerFile" />
                                    </div>

                                    <div class="input-error-box">
                                        <div class="input-box">
                                            <asp:FileUpload ID="fuAnswerFile" runat="server" CssClass="fu-answer-file" />
                                        </div>

                                        <div class="error-box">
                                            <asp:Label Text="" runat="server" ID="lblErrorAnswerFile" CssClass="lbl-error-answer-file" />
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="button-container">
                                <asp:Button Text="Cancel" runat="server" ID="btnCancel" CssClass="button-create button-cancel" />
                                <asp:Button Text="Submit" runat="server" ID="btnCreate" CssClass="button-create button-design" OnClick="btnCreate_Click" />
                            </div>
                        </div>
                    </div>
                    <script src="../Javascript/Student/Assignment-AddAssignmentValidation.js"></script>
                </asp:Panel>
            </ItemTemplate>
            
        </asp:Repeater>
    </div>

    
</asp:Content>
