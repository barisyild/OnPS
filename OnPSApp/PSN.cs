using OnPS.Models;
using OnPS.Models.Data;
using OnPS.Platforms;
using System;
using System.Collections.Specialized;
using System.Web;
using System.Windows.Forms;

namespace OnPS
{
    public partial class PSN : Form
    {
        public string code = null;
        public PSN()
        {
            InitializeComponent();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (webBrowser1.Url.ToString().Contains("/mobile-success.jsp"))
            {
                Uri uri = new Uri(webBrowser1.Url.ToString()); //Convert url to Uri class.
                string queryString = uri.Query; //Get uri query.
                NameValueCollection name = HttpUtility.ParseQueryString(queryString); //Some computers may not respond here.
                code = name["targetUrl"]; //Get Target URL.
                code = code.Replace("com.playstation.remoteplay.sceappcall://redirect?code=", ""); //Replace target url and get code.
                PSNAuthData AuthData = Platforms.PSN.AuthWithCode(code); //Authentication with code.
                IniModel.SetPSNRefreshToken(AuthData.refresh_token); //Get refresh token and save config file.
                this.Close(); //Close Form
            }
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://auth.api.sonyentertainmentnetwork.com/2.0/oauth/authorize?service_entity=urn:service-entity:psn&response_type=code&client_id=ba495a24-818c-472b-b12d-ff231c1b5745&redirect_uri=com.playstation.remoteplay.sceappcall://redirect&scope=psn:clientapp&request_locale=tr_TR&ui=pr&service_logo=ps&layout_type=popup&smcid=remoteplay&prompt=always&PlatformPrivacyWs1=minimal&");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Text = webBrowser1.DocumentTitle;
        }

        private void PSNLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IniModel.GetPSNRefreshToken() == null)
            {
                Environment.Exit(-1);
            }
        }

        private void PSNLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
