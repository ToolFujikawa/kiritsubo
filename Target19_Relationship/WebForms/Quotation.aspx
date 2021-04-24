<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quotation.aspx.cs" Inherits="Target19_Relationship.WebForms.Quotation" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:LinkButton ID="linShowReport" runat="server" OnClick="LinShowReport_Click">ShowReport</asp:LinkButton>
        </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="850px">
            <LocalReport ReportPath="Reports\QuotationMain.rdlc">
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
    </form>
</body>
</html>
