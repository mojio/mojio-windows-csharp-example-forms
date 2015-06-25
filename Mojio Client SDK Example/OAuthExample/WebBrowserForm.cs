using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OAuthExample
{
    public partial class WebBrowserForm : Form
    {
        #region Variables
        private readonly Uri _authenticationUri;
        private readonly string _redirectUri;
        private bool _closeRequested;
        #endregion Variables
        
        #region Delegate/Events
        public delegate void Token(object sender, EventArgs eventArgs);
        public event Token UserApiTokenRecieved;
        #endregion Delegate/Events

        #region Functions
        public WebBrowserForm(Uri uri, string redirectUrl)
        {
            InitializeComponent();
            _authenticationUri = uri;
            _redirectUri = redirectUrl;
        }
        #endregion Functions

        #region Event Handlers
        private void WebBrowserForm_Load(object sender, EventArgs e)
        {
            webBrowser.Navigated += WebBrowserOnNavigated;
            webBrowser.DocumentCompleted += WebBrowserDocumentCompleted;
            webBrowser.ScriptErrorsSuppressed = true;
            webBrowser.Navigate(_authenticationUri);
            webBrowser.Dock = DockStyle.Fill;
            this.Text = @"OAuth User Log-in Page";
        }

        /// <summary>
        /// Hack to close this form without spawning new web browser.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebBrowserDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            // Hack to prevent new browser window from appearing.
            if(_closeRequested && e.Url.AbsoluteUri.StartsWith("about:blank"))
            {
                this.Close();
            }
        }

        private void WebBrowserOnNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            string returnUri = e.Url.AbsoluteUri;
            if (returnUri.StartsWith(_redirectUri))
            {
                Regex regex = new Regex(@"access_token=([0-9a-f-]{36})");
                Match match = regex.Match(returnUri);
                if (match.Success)
                {
                    string[] words = match.Value.Split('=');
                    string code = words[1];
                    webBrowser.Stop();
                    webBrowser.Navigate("about:blank");
                    _closeRequested = true;
                    if (UserApiTokenRecieved != null)
                    {
                        UserApiTokenRecieved(this, new UserTokenEventArgs(code));
                    }
                }
            }
        }
        #endregion Event Handlers
    }

    public class UserTokenEventArgs : EventArgs
    {
        public UserTokenEventArgs(string userToken)
        {
            UserToken = userToken;
        }

        public string UserToken { get; set; }
    }

}
