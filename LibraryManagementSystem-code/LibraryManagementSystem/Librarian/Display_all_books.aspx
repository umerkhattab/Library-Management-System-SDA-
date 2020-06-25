﻿<%@ Page Title="Books" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="Display_all_books.aspx.cs" Inherits="LibraryManagementSystem.Librarian.Display_all_books" %>

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
                                    <th scope="col">Edit Book</th>
                                    <th scope="col">Delete Book</th>

                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <FooterTemplate>
                        </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>



               
            </div>
        </div>
    </div>


</asp:Content>