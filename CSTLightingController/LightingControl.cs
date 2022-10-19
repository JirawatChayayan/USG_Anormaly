using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Text.RegularExpressions;

namespace CSTLightingController
{
    public enum LightingCH
    {
        CH1,
        CH2
    }

    public enum TriggerMode
    {
        Pos,
        Neg
    }

    public delegate void FinishSendData();
    public delegate void TriggerVal(TriggerMode val);
    public delegate void LightingValue(LightingCH ch,int val);
    public static class CSTLightingCommand
    {

        private static string convertCH(LightingCH ch)
        {
            return ch == LightingCH.CH1 ? "A" : "B";
        }

        private static string convertTrigMode(TriggerMode mode)
        {
            return mode == TriggerMode.Pos ? "L" : "H";
        }

        private static string convertVal(int value)
        {
            if (value < 0 || value > 255)
                throw new Exception("value range is 0-255 !!!");
            return value.ToString("000");
        }

        public static string setLighting(LightingCH ch,int value)
        {
            string lightCh = convertCH(ch);
            string val = convertVal(value);
            return $"S{lightCh}0{val}#";
        }
        public static string getLighting(LightingCH ch)
        {
            string lightCh = convertCH(ch);
            return $"S{lightCh}#";
        }

        public static string setTrigger(TriggerMode mode)
        {
            string trigMode = convertTrigMode(mode);
            return $"T{trigMode}#";
        }

        public static string getTrigger()
        {
            return $"T#";
        }
    }

    public static class CSTLightingControl
    {
        static string _comport = "COM14";
        static int _buadrate = 19200;
        static int _databit = 8;
        static StopBits _stopbit = StopBits.One;
        static SerialPort _serialport = null;
        static string _paternGetResult = @"^(a|b)(0)([0-2][0-9][0-9])";
        static Regex _regLightValue = new Regex(_paternGetResult);

        public static event FinishSendData OnSendDataFinished;
        public static event TriggerVal OnRecieveTriggerVal;
        public static event LightingValue OnRecieveLightingVal;


        public static string ComPort
        {
            set
            {
                _comport = value;
            }
        }

        public static bool connect(string comPort = null)
        {
            string port = _comport;
            if (comPort != null)
                port = comPort;
            if (_serialport == null)
                _serialport = new SerialPort();
            if (_serialport.IsOpen)
            {
                if(comPort == _comport)
                {
                    return _serialport.IsOpen;
                }
                else
                {
                    _serialport.Close();
                    _serialport.DataReceived -= serialport_DataReceived;
                }
            }
            _serialport.PortName = port;
            _serialport.BaudRate = _buadrate;
            _serialport.DataBits = _databit;
            _serialport.StopBits = _stopbit;
            _serialport.Open();
            _serialport.DataReceived += serialport_DataReceived;

            firstCmd();
            return _serialport.IsOpen;
        }

        private static void firstCmd()
        {
            Thread.Sleep(10);
            sendCommand(CSTLightingCommand.setLighting(LightingCH.CH1, 0));
            Thread.Sleep(10);
            sendCommand(CSTLightingCommand.setLighting(LightingCH.CH2, 0));
            Thread.Sleep(10);
            sendCommand(CSTLightingCommand.setTrigger(TriggerMode.Neg));
            Thread.Sleep(10);
            sendCommand(CSTLightingCommand.getLighting(LightingCH.CH1));
            Thread.Sleep(10);
            sendCommand(CSTLightingCommand.getTrigger());
        }

        public static void disconnect()
        {
            if (_serialport == null)
                return;
            if (_serialport.IsOpen)
            {
                _serialport.Close();
                _serialport.DataReceived -= serialport_DataReceived;
                _serialport.Dispose();
            }
        }

        public static void sendCommand(string cmd)
        {
            if (_serialport == null)
                return;
            if (!_serialport.IsOpen)
                return;
            _serialport.WriteLine(cmd);
        }

        private static void serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {


            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Console.WriteLine($"Data Received: {indata}");
            if (indata == "a" || indata == "b")
            {
                //setlightingFinished
                Task.Run(() =>
                {
                    try
                    {
                        if (OnSendDataFinished != null)
                            OnSendDataFinished();
                    }
                    catch
                    {

                    }
                });

            }
            else if (indata == "h" || indata == "l")
            {
                //setTriggerFinished
                Task.Run(() =>
                {
                    try
                    {
                        if (OnSendDataFinished != null)
                            OnSendDataFinished();
                    }
                    catch
                    {

                    }
                });
            }
            else
            if (indata == "H" || indata == "L")
            {
                //getTrigger
                Task.Run(() =>
                {
                    try
                    {
                        if (OnRecieveTriggerVal != null)
                            OnRecieveTriggerVal(indata == "H" ? TriggerMode.Neg : TriggerMode.Pos);
                    }
                    catch
                    {

                    }
                });
            }
            //else
            //{
            //    Match m = _regLightValue.Match(indata);
            //    if(m.Success)
            //    {
            //        if(m.Groups.Count == 4)
            //        {
            //            LightingCH ch = m.Groups[1].Value == "a" ? LightingCH.CH1 : LightingCH.CH2;
            //            int value = Convert.ToInt32(m.Groups[3].Value);
            //            Task.Run(() =>
            //            {
            //                try
            //                {
            //                    if (OnRecieveLightingVal != null)
            //                        OnRecieveLightingVal(ch, value);
            //                }
            //                catch
            //                {

            //                }
            //            });
            //        }
            //    }
            //}
        }
    }
}
