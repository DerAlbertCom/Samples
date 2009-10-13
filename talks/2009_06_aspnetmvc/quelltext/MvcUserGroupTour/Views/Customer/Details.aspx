<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CustomerDetailModel>" %>
<%@ Import Namespace="MvcUserGroupTour.Controllers"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            CustomerID:
            <%=Html.Encode(Model.Customer.CustomerID)%>
        </p>
        <p>
            CompanyName:
            <%=Html.Encode(Model.Customer.CompanyName)%>
        </p>
        <p>
            ContactName:
            <%=Html.Encode(Model.Customer.ContactName)%>
        </p>
        <p>
            ContactTitle:
            <%=Html.Encode(Model.Customer.ContactTitle)%>
        </p>
        <p>
            Address:
            <%=Html.Encode(Model.Customer.Address)%>
        </p>
        <p>
            City:
            <%=Html.Encode(Model.Customer.City)%>
        </p>
        <p>
            Region:
            <%=Html.Encode(Model.Customer.Region)%>
        </p>
        <p>
            PostalCode:
            <%=Html.Encode(Model.Customer.PostalCode)%>
        </p>
        <p>
            Country:
            <%=Html.Encode(Model.Customer.Country)%>
        </p>
        <p>
            Phone:
            <%=Html.Encode(Model.Customer.Phone)%>
        </p>
        <p>
            Fax:
            <%=Html.Encode(Model.Customer.Fax)%>
        </p>
        <p>
            OrderCount:
            <%=Html.Encode(Model.Customer.OrderCount)%>
        </p>
        <%Html.RenderPartial("DetailOrders",Model.Orders); %>
    </fieldset>
    <p>
        <%=Html.ActionLink("Edit", "Edit", new {id = Model.Customer.CustomerID})%> |
        <%=Html.ActionLink<CustomerController>(c => c.Index(), "Back to List")%>
    </p>

</asp:Content>

