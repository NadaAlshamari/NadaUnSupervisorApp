<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testfile.aspx.cs" Inherits="unSupervisorApp.demo.testfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <table class="nav-justified">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 215px; height: 22px; text-align: center;"><strong>ClintName</strong></td>
            <td style="height: 22px">
                <asp:TextBox ID="txtClintName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 215px">&nbsp;</td>
            <td>
                <asp:FileUpload ID="FileUpload" runat="server" AllowMultiple="True" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 215px; height: 26px"></td>
            <td style="height: 26px">
                <asp:Button ID="btnUploadToFileSystem" runat="server" OnClick="btnUploadToFileSystem_Click" Text="UploadToFileSystem" />
                <asp:Button ID="btnUploadToDb" runat="server" OnClick="btnUploadToDb_Click" Text="UploadToDb" />
                <asp:Button ID="btnShowFile" runat="server" OnClick="btnShowFile_Click" Text="ShowFile" />
                <br />
                <br />
                <br />
                <asp:GridView ID="gvClientFiles" runat="server">
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
