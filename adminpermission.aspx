﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminpermission.aspx.cs" Inherits="QuickPharm360.adminpermission" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8" />
  <link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png">
  <link rel="icon" type="image/png" href="assets/img/favicon.png">
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
  <title>
      360 Degrees Pharmacy - Permissions 
  </title>
  <meta content='width=device-width, initial-scale=1.0, shrink-to-fit=no' name='viewport' />
  <!--     Fonts and icons     -->
  <link rel="stylesheet" type="text/css" href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css">
  <!-- CSS Files -->
  <link href="assets/css/material-dashboard.css?v=2.1.2" rel="stylesheet" />
  <!-- CSS Just for demo purpose, don't include it in your project -->
  <link href="assets/demo/demo.css" rel="stylesheet" />
    <link href="dist/img/favicon.png" type="image/png" rel="icon">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>

   


<script type="text/javascript">
    function ShowPopup() {
        $("#btnShowPopup").click();
    }
    </script>
</head>

<body class="">
    <form id="form1" runat="server">
        <!-- Modal -->
  <div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
    <button type="button" style="display: none;" id="btnShowPopup" class="btn btn-primary btn-lg"
                        data-toggle="modal" data-target="#myModal">
                    Launch demo modal
                </button>
      <!-- Modal content-->
      <div class="modal-content">
        <div class="modal-header">
          <h4 class="modal-title">360QuickPharm</h4>
          <button type="button" class="close" data-dismiss="modal">&times;</button>
        </div>
        <div class="modal-body">
          <p>
              <asp:Label ID="LblMessage" runat="server" Text=""></asp:Label></p>
        </div>
        <div class="modal-footer">
            <asp:Button ID="BtnYes" CssClass="btn btn-success" runat="server" Text="Yes" OnClick="BtnYes_Click"/>
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
        </div>
      </div>
      
    </div>
  </div>
        
  <div class="wrapper ">
    <div class="sidebar" data-color="purple" data-background-color="white" data-image="assets/img/sidebar-1.jpg">
      <!--
        Tip 1: You can change the color of the sidebar using: data-color="purple | azure | green | orange | danger"

        Tip 2: you can also add an image using data-image tag
    -->
       <div class="logo">
            <nav class="float-right">
               <img src="dist/img/360Logo.png" width="80" height="80" />
            </nav>  
            <a href="http://www.360quickpharm.com" class="simple-text logo-normal">
                360 Quick Pharm
            </a>
        </div>
      <div class="sidebar-wrapper">
        <ul class="nav">
          <li class="nav-item  ">
            <a class="nav-link" href="admindashboard.aspx">
              <i class="material-icons">dashboard</i>
              <p>Dashboard</p>
            </a>
          </li>
          <li class="nav-item active ">
            <a class="nav-link" href="adminpermission.aspx">
              <i class="material-icons">person</i>
              <p>Permissions</p>
            </a>
          </li>
          <li class="nav-item ">
            <a class="nav-link" href="adminchat.aspx">
              <i class="material-icons">content_paste</i>
              <p>Unattended Chats</p>
            </a>
          </li>
          <li class="nav-item ">
            <a class="nav-link" href="ongoingchat.aspx">
              <i class="material-icons">library_books</i>
              <p>Ongoing Chats</p>
            </a>
          </li>
          <li class="nav-item ">
            <a class="nav-link" href="drugrecord.aspx">
              <i class="material-icons">bubble_chart</i>
              <p>Drug Record</p>
            </a>
          </li>
          <li class="nav-item ">
              <a class="nav-link" href="adminsignout.aspx">
                <i class="material-icons">unarchive</i>
                <p>Sign Out</p>
              </a>
          </li>
        </ul>
      </div>
    </div>
    <div class="main-panel">
      <!-- Navbar -->
      <nav class="navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top ">
        <div class="container-fluid">
          <div class="navbar-wrapper">
            <a class="navbar-brand" href="javascript:;">Admin</a>
          </div>
          <button class="navbar-toggler" type="button" data-toggle="collapse" aria-controls="navigation-index" aria-expanded="false" aria-label="Toggle navigation">
            <span class="sr-only">Toggle navigation</span>
            <span class="navbar-toggler-icon icon-bar"></span>
            <span class="navbar-toggler-icon icon-bar"></span>
            <span class="navbar-toggler-icon icon-bar"></span>
          </button>
        </div>
      </nav>
      <!-- End Navbar -->
      <div class="content">
        <div class="container-fluid">
          <div class="row">
            <div class="col-md-8">
              <div class="card">
                <div class="card-header card-header-primary">
                  <h4 class="card-title">Admin Access</h4>
                  <p class="card-category">Set access for each Admin user here</p>
                </div>
                <div class="card-body">
                    <div class="row">
                      <div class="col-md-6">
                        <div class="form-group">
                          <label class="bmd-label-floating">Username</label><!--Put dropdownlists here-->
                            <asp:DropDownList ID="ddlUsername" CssClass="form-control" runat="server">
                                <asp:ListItem>- Select User -</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                      </div>
                    </div>
                      <div class="row">
                          <div class="col-md-6">
                              <div class="form-group">
                                  <label class="bmd-label-floating">Access</label><!--Put dropdownlists here-->
                                  <asp:DropDownList ID="ddlAccess" CssClass="form-control" runat="server">
                                  <asp:ListItem>- Pls Select -</asp:ListItem>
                                  <asp:ListItem>Allow</asp:ListItem>
                                  <asp:ListItem>Deny</asp:ListItem>
                                  <asp:ListItem>Delete</asp:ListItem>
                                  <asp:ListItem>Make Admin</asp:ListItem>
                                  </asp:DropDownList>
                              </div>
                          </div>
                          </div>
                          <asp:Button ID="BtnSetAccess" runat="server" CssClass="btn btn-primary pull-right" Text="Set Access" OnClick="BtnSetAccess_Click" />
                          <div class="clearfix"></div>
                        <div class="clearfix"></div>
                    <hr />
                  <p class="card-category"><strong>Update Admin Password</strong></p>
                    <div class="row">
                      <div class="col-md-6">
                        <div class="form-group">
                            <asp:TextBox ID="txtNewPassword" CssClass="form-control" runat="server" placeholder="Type your password here..."></asp:TextBox>
                        </div>
                      </div>
                    </div>                    
                          <asp:Button ID="BtnUpdatePassword" runat="server" CssClass="btn btn-primary pull-right" Text="Set New Password" OnClick="BtnUpdatePassword_Click" />
                          <div class="clearfix"></div>
                        <div class="clearfix"></div>
                    <hr />
                  <p class="card-category"><strong>Set Email to receive notifications</strong></p>
                    <div class="row">
                      <div class="col-md-6">
                        <div class="form-group">
                            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server" placeholder="Type your email here..."></asp:TextBox>
                        </div>
                      </div>
                    </div>                    
                          <asp:Button ID="BtnSetEmail" runat="server" CssClass="btn btn-primary pull-right" Text="Set Email" OnClick="BtnSetEmail_Click" />
                    <asp:Panel ID="PanelMessage" runat="server" Visible="false">
                        <div class="row">
                          <div class="col-md-6">
                              <div class="form-group">
                                  <nav class="float-center">
                                     <asp:Button ID="BtnMessage" runat="server" CssClass="btn btn-danger pull-right" Text="" />
                                      <asp:Label ID="LblAdminUsername" runat="server" Text="" Visible="false"></asp:Label>
                                  </nav>
                              </div>
                          </div>
                      </div>
                    </asp:Panel>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <footer class="footer">
        <div class="container-fluid">
          <div class="copyright float-center">
            &copy;
            <script>
              document.write(new Date().getFullYear())
            </script> for 
            <a href="https://www.360quickpharm.com" target="_blank">360 Degrees Pharmacy</a>.
          </div>
        </div>
      </footer>
    </div>
  </div>
  <!--   Core JS Files   -->
  <script src="assets/js/core/jquery.min.js"></script>
  <script src="assets/js/core/popper.min.js"></script>
  <script src="assets/js/core/bootstrap-material-design.min.js"></script>
  <script src="assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>
  <!-- Plugin for the momentJs  -->
  <script src="assets/js/plugins/moment.min.js"></script>
  <!--  Plugin for Sweet Alert -->
  <script src="assets/js/plugins/sweetalert2.js"></script>
  <!-- Forms Validations Plugin -->
  <script src="assets/js/plugins/jquery.validate.min.js"></script>
  <!-- Plugin for the Wizard, full documentation here: https://github.com/VinceG/twitter-bootstrap-wizard -->
  <script src="assets/js/plugins/jquery.bootstrap-wizard.js"></script>
  <!--	Plugin for Select, full documentation here: http://silviomoreto.github.io/bootstrap-select -->
  <script src="assets/js/plugins/bootstrap-selectpicker.js"></script>
  <!--  Plugin for the DateTimePicker, full documentation here: https://eonasdan.github.io/bootstrap-datetimepicker/ -->
  <script src="assets/js/plugins/bootstrap-datetimepicker.min.js"></script>
  <!--  DataTables.net Plugin, full documentation here: https://datatables.net/  -->
  <script src="assets/js/plugins/jquery.dataTables.min.js"></script>
  <!--	Plugin for Tags, full documentation here: https://github.com/bootstrap-tagsinput/bootstrap-tagsinputs  -->
  <script src="assets/js/plugins/bootstrap-tagsinput.js"></script>
  <!-- Plugin for Fileupload, full documentation here: http://www.jasny.net/bootstrap/javascript/#fileinput -->
  <script src="assets/js/plugins/jasny-bootstrap.min.js"></script>
  <!--  Full Calendar Plugin, full documentation here: https://github.com/fullcalendar/fullcalendar    -->
  <script src="assets/js/plugins/fullcalendar.min.js"></script>
  <!-- Vector Map plugin, full documentation here: http://jvectormap.com/documentation/ -->
  <script src="assets/js/plugins/jquery-jvectormap.js"></script>
  <!--  Plugin for the Sliders, full documentation here: http://refreshless.com/nouislider/ -->
  <script src="assets/js/plugins/nouislider.min.js"></script>
  <!-- Include a polyfill for ES6 Promises (optional) for IE11, UC Browser and Android browser support SweetAlert -->
  <script src="https://cdnjs.cloudflare.com/ajax/libs/core-js/2.4.1/core.js"></script>
  <!-- Library for adding dinamically elements -->
  <script src="assets/js/plugins/arrive.min.js"></script>
  <!--  Google Maps Plugin    -->
  <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
  <!-- Chartist JS -->
  <script src="assets/js/plugins/chartist.min.js"></script>
  <!--  Notifications Plugin    -->
  <script src="assets/js/plugins/bootstrap-notify.js"></script>
  <!-- Control Center for Material Dashboard: parallax effects, scripts for the example pages etc -->
  <script src="assets/js/material-dashboard.js?v=2.1.2" type="text/javascript"></script>
  <!-- Material Dashboard DEMO methods, don't include it in your project! -->
  <script src="assets/demo/demo.js"></script>
  <script>
    $(document).ready(function() {
      $().ready(function() {
        $sidebar = $('.sidebar');

        $sidebar_img_container = $sidebar.find('.sidebar-background');

        $full_page = $('.full-page');

        $sidebar_responsive = $('body > .navbar-collapse');

        window_width = $(window).width();

        fixed_plugin_open = $('.sidebar .sidebar-wrapper .nav li.active a p').html();

        if (window_width > 767 && fixed_plugin_open == 'Dashboard') {
          if ($('.fixed-plugin .dropdown').hasClass('show-dropdown')) {
            $('.fixed-plugin .dropdown').addClass('open');
          }

        }

        $('.fixed-plugin a').click(function(event) {
          // Alex if we click on switch, stop propagation of the event, so the dropdown will not be hide, otherwise we set the  section active
          if ($(this).hasClass('switch-trigger')) {
            if (event.stopPropagation) {
              event.stopPropagation();
            } else if (window.event) {
              window.event.cancelBubble = true;
            }
          }
        });

        $('.fixed-plugin .active-color span').click(function() {
          $full_page_background = $('.full-page-background');

          $(this).siblings().removeClass('active');
          $(this).addClass('active');

          var new_color = $(this).data('color');

          if ($sidebar.length != 0) {
            $sidebar.attr('data-color', new_color);
          }

          if ($full_page.length != 0) {
            $full_page.attr('filter-color', new_color);
          }

          if ($sidebar_responsive.length != 0) {
            $sidebar_responsive.attr('data-color', new_color);
          }
        });

        $('.fixed-plugin .background-color .badge').click(function() {
          $(this).siblings().removeClass('active');
          $(this).addClass('active');

          var new_color = $(this).data('background-color');

          if ($sidebar.length != 0) {
            $sidebar.attr('data-background-color', new_color);
          }
        });

        $('.fixed-plugin .img-holder').click(function() {
          $full_page_background = $('.full-page-background');

          $(this).parent('li').siblings().removeClass('active');
          $(this).parent('li').addClass('active');


          var new_image = $(this).find("img").attr('src');

          if ($sidebar_img_container.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
            $sidebar_img_container.fadeOut('fast', function() {
              $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
              $sidebar_img_container.fadeIn('fast');
            });
          }

          if ($full_page_background.length != 0 && $('.switch-sidebar-image input:checked').length != 0) {
            var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

            $full_page_background.fadeOut('fast', function() {
              $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
              $full_page_background.fadeIn('fast');
            });
          }

          if ($('.switch-sidebar-image input:checked').length == 0) {
            var new_image = $('.fixed-plugin li.active .img-holder').find("img").attr('src');
            var new_image_full_page = $('.fixed-plugin li.active .img-holder').find('img').data('src');

            $sidebar_img_container.css('background-image', 'url("' + new_image + '")');
            $full_page_background.css('background-image', 'url("' + new_image_full_page + '")');
          }

          if ($sidebar_responsive.length != 0) {
            $sidebar_responsive.css('background-image', 'url("' + new_image + '")');
          }
        });

        $('.switch-sidebar-image input').change(function() {
          $full_page_background = $('.full-page-background');

          $input = $(this);

          if ($input.is(':checked')) {
            if ($sidebar_img_container.length != 0) {
              $sidebar_img_container.fadeIn('fast');
              $sidebar.attr('data-image', '#');
            }

            if ($full_page_background.length != 0) {
              $full_page_background.fadeIn('fast');
              $full_page.attr('data-image', '#');
            }

            background_image = true;
          } else {
            if ($sidebar_img_container.length != 0) {
              $sidebar.removeAttr('data-image');
              $sidebar_img_container.fadeOut('fast');
            }

            if ($full_page_background.length != 0) {
              $full_page.removeAttr('data-image', '#');
              $full_page_background.fadeOut('fast');
            }

            background_image = false;
          }
        });

        $('.switch-sidebar-mini input').change(function() {
          $body = $('body');

          $input = $(this);

          if (md.misc.sidebar_mini_active == true) {
            $('body').removeClass('sidebar-mini');
            md.misc.sidebar_mini_active = false;

            $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar();

          } else {

            $('.sidebar .sidebar-wrapper, .main-panel').perfectScrollbar('destroy');

            setTimeout(function() {
              $('body').addClass('sidebar-mini');

              md.misc.sidebar_mini_active = true;
            }, 300);
          }

          // we simulate the window Resize so the charts will get updated in realtime.
          var simulateWindowResize = setInterval(function() {
            window.dispatchEvent(new Event('resize'));
          }, 180);

          // we stop the simulation of Window Resize after the animations are completed
          setTimeout(function() {
            clearInterval(simulateWindowResize);
          }, 1000);

        });
      });
    });
  </script>
    <!--
    =========================================================
    Material Dashboard - v2.1.2
    =========================================================

    Product Page: https://www.creative-tim.com/product/material-dashboard
    Copyright 2020 Creative Tim (https://www.creative-tim.com)
    Coded by Creative Tim

    =========================================================
    The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. -->
    </form>
</body>

</html>

