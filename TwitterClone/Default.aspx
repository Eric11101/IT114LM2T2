﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TwitterClone.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
<%--            <asp:Repeater ID="PostsRepeater" runat="server">
            <ItemTemplate>
                <div>
                    <p><%#Eval("Content") %></p>
                    <p><%#Eval("PostedBy") %></p>
                    <p><%#Eval("PostedOn") %></p>
                </div>
                <br />

            </ItemTemplate>
                </asp:Repeater>--%>

            <% foreach(var post in posts) %>
            <%{ %>
                <% if (post.PostedBy != "joblipat")%>
                <%{ %>

                <div>
                    <p><%=post.Content %></p>
                    <p><%=post.PostedBy %></p>
                    <p><%=post.PostedOn%></p>
                    <br />
                </div>

                <%} %>
                <%else %>
                    <%{ %>
                    <div> 
                        <p>You are not allowed to see this post</p>
                    </div>
                    <%}%>
             <%}%>
        </div>s
    </form>
</body>
</html>
