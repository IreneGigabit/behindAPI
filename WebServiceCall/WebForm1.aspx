<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebServiceCall.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		字串1：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
		字串2：<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br />
		<asp:Button ID="Button1" runat="server" Text="呼叫web service" OnClick="Button1_Click" /><br />
		回傳結果：<asp:Label ID="Label1" runat="server" Text="Label1" ForeColor="Red"></asp:Label>
    </form>
</body>
</html>
