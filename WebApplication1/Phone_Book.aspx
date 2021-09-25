<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Phone_Book.aspx.cs" Inherits="WebApplication1.Phone_Book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
        <div>   
        <table>
            <tr>
            <td>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="XX-Large" ForeColor="#CC0000" Text="Phone Book"></asp:Label>
            </td>
           </tr>
             <tr>
            <td>
            <asp:Label ID="IbIName" runat="server" Text="Name"></asp:Label>
            </td><td>
                <asp:TextBox ID="txtName" runat="server" MaxLength="50"></asp:TextBox>
               </td>
           </tr>
           <tr>
            <td>
            <asp:Label ID="IbIContact" runat="server" Text="Contact No."></asp:Label>
           </td><td>
             <asp:TextBox ID="txtContact" runat="server" MaxLength="11"></asp:TextBox>
            </td>
           </tr>
            <tr>
            <td>
            <asp:Label ID="IbILocation" runat="server" Text="Location"></asp:Label>
           </td><td>
                <asp:TextBox ID="txtLocation" runat="server" MaxLength="50"></asp:TextBox>
             </td>
           </tr>
            <tr>
            <td>
            <asp:Button ID="addbtn" runat="server" OnClick="addbtn_Click" Text="Add" style="height: 40px" />
          </td><td>
                <asp:Button ID="upbtn" runat="server" Text="Update" OnClick="upbtn_Click" />
             </td>
           </tr>
       </table>
      </div>
        <asp:GridView ID="gridBook" runat="server">
            <Columns>
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Phone_Book.aspx?id={0}&amp;action=1" HeaderText="Delete" Text="Delete">
                <ControlStyle ForeColor="Red" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Phone_Book.aspx?id={0}&amp;action=2" HeaderText="Edit" Text="Edit">
                <ControlStyle ForeColor="Green" />
                </asp:HyperLinkField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
