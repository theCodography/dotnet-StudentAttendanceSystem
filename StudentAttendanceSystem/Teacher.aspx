<%@ Page Title="" MasterPageFile="~/Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="StudentAttendanceSystem.Teacher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="heading" runat="server">
    <asp:Label ID="lbAccount" runat="server"></asp:Label>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="student d-flex flex-column">
        <a class="btn btn-dark mb-3" href="Report/ViewStudentReport.aspx">Attendance report</a>
        <a class="btn btn-dark" href="Report/CheckAttend.aspx">Check Attendance</a>
    </div>
</asp:Content>
