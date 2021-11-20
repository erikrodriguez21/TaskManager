﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TaskManager.Helpers;

namespace TaskManager.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            #region user control event handlers
            minCloseButtons1.ButtonClose += new EventHandler(User_Control_Close);
            minCloseButtons1.ButtonMinimize += new EventHandler(User_Control_Minimize);
            #endregion
        }

        #region Use control events
        private void User_Control_Minimize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void User_Control_Close(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        } 
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {            
           
        }
        public void MainForm_Logout(object sender, FormClosedEventArgs e)
        {
            Logout();//Log out
        }
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login();
        }       
       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
        private void biGitHub_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/ErikRodrigu3z");
        }

        #region Methods
        public void Login()
        {
            var mainForm = new MainForm();
            FormHelper.Show(mainForm);
            this.Hide();

            ////Validate fields
            //if (string.IsNullOrWhiteSpace(txtEmail.Text))
            //{
            //    lblMessage.Text = "* Please enter your User";
            //    lblMessage.Visible = true;
            //    return;
            //}
            //if (string.IsNullOrWhiteSpace(txtPassword.Text))
            //{
            //    lblMessage.Text = "* Please enter your Password";
            //    lblMessage.Visible = true;
            //    return;
            //}

            ////Login
            //var user = new Models.User().Login(txtEmail.Text, txtPassword.Text);

            //if (user != null)
            //{
            //    var mainForm = new MainForm();
            //    FormHelper.Show(mainForm);
            //    this.Hide();

            //    //Redisplay the login form and clear fields if the main form is closed
            //    mainForm.FormClosed += new FormClosedEventHandler(MainForm_Logout);
            //}
            //else
            //{
            //    lblMessage.Text = "* Incorrect username or password";
            //    lblMessage.Visible = true;
            //}
        }
        public void Logout()
        {
            txtPassword.Clear();
            txtEmail.Clear();
            lblMessage.Visible = false;
            this.Show();
        } 
        #endregion

        #region Darag Form

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void rjImageColorOverlay2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

    }
}
