<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="unSupervisorApp.demo._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <table class="nav-justified">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 163px; font-size: medium; text-align: center;"><strong>Insititution Name</strong></td>
            <td>
                <asp:DropDownList ID="ddlInsitution" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 163px; font-size: medium; text-align: center;"><strong>Supervisor ID</strong></td>
            <td style="height: 20px">
                <asp:TextBox ID="txtSupervisorId" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="height: 20px; width: 163px; font-size: medium; text-align: center;"><strong>First Name</strong></td>
            <td>
                <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 163px; font-size: medium; text-align: center;"><strong>Last Name</strong></td>
            <td>
                <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="height: 20px; width: 163px; font-size: medium; text-align: center;"><strong>Cell</strong></td>
            <td style="height: 20px">
                <asp:TextBox ID="txtCell" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="height: 20px; width: 163px; font-size: medium; text-align: center;"><strong>Email</strong></td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 163px">&nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" Text="ADD" OnClick="btnAdd_Click" />
                <asp:Button ID="btnEdit" runat="server" Text="EDIT" OnClick="btnEdit_Click" />
                <asp:Button ID="btnDelete" runat="server" Text="DELETE" OnClick="btnDelete_Click" />
                <asp:Button ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click" />
                <br />
                <br />
            </td>
        </tr>
    </table>

    <div>
        <asp:GridView ID="gvSupervisor" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="supervisorId" >
            <Columns>
                <asp:BoundField DataField="supervisorId" HeaderText="supervisorId" InsertVisible="False" ReadOnly="True" SortExpression="supervisorId" />
                <asp:BoundField DataField="fName" HeaderText="fName" SortExpression="fName" />
                <asp:BoundField DataField="lName" HeaderText="lName" SortExpression="lName" />
                <asp:BoundField DataField="cell" HeaderText="cell" SortExpression="cell" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="institution" HeaderText="institution" SortExpression="institution" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
