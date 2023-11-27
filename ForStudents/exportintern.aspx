<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="exportintern.aspx.cs" 
    Inherits="unSupervisorApp.ForStudents.exportintern" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;<br />
    <asp:GridView ID="gvIntern" runat="server">
    </asp:GridView>
</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="btnExpot" runat="server" OnClick="btnExpot_Click" Text="Export TO Excle" />
&nbsp;
        <%--<asp:Button ID="btnExportToPdf" runat="server" OnClick="btnExportToPdf_Click" Text="Export TO Pdf" />--%>
&nbsp;&nbsp;<%--<asp:Button ID="btnExportToWord" runat="server" Text="Export TO Word" />--%>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
</p>
</asp:Content>
