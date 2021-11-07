<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox type="hidden" id="token" runat="server" name="token" />

            <asp:Button style="display:none" runat="server" OnClick="Unnamed_Click" ID="btn" />
        </div>
    </form>
    <script src="Scripts/jquery-3.4.1.min.js"></script>

    <script type="text/javascript">
        //localStorage.setItem("token", "123");
        //$("#token").val(localStorage.getItem("token"));
        ////$("#btn").click();
        //window.location.href = "http://localhost:8080/account/signin";

    </script>
</body>
</html>
