<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DemoDtPaging._Default" %>

<%--  Code fragment showing an example of invoking Ajax  --%>
<%-- Notice that the parameters from DataTable must be encapsulated in 
     a Javascript object, and then stringified.
    Notice also that the name of the Javascript object ("paerameters" in this example
    has to match the parameter name in the WebMethod, or dotnet won't find the correct
    WebMethod and the Ajax call will kick back a 500 error.
    
    Permission to use this code for any purpose and without fee is hereby granted.
    No warrantles.
--%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    <table id="mytable" class="display" cellspacing="0" width="100%">
        <thead>
            <tr>
                <th>#</th>
                <th>fAbbrev</th>
                <th>fCountry</th>
            </tr>
        </thead>
        <tfoot>
            <tr>
                 <th>#</th>
                <th>fCountry</th>
            </tr>
        </tfoot>
    </table>
    <script type="text/javascript" src="/scripts/datatables/media/js/jquery.js"></script>
    <script type="text/javascript" src="/scripts/datatables/media/js/jquery.dataTables.js"></script>
    <script type="text/javascript" src="/scripts/mytable.js"></script>
</asp:Content>



