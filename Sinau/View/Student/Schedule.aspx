<%@ Page Title="Schedule - SINAU" Language="C#" MasterPageFile="~/View/Student/Master.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Sinau.View.Student.Schedule" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../CSS/Student/ScheduleStyle.css" rel="stylesheet" type="text/css" />
    <link href="../CSS/MainStyle.css" rel="stylesheet" type="text/css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="title-container">
        <div class="vertical-line">
        </div>

        <div class="title-name">
            <h2>Class Schedule</h2>
        </div>
    </div>

    <div class="Accordion">
        <ajaxToolkit:Accordion ID="Accordion1" runat="server" HeaderCssClass="AccordionHead"
            ContentCssClass="AccordionContent" HeaderSelectedCssClass="SelectedHeader"
            FadeTransitions="true" TransitionDuration="100" FramesPerSecond="60" RequireOpenedPane="false">

            <Panes>
                <ajaxToolkit:AccordionPane ID="AccordionPaneMonday" runat="server">
                    <Header>Monday</Header>

                    <Content>
                        <div class="no-schedule-div" id="noScheduleDay1" runat="server">
                            <h3>It's FREE. You have no class schedule for this day &#129303</h3>
                        </div>

                        <table class="tbl">
                            <asp:Repeater runat="server" ID="rptScheduleMonday">
                                <ItemTemplate>
                                    <tr>
                                        <td class="course-name-td">
                                            <asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("_SubjectName") %>'></asp:Label>
                                        </td>
                                        <td class="course-time-td">
                                            <asp:Label ID="lblCourseTime" runat="server" Text='<%# Eval("_TimeStart") + " - " + Eval("_TimeEnd") %>'></asp:Label>
                                        </td>

                                        <td class="join-button-td">
                                            <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button button-design" PostBackUrl='<%# Eval("_LinkVidcon") %>' OnClientClick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);"/>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </Content>

                </ajaxToolkit:AccordionPane>

                <ajaxToolkit:AccordionPane ID="AccordionPaneTuesday" runat="server">
                    <Header>Tuesday</Header>
                    <Content>
                        <div class="no-schedule-div" id="noScheduleDay2" runat="server">
                            <h3>It's FREE. You have no class schedule for this day &#129303</h3>
                        </div>

                        <table class="tbl">
                            <asp:Repeater runat="server" ID="rptScheduleTuesday">
                                <ItemTemplate>
                                    <tr>
                                        <td class="course-name-td">
                                            <asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("_SubjectName") %>'></asp:Label>
                                        </td>
                                        <td class="course-time-td">
                                            <asp:Label ID="lblCourseTime" runat="server" Text='<%# Eval("_TimeStart") + " - " + Eval("_TimeEnd") %>'></asp:Label>
                                        </td>

                                        <td class="join-button-td">
                                            <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button button-design" PostBackUrl='<%# Eval("_LinkVidcon") %>' OnClientClick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);"/>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>

                <ajaxToolkit:AccordionPane ID="AccordionPaneWednesday" runat="server">
                    <Header>Wednesday</Header>
                    <Content>
                        <div class="no-schedule-div" id="noScheduleDay3" runat="server">
                            <h3>It's FREE. You have no class schedule for this day &#129303</h3>
                        </div>

                        <table class="tbl">
                            <asp:Repeater runat="server" ID="rptScheduleWednesday">
                                <ItemTemplate>
                                    <tr>
                                        <td class="course-name-td">
                                            <asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("_SubjectName") %>'></asp:Label>
                                        </td>
                                        <td class="course-time-td">
                                            <asp:Label ID="lblCourseTime" runat="server" Text='<%# Eval("_TimeStart") + " - " + Eval("_TimeEnd") %>'></asp:Label>
                                        </td>

                                        <td class="join-button-td">
                                            <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button button-design" PostBackUrl='<%# Eval("_LinkVidcon") %>' OnClientClick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);"/>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>

                <ajaxToolkit:AccordionPane ID="AccordionPaneThursday" runat="server">
                    <Header>Thursday</Header>
                    <Content>
                        <div class="no-schedule-div" id="noScheduleDay4" runat="server">
                            <h3>It's FREE. You have no class schedule for this day &#129303</h3>
                        </div>

                        <table class="tbl">
                            <asp:Repeater runat="server" ID="rptScheduleThursday">
                                <ItemTemplate>
                                    <tr>
                                        <td class="course-name-td">
                                            <asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("_SubjectName") %>'></asp:Label>
                                        </td>
                                        <td class="course-time-td">
                                            <asp:Label ID="lblCourseTime" runat="server" Text='<%# Eval("_TimeStart") + " - " + Eval("_TimeEnd") %>'></asp:Label>
                                        </td>

                                        <td class="join-button-td">
                                            <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button button-design" PostBackUrl='<%# Eval("_LinkVidcon") %>' OnClientClick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);"/>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>

                <ajaxToolkit:AccordionPane ID="AccordionPaneFriday" runat="server">
                    <Header>Friday</Header>
                    <Content>
                        <div class="no-schedule-div" id="noScheduleDay5" runat="server">
                            <h3>It's FREE. You have no class schedule for this day &#129303</h3>
                        </div>

                        <table class="tbl">
                            <asp:Repeater runat="server" ID="rptScheduleFriday">
                                <ItemTemplate>
                                    <tr>
                                        <td class="course-name-td">
                                            <asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("_SubjectName") %>'></asp:Label>
                                        </td>
                                        <td class="course-time-td">
                                            <asp:Label ID="lblCourseTime" runat="server" Text='<%# Eval("_TimeStart") + " - " + Eval("_TimeEnd") %>'></asp:Label>
                                        </td>

                                        <td class="join-button-td">
                                            <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button button-design" PostBackUrl='<%# Eval("_LinkVidcon") %>' OnClientClick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);"/>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>

                <ajaxToolkit:AccordionPane ID="AccordionPaneSaturday" runat="server">
                    <Header>Saturday</Header>
                    <Content>
                        <div class="no-schedule-div" id="noScheduleDay6" runat="server">
                            <h3>It's FREE. You have no class schedule for this day &#129303</h3>
                        </div>

                        <table class="tbl">
                            <asp:Repeater runat="server" ID="rptScheduleSaturday">
                                <ItemTemplate>
                                    <tr>
                                        <td class="course-name-td">
                                            <asp:Label ID="lblCourseName" runat="server" Text='<%# Eval("_SubjectName") %>'></asp:Label>
                                        </td>
                                        <td class="course-time-td">
                                            <asp:Label ID="lblCourseTime" runat="server" Text='<%# Eval("_TimeStart") + " - " + Eval("_TimeEnd") %>'></asp:Label>
                                        </td>

                                        <td class="join-button-td">
                                            <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button button-design" PostBackUrl='<%# Eval("_LinkVidcon") %>' OnClientClick="window.document.forms[0].target='_blank'; setTimeout(function(){window.document.forms[0].target='';}, 500);"/>
                                        </td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>



            </Panes>

        </ajaxToolkit:Accordion>
    </div>


</asp:Content>
