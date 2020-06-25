﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Student/student.Master" AutoEventWireup="true" CodeBehind="student_display_all_books.aspx.cs" Inherits="LibraryManagementSystem.Student.student_display_all_books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">

     <div class="col-lg-14">
        <div class="card">
            <div class="card-header">
                <strong class="card-title">All Books</strong>
            </div>
            <div class="card-body">
                <asp:Repeater ID="r1" runat="server">
                    <HeaderTemplate>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col">Books Image</th>
                                    <th scope="col">Books Title</th>
                                    <th scope="col">Books Pdf</th>
                                    <th scope="col">Books Video</th>
                                    <th scope="col">Author Name</th>
                                    <th scope="col">ISBN</th>
                                    <th scope="col">Available Quantity</th>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                         <ItemTemplate>
                        <tr>
                            <td><img src="../Librarian/<%# Eval("books_image") %>" height="100" width="100" /></td>
                            <td><%# Eval("books_title") %></td>
                            <td><%# Eval("books_pdf") %><br /><%#checkPdf(Eval("books_pdf"),Eval("id")) %></td>
                            <td><video src="../Librarian/<%# Eval("books_video") %>" height="100" width="100" /><br /><%#checkvideo(Eval("books_video"),Eval("id")) %></td>
                            <td><%# Eval("books_author_name") %></td>
                            <td><%# Eval("books_isbn") %></td>
                            <td><%# Eval("available_qty") %></td>    
                        </tr>

                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>



               
            </div>
        </div>
    </div>

</asp:Content>
