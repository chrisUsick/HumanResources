<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfEmployee.aspx.cs" Inherits="wfEmployee" %>
<%@ Register src="~/MessageBoxUserControl.ascx" tagname="MessageBoxUserControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:MessageBoxUserControl ID="MessageBoxUserControl1" runat="server" />
    <asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
<asp:GridView ID="gvEmployees" runat="server" AutoGenerateColumns="False" 
    AutoGenerateSelectButton="True">
    <Columns>
        <asp:BoundField DataField="EmployeeID" HeaderText="Employee" />
        <asp:BoundField HeaderText="First Name" DataField="FirstName" />
        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
        <asp:BoundField DataField="HireDate" HeaderText="Hire Date" />
        <asp:BoundField DataField="Salary" DataFormatString="{0:c}" 
            HeaderText="Salary" >
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
<asp:Literal ID="PopupBox" runat="server"></asp:Literal>
</asp:Content>

