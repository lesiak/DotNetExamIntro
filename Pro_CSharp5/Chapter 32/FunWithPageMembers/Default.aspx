<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnGetBrowserStats" runat="server" OnClick="btnGetBrowserStats_Click" Text="Get Browser Stats" />
        <br />
        <br />
        <asp:Button ID="btnWriteToResponse" runat="server"  Text="Write to response" OnClick="btnWriteToResponse_Click" />
        <br />
        <br />
        <asp:Button ID="btnRedirect" runat="server" Text="Redirect to MS" OnClick="btnRedirect_Click" />
        <br />
        <br />
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
