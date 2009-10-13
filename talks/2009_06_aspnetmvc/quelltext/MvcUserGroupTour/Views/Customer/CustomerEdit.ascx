<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcUserGroupTour.DataTransferObjects.CustomerDto>" %>

            <p>
                <label for="CustomerID">CustomerID:</label>
                <%=Html.TextBox("CustomerID", Model.CustomerID)%>
                <%=Html.ValidationMessage("CustomerID", "*")%>
            </p>
            <p>
                <label for="CompanyName">CompanyName:</label>
                <%=Html.TextBoxFor(c => c.CompanyName)%>
                <%=Html.ValidationMessage("CompanyName", "*")%>
            </p>
            <p>
                <label for="ContactName">ContactName:</label>
                <%=Html.TextBoxFor(c => c.ContactName)%>
                <%=Html.ValidationMessageFor(c => c.ContactName, "*")%>
            </p>
            <p>
                <%=Html.LabelFor(c => c.ContactTitle, "ContactTitle")%>
                <%=Html.TextBoxFor(ctx => ctx.ContactTitle)%>
                <%=Html.ValidationMessageFor(c => c.ContactTitle, "*")%>
            </p>
            <p>
                <label for="Address">Address:</label>
                <%=Html.TextBox("Address", Model.Address)%>
                <%=Html.ValidationMessage("Address", "*")%>
            </p>
            <p>
                <label for="City">City:</label>
                <%=Html.TextBox("City", Model.City)%>
                <%=Html.ValidationMessage("City", "*")%>
            </p>
            <p>
                <label for="Region">Region:</label>
                <%=Html.TextBox("Region", Model.Region)%>
                <%=Html.ValidationMessage("Region", "*")%>
            </p>
            <p>
                <label for="PostalCode">PostalCode:</label>
                <%=Html.TextBox("PostalCode", Model.PostalCode)%>
                <%=Html.ValidationMessage("PostalCode", "*")%>
            </p>
            <p>
                <label for="Country">Country:</label>
                <%=Html.TextBox("Country", Model.Country)%>
                <%=Html.ValidationMessage("Country", "*")%>
            </p>
            <p>
                <label for="Phone">Phone:</label>
                <%=Html.TextBox("Phone", Model.Phone)%>
                <%=Html.ValidationMessage("Phone", "*")%>
            </p>
            <p>
                <label for="Fax">Fax:</label>
                <%=Html.TextBox("Fax", Model.Fax)%>
                <%=Html.ValidationMessage("Fax", "*")%>
            </p>
            <p>
                <label for="OrderCount">OrderCount:</label>
                <%=Html.TextBox("OrderCount", Model.OrderCount)%>
                <%=Html.ValidationMessage("OrderCount", "*")%>
            </p>
