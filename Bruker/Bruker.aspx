<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Bruker.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSourceUserInSport" AutoGenerateColumns="False" Visible="False">
        <Columns>
            <asp:BoundField DataField="Sport" HeaderText="Sport" SortExpression="Sport" />
            <asp:BoundField DataField="UserName" HeaderText="Medlem" SortExpression="UserName" />
        </Columns>
    </asp:GridView>
    <asp:ListView ID="ListView1" runat="server" DataSourceID="sqlDataSport" DataKeyNames="Id" Visible="False">
        <AlternatingItemTemplate>
            <span style="background-color: #FAFAD2;color: #284775;">Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Sport:
            <asp:Label ID="SportLabel" runat="server" Text='<%# Eval("Sport") %>' />
            <br />
<br /></span>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <span style="background-color: #FFCC66;color: #000080;">Id:
            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Sport:
            <asp:TextBox ID="SportTextBox" runat="server" Text='<%# Bind("Sport") %>' />
            <br />
            <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
            <br /><br /></span>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <span>No data was returned.</span>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <span style="">Sport:
            <asp:TextBox ID="SportTextBox" runat="server" Text='<%# Bind("Sport") %>' />
            <br />
            <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
            <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
            <br /><br /></span>
        </InsertItemTemplate>
        <ItemTemplate>
            <span style="background-color: #FFFBD6;color: #333333;">Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Sport:
            <asp:Label ID="SportLabel" runat="server" Text='<%# Eval("Sport") %>' />
            <br />
<br /></span>
        </ItemTemplate>
        <LayoutTemplate>
            <div id="itemPlaceholderContainer" runat="server" style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                <span runat="server" id="itemPlaceholder" />
            </div>
            <div style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
            </div>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <span style="background-color: #FFCC66;font-weight: bold;color: #000080;">Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Sport:
            <asp:Label ID="SportLabel" runat="server" Text='<%# Eval("Sport") %>' />
            <br />
<br /></span>
        </SelectedItemTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="sqlDataSport" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT * FROM [Sport] ORDER BY [Sport]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceUserInSport" runat="server" ConnectionString="<%$ ConnectionStrings:DefaultConnection %>" SelectCommand="SELECT [Sport].Sport, [Users].UserName 
FROM [UserInSport],[Users],[Sport]
WHERE [Users].UserId = [UserInSport].UserID AND [Sport].Id = [UserInSport].SportID
ORDER BY [Sport].Sport, [Users].UserName"></asp:SqlDataSource>
    <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
</asp:Content>

