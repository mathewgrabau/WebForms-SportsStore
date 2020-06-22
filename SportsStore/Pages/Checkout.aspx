﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Store.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="SportsStore.Pages.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="bodyContent" runat="server">
    <div id="content">
        <div id="checkoutForm" runat="server" class="checkout">
            <h2>Checkout Now</h2>
            Please enter your details. Your order will be dispatched as soon as possible.

            <div id="errors">
                <asp:ValidationSummary runat="server" />
            </div>

            <h3>Ship to</h3>
            <div>
                <label for="name">Name:</label>
                <input id="name" name="name" />
            </div>

            <h3>Address</h3>
            <div>
                <label for="line1">Line 1:</label>
                <input id="line1" name="line1" />
            </div>
            <div>
                <label for="line2">Line 2:</label>
                <input id="line2" name="line2" />
            </div>
            <div>
                <label for="line3">Line 3:</label>
                <input id="line3" name="line3" />
            </div>
            <div>
                <label for="city">City:</label>
                <input id="city" name="city" />
            </div>
            <div>
                <label for="state">State:</label>
                <input id="state" name="state" />
            </div>

            <h3>Options</h3>
            <input type="checkbox" id="giftwrap" name="giftwrap" value="true" />
            Gift wrap your order?

            <p class="actionButtons">
                <button class="actionButtons" type="submit">Complete Order</button>
            </p>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Thanks!</h2>
            Thanks for placing your order. Your order will be shipped as soon as possible.
        </div>
    </div>
</asp:Content>