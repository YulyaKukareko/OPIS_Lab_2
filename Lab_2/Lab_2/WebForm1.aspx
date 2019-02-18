<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab_2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Input param:"></asp:Label>
            <br />
            <asp:TextBox ID="myText" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="getButton" runat="server" Text="Get" OnClick="Button1_Click" />
            <br /> 
            <br />
            <asp:Button ID="postButton" runat="server" Text="Post" OnClick="postButton_Click" />
            <br /> 
            <br />
            <asp:Button ID="putButton" runat="server" Text="Put" OnClick="putButton_Click" />
            <br /> 
            <br />
            <asp:Button ID="errorHandler" runat="server" Text="403" OnClick="errorHandler_Click" />
        </div>
    </form>
</body>
</html>
