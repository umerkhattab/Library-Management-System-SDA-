<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="student_registration.aspx.cs" Inherits="LibraryManagementSystem.Student.student_registration" %>

<!doctype html>
<html class="no-js" lang="">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>Student Registration Form</title>
    <meta name="description" content="Sufee Admin - HTML5 Admin Template">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="apple-touch-icon" href="apple-icon.png">
    <link rel="shortcut icon" href="favicon.ico">

    <link rel="stylesheet" href="assets/css/normalize.css">
    <link rel="stylesheet" href="assets/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/css/font-awesome.min.css">
    <link rel="stylesheet" href="assets/css/themify-icons.css">
    <link rel="stylesheet" href="assets/css/flag-icon.min.css">
    <link rel="stylesheet" href="assets/css/cs-skin-elastic.css">
    <link rel="stylesheet" href="assets/scss/style.css">

    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css'>

</head>
<body class="bg-dark">
    <div class="sufee-login d-flex align-content-center flex-wrap">
        <div class="container">
            <div class="login-content">
                <div class="login-logo">
                    <a href="index.html">
                        <asp:Label ID="title" runat="server" Text="Registration Form" Font-Names="Comic Sans MS" Font-Size="XX-Large" Width="400" BorderStyle="Solid"></asp:Label>
                    </a>
                </div>
                <div class="login-form">
                    <form id="f1" runat="server">
                        <div class="form-group">
                            <label>First Name</label>                           
                            <asp:TextBox ID="firstname" runat="server" class="form-control" placeholder="First Name"  ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Last Name</label>
                            <asp:TextBox ID="lastname" runat="server" class="form-control" placeholder="Last Name"  ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>Enrollment Number</label>
                            <asp:TextBox ID="enrollmentno" runat="server" class="form-control" placeholder="Enrollment Number"  ></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Username</label>
                            <asp:TextBox ID="username" runat="server" class="form-control" placeholder="Username"  ></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Password</label>
                            <asp:TextBox ID="password" runat="server" class="form-control" placeholder="Password" TextMode="Password"  ></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Email</label>
                            <asp:TextBox ID="email" runat="server" class="form-control" placeholder="Email"  ></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Contact</label>
                            <asp:TextBox ID="contact" runat="server" class="form-control" placeholder="Contact"  ></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>Student Image</label>
                            <asp:FileUpload ID="fo1" runat="server" />
                        </div>

                        <asp:Button ID="b1" runat="server"  class="btn btn-primary btn-flat m-b-30 m-t-30" Text="Register Now" OnClick="b1_Click"/>

                    </form>
                </div>
            </div>
        </div>
    </div>
    
    <script src="assets/js/vendor/jquery-2.1.4.min.js"></script>
    <script src="assets/js/popper.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/main.js"></script>
    
</body>
</html>
