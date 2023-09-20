<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendEmails.aspx.cs" Inherits="ConnectMagnetNew.Office.Email.SendEmails" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <title>ConnectMagnet - Email Setup</title>
  <!-- plugins:css -->
  <link rel="stylesheet" href="../vendors/iconfonts/mdi/css/materialdesignicons.min.css">
  <link rel="stylesheet" href="../vendors/css/vendor.bundle.base.css">
  <link rel="stylesheet" href="../vendors/css/vendor.bundle.addons.css">
  <!-- endinject -->
  <!-- plugin css for this page -->
  <!-- End plugin css for this page -->
  <!-- inject:css -->
  <link rel="stylesheet" href="../css/style.css">
  <!-- endinject -->
  <link rel="shortcut icon" href="../images/favicon.ico" />
     <script type="text/javascript">
        function ShowPopup() {
            $("#btnShowPopup").click();
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
                        data-toggle="modal" data-target="#myModal">
                    Launch demo modal
                </button>
                <div class="modal fade" id="myModal">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title" style="text-align:center;">
                  ConnectMagnet Messenger:
                   &nbsp&nbsp&nbsp&nbsp
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span> &times;</span>
                                </button>                                
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblMessage" runat="server" style="text-align:center;"/>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-success btn-fw" data-dismiss="modal" data-backdrop="false">
                                    Close
                                </button>
                                <%--<button type="button" class="btn btn-primary">
                                    Save changes
                                </button>--%>
                            </div>
                        </div>
                        <!-- /.modal-content -->
                    </div>
                    <!-- /.modal-dialog -->
                </div>
                
            </div>
        </div>
  <div class="container-scroller">
    <!-- partial:partials/_navbar.html -->
    <nav class="navbar default-layout col-lg-12 col-12 p-0 fixed-top d-flex flex-row">
      <div class="text-center navbar-brand-wrapper d-flex align-items-top justify-content-center">
        <a class="navbar-brand brand-logo" href="index.aspx">
          <!--<img src="images/logo.png" alt="logo">-->
        </a>
        <a class="navbar-brand brand-logo-mini" href="index.aspx">
          <!--<img src="images/logo-mini.png" alt="logo" />-->
        </a>
      </div>
      <div class="navbar-menu-wrapper d-flex align-items-center">
        <ul class="navbar-nav navbar-nav-left header-links d-none d-md-flex">
          <li class="nav-item">
            <a href="Deposit.aspx" class="nav-link">
                 <i class="mdi mdi-credit-card-plus"></i>Deposits</a>
          </li>
          <li class="nav-item active">
            <a href="Earnings.aspx" class="nav-link">
              <i class="mdi mdi-bank"></i>Earnings</a>
          </li>
          <li class="nav-item">
            <a href="Reports.aspx" class="nav-link">
              <i class="mdi mdi-bookmark-plus-outline"></i>Reports</a>
          </li>
        </ul>
        <ul class="navbar-nav navbar-nav-right">
          <%--<li class="nav-item dropdown">
            <a class="nav-link count-indicator dropdown-toggle" id="messageDropdown" href="#" data-toggle="dropdown" aria-expanded="false">
              <i class="mdi mdi-file-document-box"></i>
              <span class="count">7</span>
            </a>
            <div class="dropdown-menu dropdown-menu-right navbar-dropdown preview-list" aria-labelledby="messageDropdown">
              <div class="dropdown-item">
                <p class="mb-0 font-weight-normal float-left">You have 7 unread mails
                </p>
                <span class="badge badge-info badge-pill float-right">View all</span>
              </div>
              <div class="dropdown-divider"></div>
              <a class="dropdown-item preview-item">
                <div class="preview-thumbnail">
                  <img src="images/faces/face4.jpg" alt="image" class="profile-pic">
                </div>
                <div class="preview-item-content flex-grow">
                  <h6 class="preview-subject ellipsis font-weight-medium text-dark">David Grey
                    <span class="float-right font-weight-light small-text">1 Minutes ago</span>
                  </h6>
                  <p class="font-weight-light small-text">
                    The meeting is cancelled
                  </p>
                </div>
              </a>
              <div class="dropdown-divider"></div>
              <a class="dropdown-item preview-item">
                <div class="preview-thumbnail">
                  <img src="images/faces/face2.jpg" alt="image" class="profile-pic">
                </div>
                <div class="preview-item-content flex-grow">
                  <h6 class="preview-subject ellipsis font-weight-medium text-dark">Tim Cook
                    <span class="float-right font-weight-light small-text">15 Minutes ago</span>
                  </h6>
                  <p class="font-weight-light small-text">
                    New product launch
                  </p>
                </div>
              </a>
              <div class="dropdown-divider"></div>
              <a class="dropdown-item preview-item">
                <div class="preview-thumbnail">
                  <img src="images/faces/face3.jpg" alt="image" class="profile-pic">
                </div>
                <div class="preview-item-content flex-grow">
                  <h6 class="preview-subject ellipsis font-weight-medium text-dark"> Johnson
                    <span class="float-right font-weight-light small-text">18 Minutes ago</span>
                  </h6>
                  <p class="font-weight-light small-text">
                    Upcoming board meeting
                  </p>
                </div>
              </a>
            </div>
          </li>
          <li class="nav-item dropdown">
            <a class="nav-link count-indicator dropdown-toggle" id="notificationDropdown" href="#" data-toggle="dropdown">
              <i class="mdi mdi-bell"></i>
              <span class="count">4</span>
            </a>
            <div class="dropdown-menu dropdown-menu-right navbar-dropdown preview-list" aria-labelledby="notificationDropdown">
              <a class="dropdown-item">
                <p class="mb-0 font-weight-normal float-left">You have 4 new notifications
                </p>
                <span class="badge badge-pill badge-warning float-right">View all</span>
              </a>
              <div class="dropdown-divider"></div>
              <a class="dropdown-item preview-item">
                <div class="preview-thumbnail">
                  <div class="preview-icon bg-success">
                    <i class="mdi mdi-alert-circle-outline mx-0"></i>
                  </div>
                </div>
                <div class="preview-item-content">
                  <h6 class="preview-subject font-weight-medium text-dark">Application Error</h6>
                  <p class="font-weight-light small-text">
                    Just now
                  </p>
                </div>
              </a>
              <div class="dropdown-divider"></div>
              <a class="dropdown-item preview-item">
                <div class="preview-thumbnail">
                  <div class="preview-icon bg-warning">
                    <i class="mdi mdi-comment-text-outline mx-0"></i>
                  </div>
                </div>
                <div class="preview-item-content">
                  <h6 class="preview-subject font-weight-medium text-dark">Settings</h6>
                  <p class="font-weight-light small-text">
                    Private message
                  </p>
                </div>
              </a>
              <div class="dropdown-divider"></div>
              <a class="dropdown-item preview-item">
                <div class="preview-thumbnail">
                  <div class="preview-icon bg-info">
                    <i class="mdi mdi-email-outline mx-0"></i>
                  </div>
                </div>
                <div class="preview-item-content">
                  <h6 class="preview-subject font-weight-medium text-dark">New user registration</h6>
                  <p class="font-weight-light small-text">
                    2 days ago
                  </p>
                </div>
              </a>
            </div>
          </li>--%>
          <li class="nav-item dropdown d-none d-xl-inline-block">
            <a class="nav-link dropdown-toggle" id="UserDropdown" href="#" data-toggle="dropdown" aria-expanded="false">
              <span class="profile-text">Hello, <asp:Label ID="LblName" runat="server" Text=""></asp:Label> !</span>
              <img class="img-xs rounded-circle" src="images/faces/face1.jpg" alt="Profile image">
            </a>
            <div class="dropdown-menu dropdown-menu-right navbar-dropdown" aria-labelledby="UserDropdown">
              <a class="dropdown-item p-0">
                <div class="d-flex border-bottom">
                  <div class="py-3 px-4 d-flex align-items-center justify-content-center">
                    <a href="Deposit.aspx"><i class="mdi mdi-credit-card-plus mr-0 text-gray"></i></a>
                  </div>
                  <div class="py-3 px-4 d-flex align-items-center justify-content-center border-left border-right">
                    <a href="Earnings.aspx"><i class="mdi mdi-bank mr-0 text-gray"></i></a>
                  </div>
                  <div class="py-3 px-4 d-flex align-items-center justify-content-center">
                    <a href="Reports.aspx"><i class="mdi mdi-bookmark-plus-outline mr-0 text-gray"></i></a>
                  </div>                  
                </div>
              </a>
              <a class="dropdown-item mt-2" href="Profile.aspx">
                Manage Accounts
              </a>
              <a class="dropdown-item" href="ChangePassword.aspx">
                Change Password
              </a>
              <%--<a class="dropdown-item">
                Check Inbox
              </a>--%>
              <a class="dropdown-item">
                  <asp:Button ID="BtnSignOut" runat="server" CssClass="btn btn-danger btn-fw" Text="Sign Out" BorderStyle="None" OnClick="BtnSignOut_Click" />
              </a>
            </div>
          </li>
        </ul>
        <button class="navbar-toggler navbar-toggler-right d-lg-none align-self-center" type="button" data-toggle="offcanvas">
          <span class="mdi mdi-menu"></span>
        </button>
      </div>
    </nav>
    <!-- partial -->
    <div class="container-fluid page-body-wrapper">
      <!-- partial:partials/_sidebar.html -->
      <nav class="sidebar sidebar-offcanvas" id="sidebar">
        <ul class="nav">
          <li class="nav-item nav-profile">
            <div class="nav-link">
              <div class="user-wrapper">
                <div class="profile-image">
                  <img src="images/faces/face1.jpg" alt="profile image">
                </div>
                <div class="text-wrapper">
                  <p class="profile-name"><asp:Label ID="LblName1" runat="server" Text=""></asp:Label></p>
                  <div>
                    <small class="designation text-muted">Client</small>
                    <span class="status-indicator online"></span>
                  </div>
                </div>
              </div>
                <asp:Button ID="BtnStart" runat="server" Text="Start here  > > > " CssClass="btn btn-success mr-2" ></asp:Button>
            </div>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Dashboard.aspx">
              <i class="menu-icon mdi mdi-television"></i>
              <span class="menu-title">Dashboard</span>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="#ui-basic" aria-expanded="false" aria-controls="ui-basic">
              <i class="menu-icon mdi mdi-content-copy"></i>
              <span class="menu-title">Manage Account</span>
              <i class="menu-arrow"></i>
            </a>
            <div class="collapse" id="ui-basic">
              <ul class="nav flex-column sub-menu">
                <li class="nav-item">
                  <a class="nav-link" href="Emailsetup.aspx">Email Confirmation</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="Profile.aspx">Edit Profile</a>
                </li>
              </ul>
            </div>
          </li>
          <li class="nav-item">
          <a class="nav-link" data-toggle="collapse" href="#ui-basicW" aria-expanded="false" aria-controls="ui-basicW">
              <i class="menu-icon mdi mdi-wallet"></i>
              <span class="menu-title">Wallet</span>
              <i class="menu-arrow"></i>
            </a>      
              <div class="collapse" id="ui-basicW">
              <ul class="nav flex-column sub-menu">
                <li class="nav-item">        
                    <a class="nav-link" href="Deposit.aspx">Deposits</a>
                </li>
                  <li class="nav-item">        
                    <a class="nav-link" href="EarningsTrailView.aspx">Earnings</a>
                </li>
                  <li class="nav-item">        
                    <a class="nav-link" href="DepositTrail.aspx">Deposits/Purchase Trail</a>
                </li>
                  <li class="nav-item">        
                    <a class="nav-link" href="EarningsTrailView.aspx">Earnings Trail</a>
                </li>
               </ul>
              </div>
          </li>
            <li class="nav-item">
            <a class="nav-link" href="Purchase.aspx">
              <i class="menu-icon mdi mdi-backup-restore"></i>
              <span class="menu-title">Purchases</span>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="Investment.aspx">
              <i class="menu-icon mdi mdi-chart-line"></i>
              <span class="menu-title">Investment</span>
            </a>
          </li>
          <%--<li class="nav-item">
            <a class="nav-link" href="Reports.aspx">
              <i class="menu-icon mdi mdi-table"></i>
              <span class="menu-title">Reports</span>
            </a>
          </li>--%>
             <li class="nav-item">
            <a class="nav-link" href="Withdrawal.aspx">
              <i class="menu-icon mdi mdi-table"></i>
              <span class="menu-title">Withdrawals</span>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link">
              <%--<i class="menu-icon mdi mdi-sticker"></i>--%>
              <span class="menu-title"><asp:Button ID="BtnSignOut1" runat="server" CssClass="btn btn-danger btn-fw" Text="Sign Out" BorderStyle="None" OnClick="BtnSignOut_Click" /></span>
            </a>
          </li>
          <%--<li class="nav-item">
            <a class="nav-link" data-toggle="collapse" href="#auth" aria-expanded="false" aria-controls="auth">
              <i class="menu-icon mdi mdi-restart"></i>
              <span class="menu-title">User Pages</span>
              <i class="menu-arrow"></i>
            </a>
            <div class="collapse" id="auth">
              <ul class="nav flex-column sub-menu">
                <li class="nav-item">
                  <a class="nav-link" href="pages/samples/blank-page.html"> Blank Page </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="pages/samples/login.html"> Login </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="pages/samples/register.html"> Register </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="pages/samples/error-404.html"> 404 </a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="pages/samples/error-500.html"> 500 </a>
                </li>
              </ul>
            </div>
          </li>--%>
        </ul>
      </nav>
      <!-- partial -->
      <div class="main-panel">
        <div class="content-wrapper">
          <div class="row">
            <div class="col-md-6 d-flex align-items-stretch grid-margin">
              <div class="row flex-grow">
                <div class="col-12">
                  <div class="card">
                    <div class="card-body">
                      <h4 class="card-title">Email Sender</h4>
                      <p class="card-description">
                        <%--Basic form layout--%>
                      </p>
                      
                        <div class="form-group">
                          <label for="txtTotEmails">Total Emails on Server</label>
                          <asp:TextBox ID="txtTotEmails" runat="server" CssClass="form-control" placeholder="Enter User ID"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label for="txtEmail">Start Send Number:</label>
                          <asp:TextBox ID="txtStartEmailNo" runat="server" CssClass="form-control" placeholder="Start Email Number"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label for="txtEndEmailNo">End Send No:</label>
                          <asp:TextBox ID="txtEndEmailNo" runat="server" CssClass="form-control" placeholder="End Email Number"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label for="txtEmailCode">Email Sender</label>
                          <asp:TextBox ID="txtSender" runat="server" CssClass="form-control" placeholder="Sender Email" Text="affiliate.cheques@connectmagnet.com"></asp:TextBox>
                        </div>
                         <div class="form-group">
                          <label for="txtEmailTitle">Email Title</label>
                          <asp:TextBox ID="txtEmailTitle" runat="server" CssClass="form-control" placeholder="Title of Email"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label for="txtEmail">Body Header Text</label>
                          <asp:TextBox ID="txtHeaderText" runat="server" CssClass="form-control" placeholder="Email Body Header"></asp:TextBox>
                        </div>
                        <div class="form-group">
                          <label for="txtEmailCode">Full Body Text</label>
                          <asp:TextBox ID="txtBodyText" runat="server" CssClass="form-control" placeholder="Email Body Full Text" TextMode="MultiLine" Width="459px"></asp:TextBox>
                        </div>
                        <br />
                        <asp:Button ID="BtnSendEmails" runat="server" CssClass="btn btn-success mr-2" Text="Send Emails" OnClick="BtnSendEmails_Click"/>
                        <div class="form-group">
                            <p></p>
                            <br/>
                           <%--<asp:LinkButton ID="LinkEmailCode" runat="server" OnClick="LinkEmailCode_Click">Didn't receive Email Code? Resend Now</asp:LinkButton>--%>
                        </div>
                  </div>
          <asp:Label ID="lblUsername" runat="server" Text="" Visible="false"></asp:Label>
                </div>
                
              </div>
            </div>           
          </div>
        </div>
        <!-- content-wrapper ends -->
        <!-- partial:../../partials/_footer.html -->
<footer class="footer">
          <div class="container-fluid clearfix">
            <span class="text-muted d-block text-center text-sm-left d">Copyright © 2018
              <a href="https://www.connectmagnet.com/" target="_blank">ConnectMagnet</a>. All rights reserved.</span>
            <%--<span class="float-none float-sm-right d-block mt-1 mt-sm-0 text-center">Hand-crafted & made with
              <i class="mdi mdi-heart text-danger"></i>
            </span>--%>
          </div>
        </footer>
        <!-- partial -->
      </div>
      <!-- main-panel ends -->
    </div>
    <!-- page-body-wrapper ends -->
  </div>
  <!-- container-scroller -->

  <!-- plugins:js -->
  <script src="../vendors/js/vendor.bundle.base.js"></script>
  <script src="../vendors/js/vendor.bundle.addons.js"></script>
  <!-- endinject -->
  <!-- Plugin js for this page-->
  <!-- End plugin js for this page-->
  <!-- inject:js -->
  <script src="../js/off-canvas.js"></script>
  <script src="../js/misc.js"></script>
  <!-- endinject -->
  <!-- Custom js for this page-->
  <script src="../js/dashboard.js"></script>
  <!-- End custom js for this page-->
      </div>
        </form>

    <!--Start of Tawk.to Script-->
<script type="text/javascript">
    var Tawk_API = Tawk_API || {}, Tawk_LoadStart = new Date();
    (function () {
        var s1 = document.createElement("script"), s0 = document.getElementsByTagName("script")[0];
        s1.async = true;
        s1.src = 'https://embed.tawk.to/5bddba244cfbc9247c1e966e/default';
        s1.charset = 'UTF-8';
        s1.setAttribute('crossorigin', '*');
        s0.parentNode.insertBefore(s1, s0);
    })();
</script>
<!--End of Tawk.to Script-->
</body>

</html>