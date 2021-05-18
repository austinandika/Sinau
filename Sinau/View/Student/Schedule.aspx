﻿<%@ Page Title="Schedule - SINAU" Language="C#" MasterPageFile="~/View/Student/Master.Master" AutoEventWireup="true" CodeBehind="Schedule.aspx.cs" Inherits="Sinau.View.Student.Schedule" %>

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
                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>Monday
                        </Header>

                    <Content>



                        <table class="tbl">
                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="lblCourseName" runat="server" Text="Mathematics"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCourseTime" runat="server" Text="07:00-09:30"></asp:Label>
                                </td>

                                <td>
                                    <asp:Button Text="Join" runat="server" ID="btnJoinClass" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label1" runat="server" Text="English"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="10:00-11:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>
                            </tr>


                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label3" runat="server" Text="Biology"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="12:00-13:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                        </table>



                    </Content>

                </ajaxToolkit:AccordionPane>

                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>Tuesday</Header>
                    <Content>
                        <table class="tbl">
                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label5" runat="server" Text="Social Studies"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="07:00-09:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label7" runat="server" Text="Physics"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="10:00-11:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>
                            </tr>


                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label9" runat="server" Text="Chemistry"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="12:00-13:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>

                <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>Wednesday</Header>
                    <Content>
                        <table class="tbl">
                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label11" runat="server" Text="Social Studies"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="07:00-09:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label13" runat="server" Text="Physics"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="10:00-11:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>
                            </tr>


                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label15" runat="server" Text="Chemistry"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label16" runat="server" Text="12:00-13:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>

                <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                    <Header>Thursday</Header>
                    <Content>
                        <table class="tbl">
                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label17" runat="server" Text="Social Studies"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="07:00-09:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label19" runat="server" Text="Physics"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label20" runat="server" Text="10:00-11:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>
                            </tr>


                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label21" runat="server" Text="Chemistry"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label22" runat="server" Text="12:00-13:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>

                <ajaxToolkit:AccordionPane ID="AccordionPane5" runat="server">
                    <Header>Friday</Header>
                    <Content>
                        <table class="tbl">
                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label23" runat="server" Text="Social Studies"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label24" runat="server" Text="07:00-09:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label25" runat="server" Text="Physics"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label26" runat="server" Text="10:00-11:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>
                            </tr>


                            <tr>
                                <td class="coursename">
                                    <asp:Label ID="Label27" runat="server" Text="Chemistry"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label28" runat="server" Text="12:00-13:30"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button Text="Join" runat="server" CssClass="join-class-button button-design" />
                                </td>

                            </tr>

                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>

            </Panes>

        </ajaxToolkit:Accordion>
    </div>


</asp:Content>
