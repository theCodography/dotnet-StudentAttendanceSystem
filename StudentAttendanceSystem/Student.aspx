<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="StudentAttendanceSystem.Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="heading" runat="server">
    <asp:Label ID="lbAccount" runat="server"></asp:Label>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="student d-flex flex-column">
        <a class="btn btn-dark mb-3" href="Report/ViewAttendstudent.aspx">Attendance report</a>
        <a class="btn btn-dark" href="Report/ScheduleOfWeek.aspx">Weekly Timetable</a>
    </div>
</asp:Content>
