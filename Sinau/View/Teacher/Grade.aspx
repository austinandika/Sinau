<%@ Page Title="" Language="C#" MasterPageFile="~/View/Teacher/Master.Master" AutoEventWireup="true" CodeBehind="Grade.aspx.cs" Inherits="Sinau.View.Teacher.Grade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <table>
            <tr>
                <th>No</th>
                <th>Subject Code</th>
                <th>Subject</th>
                <th>Class</th>
                <th>Component</th>
                <th>Score</th>
                <th>Min. Score</th>
                <th>Total Score</th>
                <th>Grade</th>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
    </div>
</asp:Content>
