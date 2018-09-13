using SteamKit2;
using SteamKit2.Discovery;
using SteamKit2.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SteamTheme;
using OnPS.Models;
using OnPS.Platforms;

namespace OnPS
{
    public partial class Steam : Form
    {
        public Steam()
        {
            InitializeComponent();
        }
        private bool twoFactor = false;
        
        private void SteamTest_Load(object sender, EventArgs e)
        {
            if(IniModel.GetSteamUsername() != null)
            {
                username.Text = IniModel.GetSteamUsername();
            }
            Program.steam = new Platforms.Steam();
        }

        private void login_Click(object sender, EventArgs e)
        {
            if(username.Text == "" || password.Text == "")
                return;
            this.Cursor = Cursors.WaitCursor;
            Program.steam = new Platforms.Steam();
            Program.steam.manager.Subscribe<SteamUser.LoggedOnCallback>(OnLoggedOn);
            Program.steam.manager.Subscribe<SteamUser.LoginKeyCallback>(onLoginKey);
            Program.steam.Connect(username.Text, password.Text);
            this.Cursor = Cursors.Default;
        }

        private void onLoginKey(SteamUser.LoginKeyCallback callback)
        {
            Program.steam.isRunning = false;
            this.closeForm();
        }

        private void OnLoggedOn(SteamUser.LoggedOnCallback callback)
        {
            bool twoFactorAgain = false;
            String ErrorText = null;
            if (callback.Result == EResult.InvalidEmail || callback.Result == EResult.InvalidName || callback.Result == EResult.InvalidPassword || callback.Result == EResult.InvalidLoginAuthCode)
            {
                ErrorText = "The login credentials are incorrect, please make sure you have entered the correct credentials.";
            }
            if(callback.Result == EResult.LimitExceeded)
            {
                ErrorText = "You are in too many invalid login requests, Please try again later.";
            }
            if(callback.Result == EResult.TwoFactorActivationCodeMismatch || callback.Result == EResult.TwoFactorCodeMismatch)
            {
                ErrorText = "Two factor mismatch!";
            }
            if(callback.Result == EResult.ExpiredLoginAuthCode || callback.Result == EResult.InvalidLoginAuthCode)
            {
                ErrorText = "Auth code expired or not working.";
            }
            if(callback.Result == EResult.AccountLoginDeniedNeedTwoFactor || callback.Result == EResult.AccountLogonDeniedVerifiedEmailRequired || callback.Result == EResult.AccountLogonDenied)
            {
                twoFactor = true;
                twoFactorAgain = true;
            }
            if (callback.Result == EResult.OK)
            {
                return;
            }
            else
            {
                if (ErrorText == null)
                    ErrorText = "An unknown error has occurred! - " + callback.Result;
            }
            if(twoFactor == false && twoFactorAgain == false)
            {
                Program.steam.isRunning = false;
                MessageBox.Show(ErrorText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void steamClose_Click(object sender, EventArgs e)
        {
            this.closeForm();
        }

        private void LoginKeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                login_Click(this, null);
            }
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.closeForm();
        }

        private void steamButton1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://help.steampowered.com/wizard/HelpWithLogin?redir=clientlogin");
        }

        private void steamButton2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://store.steampowered.com/join/");
        }

        private void closeForm()
        {
            foreach (Control c in this.Controls)
            {
                Controls.Remove(c);
                c.Dispose();
            }
            this.Close();
        }

        private void steamTheme_Click(object sender, EventArgs e)
        {

        }
    }
}
