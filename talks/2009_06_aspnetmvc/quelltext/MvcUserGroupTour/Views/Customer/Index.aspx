<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcUserGroupTour.DataTransferObjects.CustomerDto>>" %>
<%@ Import Namespace="MvcUserGroupTour.Controllers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%
    Html.BeginForm<CustomerController>(c => c.Search(""), FormMethod.Post);%>
<label for="searchText">Suchtext: </label><%=Html.TextBox("searchText") %><button type="submit">Suchen</button>
<%Html.EndForm(); %>
    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                CustomerID
            </th>
            <th>
                CompanyName
            </th>
            <th>
                ContactName
            </th>
            <th>
                City
            </th>
            <th>
                Country
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink<CustomerController>(c=>c.Edit(item.CustomerID),"Edit") %> |
                <%= Html.ActionLink<CustomerController>(c=>c.Details(item.CustomerID),"Details") %> |
            </td>
            <td>
                <%= Html.Encode(item.CustomerID) %>
            </td>
            <td>
                <%= Html.Encode(item.CompanyName) %>
            </td>
            <td>
                <%= Html.Encode(item.ContactName) %>
            </td>
            <td>
                <%= Html.Encode(item.City) %>
            </td>
            <td>
                <%= Html.Encode(item.Country) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
                <%= Html.ActionLink<CustomerController>(c=>c.Create(),"Create") %> |
    </p>

</asp:Content>

