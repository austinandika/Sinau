<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="AjaxControlToolkit" %>

<%@ Page Title="Grade - SINAU" Language="C#" MasterPageFile="~/View/Teacher/Master.Master" AutoEventWireup="true" CodeBehind="Grade.aspx.cs" Inherits="Sinau.View.Teacher.Grade" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Teacher/GradeStyle.css" rel="stylesheet" />
    <link href="../CSS/MainStyle.css" rel="stylesheet" type="text/css"/>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="error-main" runat="server" id="errorMain">
        <asp:Label Text="" CssClass="lbl-error-main" ID="lblErrorMain" runat="server" Visible="false" />
    </div>

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
                    <td>Academic Year</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlAcademicYear" CssClass="ddl" OnSelectedIndexChanged="ddlAcademicYear_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>

                    <td>Class</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlClass" CssClass="ddl" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>Subject</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSubject" CssClass="ddl" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </td>

                    <%--<td>Category</td>
                    <td>
                        <asp:DropDownList runat="server" ID="ddlSemester" CssClass="ddl">
                            <asp:ListItem Text="-" />
                        </asp:DropDownList>
                    </td>--%>
                </tr>
            </table>
        </div>

        <div class="edit-score-container">
            <asp:Button Text="Add Grade Component" ID="btnAddComponent" CssClass="btn-modify-score button-design"  OnClientClick="return false;" runat="server" />
            <asp:Button Text="Edit Score" ID="btnEdit" CssClass="btn-modify-score button-design"   OnClick="btnEdit_Click" runat="server" />
            <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn-modify-score hide-button button-design" runat="server" OnClick="btnCancel_Click" />
            <asp:Button Text="Submit Changes" ID="btnSubmit" CssClass="btn-modify-score hide-button button-design" OnClientClick="return editScoreMode();" OnClick="btnSubmit_Click" runat="server" />
        </div>
    </div>

    <div class="score-table-container">
        <table>
            <asp:Repeater ID="rptGradeMain" runat="server" OnItemDataBound="rptGradeMain_ItemDataBound">
                    <HeaderTemplate>
                        <thead>
                            <tr>
                                <th rowspan="3" id="no-th">No</th>
                                <th rowspan="3" id="nisn-th">NISN</th>
                                <th rowspan="3" id="student-name-th" class="fixed-header">Student Name</th>
                                <asp:Repeater runat="server" ID="rptComponentHeader">
                                    <ItemTemplate>
                                        <th class="rotated-th">
                                            <div>
                                                <asp:Label Text='<%# Eval("_Component") %>' runat="server" ID="lblComponent" />
                                            </div>
                                        </th>
                                    </ItemTemplate>
                                </asp:Repeater>  

                                <th rowspan="3" class="rotated-th">
                                    <div><span>Total Assignment</span></div>
                                </th>
                                <th rowspan="3" class="rotated-th">
                                    <div><span>Total Quiz</span></div>
                                </th>
                                <th rowspan="3" class="rotated-th">
                                    <div><span>Total Mid Exam</span></div>
                                </th>
                                <th rowspan="3" class="rotated-th">
                                    <div><span>Total Final Exam</span></div>
                                </th>
                                <th rowspan="3" id="min-score-th">
                                    <div><span>Min Score</span></div>
                                </th>
                                <th rowspan="3" id="total-th">
                                    <div><span>Total</span></div>
                                </th>
                            </tr>

                            <tr>
                                <asp:Repeater runat="server" ID="rptCategoryHeader">
                                    <ItemTemplate>
                                        <th class="component-th">
                                            <asp:Label Text='<%#Eval("_CategoryID")%>' runat="server" ID="lblCategory" />
                                        </th>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tr>

                            <tr>
                                <asp:Repeater runat="server" ID="rptIsActiveCategory" OnItemDataBound="rptIsActiveCategory_ItemDataBound">
                                    <ItemTemplate>
                                        <th class="component-th-2">
                                            <asp:hiddenfield ID="hfComponentID" runat="server" value='<%# Eval("_componentid") %>'/>
                                            <asp:CheckBox Checked='<%#Convert.ToInt32(Eval("_isActiveComponent"))==1?true:false%>' ID="cbIsActive" Enabled="false" runat="server"/>
                                        </th>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tr>
                        </thead>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tbody>
                            <tr>
                                <td class="no-td">
                                    <asp:Label Text='<%# Container.ItemIndex + 1 %>' runat="server" ID="lblRowNo" />
                                </td>

                                <td class="nisn-td">
                                    <asp:Label Text='<%# Eval("_NISN") %>' runat="server" ID="lblNISN" />
                                </td>

                                <td class="student-name-td">
                                    <asp:Label Text='<%# Eval("_StudentName") %>' runat="server" ID="lblStudentName" />
                                </td>

                                <asp:Repeater runat="server" ID="rptComponentScoreItem">
                                    <ItemTemplate>
                                        <td class="student-score-td">
                                            <asp:HiddenField ID="hfScoreID" runat="server" Value='<%# Eval("_ScoreID") %>'/>
                                            <asp:TextBox ID="txtScore" runat="server" ReadOnly="true" CssClass="txt-score" Text='<%# Eval("_Score") %>' onkeypress="return ValidNumeric()" ></asp:TextBox>
                                        </td>
                                    </ItemTemplate>
                                </asp:Repeater>
                                
                                <td class="student-score-td">
                                    <asp:Label Text="" runat="server" ID="lblTotalAssignment" />
                                </td>

                                <td class="student-score-td">
                                    <asp:Label Text="" runat="server" ID="lblTotalQuiz" />
                                </td>

                                <td class="student-score-td">
                                    <asp:Label Text="" runat="server" ID="lblTotalMidExam" />
                                </td>

                                <td class="student-score-td">
                                    <asp:Label Text="" runat="server" ID="lblTotalFinalExam" />
                                </td>

                                <td class="min-score-td">
                                    <asp:Label Text='<%# Eval("_MinScore") %>' runat="server" ID="lblMinScore" />
                                </td>
                                <td class="total-td">
                                    <asp:Label Text="" runat="server" ID="lblTotalScore" />
                                </td>
                            </tr>
                        </tbody>
                    </ItemTemplate>
                </asp:Repeater>
            
            
        </table>
    </div>


    <%--<div class="score-table-container">
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
            </thead>--%>

            
            <%-- CONTENT SCORE --%>
            <%--<tbody>
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
            </tbody>

        </table>
    </div>--%>

    <%-- POPUP ADD ASSIGNMENT --%>
    <cc1:ModalPopupExtender ID="mp1" runat="server" PopupControlID="pnlAddComponent" TargetControlID="btnAddComponent"
        CancelControlID="btnCancelComponent" BackgroundCssClass="popup-background">
    </cc1:ModalPopupExtender>

    <asp:Panel ID="pnlAddComponent" runat="server" align="center" Style="display: none">
        <div class="popup-container">
            <div class="user-input">
                <div class="title">
                    <h1>Add Grade Component</h1>
                </div>

                <div class="error-server-container">
                    <asp:Label Text="" runat="server" ID="lblErrorServer" />
                </div>

                <div class="form-table">
                    <asp:UpdatePanel runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="Class" runat="server" ID="lblClass" />
                                </div>

                                <div class="input-error-box">
                                    <div class="input-box">
                                        <asp:DropDownList runat="server" ID="ddlClassPopup" CssClass="ddl" OnSelectedIndexChanged="ddlClassPopup_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="error-box">
                                        <asp:Label Text="" runat="server" ID="lblErrorClass" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="Subject" runat="server" ID="lblSubjectPopup" />
                                </div>

                                <div class="input-error-box">
                                    <div class="input-box">
                                        <asp:DropDownList runat="server" ID="ddlSubjectPopup" CssClass="ddl" OnSelectedIndexChanged="ddlSubjectPopup_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="error-box">
                                        <asp:Label Text="" runat="server" ID="lblErrorSubject" />
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="input-command">
                                    <asp:Label Text="Category" runat="server" ID="lblComponentCategoryPopup" />
                                </div>

                                <div class="input-error-box">
                                    <div class="input-box">
                                        <asp:DropDownList runat="server" ID="ddlComponentCategory" CssClass="ddl" OnSelectedIndexChanged="ddlComponentCategory_SelectedIndexChanged" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="error-box">
                                        <asp:Label Text="" runat="server" ID="lblErrorComponentCategory" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClassPopup" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="ddlSubjectPopup" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                    

                    <div class="row">
                        <div class="input-command">
                            <asp:Label Text="Component Name" runat="server" ID="lblComponentNamePopup" />
                        </div>

                        <div class="input-error-box">
                            <div class="input-box">
                                <asp:TextBox ID="txtComponentName" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>

                            <div class="error-box">
                                <asp:Label Text="" runat="server" ID="lblErrorComponentName" />
                            </div>
                        </div>
                    </div>

                <div class="button-container">
                    <asp:Button Text="Cancel" runat="server" ID="btnCancelComponent" CssClass="button-create button-design" />
                    <asp:Button Text="Create" runat="server" ID="btnCreateComponent" CssClass="button-create button-design" OnClientClick="return validateCreateComponent();" OnClick="btnCreateComponent_Click"/>
                </div>
            </div>


        </div>
    </asp:Panel>

    <script src="../Javascript/Teacher/Grade-TableModification.js"></script>
    
</asp:Content>
