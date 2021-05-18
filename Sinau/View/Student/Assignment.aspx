<%@ Page Title="Assignment - SINAU" Language="C#" MasterPageFile="~/View/Student/Master.Master" AutoEventWireup="true" CodeBehind="Assignment.aspx.cs" Inherits="Sinau.View.Student.Assignmennt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Student/AssignmentStyle.css" rel="stylesheet" />
    <link href="../CSS/MainStyle.css" rel="stylesheet" type="text/css"/>
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

            <%-- Submission Date --%>
            <div class="date-column">
                <asp:Label Text="-" runat="server" ID="lblSubmissionDate" />
            </div>

            <div class="status-column">
                <asp:Label Text="Waiting" runat="server" ID="lblStatus" />
            </div>

            <div class="action-column">
                <label class="upload-answer">
                    <i class="fa fa-upload" aria-hidden="true" title="Upload your answer"></i>
                    <asp:FileUpload ID="fuAnswer" runat="server" />
                </label>

                <asp:LinkButton ID="btnDownloadAnswer" runat="server">
                    <div class="btn-download-answer">
                        <i class="fa fa-download" aria-hidden="true" title="Download your last submitted answer"></i>
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

            <%-- Submission Date --%>
            <div class="date-column">
                <asp:Label Text="May 1, 2021" runat="server" ID="Label5" />
            </div>

            <div class="status-column">
                <asp:Label Text="Submitted" runat="server" ID="Label6" />
            </div>

            <div class="action-column">
                <label class="upload-answer">
                    <i class="fa fa-upload" aria-hidden="true"></i>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </label>

                <asp:LinkButton ID="LinkButton2" runat="server">
                    <div class="btn-download-answer">
                        <i class="fa fa-download" aria-hidden="true"></i>
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

            <%-- Submission Date --%>
            <div class="date-column">
                <asp:Label Text="-" runat="server" ID="Label11" />
            </div>

            <div class="status-column">
                <asp:Label Text="Waiting" runat="server" ID="Label12" />
            </div>

            <div class="action-column">
                <label class="upload-answer">
                    <i class="fa fa-upload" aria-hidden="true"></i>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                </label>

                <asp:LinkButton ID="LinkButton4" runat="server">
                    <div class="btn-download-answer">
                        <i class="fa fa-download" aria-hidden="true"></i>
                    </div>
                </asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
