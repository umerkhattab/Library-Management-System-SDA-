<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="display_student_info.aspx.cs" Inherits="LibraryManagementSystem.Librarian.display_student_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="container-fluid" style="background-color: white; padding: 20px">
        <asp:Repeater ID="r1" runat="server">
            <HeaderTemplate>
                <table class="table table-bordered">
                    <tr>
                        <th>Image</th>
                        <th>Firstname</th>
                        <th>Lastname</th>
                        <th>Enr No</th>
                        <th>Username</th>
                        <th>Email</th>
                        <th>Contact</th>
                        <th>Status</th>
                        <th>Activate</th>
                        <th>Deactivate</th>


                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <img src="../<%#Eval("student_img") %>" height="100" width="100" /></td>
                    <td><%# Eval("firstname") %></td>
                    <td><%# Eval("lastname") %></td>
                    <td><%# Eval("enrollment_no") %></td>
                    <td><%# Eval("username") %></td>
                    <td><%# Eval("emial") %></td>
                    <td><%# Eval("contact") %></td>
                    <td><%# Eval("approved") %></td>
                    <td><a href="student_activate.aspx?id=<%# Eval("id") %>">Activate</a></td>
                    <td><a href="student_deactivate.aspx?id=<%# Eval("id") %>">Deactivate</a></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>

</asp:Content>
