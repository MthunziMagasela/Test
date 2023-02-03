<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XMLAddUpdateDelete.aspx.cs"
    Inherits="xmlInsertUpdateDelete.XMLAddUpdateDelete" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
                    ID
                </td>
                <td>
                    <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Name
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Designation
                </td>
                <td>
                    <asp:TextBox ID="txtDesignation" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    EmailID
                </td>
                <td>
                    <asp:TextBox ID="txtEmailID" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    City
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Country
                </td>
                <td>
                    <asp:TextBox ID="txtCountry" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Technology
                </td>
                <td>
                    <asp:TextBox ID="txtTechnology" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnAdd" runat="server" Text="Add Employee" 
                        OnClick="btnAdd_Click" Width="150px" />
                    &nbsp; <asp:Button ID="btnClear" runat="server" Text="Clear" 
                        onclick="btnClear_Click" Width="150px" />
                </td>
            </tr>
        </table>
    </div>
    <br />
    <br />
    <div>
        <table>
            <tr>
                <td>
                    <h2>
                        XML Records</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="grdxml" runat="server" AutoGenerateColumns="false" BackColor="White"
                        BorderColor="Black" BorderStyle="None" BorderWidth="1px" CellPadding="1" GridLines="Vertical"
                        OnSelectedIndexChanged="grdxml_SelectedIndexChanged" 
                        onrowdeleting="grdxml_RowDeleting">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:TemplateField HeaderText="ID">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpId" runat="server" Text='<%# Bind("ID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpName" runat="server" Text='<%# Bind("Name")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpDesignation" runat="server" Text='<%# Bind("Designation")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EmailID">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpEmailID" runat="server" Text='<%# Bind("EmailID")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="City">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpCity" runat="server" Text='<%# Bind("City")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpCountry" runat="server" Text='<%# Bind("Country")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Technology">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmpTechnology" runat="server" Text='<%# Bind("Technology")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton Text="Select" ID="lnkSelect" runat="server" CommandName="Select" />
                                     <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete">Delete</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>


                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="Azure" Font-Bold="True" />
                        <PagerStyle BackColor="ActiveCaption" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="LightCyan" ForeColor="Black" />
                        <SelectedRowStyle BackColor="LightSalmon" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
