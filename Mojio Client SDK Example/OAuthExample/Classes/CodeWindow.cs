using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OAuthExample.Classes
{
    class CodeWindow
    {
        #region Properties
        private RichTextBox CodeWindowRichTextBox { get; set; }
        #endregion Properties

        #region Function
        public CodeWindow(RichTextBox codeWindowTextBox)
        {
            CodeWindowRichTextBox = codeWindowTextBox;
        }

        public void DisplayNewCode(StringBuilder code)
        {
            CodeWindowRichTextBox.Clear();
            CodeWindowRichTextBox.Text = code.ToString();
        }

        public void DisplayNewCode(string code)
        {
            CodeWindowRichTextBox.Clear();
            CodeWindowRichTextBox.Text = code;
        }
        #endregion Function
    }
}
