<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<eCommerceSiteWeb.Models.UserClass>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Registration
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Registration</h2>
<form id="Form1" method="post" runat="server">
<div class="editor-label">
                    <%: Html.LabelFor(m => m.FirstName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.FirstName) %>
                    <%: Html.ValidationMessageFor(m => m.FirstName) %>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.LastName) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.LastName)%>
                    <%: Html.ValidationMessageFor(m => m.LastName)%>
                </div>
                
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.Mail) %>
                </div>
                <div class="editor-field">
                    <%: Html.TextBoxFor(m => m.Mail) %>
                    <%: Html.ValidationMessageFor(m => m.Mail )%>
                </div>
                 <div class="editor-label">
                    <%: Html.LabelFor(m => m.Password) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.Password) %>
                    <%: Html.ValidationMessageFor(m => m.Password) %>
                </div>
                <div class="editor-label">
                    <%: Html.LabelFor(m => m.ConfirmPassword) %>
                </div>
                <div class="editor-field">
                    <%: Html.PasswordFor(m => m.ConfirmPassword) %>
                    <%: Html.ValidationMessageFor(m => m.ConfirmPassword) %>
                </div>
                
                <p>
                    <asp:Button ID="prova" runat="server" Text="Register" />
                </p>
                </form>

</asp:Content>
