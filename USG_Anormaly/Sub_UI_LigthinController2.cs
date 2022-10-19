using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using USG_Anormaly_lib;

namespace USG_Anormaly
{
    public partial class Sub_UI_LigthinController2 : UserControl
    {
        public Sub_UI_LigthinController2()
        {
            InitializeComponent();
            ui_front.lightingFor = CameraIdx.Front;
            ui_side.lightingFor = CameraIdx.Side;
            ui_side2.lightingFor = CameraIdx.Side2;
            ui_front.OnUpdate += OnUpdate_lightValue;
            ui_side.OnUpdate += OnUpdate_lightValue;
            ui_side2.OnUpdate += OnUpdate_lightValue;
        }

        private void OnUpdate_lightValue(CameraIdx lightingFor, int val)
        {

        }
    }
}
