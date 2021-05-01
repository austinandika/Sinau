<%@ Page Title="" Language="C#" MasterPageFile="~/View/Teacher/Master.Master" AutoEventWireup="true" CodeBehind="Grade.aspx.cs" Inherits="Sinau.View.Teacher.Grade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Teacher/GradeStyle.css" rel="stylesheet" />
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
                <td>Course</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlGrade">
                        <asp:ListItem Text="Biology" />
                        <asp:ListItem Text="Mathematics" />
                    </asp:DropDownList>
                </td>

                <td>Class</td>
                <td>
                    <asp:DropDownList runat="server" ID="DropDownList1">
                        <asp:ListItem Text="11-A" />
                        <asp:ListItem Text="12-A" />
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Category</td>
                <td>
                    <asp:DropDownList runat="server" ID="ddlSemester">
                        <asp:ListItem Text="Assignment" />
                        <asp:ListItem Text="Mid Exam" />
                    </asp:DropDownList>
                </td>

                <td>Academic Year</td>
                <td>
                    <asp:DropDownList runat="server" ID="DropDownList2">
                        <asp:ListItem Text="2019-20" />
                        <asp:ListItem Text="2020-21" />
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </div>

    <div class="score-table-container">
        <table>
            <tr>
                <th>No</th>
                <th id="nisn-th">NISN</th>
                <th id="student-name-th">Student Name</th>

                <th class="rotated-th">
                    <div><span>Assignment 1</span></div>
                </th>
                <th class="rotated-th"> 
                    <div><span>Assignment 2</span></div>
                </th>
                <th class="rotated-th">
                    <div><span>Assignment 3</span></div>
                </th>
                <th class="rotated-th">
                    <div><span>Mid Exam</span></div>
                </th>
                <th class="rotated-th">
                    <div><span>Final Exam</span></div>
                </th>

                <th class="rotated-th">
                    <div><span>Total Assignment</span></div>
                </th>
                <th class="rotated-th">
                    <div><span>Total Quiz</span></div>
                </th>
                <th class="rotated-th">
                    <div><span>Total Mid Exam</span></div>
                </th>
                <th class="rotated-th">
                    <div><span>Total Final Exam</span></div>
                </th>
                <th>
                    <div><span>Total</span></div>
                </th>
            </tr>

            <tr>
                <th colspan="3"></th>
                <th>ASG</th>
                <th>ASG</th>
                <th>ASG</th>
                <th>MID</th>
                <th>FIN</th>
            </tr>

            <tr>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
