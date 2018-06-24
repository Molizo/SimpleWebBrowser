using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWebBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            var errorText = String.Empty;
            try
            {
                if (!(URLTextBox.Text.Contains("http://") || URLTextBox.Text.Contains("https://")))
                    errorText = "URL does not specify protocol.\nPlease enter a valid URL.";
                if (URLTextBox.Text == String.Empty)
                    errorText = "URL is empty.\nPlease enter a valid URL.";
                if (errorText != String.Empty)
                    throw new Exception(errorText);
                backButton.Enabled = true;
                Uri url = new Uri(URLTextBox.Text, UriKind.Absolute);
                webBrowser.Url = url;
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.ToString());
                ErrorBox errorBox = new ErrorBox();
                errorBox.exceptionLabelText(errorText);
                errorBox.ShowDialog();
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser.GoBack();
                backButton.Enabled = webBrowser.CanGoBack;
            }
            catch(Exception exception)
            {
                Console.WriteLine("No website to go back to!\n" + exception.ToString());
                ErrorBox errorBox = new ErrorBox();
                errorBox.exceptionLabelText("No website to go back to!");
                errorBox.ShowDialog();
            }
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            URLTextBox.Text = webBrowser.Url.ToString();
        }

        private void forwardButton_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser.GoForward();
                backButton.Enabled = webBrowser.CanGoForward;
            }
            catch (Exception exception)
            {
                Console.WriteLine("No website to go forward to!\n" + exception.ToString());
                ErrorBox errorBox = new ErrorBox();
                errorBox.exceptionLabelText("No website to go forward to!");
                errorBox.ShowDialog();
            }
        }

        private void URLTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.searchButton_Click(sender, e);
        }
    }
}
