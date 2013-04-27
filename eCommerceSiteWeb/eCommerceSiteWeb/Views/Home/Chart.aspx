<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<eCommerceSiteWeb.Models.ChartClass>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Chart
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<h2>Chart</h2>
<%if (Model == null)
  {%> <a>There aren't any products</a> <%}
  else
  { %>

<table>
    <tr>
        <th>
            ID
        </th>
        <th>
            Quantity
        </th>
         <th>
            Title
        </th>
        <th>
            PriceSingProduct
        </th>
         <th>
            TotPriceAllProduct
        </th>
       
    </tr>


<% foreach (var item in Model)
   { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.IDProduct)%>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Quantity)%>
        </td>
         <td>
            <%: Html.DisplayFor(modelItem => item.Title)%>
        </td>
        <td>
           € <%: Html.DisplayFor(modelItem => item.PriceSingProduct)%>
        </td>
      
        <td>
           € <%: Html.DisplayFor(modelItem => item.TotPriceAllProduct)%>
        </td>

        
       
       
        
       
    </tr>
    
<% } %>

</table>
<%} %>

</asp:Content>
