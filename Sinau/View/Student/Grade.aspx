<%@ Page Title="Grade - SINAU" Language="C#" MasterPageFile="~/View/Student/Master.Master" AutoEventWireup="true" CodeBehind="Grade.aspx.cs" Inherits="Sinau.View.Student.Grade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Student/GradeStyle.css" rel="stylesheet" />
    <link href="../CSS/MainStyle.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="title-container">
        <div class="vertical-line">
        </div>

        <div class="title-name">
            <h2>Grade Report</h2>
        </div>
    </div>

    <div class="grade-filter-container">
        <table>
            <tr>
                <td>Grade</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlGrade" CssClass="ddl" OnSelectedIndexChanged="ddlGrade_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Semester</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSemester" CssClass="ddl" OnSelectedIndexChanged="ddlSemester_SelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>

    <div class="score-table-container">
        <div class="score-table-header">
            <div class="grade-column-no">No</div>
            <div class="grade-column-class">Class</div>
            <div class="grade-column-subjectid">Subject ID</div>
            <div class="grade-column-subjectname">Subject</div>
            <div class="grade-column-teachername">Teacher Name</div>
            <div class="grade-column-category">Category</div>
            <div class="grade-column-component">Component</div>
            <div class="grade-column-minscore">Min. Score</div>
            <div class="grade-column-score">Score</div>
            <div class="grade-column-grade">Grade</div>
        </div>

        <div class="score-table-content no-grade" id="noGradeDiv" runat="server" visible="false">Your score has not been inputted yet.</div>

        <asp:Repeater ID="rptStudentGrade" runat="server">
            <ItemTemplate>
                <div class="score-table-content">
                    <div class="grade-column-no">
                        <asp:Label ID="lblDataNo" Text='<%# Eval("_seqViewNo") %>' runat="server" />
                    </div>
                    <div class="grade-column-class">
                        <asp:Label ID="lblClass" Text='<%# Eval("_Class") %>' runat="server" />
                    </div>
                    <div class="grade-column-subjectid">
                        <asp:Label ID="lblSubjectID" Text='<%# Eval("_SubjectID") %>' runat="server" />
                    </div>
                    <div class="grade-column-subjectname">
                        <asp:Label ID="lblSubjectName" Text='<%# Eval("_Subject") %>' runat="server" />
                    </div>
                    <div class="grade-column-teachername">
                        <asp:Label ID="lblTeacherName" Text='<%# Eval("_TeacherName") %>' runat="server" />
                    </div>
                    <div class="grade-column-category">
                        <asp:Label ID="lblCategory" Text='<%# Eval("_CategoryID") %>' runat="server" />
                    </div>
                    <div class="grade-column-component">
                        <asp:Label ID="lblComponent" Text='<%# Eval("_Component") %>' runat="server" />
                    </div>
                    <div class="grade-column-minscore">
                        <asp:Label ID="lblMinScore" Text='<%# Eval("_MinScore") %>' runat="server" />
                    </div>
                    <div class="grade-column-score">
                        <asp:Label ID="lblScore" Text='<%# Eval("_Score") %>' runat="server" />
                    </div>
                    <div class="grade-column-grade">
                        <asp:Label ID="lblGrade" Text='<%# Eval("_GradeLetter") %>' runat="server" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
