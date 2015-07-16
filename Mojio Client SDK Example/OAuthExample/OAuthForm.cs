using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Mojio;
using Mojio.Client;
using Mojio.Events;
using OAuthExample.Classes;

namespace OAuthExample
{
    enum TextBox
    {
        AppId,
        RedirectUrl,
        VehicleId,
        ObserverId,
        ObserverName
    }

    public partial class MainWindow : Form
    {
        #region Variables
        private WebBrowserForm _webBrowserForm;
        private MojioClient _mojioClient;
        private RadioButton _environmentButton;
        private ConsoleWindow _consoleWindow;
        private CodeWindow _codeWindow;
        private User _user;
        private bool _isDefaultTextRedirectUrl = true;
        private bool _isDefaultTextAppId = true;
        private bool _isDefaultTextObserverName = true;
        private bool _isDefaultTextVehicleId = true;
        private bool _isDefaultTextObserverId = true;
        private Dictionary<Guid, Observer> _observerDictionary = new Dictionary<Guid, Observer>(); 

        private readonly string APPID_ID_DEFAULT_TEXT = "ENTER APPLICATION ID HERE";
        private readonly string REDIRECT_URL_DEFAULT_TEXT = "ENTER REDIRECT URL HERE";
        private readonly string OBSERVER_NAME_DEFAULT_TEXT = "Observer Name";
        private readonly string VEHICLE_ID_DEFAULT_TEXT = "Vehicle Id To Observe";
        private readonly string OBSERVER_ID_DEFAULT_TEXT = "Observer Id";
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
            InitializeEvents();
            _consoleWindow = new ConsoleWindow(consoleWindowRichTextBox);
            _codeWindow = new CodeWindow(codeWindowRichTextBox);
        }

        /// <summary>
        /// Set custom events
        /// </summary>
        private void InitializeEvents()
        {
            this.codeWindowRichTextBox.Click += (sender, args) =>
            {
                if (this.codeWindowRichTextBox.Text != string.Empty)
                {
                    Clipboard.SetText(this.codeWindowRichTextBox.Text);
                    MessageBox.Show("Copied to clipboard!"); 
                }
            };
        }

        /// <summary>
        /// New up a new form with Web Browser to get the user token
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="redirectUrl"></param>
        /// <param name="live"></param>
        private void DisplayOauthForm(string appId, string redirectUrl, bool live)
        {
            try
            {
                Uri loginUri = Client.getAuthorizeUri(appId, redirectUrl, live);
                _webBrowserForm = new WebBrowserForm(loginUri, redirectUrl);
                _webBrowserForm.Closed += WebBrowserFormOnClosed;
                _webBrowserForm.UserApiTokenRecieved += WebBrowserFormOnUserApiTokenRecieved;
                _webBrowserForm.Show();
            }
            catch (Exception ex)
            {
                // eat it
            }
        }

        /// <summary>
        /// To reset default textbox becomes empty.
        /// </summary>
        private void ResetDefaultTextBox(TextBox clickBoxType)
        {
            if (appIdTextBox.Text == string.Empty && clickBoxType != TextBox.AppId)
            {
                appIdTextBox.Text = APPID_ID_DEFAULT_TEXT;
                _isDefaultTextAppId = true;
            }

            if (redirecUrlTextBox.Text == string.Empty && clickBoxType != TextBox.RedirectUrl)
            {
                redirecUrlTextBox.Text = REDIRECT_URL_DEFAULT_TEXT;
                _isDefaultTextRedirectUrl = true;
            }

            if (observerNameTextBox.Text == string.Empty && clickBoxType != TextBox.ObserverName)
            {
                observerNameTextBox.Text = OBSERVER_NAME_DEFAULT_TEXT;
                _isDefaultTextObserverName = true;
            }

            if (vehicleIdTextBox.Text == string.Empty && clickBoxType != TextBox.VehicleId)
            {
                vehicleIdTextBox.Text = VEHICLE_ID_DEFAULT_TEXT;
                _isDefaultTextVehicleId = true;
            }

            if (observerIdTextBox.Text == string.Empty && clickBoxType != TextBox.ObserverId)
            {
                observerIdTextBox.Text = OBSERVER_ID_DEFAULT_TEXT;
                _isDefaultTextObserverId = true;
            }

            
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
            ResetDefaultTextBox(TextBox.AppId);
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
            ResetDefaultTextBox(TextBox.RedirectUrl);
        }

        private void observerNameTextBox_Click(object sender, EventArgs e)
        {
            if (_isDefaultTextObserverName)
            {
                observerNameTextBox.Text = string.Empty;
                _isDefaultTextObserverName = false;
            }
            ResetDefaultTextBox(TextBox.ObserverName);
            
        }

        private void vehicleIdTextBox_Click(object sender, EventArgs e)
        {
            if (_isDefaultTextVehicleId)
            {
                vehicleIdTextBox.Text = string.Empty;
                _isDefaultTextVehicleId = false;
            }
            ResetDefaultTextBox(TextBox.VehicleId);
        }

        private void ObserverIdTextBox_Click(object sender, EventArgs e)
        {
            if (_isDefaultTextObserverId)
            {
                observerIdTextBox.Text = string.Empty;
                _isDefaultTextObserverId = false;
            }
            ResetDefaultTextBox(TextBox.ObserverId);
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

            Guid applicationIdGuid;
            bool isValidGuid = Guid.TryParse(appIdTextBox.Text, out applicationIdGuid);
            if (!isValidGuid)
            {
                MessageBox.Show(@"Please enter a valid Application Id", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            ApplicationId = applicationIdGuid;
            
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
            
            DisplayOauthForm(appIdTextBox.Text, redirecUrlTextBox.Text, isLive);
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
        
        
        private async void beginAsyncButton_Click(object sender, EventArgs e)
        {
            var code = new StringBuilder();
            Guid userToken;
            Guid.TryParse(userTokenTextBox.Text, out userToken);
            UserToken = userToken;

            Guid applicationId;
            Guid.TryParse(appIdTextBox.Text, out applicationId);
            ApplicationId = applicationId;
            Guid secretKeyGuid;

            if (UserToken == Guid.Empty)
            {
                MessageBox.Show(@"User Token is empty", @"Empty User Token", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ApplicationId == Guid.Empty)
            {
                MessageBox.Show(@"Application ID is empty", @"Empty Application ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // GENERATE CODE
            code.AppendLine("//*");
            code.AppendLine("  * You can accomplish this in two different ways:");
            code.AppendLine("  *     1. TokenAsync(APPLICATION_ID, USER_TOKEN)");
            code.AppendLine("  *     2. BeginAsync(APPLCATION ID, SECRET_KEY, USER_TOKEN)");
            code.AppendLine("  */");
            code.AppendLine();
            code.AppendLine(string.Format("var applicationId = {0};", ApplicationId));
            code.AppendLine(string.Format("var userToken = {0};", UserToken));
            code.AppendLine("bool tokenAccepted = await Client.TokenAsync(applicationId, userToken);");

            // EXECUTE CODE
            try
            {
                var tokenAccepted = await Client.TokenAsync(ApplicationId.ToString(), UserToken.ToString());
                //var begun = await Client.BeginAsync(ApplicationId, secretKeyGuid, UserToken); // works as well!
                _codeWindow.DisplayNewCode(code);
                if (tokenAccepted)
                {
                    _consoleWindow.DisplaySuccessfulMessage("User Token Accepted!");
                }
                else
                {
                    _consoleWindow.DisplayErrorMessage("FAILED: User Token invalid!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    @"An exception was thrown by Mojio Client while setting User Token\nException Message: " + ex.Message, @"Exception Thrown");
            }
        }

        private async void getUserButton_Click(object sender, EventArgs e)
        {
            var code = new StringBuilder();
            var console = new StringBuilder();
            try
            {
                code.AppendLine("var user = await Client.GetCurrentUserAsync();");
                _user = await Client.GetCurrentUserAsync();
                _codeWindow.DisplayNewCode(code);
                if (_user != null)
                {
                    _consoleWindow.DisplayUser(_user);
                }
                else
                {
                    console.AppendLine("Failed to retrieve User");
                    console.AppendLine("Possible Error:");
                    console.AppendLine("1. Application Id is not set");
                    console.AppendLine("2. User token is set");
                    console.AppendLine("3. Client not started, Click on \"Begin Async\"");
                    console.AppendLine("4. Invalid User Token");
                    _consoleWindow.DisplayErrorMessage(console.ToString());
                }
            }
            catch (Exception ex)
            {
                _consoleWindow.DisplayErrorMessage("Failed to retrieve User");
                MessageBox.Show(this, @"An exception was thrown by Mojio Client while retrieviing a User\nException Message: " + ex.Message, @"Exception Thrown");
            }
        }

        private async void getAllMojioButton_Click(object sender, EventArgs e)
        {
            try
            {
                var code = new StringBuilder();
                // GENERATE CODE
                code.AppendLine("try{");
                code.AppendLine("   var response = await Client.GetAsync<Mojio.Mojio>();");
                code.AppendLine("   var mojios = response.Data;");
                code.AppendLine("   var status = response.StatusCode;");
                code.AppendLine("   var errorMessage = response.ErrorMessage;");
                code.AppendLine("   if (status == HTTPStatusCode.OK && mojios.Data.Any()){");
                code.AppendLine("       foreach (var moj in mojios.Data){");
                code.AppendLine("           // HANDLE CODE HERE");
                code.AppendLine("       }");
                code.AppendLine("   }");
                code.AppendLine("}");
                code.AppendLine("catch(Exception){");
                code.AppendLine("   // HANDLE EXCEPTION HERE");
                code.AppendLine("}");
                _codeWindow.DisplayNewCode(code);
                // EXECUTE CODE
                var response = await Client.GetAsync<Mojio.Mojio>();
                var mojios = response.Data;
                var status = response.StatusCode;
                var errorMessage = response.ErrorMessage;

                if (status == HttpStatusCode.OK)
                {
                    if (mojios.Data.Any())
                    {
                        _consoleWindow.DisplayMojios(mojios.Data);
                    }
                    else
                    {
                        _consoleWindow.DisplaySuccessfulMessage("No Mojio found!");
                    }

                }
                else
                {
                    var console = new StringBuilder();
                    console.AppendLine(errorMessage);
                    console.AppendLine("Failed to retrieve User");
                    console.AppendLine("Possible Error:");
                    console.AppendLine("1. Application Id is not set");
                    console.AppendLine("2. User token is set");
                    console.AppendLine("3. Client not started, Click on \"Begin Async\"");
                    console.AppendLine("4. Invalid User Token");
                    _consoleWindow.DisplayErrorMessage(console.ToString());
                }
            }
            catch (Exception ex)
            {
                _consoleWindow.DisplayErrorMessage("Failed to retrieve Mojios for User");
                MessageBox.Show(this, @"An exception was thrown by Mojio Client while retrieviing User\'s Mojio\nException Message: " + ex.Message, @"Exception Thrown");
            }
        }

        private async void getVehiclesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var code = new StringBuilder();
                // GENERATE CODE
                code.AppendLine("try{");
                code.AppendLine("   var response = await Client.GetAsync<Vehicle>();");
                code.AppendLine("   var vehicles = response.Data;");
                code.AppendLine("   var status = response.StatusCode;");
                code.AppendLine("   var errorMessage = response.ErrorMessage;");
                code.AppendLine("   if (status == HTTPStatusCode.OK && vehicles.Data.Any()){");
                code.AppendLine("       foreach (var vehicle in vehicles.Data){");
                code.AppendLine("           // HANDLE CODE HERE");
                code.AppendLine("       }");
                code.AppendLine("   }");
                code.AppendLine("}");
                code.AppendLine("catch(Exception){");
                code.AppendLine("   // HANDLE EXCEPTION HERE");
                code.AppendLine("}");
                _codeWindow.DisplayNewCode(code.ToString());

                // EXECUTE CODE
                var response = await Client.GetAsync<Vehicle>();
                var vehicles = response.Data;
                var status = response.StatusCode;
                var errorMessage = response.ErrorMessage;


                if (status == HttpStatusCode.OK)
                {
                    if (vehicles.Data.Any())
                    {
                        _consoleWindow.DisplayVehicles(vehicles.Data);
                    }
                    else
                    {
                        _consoleWindow.DisplaySuccessfulMessage("No Vehicle found!");
                    }

                }
                else
                {
                    var console = new StringBuilder();
                    console.AppendLine(errorMessage);
                    console.AppendLine("Failed to retrieve User");
                    console.AppendLine("Possible Error:");
                    console.AppendLine("1. Application Id is not set");
                    console.AppendLine("2. User token is set");
                    console.AppendLine("3. Client not started, Click on \"Begin Async\"");
                    console.AppendLine("4. Invalid User Token");
                    _consoleWindow.DisplayErrorMessage(console.ToString());
                }
            }
            catch (Exception ex)
            {
                _consoleWindow.DisplayErrorMessage("Failed to retrieve Vehicle for User");
                MessageBox.Show(this, @"An exception was thrown by Mojio Client while retrieviing User\'s Vehicle\nException Message: " + ex.Message, @"Exception Thrown");
            }
        }

        private async void getAllObserversButton_Click(object sender, EventArgs e)
        {
            try
            {
                var code = new StringBuilder();
                code.AppendLine("var response = await Client.GetAsync<Observer>();");
                code.AppendLine("var observers = response.Data;");
                code.AppendLine("var status = response.StatusCode;");
                code.AppendLine("var errorMessage = response.ErrorMessage;");
                code.AppendLine("if(status == HttpStatusCode.OK)");
                code.AppendLine("{");
                code.AppendLine("   foreach(var observer in observers)");
                code.AppendLine("   {");
                code.AppendLine("       // HANDLE CODE HERE");
                code.AppendLine("   }");
                code.AppendLine("}");
                // GET ALL THE OBSERVERS
                var response = await Client.GetAsync<Observer>();
                var observers = response.Data;
                var status = response.StatusCode;
                var errorMessage = response.ErrorMessage;

                if (status == HttpStatusCode.OK)
                {
                    _codeWindow.DisplayNewCode(code.ToString());
                    if (observers.Data.Any())
                    {
                        _consoleWindow.DisplayObservers(observers.Data);
                        foreach (var obs in observers.Data)
                        {
                            if (!_observerDictionary.ContainsKey(obs.Id))
                            {
                                _observerDictionary.Add(obs.Id, obs);
                            }
                        }
                    }
                    else
                    {
                        _consoleWindow.DisplaySuccessfulMessage("No Observers found!");
                    }
                }
                else
                {
                    var console = new StringBuilder();
                    console.AppendLine(errorMessage);
                    console.AppendLine("Failed to retrieve User");
                    console.AppendLine("Possible Error:");
                    console.AppendLine("1. Application Id is not set");
                    console.AppendLine("2. User token is set");
                    console.AppendLine("3. Client not started, Click on \"Begin Async\"");
                    console.AppendLine("4. Invalid User Token");
                    _consoleWindow.DisplayErrorMessage(console.ToString());
                }
            }
            catch (Exception ex)
            {
                _consoleWindow.DisplayErrorMessage("Failed to retrieve Observer for User");
                MessageBox.Show(this, @"An exception was thrown by Mojio Client while retrieviing User\'s Observer\nException Message: " + ex.Message, @"Exception Thrown");
            }
        }

        private async void observeVehicleButton_Click(object sender, EventArgs e)
        {
            string vehicleGuidString = vehicleIdTextBox.Text;
            Guid vehicleId;
            if (Guid.TryParse(vehicleGuidString, out vehicleId) && !_isDefaultTextObserverName)
            {
                bool isUniqueObserver = true;
                foreach (var keyValue in _observerDictionary)
                {
                    var observer = keyValue.Value;
                    if (String.CompareOrdinal(observer.Name, observerNameTextBox.Text) == 0)
                    {
                        isUniqueObserver = false;
                    }
                }

                if (!isUniqueObserver)
                {
                    MessageBox.Show(this, @"Please choose a unique observer name", @"Error: Observer Creation",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    var code = new StringBuilder();
                    var console = new StringBuilder();
                    code.AppendLine("// GENERIC OBSERVER");
                    code.AppendLine("//var newObserverResponse = await Client.CreateAsync(new Observer(ObserverType.Generic)");
                    code.AppendLine("//                             {");
                    code.AppendLine("//                                 Name = observerNameTextBox.Text,");
                    code.AppendLine("//                                 AppId = ApplicationId,");
                    code.AppendLine("//                                 Subject = \"Vehicle\",");
                    code.AppendLine("//                                 SubjectId = vehicleId,");
                    code.AppendLine("//                                 Transports = Transport.SignalR");
                    code.AppendLine("//                             });");
                    code.AppendLine();
                    code.AppendLine("// EVENT OBSERVER - IgnitionOn & Ignition Off");
                    code.AppendLine("//var newObserverResponse = await Client.CreateAsync(new EventObserver(vehicleId, new EventType[] { EventType.IgnitionOn, EventType.IgnitionOff }, ObserverTiming.leading)");
                    code.AppendLine("//                             {");
                    code.AppendLine("//                                 Name = observerNameTextBox.Text,");
                    code.AppendLine("//                                 AppId = ApplicationId,");
                    code.AppendLine("//                                 Transports = Transport.SignalR");
                    code.AppendLine("//                             });");
                    code.AppendLine("// GEO FENCE OBSERVER");
                    code.AppendLine("var location = new Location()");
                    code.AppendLine("{");
                    code.AppendLine("   Lat = 49.25784,");
                    code.AppendLine("   Lng = -123.17184");
                    code.AppendLine("};");
                    code.AppendLine("var newObserverResponse = await Client.CreateAsync(new GeoFenceObserver(vehicleId, location, 1)");
                    code.AppendLine("{");
                    code.AppendLine("   Name = observerNameTextBox.Text,");
                    code.AppendLine("   AppId = ApplicationId,");
                    code.AppendLine("   Subject = \"Vehicle\",");
                    code.AppendLine("   Transports = Transport.SignalR");
                    code.AppendLine("});");
                    code.AppendLine("var observer = newObserverResponse.Data;");
                    code.AppendLine("var status = newObserverResponse.StatusCode;");
                    code.AppendLine("var errorMessage = newObserverResponse.ErrorMessage;");
                    code.AppendLine("if (status == HttpStatusCode.OK && observer.Id != Guid.Empty)");
                    code.AppendLine("{");
                    code.AppendLine("   _observerDictionary.Add(observer.Id, observer);");
                    code.AppendLine("   await Client.Observe(observer.Id);");
                    code.AppendLine("   Client.ObserveHandler += delegate(GuidEntity entity)");
                    code.AppendLine("   {");
                    code.AppendLine("       // HANDLE CALL BACK CODE");
                    code.AppendLine("   };");
                    code.AppendLine("}");

                    // GEO FENCE OBSERVER
                    var location = new Location()
                    {
                        Lat = 49.25784,
                        Lng = -123.17184
                    };
                    var newObserverResponse = await Client.CreateAsync(new GeoFenceObserver(vehicleId, location, 1)
                    {
                        Name = observerNameTextBox.Text,
                        AppId = ApplicationId,
                        Subject = "Vehicle",
                        Transports = Transport.SignalR
                    });

                    var observer = newObserverResponse.Data;
                    var status = newObserverResponse.StatusCode;
                    var errorMessage = newObserverResponse.ErrorMessage;

                    if (status == HttpStatusCode.OK && observer.Id != Guid.Empty)
                    {
                        _observerDictionary.Add(observer.Id, observer);
                        await Client.Observe(observer.Id);

                        _codeWindow.DisplayNewCode(code.ToString());
                        _consoleWindow.DisplayModifiedObservers(@"The following observer has been created!",observer);

                        Client.ObserveHandler += delegate(GuidEntity entity)
                        {
                            if (entity.GetType() == typeof(Vehicle))
                            {
                                this.Invoke(new Action(() =>
                                {
                                    MessageBox.Show(this, entity.IdToString, @"Observer Call Back",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }));
                            }
                            else if (entity.GetType() == typeof (Event))
                            {
                                this.Invoke(new Action(() =>
                                {
                                    MessageBox.Show(this, entity.IdToString, @"Observer Call Back",
                                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }));
                            }
                            else
                            {
                                this.Invoke(new Action(() =>
                                {
                                    MessageBox.Show(this, @"Observer Call Back Occured", @"Observer Call Back");
                                }));
                            }
                        };
                    }
                    else
                    {
                        console.AppendLine("Failed to create a new observer!");
                        console.AppendLine(errorMessage);
                        _consoleWindow.DisplayErrorMessage(console.ToString());
                    }
                }
                catch (Exception ex)
                {
                    _consoleWindow.DisplayErrorMessage("Failed to setup an observer for User");
                    MessageBox.Show(this, @"An exception was thrown by Mojio Client while setting up an Observer\nException Message: " + ex.Message, @"Exception Thrown");
                }
            }
            else
            {
                MessageBox.Show(this, @"Invalid Vehicle Id or Observer Name", @"Error: Observer Creation",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void unobserveByIdButton_Click(object sender, EventArgs e)
        {
            string observerGuidString = observerIdTextBox.Text;
            Guid observerId;
            if (Guid.TryParse(observerGuidString, out observerId))
            {
                await Client.Unobserve(observerId);
                MessageBox.Show(observerId.ToString() + " successfully unobserved");
            }
            else
            {
                MessageBox.Show("Invalid Observer Id");
            }
        }

        private async void deleteObserverByIdButton_Click(object sender, EventArgs e)
        {
            try
            {
                string observerGuidString = observerIdTextBox.Text;
                Guid observerId;
                if (Guid.TryParse(observerGuidString, out observerId))
                {
                    // DELETE AN ABSERVER
                    var response = await Client.DeleteAsync<Observer>(observerId);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        if (_observerDictionary.ContainsKey(observerId))
                        {
                            _consoleWindow.DisplayModifiedObservers(@"The following observer has been deleted!",
                                _observerDictionary[observerId]);
                            _observerDictionary.Remove(observerId);
                        }
                        else
                        {
                            _consoleWindow.DisplaySuccessfulMessage(string.Format("Observer ID: {0} has been deleted", observerId));
                        }
                    }
                    else
                    {
                        _consoleWindow.DisplayErrorMessage("Failed to delete the observer");
                    }
                }
                else
                {
                    MessageBox.Show(@"Invalid Observer ID");
                }
            }
            catch (Exception ex)
            {
                _consoleWindow.DisplayErrorMessage("Failed to delete an observer for User");
                MessageBox.Show(this, @"An exception was thrown by Mojio Client while deleting up an Observer\nException Message: " + ex.Message, @"Exception Thrown");
            }
        }
        #endregion Event Handler

        #region Disabled Button Handler
        private async void observeOldButton_Click(object sender, EventArgs e)
        {
            string vehicleGuidString = vehicleIdTextBox.Text;
            Guid vehicleId;
            if (Guid.TryParse(vehicleGuidString, out vehicleId))
            {
                EventType[] eventTypes = new EventType[] { EventType.IgnitionOn, EventType.IgnitionOff };
                Client.EventHandler += delegate(Event evt)
                {
                    if (evt.EventType == EventType.IgnitionOn)
                    {
                        MessageBox.Show("Ignition On Event Fired");
                    }
                    if (evt.EventType == EventType.IgnitionOff)
                    {
                        MessageBox.Show("Ignition Off Event Fired");
                    }
                };
                await Client.Subscribe<Vehicle>(vehicleId, eventTypes);
                MessageBox.Show(vehicleId.ToString()+" Subscribed to Ignition On and Off");
            }
            else
            {
                MessageBox.Show("Invalid Vehicle Id");
            }
            
        }

        // todo : test this out
        private void unsubscribeOldButton_Click(object sender, EventArgs e)
        {
            string vehicleGuidString = vehicleIdTextBox.Text;
            Guid vehicleId;
            if (Guid.TryParse(vehicleGuidString, out vehicleId))
            {
                EventType[] eventTypes = new EventType[] { EventType.IgnitionOn, EventType.IgnitionOff };

                var isUnsubscribed = Client.Unsubscribe<Vehicle>(vehicleId, eventTypes);
                if (isUnsubscribed)
                {
                    MessageBox.Show(String.Format("Vehicle Imei: {0} ; Unsubscribed to Ignition On/Off",
                        vehicleId));
                }
                else
                {
                    MessageBox.Show(String.Format("Vehicle Imei: {0} ; FAILED TO UNSUBSCRIBED TO IGNITION ON/OFF",
                        vehicleId));
                }
            }
            else
            {
                MessageBox.Show("Invalid Vehicle Id");
            }
        }
        #endregion Disabled Button Handler

    }
}
