<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormBase64.aspx.cs" Inherits="WebAPIPrj.WebForm.WebFormBase64" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../Scripts/jquery-1.8.2.min.js"></script>
    <script type="text/javascript">  
        function getStudents() {
            $.getJSON("api/Image",
                function (data) {
                    $('#stud').empty(); // Clear table body.  

                    // Loop through the list of students.  
                    $.each(data, function (key, val) {
                        // Add a table row for the student.  
                        var row = '<tr><td>' + val.StudName +
                            '</td><td>' + val.StudAddress + '</td><td>' +
                            val.StudMONO + '</td><td>' + val.StudCourse +
                            '</td></tr>';
                        $("#stud").append(row);

                    });
                });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" action="/api/Image/Upload">
    <div>
        <asp:TextBox ID="file" runat="server" TextMode="MultiLine" Columns="100" Rows="10"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="上傳" />
    </div>
    </form>
</body>
</html>
