<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudentAttendanceSystem.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <title>Student Attendance</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="login ">
                <h2 class="text-center">Login</h2>
                <div class="login-box d-flex flex-column">
                    <label for="ddlRole">Choose Role</label>
                    <asp:DropDownList AutoPostBack="true" ID="ddlRole" runat="server">
                    </asp:DropDownList>
                    <label for="tbEmail">Email address</label>
                    <asp:TextBox ID="tbEmail" runat="server" placeholder="email@example.com"></asp:TextBox>
                    <label for="tbPassword">Password</label>
                    <asp:TextBox ID="tbPassword" TextMode="Password" runat="server" placeholder="Password"></asp:TextBox>
                    <asp:Button CssClass="btn btn-primary mt-3" ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                    <asp:Label ID="Label4" runat="server" Font-Size="X-Large"></asp:Label>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
