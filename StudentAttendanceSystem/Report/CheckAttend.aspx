<%@ Page Title="" MasterPageFile="../Site1.Master" Language="C#" AutoEventWireup="true" CodeBehind="CheckAttend.aspx.cs" Inherits="StudentAttendanceSystem.Report.CheckAttend" %>

<asp:Content ID="Content1" ContentPlaceHolderID="heading" runat="server">
    <asp:Label ID="lbAccount" runat="server"></asp:Label>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="attend-student">
        <div class="row m-0 w-100">
            <div class="col-md-6 p-0">
                <asp:GridView DataKeyNames="subject_id" AutoGenerateColumns="false" EnableViewState="false" ID="gvSubject" runat="server">
                    <Columns>
                        <asp:HyperLinkField HeaderText="SUBJECT" DataTextField="subject_name" DataNavigateUrlFields="subject_id" DataNavigateUrlFormatString="CheckAttend.aspx?subID={0}" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-md-6 p-0">
                <asp:GridView DataKeyNames="class_id" AutoGenerateColumns="false" EnableViewState="false" ID="gvClass" runat="server">
                    <Columns>
                        <asp:HyperLinkField HeaderText="CLASS" DataTextField="class_code" DataNavigateUrlFields="subject_id,class_id" DataNavigateUrlFormatString="CheckAttend.aspx?subID={0}&classID={1}" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
        <asp:DropDownList ID="ddlDate" AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDate_SelectedIndexChanged">
        </asp:DropDownList>
        <div class="row mt-5">
            <div class="col-md-12">
                <asp:Label runat="server" ID="lbTest"></asp:Label>
                <asp:GridView DataKeyNames="student_id" AutoGenerateColumns="false" EnableViewState="false" ID="gvStudent" runat="server" OnRowDataBound="gvStudent_RowDataBound">
                    <Columns>
                        <asp:BoundField HeaderText="Name" DataField="student_name" />
                        <asp:BoundField  HeaderText="Code" DataField="student_code" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lbRadio" Text='<%# Eval("status_description").ToString() %>' runat="server"/>
                                <asp:RadioButton GroupName="checkAttend" ID="rdAbsent" runat="server" Text="Absent" />
                                <asp:RadioButton GroupName="checkAttend" ID="rdAttend" runat="server" Text="Attend" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                
                </asp:GridView>
                <asp:Button ID="btnSubmitAttend" runat="server" Text="Submit" OnClick="btnSubmitAttend_Click"/>
            </div>
        </div>

    </div>
    <script>

    </script>
</asp:Content>

