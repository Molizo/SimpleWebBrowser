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
    public partial class ErrorBox : Form
    {
        ///<summary>
        ///   An error box dialog.
        ///   Before showing the form,set the error text
        ///   with the exceptionLabelText method.
        ///</summary>
        public ErrorBox()
        {
            System.Media.SystemSounds.Asterisk.Play();
            InitializeComponent();
        }

        public void exceptionLabelText(string errorText)
        {
            errorLabel.Text = errorText;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
