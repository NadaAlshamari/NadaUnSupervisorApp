<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Intern.aspx.cs" Inherits="unSupervisorApp.ForStudents.Intern" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <h2> intern Management  </h2>
        <p> 
            <asp:Label ID="lblOutput" runat="server" ></asp:Label>
        </p>
        <table class="nav-justified">
            <tr>
                <td class="text-center" style="width: 252px">
        <label style="margin-top: 0px"> intern Id</label></td>
                <td>
        <asp:TextBox ID="txtinternId" runat="server"
           
            />
       
                </td>
            </tr>
            <tr>
                <td class="text-center" style="width: 252px">
        <label>First Name</label></td>
                <td>
        <asp:TextBox ID="txtfName" runat="server"   />
                </td>
            </tr>
            <tr>
                <td class="text-center" style="width: 252px">
        <label>Middel Name </label>
                </td>
                <td>
        <asp:TextBox ID="txtmName"  runat="server" />
                </td>
            </tr>
            <tr>
                <td class="text-center" style="width: 252px">
        <label>GrandFather Name </label>
                </td>
                <td>
        <asp:TextBox ID="txtgfName"  runat="server" />
                </td>
            </tr>
            <tr>
                <td class="text-center" style="width: 252px">
        <label>&nbsp;Last Name </label>
                </td>
                <td>
        <asp:TextBox ID="txtlName"  runat="server" />
                </td>
            </tr>
            <tr>
                <td class="text-center" style="width: 252px">
        <label>NID </label>
                </td>
                <td>
        <asp:TextBox ID="txtNId"  runat="server" />
                </td>
            </tr>
            <tr>
                <td class="text-center" style="width: 252px">
        <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; institution</label></td>
                <td>
            <asp:DropDownList ID="ddlinsitution" runat="server">

            </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="text-center" style="width: 252px">
        <label>cell</label></td>
                <td>
        <asp:TextBox ID="txtcell"  runat="server" />
                </td>
            </tr>
            <tr>
                <td class="text-center" style="width: 252px">
                    <label>
                    email</label></td>
                <td>
                    <asp:TextBox ID="txtemail"  runat="server" />
                </td>
            </tr>
            <tr>
                <td class="text-center" style="width: 252px">
        <label style="height: 20px">active </label>
                </td>
                <td>
                     <asp:RadioButtonList ID="rblActive" runat="server">
                         <asp:ListItem Value="0"> NO </asp:ListItem>
                         <asp:ListItem Value="1"> Yes </asp:ListItem>
                     </asp:RadioButtonList>
                 </td>
            </tr>
        </table>
  
    <div   >
        &nbsp;</div>
    
  

    <div>
        &nbsp;</div> 

    
    <div>
    <table class="nav-justified">
        <tr>
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

         

  
    </div> 

    <br />
 


      <asp:GridView ID="gvintern" runat="server" AutoGenerateColumns="False" >
          <Columns>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="internId">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkupdate" runat="server"  
                                        CommandArgument='<%# Bind("internId") %>' OnClick="populateForm_Click"
                                        Text='<%# Eval("internId")  %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left"></ItemStyle>
                            </asp:TemplateField>

               <asp:BoundField DataField="internId" HeaderText="internId" SortExpression="internId" />
              <asp:BoundField DataField="fName" HeaderText="fName" SortExpression="fName" />
              <asp:BoundField DataField="mName" HeaderText="mName" SortExpression="mName" />
              <asp:BoundField DataField="gfName" HeaderText="gfName" SortExpression="gfName" />
              <asp:BoundField DataField="lName" HeaderText="lName" SortExpression="lName" />
              <asp:BoundField DataField="nId" HeaderText="nId" SortExpression="nId" />
              <asp:BoundField DataField="cell" HeaderText="cell" SortExpression="cell" />
              <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
              <asp:CheckBoxField DataField="active" HeaderText="active" SortExpression="active" />
              <asp:BoundField DataField="institution" HeaderText="institution" SortExpression="institution" />
          </Columns>
               
      </asp:GridView>

 
</asp:Content>


