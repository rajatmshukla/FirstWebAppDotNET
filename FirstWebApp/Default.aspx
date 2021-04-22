<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FirstWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <p>Hello World</p>
    <br />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" Height="277px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="1055px">
</asp:GridView>
    <br />
    <asp:Label ID="lblError" runat="server" Text="Label" ForeColor="#CC3300"></asp:Label>
<br />
<br />
<asp:TextBox ID="TxtBoxEmpId" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtBoxEmpId" ErrorMessage="ID Cannot Be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;
<br />
<asp:TextBox ID="TxtBoxEmpName" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtBoxEmpName" ErrorMessage="Employee Name Should Not Be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtBoxEmpName" ErrorMessage="Only Characters Allowed" ForeColor="Red" ValidationExpression="[a-zA-Z ]*$"></asp:RegularExpressionValidator>
<br />
<asp:TextBox ID="TxtBoxDept" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtBoxDept" ErrorMessage="Department ID Should Not Be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;
<br />
<asp:TextBox ID="TxtBoxSal" runat="server"></asp:TextBox>
&nbsp;&nbsp;
    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtBoxSal" ErrorMessage="Salary Should Not Be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
&nbsp;
<br />
    &nbsp;&nbsp;
<br />
&nbsp;&nbsp;
    <asp:Button ID="btnAddEdit" runat="server" Text="Add" OnClick="Button1_Click" />
    &nbsp;&nbsp;
    <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
    <br />
    <br />
    <br />
    <br />
</asp:Content>