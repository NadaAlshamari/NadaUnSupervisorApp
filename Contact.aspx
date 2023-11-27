<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="unSupervisorApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        &nbsp;</address>
    <table border="0">
        <tr>
            <td></td>
            <td><strong><em>
                <asp:Label ID="lblMsg" runat="server" ForeColor="Black"></asp:Label>
                </em></strong></td>
        </tr>
        <tr>
            <td><strong><em>From -Email</em></strong></td>
            <td><strong>
                <asp:TextBox ID="txtSenderEmail" runat="server" Height="16px" Width="450px"></asp:TextBox>
                </strong></td>
        </tr>
        <tr>
            <td><strong><em>Subject </em></strong></td>
            <td><strong>
                <asp:TextBox ID="txtSubject" runat="server" OnLoad="lblOutputClear_txtSubject" Width="450px"></asp:TextBox>
                </strong></td>
        </tr>
        <tr>
            <td><strong><em>File Attachments:</em></strong></td>
            <td><strong>
                <asp:FileUpload ID="fuAttachment" runat="server" AllowMultiple="true" Enabled="true" Width="449px" />
                </strong></td>
        </tr>
        <tr>
            <td valign="top"><strong><em>Message </em></strong></td>
            <td><strong>
                <asp:TextBox ID="txtBody" runat="server" Height="103px" TextMode="MultiLine" Width="455px"></asp:TextBox>
                </strong></td>
        </tr>
        <tr>
            <td valign="top">&nbsp;</td>
            <td><strong>
                <asp:Button ID="btnSendMailViaMailMgr" runat="server" BackColor="Black" BorderColor="Black" OnClick="btnSendMailViaMailMgr_Click" style="color: #FFFFFF; font-weight: bold" Text="Send " />
                <asp:Button ID="Button1" runat="server" BackColor="Black" BorderColor="Black" OnClick="Button1_Click" style="font-weight: bold; color: #FFFFFF" Text="Button" />
                </strong></td>
        </tr>
    </table>
    <address>
        &nbsp;</address>
    <address>
    </address>
    <address>
        &nbsp;</address>

    </asp:Content>
