﻿<%@ Page Language="C#" Async ="true" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title> Login </title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <section>
            <div class="content">
            <h1> Login Form : </h1>
            <asp:Table ID="Table" runat = "server" Height="250px" Width="382px" HorizontalAlign="Center" > 
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="Label2" runat="server" Text="Login" Font-Size="XX-Large" ></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="TextBox1" runat="server" BackColor="LightCyan" Width ="210px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                
                <asp:TableRow>
                    <asp:TableCell >
                        <asp:Label ID="Label3" runat="server" Text="Password" Font-Size="XX-Large"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                       <asp:TextBox ID="TextBox2" TextMode="Password" runat="server" BackColor="LightCyan" Width ="210px"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell ColumnSpan ="2" HorizontalAlign ="Center">
                        <asp:Label ID="Label1" ForeColor="Red" BackColor="LightPink" runat="server" 
                            Text=" Пользователь с таким логином и паролем не существует!"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell  HorizontalAlign ="Right">
                        <asp:Button ID="Button2" runat="server" Height ="35" Width ="150" BackColor="LawnGreen" Text="Registration Form" OnClick="Button2_Click"/>
                        </asp:TableCell>
                        <asp:TableCell  HorizontalAlign ="Right">
                         <asp:Button ID="Button1" runat="server" Height ="35" Width ="150" Text="Log in" OnClick ="Button1_Click" />
                    </asp:TableCell>   
                </asp:TableRow>

            </asp:Table>
            
        </div>
        </section>

        

    </form>
</body>
</html>
