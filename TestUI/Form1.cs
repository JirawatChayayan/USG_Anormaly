using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //userControl11.OnCall += UserControl11_OnCall;
        }

        private void UserControl11_OnCall(string btname)
        {
            MessageBox.Show(btname);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uI_Anormaly_System3.initialLoad();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            uI_Anormaly_System3.disableCamera();
        }

        private void uI_Anormaly_System2_Load(object sender, EventArgs e)
        {

        }


    }
}
