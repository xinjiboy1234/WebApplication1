<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebApplication1.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your application description page.</h3>
    <p>Use this area to provide additional information.</p>
    <button onclick="getData()"  >GetData</button>
    <script type="text/javascript">

        $.ajax({
            url: "Services/Signout.ashx",
            success: function (data) {
                alert(data);
            }
        });

        function getData() {
            $.ajax({
                url: "Services/AjaxService.ashx",
                success: function (data) {
                    alert(data);
                }
            });
        }
    </script>
</asp:Content>


