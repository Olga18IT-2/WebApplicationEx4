<%@ Page Language="C#"  Async ="true" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="WebApplication.UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"/>   
    <link href="Style.css" rel="stylesheet" />
    <script src="SelectAllBox.js"></script>
</head>
    
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label" ></asp:Label>
            <asp:Button ID="Button3" Height="35px" OnClick ="Button3_Click" runat="server" Text=" Close " Width="200px" />
        <div class="icon-bar">
              <a id="a1" runat="server"><i class="fa fa-lock"> Block </i></a>
              <a id="a2" runat="server" ><i class="fa fa-unlock"> Unblock </i></a>
              <a  id="a3" runat="server"><i class="fa fa-trash"> Delete </i></a>
        </div>
        
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DBConnection %>" 
        SelectCommand="SELECT [Id], [Name], [Email], [Date_registration], [Date_last_login], [Status], [Login] FROM [Users]" OnSelecting="SqlDataSource1_Selecting">
    </asp:SqlDataSource>
        <table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" 
            DataSourceID="SqlDataSource1" CellPadding="4" GridLines="None" >

            <Columns>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:CheckBox ID="CheckBox2" runat="server" onclick ="javascript:SelectAllBox(this);"/>
                        &nbsp;Select All
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                <asp:BoundField DataField="Login" HeaderText="Login" SortExpression="Login" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Date_registration" DataFormatString="{0:d}" HeaderText="Registration_date" SortExpression="Date_registration" />
                <asp:BoundField DataField="Date_last_login" DataFormatString="{0:d}" HeaderText="Last_login_date" SortExpression="Date_last_login" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
            </Columns>
        </asp:GridView>
        </table>

    </div>
    </form>
</body>
</html>
