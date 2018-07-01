<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EditableListMvc.webform.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input type="text" name="list[0]" value="000" />
        <input type="text" name="list[1]" value="111" />
        <input type="text" name="list[2]" value="222" />
        <input type="text" name="list[3]" value="333" />
        <input type="submit" value="submit" />
    </div>
    </form>
</body>
</html>
