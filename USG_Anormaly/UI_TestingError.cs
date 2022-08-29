using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace USG_Anormaly
{
    public partial class UI_TestingError : UserControl
    {
        public UI_TestingError()
        {
            InitializeComponent();
        }

        public void reset()
        {
            text_msg.Text = "";
        }
        public void message(string msg)
        {
            text_msg.Text = $"Error !!! : {msg}";
        }
    }
}
