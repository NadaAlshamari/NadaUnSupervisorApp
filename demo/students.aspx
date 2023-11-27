<%@ Page Culture="en-EN" Language="C#"   MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="unSupervisorApp.demo.students" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <br />

<table class="nav-justified">
   
     <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>Opration</strong></td>
        <td>
            <asp:DropDownList ID="opration" runat="server" AutoPostBack="True" OnSelectedIndexChanged="opration_SelectedIndexChanged" >
                <asp:ListItem Selected="True" Value="Add New Student">Add New Student</asp:ListItem>
                <asp:ListItem  Value="Join To Course">Join To Course</asp:ListItem>
                 <asp:ListItem  Value="Update Student">Update Student</asp:ListItem>
               
            </asp:DropDownList>
            </td>
    </tr>
      <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>Institute</strong></td>
        <td>
            <asp:DropDownList ID="institute" runat="server" AutoPostBack="True" OnSelectedIndexChanged="institute_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>Course</strong></td>
        <td>
            <asp:DropDownList ID="course" runat="server" OnSelectedIndexChanged="course_SelectedIndexChanged">
            </asp:DropDownList>
        </td>
    </tr>
     <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>Supervisor</strong></td>
        <td>
            <asp:DropDownList ID="supervisor" AutoPostBack="True" runat="server" >
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="height: 20px; width: 250px; font-size: medium;" class="text-center"><strong>Student</strong></td>
        <td style="height: 20px">
          
            <asp:DropDownList ID="student" AutoPostBack="True" runat="server" OnSelectedIndexChanged="student_SelectedIndexChanged" >
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="height: 20px; width: 250px; font-size: medium;" class="text-center"><strong>Student ID</strong></td>
        <td style="height: 20px">
            <asp:TextBox ID="student_id2" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="height: 20px; width: 250px; font-size: medium;" class="text-center"><strong>Student First Name</strong></td>
        <td style="height: 20px">
            <asp:TextBox ID="student_first_name" runat="server"></asp:TextBox>
        </td>
    </tr>
     <tr>
        <td style="height: 20px; width: 250px; font-size: medium;" class="text-center"><strong>Student Lsat Name</strong></td>
        <td style="height: 20px">
            <asp:TextBox ID="student_last_name" runat="server"></asp:TextBox>
        </td>
    </tr>
  
    <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>Student Email Name</strong></td>
        <td>
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
          
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>Course Start Date</strong></td>
        <td>
           
            <asp:Calendar ID="start_date" runat="server"></asp:Calendar>
        </td>
    </tr>

     <tr>
        <td class="modal-lg" style="width: 250px; text-align: center; font-size: medium;"><strong>Course End Date</strong></td>
        <td>
           
            <asp:Calendar ID="end_date" runat="server"></asp:Calendar>
        </td>
    </tr>
    <tr>
        <td class="modal-lg" style="width: 250px">&nbsp;</td>
        <td>
            <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"  />
             <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_Click"   />
          
            <br />
            <br />
            <br />
           
            <br />
        </td>
    </tr>
</table>
</asp:Content>