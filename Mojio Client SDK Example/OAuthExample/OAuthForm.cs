using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Mojio;
using Mojio.Client;

namespace OAuthExample
{
    public partial class MainWindow : Form
    {
        #region Variables
        private WebBrowserForm _webBrowserForm;
        private MojioClient _mojioClient;
        private RadioButton _environmentButton = null;
        private bool _isDefaultTextRedirectUrl = true;
        private bool _isDefaultTextAppId = true;
        #endregion Variables

        #region Properties
        private MojioClient Client
        {
            get { return _mojioClient ?? (_mojioClient = new MojioClient()); }
        }

        private Guid UserToken { get; set; }

        private Guid ApplicationId { get; set; }

        private Uri RedirectUrl { get; set; }
        #endregion Properties

        #region Function
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// New up a new form with Web Browser to get the user token
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="live"></param>
        private void GetUserToken(string appId, string redirectUrl, bool live)
        {
            Uri loginUri = Client.getAuthorizeUri(appId, redirectUrl, live);
            _webBrowserForm = new WebBrowserForm(loginUri, redirectUrl);
            _webBrowserForm.Closed += WebBrowserFormOnClosed;
            _webBrowserForm.UserApiTokenRecieved += WebBrowserFormOnUserApiTokenRecieved;
            _webBrowserForm.Show();
        }
        #endregion Function

        #region Event Handler
        /// <summary>
        /// Clear default text when the text box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppIdTextBox_Click(object sender, EventArgs e)
        {
            if (_isDefaultTextAppId)
            {
                _isDefaultTextAppId = false;
                appIdTextBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Clear defualt text when the text box is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RedirecUrlTextBox_Click(object sender, EventArgs e)
        {
            if (_isDefaultTextRedirectUrl)
            {
                _isDefaultTextRedirectUrl = false;
                redirecUrlTextBox.Text = string.Empty;
            }
        }

        /// <summary>
        /// Process OAUTH workflow for user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetUserTokenButton_Click(object sender, EventArgs e)
        {
            //if (String.Compare(appIdTextBox.Text, "ENTER GUID HERE", StringComparison.Ordinal) == 0)
            if (string.IsNullOrEmpty(appIdTextBox.Text))
            {
                MessageBox.Show(@"Please enter your Application Id", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Guid guidOutput;
            bool isValidGuid = Guid.TryParse(appIdTextBox.Text, out guidOutput);
            if (!isValidGuid)
            {
                MessageBox.Show(@"Please enter a valid Application Id", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            ApplicationId = guidOutput;
            
            if (string.IsNullOrEmpty(redirecUrlTextBox.Text))
            {
                MessageBox.Show(@"Please enter your redirect Id", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }
            RedirectUrl = new Uri(redirecUrlTextBox.Text);

            bool isLive = false;
            if (_environmentButton == null)
            {
                MessageBox.Show(@"Please select an environment", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Clear userToken Box
            userTokenTextBox.Text = string.Empty;
            UserToken = Guid.Empty;
            
            if (_environmentButton == liveRadioButton)
            {
                isLive = true;
            }

            GetUserToken(appIdTextBox.Text, redirecUrlTextBox.Text, isLive);
        }

        /// <summary>
        /// This is called when the user token is recieved
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void WebBrowserFormOnUserApiTokenRecieved(object sender, EventArgs eventArgs)
        {
            var userToken = eventArgs as UserTokenEventArgs;
            if (userToken != null)
            {
                Guid guidOutput;
                bool isValidGuid = Guid.TryParse(userToken.UserToken, out guidOutput);
                if (isValidGuid)
                {
                    UserToken = guidOutput;
                    userTokenTextBox.Text = userToken.UserToken;
                }
                else
                {
                    MessageBox.Show(@"Enable to retrieve User Token", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }

        /// <summary>
        /// This is called when the web browser form is closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        private void WebBrowserFormOnClosed(object sender, EventArgs eventArgs)
        {
            _webBrowserForm.Closed -= WebBrowserFormOnClosed;
            _webBrowserForm.UserApiTokenRecieved -= WebBrowserFormOnUserApiTokenRecieved;
            _webBrowserForm = null;
        }


        private void LiveRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _environmentButton = liveRadioButton;
        }

        private void SandboxRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _environmentButton = sandboxRadioButton;
        }
        #endregion Event Handler


    }
}
