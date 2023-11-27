<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="internTask.aspx.cs" Inherits="unSupervisorApp.demo.internTask" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    <br />
</p>
<p>
</p>
<p>
</p>
<table class="nav-justified">
    <tr>
        <td colspan="2">
            <asp:Label ID="lblOutput" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height: 20px; width: 250px; font-size: medium;" class="text-center"><strong>intern Task ID</strong></td>
        <td style="height: 20px">
            <asp:TextBox ID="txtTaskId" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>intern</strong></td>
        <td>
            <asp:DropDownList ID="ddlintern" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>task name</strong></td>
        <td>
            <asp:TextBox ID="txtTaskName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>task start date</strong></td>
        <td>
            <asp:TextBox ID="txtTaskStartDate" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>task end date</strong></td>
        <td>
            <asp:TextBox ID="txtTaskEndDate" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>completed </strong> </td>
        <td>
            <asp:RadioButtonList ID="rblCompleted" runat="server">
                <asp:ListItem Value="0" Text=" NO "></asp:ListItem>
                                <asp:ListItem Value="1" Text=" YES "></asp:ListItem>

            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>notes </strong> </td>
        <td>
            <asp:TextBox ID="txtNote" runat="server" Height="99px"  TextMode="MultiLine" Width="149px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px">&nbsp;</td>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
            <asp:Button ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="delete" OnClick="btnDelete_Click" />
            <asp:Button ID="btnSelect" runat="server" Text="select" OnClick="btnSelect_Click" />
            <br />
            <br />
            <br />
            <asp:GridView ID="gvInternTask" runat="server" AutoGenerateColumns="False" DataKeyNames="internTaskId"  Width="205px">
                <Columns>
                      <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="internTaskId">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkupdate" runat="server"  
                                        CommandArgument='<%# Bind("internTaskId") %>' OnClick="populateForm_Click"
                                        Text='<%# Eval("internTaskId")  %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left"></ItemStyle>
                            </asp:TemplateField>
                    <asp:BoundField DataField="internTaskId" HeaderText="internTaskId" InsertVisible="False" ReadOnly="True" SortExpression="internTaskId" />
                    <asp:BoundField DataField="fullName" HeaderText="fullName" ReadOnly="True" SortExpression="fullName" />
                    <asp:BoundField DataField="taskName" HeaderText="taskName" SortExpression="taskName" />
                    <asp:BoundField DataField="taskStartDate" HeaderText="taskStartDate" SortExpression="taskStartDate" />
                    <asp:BoundField DataField="taskEndDate" HeaderText="taskEndDate" SortExpression="taskEndDate" />
                    <asp:CheckBoxField DataField="completed" HeaderText="completed" SortExpression="completed" />
                    <asp:BoundField DataField="note" HeaderText="note" SortExpression="note" />
                </Columns>

            </asp:GridView>
            <br />
        </td>
    </tr>
</table>
</asp:Content>
