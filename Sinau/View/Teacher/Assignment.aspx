<%@ Page Title="Assignment - SINAU" Language="C#" MasterPageFile="~/View/Teacher/Master.Master" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="Sinau.View.Teacher.Assignment" %>

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
                        <asp:DropDownList runat="server" ID="ddlClass" CssClass="ddl" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>

                    <td>Subject</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSubjectFilter" CssClass="ddl">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>

        <div class="edit-assignment-container">
            <asp:Button Text="Add Assignment" ID="btnAddAssignment" CssClass="btn-add-assignment button-design" OnClientClick="return false;" runat="server" />
        </div>
    </div>


    <div class="assignment-table-container">
        <div class="assignment-table-header">
            <div class="class-column">Class</div>
            <div class="subject-column">Subject</div>
            <div class="title-column">Title</div>
            <div class="download-question-column"></div>
            <div class="date-column">Assign Date</div>
            <div class="date-column">Due Date</div>
            <div class="status-column">Status</div>
            <div class="action-column">Action</div>
        </div>


        <div class="assignment-table-content no-assignment" id="noScheduleDiv" runat="server" visible="false">You have no assignment</div>

        <asp:Repeater ID="rptTeacherAssignment" runat="server">
            <ItemTemplate>
                <div class="assignment-table-content">
                    <asp:Label Text='<%# Eval("_ClassSubAssignID") %>' ID="lblClassSubAssignID" runat="server" Visible="false" />
                    <div class="class-column">
                        <asp:Label Text='<%# Eval("_Class") %>' runat="server" ID="lblClass" />
                    </div>

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

                    <div class="status-column">
                        <asp:Label Text='<%# Eval("_Status") %>' runat="server" ID="lblStatus" />
                    </div>

                    <div class="action-column">
                        <asp:LinkButton ID="btnDownloadAnswer" runat="server">
                    <div class="btn-download-answer">
                        <i class="fa fa-download" aria-hidden="true" title="Download all of the students answer"></i>
                    </div>
                        </asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

    <%-- POPUP ADD ASSIGNMENT --%>
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlAddAssignment" TargetControlID="btnAddAssignment"
        CancelControlID="btnCancel" BackgroundCssClass="popup-background">
    </cc1:ModalPopupExtender>


    <asp:Panel ID="pnlAddAssignment" runat="server" align="center" Style="display: none">

        <div class="popup-container">
            <div class="user-input">
                <div class="title">
                    <h1>Add Assignment</h1>
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

                                        <asp:DropDownList runat="server" ID="ddlClassPopup" CssClass="ddl" OnSelectedIndexChanged="ddlClassPopup_SelectedIndexChanged" AutoPostBack="true">
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
                            <asp:Label Text="Assignment Title" runat="server" ID="lblTitlePopup" />
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
                            <asp:Label Text="Assign Date" runat="server" ID="lblAssignDatePopup" />
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
                            <asp:Label Text="Due Date" runat="server" ID="lblDueDatePopup" />
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
                    <asp:Button Text="Create" runat="server" ID="btnCreate" CssClass="button-create button-design" OnClientClick="return validateCreateAssignment();" OnClick="btnCreate_Click" />
                </div>
            </div>
        </div>

    </asp:Panel>

    <script src="../Javascript/Teacher/Assignment-AddAssignmentValidation.js"></script>
</asp:Content>
