<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<eCommerceSiteWeb.Models.Products>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Catalogo</h2>

<form id="Form1" method="post" runat="server">

<table>
    <tr>
        <th>
            Title
        </th>
        <th>
            Description
        </th>
        <th>Quantity</th>
        <th></th>
    </tr>

<%eCommerceSiteWeb.Models.Products prt=new eCommerceSiteWeb.Models.Products();  %>

 
<%foreach (var item in Model)
  { %> 
          
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Title)%>
           
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Description)%>
        </td>
        <td>   
               <%=Html.TextBox("Quantity", null, new { @prt = item })%> 
              
               <% =Html.Hidden("IDProduct", item.ID)%> 
          </td>                   <% //uso di hidden %>
               
                

 <td>    

<asp:Button ID="prova"  runat="server" Text="Buy" /> 
  </td> 

 </tr>
<% } %>
</table>

</form>

</asp:Content>
