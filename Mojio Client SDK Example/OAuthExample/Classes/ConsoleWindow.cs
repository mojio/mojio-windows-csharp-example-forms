using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mojio;

namespace OAuthExample.Classes
{
    class ConsoleWindow
    {
        #region Variable
        private bool _isErrorFont;
        #endregion Variable

        #region Properties
        private RichTextBox ConsoleWindowRichTextBox { get; set; }
        #endregion Properties

        #region Function
        public ConsoleWindow(RichTextBox consoleWindowTextBox)
        {
            ConsoleWindowRichTextBox = consoleWindowTextBox;
            SetDefaultFontColor();
        }

        private void SetErrorFontColor()
        {
            _isErrorFont = true;
            ConsoleWindowRichTextBox.ForeColor = Color.Red;
        }

        private void SetDefaultFontColor()
        {
            _isErrorFont = false;
            ConsoleWindowRichTextBox.ForeColor = Color.Chartreuse;
        }

        public void DisplaySuccessfulMessage(string message)
        {
            SetDefaultFontColor();
            ConsoleWindowRichTextBox.Clear();
            ConsoleWindowRichTextBox.Text = message;
        }

        public void DisplayErrorMessage(string message)
        {
            SetErrorFontColor();
            ConsoleWindowRichTextBox.Clear();
            ConsoleWindowRichTextBox.Text = message;
        }

        public void DisplayUser(User user)
        {
            SetDefaultFontColor();
            ConsoleWindowRichTextBox.Clear();
            var userDetail = new StringBuilder();

            userDetail.AppendLine("USER INFO");
            userDetail.AppendLine("---------");
            userDetail.AppendLine(string.Format("FirstName: {0}", user.FirstName));
            userDetail.AppendLine(string.Format("LastName: {0}", user.LastName));
            userDetail.AppendLine(string.Format("Email: {0}", user.Email));
            userDetail.AppendLine(string.Format("UserName: {0}", user.UserName));
            userDetail.AppendLine(string.Format("USER ID: {0}", user.Id));

            ConsoleWindowRichTextBox.Text = userDetail.ToString();
        }


        public void DisplayMojios(IEnumerable<Mojio.Mojio> mojios)
        {
            if (mojios == null) return;
            SetDefaultFontColor();
            ConsoleWindowRichTextBox.Clear();
            var mojiosDetail = new StringBuilder();
            if (mojios.Count() == 1)
            {
                mojiosDetail.AppendLine("Mojio");
                mojiosDetail.AppendLine("-----");
            }
            else
            {
                mojiosDetail.AppendLine("List of Mojio");
                mojiosDetail.AppendLine("-------------");
            }
            var mojioList = mojios.ToList();
            for (int i = 0; i < mojioList.Count; i++)
            {
                mojiosDetail.AppendLine(string.Format("{0}. Name: {1}", i + 1, mojioList[i].Name));
                mojiosDetail.AppendLine(string.Format("   IMEI: {0}", mojioList[i].Imei));
                mojiosDetail.AppendLine(string.Format("   Vehicle ID: {0}", mojioList[i].VehicleId));
                mojiosDetail.AppendLine(string.Format("   Mojio ID: {0}", mojioList[i].Id));
                mojiosDetail.AppendLine();
            }

            ConsoleWindowRichTextBox.Text = mojiosDetail.ToString();
        }

        public void DisplayVehicles(IEnumerable<Vehicle> vehicles)
        {
            if (vehicles == null) return;
            SetDefaultFontColor();
            ConsoleWindowRichTextBox.Clear();
            var vehicleDetails = new StringBuilder();
            if (vehicles.Count() == 1)
            {
                vehicleDetails.AppendLine("Vehicle");
                vehicleDetails.AppendLine("-------");
            }
            else
            {
                vehicleDetails.AppendLine("List of Vehicles");
                vehicleDetails.AppendLine("----------------");
            }

            var vehicleList = vehicles.ToList();
            for (int i = 0; i < vehicleList.Count; i++)
            {
                vehicleDetails.AppendLine(string.Format("{0}. Name: {1}", i + 1, vehicleList[i].Name));
                vehicleDetails.AppendLine(string.Format("   Vehicle ID: {0}", vehicleList[i].Id));
                vehicleDetails.AppendLine(string.Format("   Mojio ID: {0}", vehicleList[i].MojioId));
                vehicleDetails.AppendLine(string.Format("   Owner ID: {0}", vehicleList[i].OwnerId));
                vehicleDetails.AppendLine(string.Format("   Type: {0}", vehicleList[i].Type));
                vehicleDetails.AppendLine(string.Format("   VIN: {0}", vehicleList[i].VIN));
                vehicleDetails.AppendLine();
            }

            ConsoleWindowRichTextBox.Text = vehicleDetails.ToString();
        }

        public void DisplayModifiedObservers(string message, Observer observers)
        {
            if (observers == null) return;
            SetDefaultFontColor();
            ConsoleWindowRichTextBox.Clear();
            var observerDetails = new StringBuilder();
            observerDetails.AppendLine(message);
            observerDetails.AppendLine("Observer");
            observerDetails.AppendLine("--------");

            observerDetails.AppendLine(string.Format("1. Name: {0}", observers.Name));
            observerDetails.AppendLine(string.Format("   Observer ID: {0}", observers.Id));
            observerDetails.AppendLine(string.Format("   Application ID: {0}", observers.AppId));
            observerDetails.AppendLine(string.Format("   Owner ID: {0}", observers.OwnerId));
            observerDetails.AppendLine(string.Format("   Type: {0}", observers.Type));
            observerDetails.AppendLine(string.Format("   Subject: {0}", observers.Subject));
            observerDetails.AppendLine(string.Format("   Subject ID: {0}", observers.SubjectId));
            observerDetails.AppendLine(string.Format("   Parent: {0}", observers.Parent));
            observerDetails.AppendLine(string.Format("   Parent ID: {0}", observers.ParentId));
            observerDetails.AppendLine(string.Format("   Transport: {0}", observers.Transports));
            observerDetails.AppendLine();

            ConsoleWindowRichTextBox.Text = observerDetails.ToString();
        
        }

        public void DisplayObservers(IEnumerable<Observer> observers)
        {
            if (observers == null) return;
            SetDefaultFontColor();
            ConsoleWindowRichTextBox.Clear();
            var observerDetails = new StringBuilder();
            if (observers.Count() == 1)
            {
                observerDetails.AppendLine("Observer");
                observerDetails.AppendLine("--------");
            }
            else
            {
                observerDetails.AppendLine("List of Observers");
                observerDetails.AppendLine("-----------------");
            }

            var observerList = observers.ToList();
            for (int i = 0; i < observerList.Count; i++)
            {
                observerDetails.AppendLine(string.Format("{0}. Name: {1}", i + 1, observerList[i].Name));
                observerDetails.AppendLine(string.Format("   Observer ID: {0}", observerList[i].Id));
                observerDetails.AppendLine(string.Format("   Application ID: {0}", observerList[i].AppId));
                observerDetails.AppendLine(string.Format("   Owner ID: {0}", observerList[i].OwnerId));
                observerDetails.AppendLine(string.Format("   Type: {0}", observerList[i].Type));
                observerDetails.AppendLine(string.Format("   Subject: {0}", observerList[i].Subject));
                observerDetails.AppendLine(string.Format("   Subject ID: {0}", observerList[i].SubjectId));
                observerDetails.AppendLine(string.Format("   Parent: {0}", observerList[i].Parent));
                observerDetails.AppendLine(string.Format("   Parent ID: {0}", observerList[i].ParentId));
                observerDetails.AppendLine(string.Format("   Transport: {0}", observerList[i].Transports));
                observerDetails.AppendLine();
            }

            ConsoleWindowRichTextBox.Text = observerDetails.ToString();
        }
        #endregion Function


    }
}
