<%@ Page Title="" Language="C#" MasterPageFile="../Site1.Master" AutoEventWireup="true" CodeBehind="ViewAttendstudent.aspx.cs" Inherits="StudentAttendanceSystem.Report.ViewAttendstudent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="heading" runat="server">
    <asp:Label ID="lbAccount" runat="server"></asp:Label>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="attend-student">
        <div class="row">
            <div class="col-md-4">
                <asp:GridView DataKeyNames="subject_id" AutoGenerateColumns="false" EnableViewState="false" ID="gvSubject" runat="server">
                    <Columns>
                        <asp:HyperLinkField HeaderText="SUBJECT" DataTextField="subject_name" DataNavigateUrlFields="subject_id" DataNavigateUrlFormatString="ViewAttendstudent.aspx?subID={0}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-8">
                <asp:GridView AutoGenerateColumns="false" EnableViewState="false" ID="gvReport" runat="server" OnRowDataBound="gvReport_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="No">
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server"><%= count++ %></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Date" DataField="teaching_date" />
                        <asp:BoundField HeaderText="Slot" DataField="slot" />
                        <asp:BoundField HeaderText="Lecture" DataField="teacher_name" />
                        <asp:BoundField HeaderText="Class" DataField="class_code" />
                        <asp:BoundField HeaderText="Attend Status" DataField="status_description" />
                        <asp:BoundField HeaderText="Lecture Comment" DataField="comment" />
                    </Columns>
                </asp:GridView>
                <asp:Label ID="LabelTest" runat="server" Text="">
                    ABSENT: <%= percent %>% ABSENT SO FAR(<%= absent %> ABSENT ON <%= total %> TOTAL)
                </asp:Label>
            </div>
        </div>
    </div>


</asp:Content>
