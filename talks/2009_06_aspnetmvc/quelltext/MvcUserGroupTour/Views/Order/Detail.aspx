<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcUserGroupTour.DataTransferObjects.OrderDto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Detail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Detail</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            OrderID:
            <%= Html.Encode(Model.OrderID) %>
        </p>
        <p>
            CustomerID:
            <%= Html.Encode(Model.CustomerID) %>
        </p>
        <p>
            EmployeeID:
            <%= Html.Encode(Model.EmployeeID) %>
        </p>
        <p>
            OrderDate:
            <%= Html.Encode(String.Format("{0:D}", Model.OrderDate)) %>
        </p>
        <p>
            RequiredDate:
            <%= Html.Encode(String.Format("{0:D}", Model.RequiredDate)) %>
        </p>
        <p>
            ShippedDate:
            <%= Html.Encode(String.Format("{0:D}", Model.ShippedDate)) %>
        </p>
        <p>
            ShipVia:
            <%= Html.Encode(Model.ShipVia) %>
        </p>
        <p>
            Freight:
            <%= Html.Encode(String.Format("{0:F}", Model.Freight)) %>
        </p>
        <p>
            ShipName:
            <%= Html.Encode(Model.ShipName) %>
        </p>
        <p>
            ShipAddress:
            <%= Html.Encode(Model.ShipAddress) %>
        </p>
        <p>
            ShipCity:
            <%= Html.Encode(Model.ShipCity) %>
        </p>
        <p>
            ShipRegion:
            <%= Html.Encode(Model.ShipRegion) %>
        </p>
        <p>
            ShipPostalCode:
            <%= Html.Encode(Model.ShipPostalCode) %>
        </p>
        <p>
            ShipCountry:
            <%= Html.Encode(Model.ShipCountry) %>
        </p>
    </fieldset>
    <p>
        <%=Html.ActionLink("Back to Customer", "Details", "Customer", new {  id=Model.CustomerID },null) %> |
    </p>

</asp:Content>

