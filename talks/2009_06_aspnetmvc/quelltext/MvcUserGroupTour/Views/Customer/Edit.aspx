<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcUserGroupTour.DataTransferObjects.CustomerDto>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <%using (Html.BeginForm())
        {%>

        <fieldset>
            <legend>Fields</legend>
            <%Html.RenderPartial("CustomerEdit"); %>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <%}%>

    <div>
        <%=Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>

