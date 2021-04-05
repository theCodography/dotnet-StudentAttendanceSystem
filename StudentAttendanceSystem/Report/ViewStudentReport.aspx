<%@ Page Title="" MasterPageFile="../Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="ViewStudentReport.aspx.cs" Inherits="StudentAttendanceSystem.Report.ViewStudentReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="heading" runat="server">
        <asp:Label ID="lbAccount" runat="server"></asp:Label>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
   <div class="attend-student">
       <div class="row m-0 w-100">
            <div class="col-md-6 p-0">
                <asp:GridView DataKeyNames="subject_id" AutoGenerateColumns="false" EnableViewState="false" ID="gvSubject" runat="server">
                    <Columns>
                        <asp:HyperLinkField HeaderText="SUBJECT" DataTextField="subject_name" DataNavigateUrlFields="subject_id" DataNavigateUrlFormatString="ViewStudentReport.aspx?subID={0}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-6 p-0">
                <asp:GridView DataKeyNames="class_id" AutoGenerateColumns="false" EnableViewState="false" ID="gvClass" runat="server">
                    <Columns>
                        <asp:HyperLinkField HeaderText="CLASS" DataTextField="class_code" DataNavigateUrlFields="subject_id,class_id" DataNavigateUrlFormatString="ViewStudentReport.aspx?subID={0}&classID={1}" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
   </div>
</asp:Content>
