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
    public delegate void UpdateControlLightingVal(CameraIdx lightingFor, int val);
    public partial class Sub_UI_LightingControl : UserControl
    {
        public Sub_UI_LightingControl()
        {
            InitializeComponent();
        }
        public event UpdateControlLightingVal OnUpdate;
        bool _isActivated = false;
        public bool IsActivated
        {
            get { return _isActivated; }
            set { _isActivated = value; }
        }
        public int _val;
        public int Value
        {
            get
            {
                return _val;
            }
        }
        CameraIdx _lightingFor = CameraIdx.Front;
        public CameraIdx lightingFor 
        {
            get
            {
                return _lightingFor;
            }
            set
            {
                _lightingFor = value;
                setlabel();
            }
        }

        private void setlabel()
        {
            if (_lightingFor == CameraIdx.Front)
            {
                group_main.Text = "Front Lighting";
            }
            else if (_lightingFor == CameraIdx.Side)
            {
                group_main.Text = "Side Lighting";
            }
            else if (_lightingFor == CameraIdx.Side2)
            {
                group_main.Text = "Side2 Lighting";
            }
        }

        private void tb_val_ValueChanged(object sender, EventArgs e)
        {
            updatValue(tb_val.Value);
        }

        private void updatValue(int val)
        {
            txt_value.Text = val.ToString();
            _val = val;
            if(_isActivated)
            {
                if(OnUpdate != null)
                {
                    OnUpdate(lightingFor, _val);
                }
            }
        }
    }
}
