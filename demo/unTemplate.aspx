<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="unTemplate.aspx.cs" Inherits="unSupervisorApp.demo.unTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
    </p>
    <table class="nav-justified">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
                 <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 276px; height: 22px; font-size: medium;" class="text-center"><strong>Institution</strong></td>
            <td style="height: 22px">
                <asp:DropDownList ID="ddlInstitution" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlInstitution_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 276px; font-size: medium;" class="text-center"><strong>Tempate</strong></td>
            <td>
                <asp:DropDownList ID="ddlTemplate" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="width: 276px">&nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnGenerateTemplateWord" runat="server" OnClick= "btnGenerateTemplateWord_Click" Text="GenerateTemplate word " />
                <asp:Button ID="btnGenerateTemplatePDF" runat="server" OnClick="btnGenerateTemplatePDF_Click" Text="GenerateTemplate PDF " />
                <asp:Button ID="btnSendEmail" runat="server" OnClick="btnSendEmail_Click" Text="SendEmail" />
            </td>
        </tr>
    </table>

    <div>
        <asp:GridView  ID="gvData" runat="server">
            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>

                        <asp:CheckBox ID="cbSelect" runat="server" AutoPostBack="true" Text=" Select All"  OnCheckedChanged="cbSelect_CheckedChanged"/>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <asp:CheckBox ID="cbAll" runat="server" OnCheckedChanged="cbAll_CheckedChanged" />
                    </ItemTemplate>

                </asp:TemplateField>


            </Columns>

        </asp:GridView>
    </div>
</asp:Content>
