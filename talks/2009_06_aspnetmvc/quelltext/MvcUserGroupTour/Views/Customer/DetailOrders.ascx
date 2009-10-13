<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcUserGroupTour.DataTransferObjects.OrderDto>>" %>
<%@ Import Namespace="MvcUserGroupTour.Controllers"%>

    <table>
        <tr>
            <th></th>
            <th>
                OrderDate
            </th>
            <th>
                RequiredDate
            </th>
            <th>
                ShippedDate
            </th>
            <th>
                Freight
            </th>
            <th>
                ShipName
            </th>
            <th>
                ShipCountry
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink<OrderController>(oc=>oc.Detail(item.OrderID), "Details")%>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:d}", item.OrderDate)) %>
            </td>
            <td>
                <%= Html.EncodeFormat("{0:d}", item.RequiredDate) %>
            </td>
            <td>
                <%= Html.EncodeFormat("{0:d}", item.ShippedDate) %>
            </td>
            <td>
                <%= Html.EncodeFormat("{0:F}", item.Freight) %>
            </td>
            <td>
                <%= Html.Encode(item.ShipName) %>
            </td>
            <td>
                <%= Html.Encode(item.ShipCountry) %>
            </td>
        </tr>
    
    <% } %>

    </table>
