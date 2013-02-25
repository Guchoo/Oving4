<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Sport.aspx.cs" EnableEventValidation="false" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Error" runat="server"></asp:Label><br />
    <asp:ListView ID="BrukerListe" DataKeyNames="Id" OnSelectedIndexChanging="BrukerListe_SelectedIndexChanging" runat="server">
        <EmptyDataTemplate>Ingen medlemmer, du kan prøve å legge noen til.</EmptyDataTemplate>
        <ItemTemplate>
            <asp:Button ID="DeleteButton" runat="server" CommandName="Select" Text="Delete" />

            <a href="/Bruker/Bruker.aspx?UID=<%# Eval("SuperId") %>"><%# Eval("Navn") %></a>
            <hr />
        </ItemTemplate>
    </asp:ListView>
</asp:Content>

 

