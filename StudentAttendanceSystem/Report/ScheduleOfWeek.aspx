<%@ Page Title="" MasterPageFile="../Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="ScheduleOfWeek.aspx.cs" Inherits="StudentAttendanceSystem.Report.ScheduleOfWeek" %>

<asp:Content ID="Content1" ContentPlaceHolderID="heading" runat="server">
    <asp:Label ID="lbAccount" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="attend-student">
        <asp:DropDownList ID="ddlWeek" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlWeek_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:Label ID="LabelTest" runat="server" Text=""></asp:Label>
        <div class="row">
            <div class="col-md-12">

                <asp:GridView ID="GridMultiD" runat="server"
                    AutoGenerateColumns="false" Font-Names="Arial"
                    Font-Size="11pt">

                    <Columns>
                        <asp:BoundField ItemStyle-Width="150px"
                            DataField="No" HeaderText="No" HtmlEncode="false" />
                        <asp:BoundField ItemStyle-Width="150px"
                            DataField="Monday" HeaderText="Monday" HtmlEncode="false" />
                        <asp:BoundField ItemStyle-Width="150px"
                            DataField="Tuesday" HeaderText="Tuesday" HtmlEncode="false" />
                        <asp:BoundField ItemStyle-Width="150px"
                            DataField="Wednesday" HeaderText="Wednesday" HtmlEncode="false" />
                        <asp:BoundField ItemStyle-Width="150px"
                            DataField="Thursday" HeaderText="Thursday" HtmlEncode="false" />
                        <asp:BoundField ItemStyle-Width="150px"
                            DataField="Friday" HeaderText="Friday" HtmlEncode="false" />
                        <asp:BoundField ItemStyle-Width="150px"
                            DataField="Saturday" HeaderText="Saturday" HtmlEncode="false" />
                        <asp:BoundField ItemStyle-Width="150px"
                            DataField="Sunday" HeaderText="Sunday" HtmlEncode="false" />
                    </Columns>

                </asp:GridView>


            </div>

        </div>
    </div>
</asp:Content>
