<%@ Page Title="" Language="C#" MasterPageFile="~/Librarian/Librarian.Master" AutoEventWireup="true" CodeBehind="add_books.aspx.cs" Inherits="LibraryManagementSystem.Librarian.add_books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="c1" runat="server">
    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Add new Books</strong>
                        </div>
                        <div class="card-body">
                          <div id="pay-invoice">
                              <div class="card-body"> 
                                 <form action="" id="fo1" runat="server" method="post" novalidate="novalidate">
                                      
                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Books Title</label>
                                          <asp:TextBox ID="booksTitle" runat="server" class="form-control"></asp:TextBox>
                                      </div>

                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Books Image</label>
                                          <asp:FileUpload ID="f1" runat="server" class="form-control" />
                                      </div>

                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Books Pdf</label>
                                          <asp:FileUpload ID="f2" runat="server" class="form-control" />
                                      </div>

                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Books Video</label>
                                          <asp:FileUpload ID="f3" runat="server" class="form-control" />
                                      </div>

                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Books Author Name</label>
                                          <asp:TextBox ID="AuthorName" runat="server" class="form-control"></asp:TextBox>
                                      </div>

                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Books ISBN</label>
                                          <asp:TextBox ID="ISBN" runat="server" class="form-control"></asp:TextBox>
                                      </div>

                                      <div class="form-group">
                                          <label for="" class="control-label mb-1">Books Quantity</label>
                                          <asp:TextBox ID="Qty" runat="server" class="form-control"></asp:TextBox>
                                      </div>
                                               
                                      
                                      <div>
                                          <asp:Button ID="b1" runat="server" class="btn btn-lg btn-info btn-block" Text="Add Books" OnClick="b1_Click" />
                                      </div>

                                      <div class="alert alert-success" id="msg" runat="server" style="margin-top:10px; display:none">
                                      <strong>Books Added Successfully!</strong>
                        </div>
                                  </form>
 
                                 
                              </div>
                          </div>

                        </div>
                    </div>

                  </div>
</asp:Content>
