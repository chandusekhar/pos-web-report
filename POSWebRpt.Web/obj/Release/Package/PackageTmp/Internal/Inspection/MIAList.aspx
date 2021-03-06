﻿<%@ Page Title=":: RQM :: Major Physical Quantities Actual" Language="C#" MasterPageFile="~/Internal/REC.Master" AutoEventWireup="true" CodeBehind="MIAList.aspx.cs" Inherits="REC.Web.Internal.Inspection.MIAList" %>
<%@ Register Src="~/UserControls/VillageSummary.ascx" TagName="VillSumm" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="container" runat="server">
    <div id="dvAsync" style="padding: 5px; display: none;">
        <div class="asynpanel">
            <div id="dvAsyncClose"><img alt="" src="../../Images/Close-Button.bmp" style="cursor: pointer;" onclick="ClearErrorState()" /></div>
            <div id="dvAsyncMessage"></div>
        </div>
    </div>
    <asp:UpdateProgress ID="uProgMI" runat="server" AssociatedUpdatePanelID="uPnlMI">
        <ProgressTemplate> 
            <div class="progress">
                <div id="image"><img src="../../Images/PleaseWait.gif" alt="" /></div>
                <div id="text">Please Wait...</div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <div id="pageheader">MAJOR PHYSICAL QUANTITIES - ACTUAL</div>
    <table id="maincontent" border="0" cellpadding="2" cellspacing="2">
        <tr>
            <td rowspan="2" class="maincontent_left">
                <uc2:VillSumm ID="ucVill" runat="server" ShowInspectionPanel="true" />
            </td>           
            <td class="maincontent_right">
                <div class="navigationpanel"><a href="../Home.aspx">Home</a>-><a href="../VillageHome.aspx">Village Home</a></div>
                <fieldset style="width: 680px;">
                    <legend>Material / Equipment List</legend>
                        <div class="listpanelheader">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="width: 120px;">Results Per Page:</td>
                                    <td>
                                        <asp:DropDownList ID="ddlPaging" runat="server" Width="65px" AutoPostBack="true" OnSelectedIndexChanged="ddlPaging_SelectedIndexChanged">
                                            <asp:ListItem Text="10" Value="10" />
                                            <asp:ListItem Text="30" Value="30" />
                                            <asp:ListItem Text="50" Value="50" />
                                            <asp:ListItem Text="100" Value="100" />
                                        </asp:DropDownList>
                                    </td>
                                    <td style="text-align: right;">
                                        <asp:ImageButton ID="imgBtn" runat="server" ImageUrl="~/Images/add.png" Height="16" ToolTip="Click to add new material" OnClick="lnkAdd_Click" />
                                        <asp:LinkButton ID="lnkAdd" runat="server" ToolTip="Click to add new material" OnClick="lnkAdd_Click">Add New Material</asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="listpanel">
                            <asp:UpdatePanel ID="uPnlMI" runat="server" UpdateMode="Conditional">
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="ddlPaging" EventName="SelectedIndexChanged" />
                                </Triggers>
                                <ContentTemplate>
                                    <asp:GridView ID="gvwList" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                                        BorderStyle="None" BorderWidth="0" Width="100%" OnRowDataBound="gvwList_RowDataBound"
                                        OnRowCommand="gvwList_RowCommand" OnPageIndexChanging="gvwList_PageIndexChanging">
                                        <PagerSettings Mode="NumericFirstLast" Position="Bottom" />
                                        <PagerStyle CssClass="gridviewpager" />
                                        <EmptyDataRowStyle CssClass="gridviewemptydatarow" />
                                        <EmptyDataTemplate>
                                            No Item(s) Found
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl#">
                                                <HeaderStyle CssClass="gridviewheader" HorizontalAlign="Right" />
                                                <ItemStyle CssClass="gridviewitem" Width="5%" HorizontalAlign="Right" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Material / Equipment">
                                                <HeaderStyle CssClass="gridviewheader" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="gridviewitem" Width="31%" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unit">
                                                <HeaderStyle CssClass="gridviewheader" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="gridviewitem" Width="10%" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Approved Qty">
                                                <HeaderStyle CssClass="gridviewheader" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="gridviewitem" Width="10%" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Actual Qty">
                                                <HeaderStyle CssClass="gridviewheader" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="gridviewitem" Width="10%" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Variation">
                                                <HeaderStyle CssClass="gridviewheader" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="gridviewitem" Width="10%" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Remarks">
                                                <HeaderStyle CssClass="gridviewheader" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="gridviewitem" Width="14%" HorizontalAlign="Left" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <ItemStyle CssClass="gridviewitem" Width="5%" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <HeaderStyle CssClass="gridviewheader" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEdit" runat="server" CommandName="EditData" ImageUrl="~/Images/edit.gif" ImageAlign="Middle" Height="16" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderStyle CssClass="gridviewheader" />
                                                <ItemStyle CssClass="gridviewitem" Width="5%" HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnRemove" runat="server" CommandName="RemoveData" ImageUrl="~/Images/trash_icon.gif" ImageAlign="Middle" Height="16" Width="16" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                </fieldset>
            </td>
        </tr>   
    </table>
</asp:Content>
