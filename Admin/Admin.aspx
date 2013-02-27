<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">    
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="User" DataTextField="UserName" DataValueField="UserId" Height="16px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="127px">
    </asp:DropDownList>
    <asp:SqlDataSource ID="User" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [UserId], [UserName] FROM [Users] ORDER BY [UserName]"></asp:SqlDataSource>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SportUser" DataTextField="Sport" DataValueField="Id" Height="16px" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged" Width="258px" RepeatColumns="3" RepeatDirection="Horizontal">
    </asp:CheckBoxList>
    <asp:SqlDataSource ID="SportUser" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Sport]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SportsLinkedToUser" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT UsersInSport.SportID
FROM UserInSport
WHERE UserInSport.UserID=@user">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="NULL" Name="user" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Label ID="Ut" runat="server"></asp:Label>
    <asp:Button ID="btnSaveSports" runat="server" OnClick="btnSaveSports_Click" Text="Lagre" />
</asp:Content>

