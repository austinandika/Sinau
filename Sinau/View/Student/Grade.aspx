<%@ Page Title="" Language="C#" MasterPageFile="~/View/Student/Master.Master" AutoEventWireup="true" CodeBehind="Grade.aspx.cs" Inherits="Sinau.View.Student.Grade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Student/GradeStyle.css" rel="stylesheet" />
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
                    <asp:DropDownList runat="server" ID="ddlGrade">
                        <asp:ListItem Text="9" />
                        <asp:ListItem Text="10" />
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Semester</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSemester">
                        <asp:ListItem Text="1 (Odd)" />
                        <asp:ListItem Text="2 (Even)" />
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

        <div class="score-table-content">
            <div class="grade-column-no">1</div>
            <div class="grade-column-class">XII MIPA 1</div>
            <div class="grade-column-subjectid">PHY6049</div>
            <div class="grade-column-subjectname">Physics</div>
            <div class="grade-column-teachername">Thomas Alfa Edison</div>
            <div class="grade-column-category">ASG</div>
            <div class="grade-column-component">Newton 1 Experiment</div>
            <div class="grade-column-minscore">70</div>
            <div class="grade-column-score">85</div>
            <div class="grade-column-grade">B+</div>
        </div>

        <div class="score-table-content">
            <div class="grade-column-no"></div>
            <div class="grade-column-class"></div>
            <div class="grade-column-subjectid"></div>
            <div class="grade-column-subjectname"></div>
            <div class="grade-column-teachername"></div>
            <div class="grade-column-category">MID</div>
            <div class="grade-column-component">Newton 1 and 2</div>
            <div class="grade-column-minscore">70</div>
            <div class="grade-column-score">90</div>
            <div class="grade-column-grade">A</div>
        </div>

    </div>
</asp:Content>
