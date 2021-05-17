﻿<%@ Page Title="" Language="C#" MasterPageFile="~/View/Teacher/Master.Master" AutoEventWireup="true" CodeBehind="Grade.aspx.cs" Inherits="Sinau.View.Teacher.Grade" %>

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

    <div class="upper-container">
        <div class="grade-filter-container">
            <table>
                <tr>
                    <td>Course</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlGrade" CssClass="ddl">
                            <asp:ListItem Text="Biology" />
                            <asp:ListItem Text="Mathematics" />
                        </asp:DropDownList>
                    </td>

                    <td>Class</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlClass" CssClass="ddl">
                            <asp:ListItem Text="11-A" />
                            <asp:ListItem Text="12-A" />
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>Category</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSemester" CssClass="ddl">
                            <asp:ListItem Text="Assignment" />
                            <asp:ListItem Text="Mid Exam" />
                        </asp:DropDownList>
                    </td>

                    <td>Academic Year</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlAcademicYear" CssClass="ddl">
                            <asp:ListItem Text="2019-20" />
                            <asp:ListItem Text="2020-21" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>

        <div class="edit-score-container">
            <asp:Button Text="Edit Score" ID="btnEdit" CssClass="btn-modify-score"  OnClientClick="return editScoreMode();" runat="server" />
            <asp:Button Text="Submit Changes" ID="btnSubmit" CssClass="btn-modify-score hide-button" OnClick="btnSubmit_Click" runat="server" />
        </div>
    </div>


    <div class="score-table-container">
        <table>
            <thead>
                <tr>
                    <th rowspan="2" id="no-th">No</th>
                    <th rowspan="2" id="nisn-th">NISN</th>
                    <th rowspan="2" id="student-name-th" class="fixed-header">Student Name</th>

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

                    <th rowspan="2" class="rotated-th">
                        <div><span>Total Assignment</span></div>
                    </th>
                    <th rowspan="2" class="rotated-th">
                        <div><span>Total Quiz</span></div>
                    </th>
                    <th rowspan="2" class="rotated-th">
                        <div><span>Total Mid Exam</span></div>
                    </th>
                    <th rowspan="2" class="rotated-th">
                        <div><span>Total Final Exam</span></div>
                    </th>
                    <th rowspan="2" id="min-score-th">
                        <div><span>Min Score</span></div>
                    </th>
                    <th rowspan="2" id="total-th">
                        <div><span>Total</span></div>
                    </th>
                </tr>

                <tr>
                    <th class="component-th">ASG</th>
                    <th class="component-th">ASG</th>
                    <th class="component-th">ASG</th>
                    <th class="component-th">MID</th>
                    <th class="component-th">FIN</th>
                </tr>
            </thead>

            <tbody>
                <%-- CONTENT SCORE --%>
                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TxtScore" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox1" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox3" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox4" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">95</td>
                    <td class="student-score-td">87</td>
                    <td class="student-score-td">80</td>
                    <td class="student-score-td">97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox80" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox81" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox82" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox83" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox84" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">95</td>
                    <td class="student-score-td">87</td>
                    <td class="student-score-td">80</td>
                    <td class="student-score-td">97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox85" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox86" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox87" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox88" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox89" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">95</td>
                    <td class="student-score-td">87</td>
                    <td class="student-score-td">80</td>
                    <td class="student-score-td">97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox90" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox91" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox92" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox93" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox94" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">95</td>
                    <td class="student-score-td">87</td>
                    <td class="student-score-td">80</td>
                    <td class="student-score-td">97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox95" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox96" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox97" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox98" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td class="student-score-td">
                        <asp:TextBox ID="TextBox99" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td class="student-score-td">95</td>
                    <td class="student-score-td">87</td>
                    <td class="student-score-td">80</td>
                    <td class="student-score-td">97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox5" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox6" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox7" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox8" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox9" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox10" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox11" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox12" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox13" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox14" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox15" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox16" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox17" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox18" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox19" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox20" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox21" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox22" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox23" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox24" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox70" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox71" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox72" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox73" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox74" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox75" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox76" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox77" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox78" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox79" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox25" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox26" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox27" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox28" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox29" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox30" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox31" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox32" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox33" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox34" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox35" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox36" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox37" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox38" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox39" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox40" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox41" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox42" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox43" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox44" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox45" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox46" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox47" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox48" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox49" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox50" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox51" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox52" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox53" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox54" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox55" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox56" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox57" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox58" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox59" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox60" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox61" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox62" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox63" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox64" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

                <tr>
                    <td class="no-td">1</td>
                    <td class="nisn-td">189654892</td>
                    <td class="student-name-td">Austin Andika Tanujaya</td>
                    <td>
                        <asp:TextBox ID="TextBox65" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox66" runat="server" ReadOnly="true" CssClass="txt-score">87</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox67" runat="server" ReadOnly="true" CssClass="txt-score">85</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox68" runat="server" ReadOnly="true" CssClass="txt-score">98</asp:TextBox></td>
                    <td>
                        <asp:TextBox ID="TextBox69" runat="server" ReadOnly="true" CssClass="txt-score">90</asp:TextBox></td>
                    <td>95</td>
                    <td>87</td>
                    <td>80</td>
                    <td>97</td>
                    <td class="min-score-td">70</td>
                    <td class="total-td">90</td>
                </tr>

            </tbody>

        </table>
    </div>

    <script src="../Javascript/Teacher/Grade-TableModification.js"></script>
    
</asp:Content>
