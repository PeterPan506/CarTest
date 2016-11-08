using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Microsoft.Win32;
using System.Threading;
using ZlgApi;
using HappyCodingStudio;
using System.Runtime.InteropServices;

namespace CarTest
{
    public partial class CarTest : Form
    {
        private enum SendType
        {
            Auto,
            Angle,
            Brake,
            BrakeReset,
            Light,
            Mode,
            AnlgeCan
        }

        public VirtualSwitchBus vs = new VirtualSwitchBus(10);

        private const int MaxAngle = 540;
        private int Angle = 0;
        private int AngleStep = 0;
        private int Brake = 0;
        private int BrakeStep = 0;
        private int PWM;
        private byte[] LightControl = new byte[7];

        private byte[] ctrl_command = new byte[13]
        {0xff, 0xbc, 0xcb, 0x0e, 0x81, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00};
        private static object receiveCanObj = new object();
        private string receive451Data;
        private string receive403Data;
        public int can403count = 0;

        private uint m_devtype = 21;
        private uint can_ind1 = 0;
        private uint can_ind0 = 0;
        private bool canOpen;
        private double SpeedInfo;
        private double SpeedInfoEx;
        private double AccelerateInfo;
        private int BrakeInfo;
        private int GasInfo;
        private int GearInfo;
        private static CanZLG.VCI_CAN_OBJ receiveFrameinfo = new CanZLG.VCI_CAN_OBJ();
        private static CanZLG.VCI_CAN_OBJ frameinfo;
        private static CanZLG.VCI_ERR_INFO Err_Info = new CanZLG.VCI_ERR_INFO();
        private static CanZLG.VCI_CAN_STATUS Can_Status = new CanZLG.VCI_CAN_STATUS();
        private Thread RecvThread;
        private string SaveFilePathText = string.Empty;
        private StreamWriter sw_Record;
        private List<string> recordList = new List<string>();
        private List<string> saveList = new List<string>();
        private List<Log> LogData = new List<Log>();
        private bool StartRecord = false;
        private int RecordCount = 0;
        private int Delay = 0;
        private int Complete = 0;
        private int LastReceiveAngle;
        private int LastSendAngle;
        private int SimAngle;
        private bool IsSimAngleSub;
        private int Torque;
        private int TimerInterval;

        public SpeedPower speedPower = new SpeedPower();

        public struct Log
        {
            public List<int> Data;
        }

        public List<double> lastspeed = new List<double>();

        public CarTest()
        {
            lastspeed.Add(0);
            lastspeed.Add(0);

            speedPower.Init();

            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            LeftButton.Enabled = false;
            RightButton.Enabled = false;
            BrakeButton.Enabled = false;
            ReleaseButton.Enabled = false;
            ModeButton.Enabled = false;
            LeftLightCheck.Enabled = false;
            RightLightCheck.Enabled = false;
            LocationLightCheck.Enabled = false;
            BrakeLightCheck.Enabled = false;
            FarLightCheck.Enabled = false;
            NearLightCheck.Enabled = false;
            VoiceCheck.Enabled = false;
            ResetCanButton.Enabled = false;

            Angle5.Checked = true;
            ModeButton.BackColor = Color.Red;
            frameinfo = new CanZLG.VCI_CAN_OBJ();
            frameinfo.Data = new byte[8];
            receiveFrameinfo.Data = new byte[8];
            RecvThread = new Thread(ReceiveCanData);
            //RecvThread.IsBackground = true;
            RecvThread.Start();
            timer1.Start();
            //RecTimer.Start();

            vs.SubMsg("ControlMessage", GetControlMessage);
        }

        public double Control_Steer = 0;
        public double Control_Speed = 0;

        public double Receive_Steer = 0;
        public double Receive_Speed = 0;

        public void GetControlMessage(byte[] msg)
        {
            double[] args = (double[])VirtualSwitchBus.GetObject(msg);

            Control_Steer = args[0];
            Control_Speed = args[1];
            Receive_Speed = args[2];

            try
            {
                Speedlabel.Text = Control_Speed.ToString() + " " + spoff;
                Steerlabel.Text = Control_Steer.ToString("F2") + " " + stoff;
            }
            catch (Exception ee) { }
        }

        private void LeftButton_MouseDown(object sender, MouseEventArgs e) //左键
        {
            if (Angle - AngleStep >= -MaxAngle)
            {
                Angle -= AngleStep;
            }
            else
            {
                Angle = -MaxAngle;
            }

            if (AngleCanCheck.Checked)
                Send(Angle, SendType.AnlgeCan);
            else
                Send(Angle, SendType.Angle);
            LeftButton.Image = global::CarTest.Properties.Resources.zuoi;
            AngleBox.Focus();
        }

        private void LeftButton_MouseUp(object sender, MouseEventArgs e)
        {

            LeftButton.Image = global::CarTest.Properties.Resources.zuo;
        }

        private void RightButton_MouseDown(object sender, MouseEventArgs e) //右键
        {
            if (Angle + AngleStep <= MaxAngle)
            {
                Angle += AngleStep;
            }
            else
            {
                Angle = MaxAngle;
            }

            if (AngleCanCheck.Checked)
                Send(Angle, SendType.AnlgeCan);
            else
                Send(Angle, SendType.Angle);
            RightButton.Image = global::CarTest.Properties.Resources.youi;
            AngleBox.Focus();
        }

        private void RightButton_MouseUp(object sender, MouseEventArgs e)
        {
            RightButton.Image = global::CarTest.Properties.Resources.you;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Angle5.Checked)
            {
                AngleStep = 5;
            }
            else if (Angle10.Checked)
            {
                AngleStep = 10;
            }
            else if (Angle20.Checked)
            {
                AngleStep = 20;
            }
            else if (Angle30.Checked)
            {
                AngleStep = 30;
            }
            else if (SetAngleRadio.Checked)
            {
                int angleStep;
                if (int.TryParse(AngelStepSetText.Text, out angleStep))
                    AngleStep = angleStep;
                else
                    AngleStep = 1;
            }   
            BrakeStep = (int) BrakeStepControl.Value;
            
            AngleBox.Text = Angle.ToString();
            BrakeBox.Text = Brake.ToString();
            SpeedInfoLabel.Text = SpeedInfo.ToString();
            
            string gearStr;
            switch (GearInfo)
            {
                case 11:
                    gearStr = "D";
                    break;
                case 13:
                    gearStr = "R";
                    break;
                default:
                    gearStr = "N";
                    break;
            }
            GearInfoLabel.Text = gearStr;
            //GasInfoLabel.Text = GasInfo.ToString();
            RealPressureText.Text = GasInfo.ToString();
            //BrakeInfoLabel.Text = threadWorkingCount.ToString();
            //DelayLabel.Text = receiveCount.ToString();
            //lock (receiveCanObj)
            {
                Can451TextBox.Text = receive451Data;
                Can403TextBox.Text = can403count.ToString() + " " + receive403Data;

                RecSpeedLabel.Text = Receive_Speed.ToString("F2");
                RecSteerLabel.Text = Receive_Steer.ToString("F2");

                //vs.PubMsg("RecSpeed", );
            }
            if (ModeButton.Text == "自动驾驶")
            {
                lock (recordList)
                {
                    saveList = new List<string>(recordList);
                    recordList.Clear();
                }
                foreach (var VARIABLE in saveList)
                {
                    sw_Record.WriteLine(VARIABLE);
                }

            }
        }

        private bool Send(int para, SendType type, int para2 = 0)
        {
            if (!canOpen)
                return false;
            frameinfo.ID = 0x20;
            switch (type)
            {
                case SendType.Auto:
                    frameinfo.Data[0] = (byte)para2;
                    if (para2 == 10) frameinfo.Data[1] = 0x09;
                    if (para2 == 00) frameinfo.Data[1] = 0x08;
                    frameinfo.Data[2] = 0x00;
                    frameinfo.Data[3] = 0x00;
                    frameinfo.Data[4] = 0x00;
                    frameinfo.Data[5] = (byte) (para >> 8);
                    frameinfo.Data[6] = (byte) (para & 0xff);
                    frameinfo.Data[7] = 0x56;
                    break;
                case SendType.Angle:
                    //frameinfo.Data[1] = 0x08;
                    frameinfo.Data[5] = (byte) (para & 0xff);
                    frameinfo.Data[4] = (byte) (para >> 8);
                    frameinfo.Data[6] = 0xF5;
                    break;
                case SendType.Brake:
                    frameinfo.Data[0] = (byte) para;
                    frameinfo.Data[1] = 0x09;
                    frameinfo.Data[5] = 0x04;
                    frameinfo.Data[7] = 0x56;
                    break;
                case SendType.BrakeReset:
                    frameinfo.Data[0] = (byte)para;
                    frameinfo.Data[1] = 0x08;
                    frameinfo.Data[5] = 0x04;
                    frameinfo.Data[7] = 0x56;
                    break;
                case SendType.Light:
                    frameinfo.Data[1] = 0x09;
                    frameinfo.Data[1] += ConvertData1(para);
                    frameinfo.Data[2] = ConvertData2(para);
                    break;
                case SendType.Mode:
                    frameinfo.Data[1] = (byte)para;
                    break;
                case SendType.AnlgeCan:
                    for (int i = 0; i < 8; ++i )
                    {
                        frameinfo.Data[i] = 0;
                    }
                    if (Angle != LastSendAngle)
                        ResetRecordAngel();
                    frameinfo.ID = 0x500;
                    frameinfo.Data[0] = 0x20; //模式  1 2 5 reserve 
                    frameinfo.Data[3] = (byte) ((Angle + 1024) >> 8);
                    frameinfo.Data[4] = (byte) ((Angle + 1024) & 0xff);
                    frameinfo.Data[6] = (byte)Torque; //角速度+力矩  0x80
                    for (int i = 0; i < 7; i++)
                        frameinfo.Data[7] ^= frameinfo.Data[i];
                    LastSendAngle = Angle;
                    break;
                default:break;
            }

            frameinfo.RemoteFlag = 0;
            frameinfo.ExternFlag = 0;
            frameinfo.DataLen = 8;
            //  打印输出测试用
            //string str = string.Empty;
            //for (int i = 0; i < 8; i++)
            //{
            //    if(frameinfo.Data[i] > 0)
            //    str += "Data" + i + ":" + frameinfo.Data[i].ToString("x2");
            //}
            //MessageBox.Show(str);
            if (CanZLG.VCI_Transmit(m_devtype, 0, can_ind0, ref frameinfo, 1) != CanZLG.STATUS_OK)
            {
                MessageBox.Show(".v");
                return false;
            }
            return true;
        }

        private void BrakeButton_Click(object sender, EventArgs e)
        {
            if (Brake + BrakeStep <= 255)
            {
                Brake += BrakeStep;
            }
            else
            {
                Brake = 255;
            }
            PWM = int.Parse(PWMTextBox.Text);
            Send(Brake, SendType.Brake);
            BrakeBox.Focus();
        }

        private void ReleaseButton_Click(object sender, EventArgs e)
        {
            Brake = 0;
            Send(Brake, SendType.Brake);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!canOpen)
                return false;
            switch (keyData)
            {
                case Keys.Left:
                    AngleBox.Focus();
                    LeftButton_MouseDown(null, null);
                    break;
                case Keys.Right:
                    AngleBox.Focus();
                    RightButton_MouseDown(null, null);
                    break;
                case Keys.B:
                    BrakeButton_Click(null, null);
                    break;
                case Keys.R:
                    ReleaseButton_Click(null, null);
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void ModeButton_Click(object sender, EventArgs e)
        {
            if (ModeButton.Text == "人工驾驶")
            {
                if (!Send(0x09, SendType.Mode)) return;

                LeftButton.Enabled = true;
                RightButton.Enabled = true;
                BrakeButton.Enabled = true;
                ReleaseButton.Enabled = true;
                LeftLightCheck.Enabled = true;
                RightLightCheck.Enabled = true;
                LocationLightCheck.Enabled = true;
                BrakeLightCheck.Enabled = true;
                FarLightCheck.Enabled = true;
                NearLightCheck.Enabled = true;
                VoiceCheck.Enabled = true;
                ModeButton.Text = "自动驾驶";

                Send(10, SendType.BrakeReset);
                Thread.Sleep(100);
                Send(10, SendType.Brake);

                Thread.Sleep(100);
                Send(10, SendType.BrakeReset);

                timer2.Enabled = true;
                //timer3.Enabled = true;

                //string Filename = "Record_", Date_Record = "";

                //SaveFilePathText = "";
                //Date_Record = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("D2")
                //              + DateTime.Now.Day.ToString("D2");
                //Filename += DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("D2")
                //            + DateTime.Now.Day.ToString("D2") + "_" + DateTime.Now.Hour.ToString("D2") +
                //            DateTime.Now.Minute.ToString("D2");
                //SaveFilePathText += Application.StartupPath + @"\" + @"\Data\" + Date_Record + @"\" + Filename + ".txt";

                ////string DirectoryPath = "";
                //DirectoryInfo di = new DirectoryInfo(Application.StartupPath + @"\" + @"\Data\" + Date_Record);
                //StartRecord = true;
                //LogData.Clear();
                //try
                //{
                //    // Determine whether the directory exists.
                //    if (di.Exists)
                //    {
                //        // Indicate that it already exists.


                //    }

                //    // Try to create the directory.
                //    di.Create();


                //}
                //catch (Exception e_dir)
                //{

                //}

                //if (File.Exists(SaveFilePathText) == false)
                //{
                //    FileStream myFs = new FileStream(SaveFilePathText, FileMode.Create);

                //    myFs.Close();
                //}
                //sw_Record = new StreamWriter(SaveFilePathText, true);
                ModeButton.BackColor = Color.Green;
            }
            else
            {
                if (!Send(0, SendType.Mode))
                    return;
                ctrl_command = new byte[13]
                {0xff, 0xbc, 0xcb, 0x0e, 0x81, 0x00, 0x00, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00};
                Brake = 0;
                Angle = 0;
                LightControl = new byte[4];
                LeftLightCheck.Checked = false;
                RightLightCheck.Checked = false;
                LeftButton.Enabled = false;
                RightButton.Enabled = false;
                BrakeButton.Enabled = false;
                ReleaseButton.Enabled = false;
                LeftLightCheck.Enabled = false;
                RightLightCheck.Enabled = false;
                LocationLightCheck.Enabled = false;
                BrakeLightCheck.Enabled = false;
                ModeButton.Text = "人工驾驶";
                timer2.Enabled = false;
                timer3.Enabled = false;

                //StartRecord = false;
                //sw_Record.Close();
                //ModeButton.BackColor = Color.Red;
                //List<string> list = new List<string>()
                //{
                //    "Time",
                //    "Angle",
                //    "ActualAngle",
                //    "Delay",
                //    "Complete"
                //};
                //string saveFile = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString("D2")
                //            + DateTime.Now.Day.ToString("D2") + "_" + DateTime.Now.Hour.ToString("D2") +
                //            DateTime.Now.Minute.ToString("D2") + DateTime.Now.Second.ToString("D2");
                ////bool result = SaveFile(@"D:\recordAngle" + saveFile + ".csv", LogData, list);
                //ResetRecordAngel();
                //LogData.Clear();
                //RecordCount = 0;
                //StartRecord = false;
            }
        }


        private void LeftLightCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (LeftLightCheck.Checked)
            {
                LightControl[0] = 1;
            }
            else
            {
                LightControl[0] = 0;
            }
            Send(ByteConvertInt(LightControl), SendType.Light);
        }

        private void RightLightCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (RightLightCheck.Checked)
            {
                LightControl[1] = 1;
            }
            else
            {
                LightControl[1] = 0;
            }
            Send(ByteConvertInt(LightControl), SendType.Light);
        }

        private void BrakeLightCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (BrakeLightCheck.Checked)
            {
                LightControl[5] = 1;
            }
            else
            {
                LightControl[5] = 0;
            }
            Send(ByteConvertInt(LightControl), SendType.Light);
        }

        private int ByteConvertInt(byte[] bts)
        {
            int value = 0;
            for (int i = 0; i < bts.Length; i++)
            {
                value += (int) (Math.Pow(2, i)*bts[i]);
            }
            return value;
        }

        private void StartCanButton_Click(object sender, EventArgs e)
        {
            if (canOpen)
            {
                canOpen = false;
                CanZLG.VCI_CloseDevice(m_devtype, 0);
            }

            CanZLG.VCI_INIT_CONFIG init_config = new CanZLG.VCI_INIT_CONFIG();
            init_config.Mode = 0;
            init_config.Filter = 1;
            init_config.AccCode = 0;
            init_config.AccMask = 0xffffffff;
            init_config.AccCode = 0x451 << 20;
            init_config.AccMask = 0x000FFFFF;
          //  init_config.Timing0 = 0;
           // init_config.Timing1 = 0x1c;
            if (CanZLG.VCI_OpenDevice(m_devtype, 0, 0) != CanZLG.STATUS_OK)
            {

                MessageBox.Show("Open device fault!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            byte[] baud;
            baud = BitConverter.GetBytes(0x60007); //500k 0x60007
            //UInt32 baud;
            //baud = 0x1000c8;
            if (CanZLG.VCI_SetReference(m_devtype, 0, can_ind1, 0, baud) != CanZLG.STATUS_OK)
            {

                MessageBox.Show("设置波特率错误，打开设备失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CanZLG.VCI_CloseDevice(m_devtype, 0);
                return;
            }

            if (CanZLG.VCI_InitCAN(m_devtype, 0, can_ind1, ref init_config) != CanZLG.STATUS_OK)
            {

                MessageBox.Show("Init can fault!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                CanZLG.VCI_CloseDevice(m_devtype, 0);
                return;
            }
            if (CanZLG.VCI_StartCAN(m_devtype, 0, can_ind1) != CanZLG.STATUS_OK)
            {
                MessageBox.Show("Start Failed");
            }

            /*
            baud = BitConverter.GetBytes(0x1000c8);//250k
            init_config.Timing0 = 1;
            init_config.Timing1 = 0x1c;
            if (CanZLG.VCI_SetReference(m_devtype, 0, can_ind0, 0, baud) != CanZLG.STATUS_OK)
            {

                MessageBox.Show("设置波特率错误，打开设备失败!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                CanZLG.VCI_CloseDevice(m_devtype, 0);
                return;
            }

            if (CanZLG.VCI_InitCAN(m_devtype, 0, can_ind0, ref init_config) != CanZLG.STATUS_OK)
            {

                //MessageBox.Show("Init can fault!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //CanZLG.VCI_CloseDevice(m_devtype, 0);
                //return;
            }
            if (CanZLG.VCI_StartCAN(m_devtype, 0, can_ind0) != CanZLG.STATUS_OK)
            {
                MessageBox.Show("Start Failed");
            }
            */
            canOpen = true;
            StartCanButton.Enabled = false;
            ModeButton.Enabled = true;
            ResetCanButton.Enabled = true;
            //RecTimer.Start();
        }

        //List<uint> ids = new List<uint>();
        //StreamWriter sw = new StreamWriter(@"D:\Documents\EQTest\0723\a.txt");

        private void ReceiveCanData()
        {
            uint ReceiveNum = 0;
            uint stsResult = 0;

            while (true)
            {
                if (this.canOpen)
                {
                    ReceiveNum = CanZLG.VCI_GetReceiveNum(m_devtype, 0, can_ind1);
                   if (ReceiveNum > 0)
                    {
                        ReceiveNum = Math.Min(ReceiveNum, 50);

                        for (int index = 0; index < ReceiveNum; index++)
                        {
                            stsResult = CanZLG.VCI_Receive(m_devtype, 0, can_ind1, ref receiveFrameinfo, 1, 1);
                            if (stsResult != 1) break;
                            else
                            {
                                //ids.Add(receiveFrameinfo.ID);

                                //if (ids.Count > 20)
                                //{
                                //    sw.WriteLine(string.Join("\t", ids));
                                //    sw.Flush();
                                //    ids.Clear();
                                //}

                                //if (receiveFrameinfo.ID == 0x21)
                                //{
                                //    SpeedInfo = receiveFrameinfo.Data[0]*256 + receiveFrameinfo.Data[1];
                                //    //GasInfo = frameinfo.Data[2];
                                //    BrakeInfo = receiveFrameinfo.Data[3];
                                //    GearInfo = receiveFrameinfo.Data[4];
                                //    AccelerateInfo = receiveFrameinfo.Data[6]*100;
                                //    Delay = receiveFrameinfo.Data[7]*10;
                                //    Record = new StringBuilder((DateTime.Now.Hour > 9 ? "" : "0") + DateTime.Now.Hour
                                //                               + (DateTime.Now.Minute > 9 ? ":" : ":0") +
                                //                               DateTime.Now.Minute
                                //                               + (DateTime.Now.Second > 9 ? ":" : ":0") +
                                //                               DateTime.Now.Second
                                //                               + (DateTime.Now.Millisecond > 9 ? ":" : ":0") +
                                //                               DateTime.Now.Millisecond + "\t");

                                //    Record.Append("SpeedInfo:" + SpeedInfo + " Accelerate:" + AccelerateInfo + " Delay:" +
                                //                  Delay);
                                //    lock (recordList)
                                //    {
                                //        recordList.Add(Record.ToString());
                                //    }
                                //}

                                if (receiveFrameinfo.ID == 0x451)
                                {
                                    receive451Data = string.Empty;
                                    GasInfo = receiveFrameinfo.Data[6];
                                    for (int i = 0; i < 8; i++)
                                    {
                                        receive451Data += receiveFrameinfo.Data[i].ToString("X2") + " ";
                                    }
                                }

                                if (receiveFrameinfo.ID == 0x403)
                                {
                                    can403count++;
                                    receive403Data = string.Empty;
                                    GasInfo = receiveFrameinfo.Data[6];
                                    for (int i = 0; i < 8; i++)
                                    {
                                        receive403Data += receiveFrameinfo.Data[i].ToString("X2") + " ";
                                    }

                                    //Receive_Speed = (((double)(receiveFrameinfo.Data[1] & 0x07) * 1024) + ((double)receiveFrameinfo.Data[2] * 4) + (double)((receiveFrameinfo.Data[3] & 0xC0) >> 6)) / 16;
                                }

                                if (receiveFrameinfo.ID == 0x394)
                                {
                                    Receive_Steer = (double)((receiveFrameinfo.Data[1] << 7) + (receiveFrameinfo.Data[2] >> 1)) * 0.04375;
                                }

                                //解析角度反馈
                                //if (StartRecord && receiveFrameinfo.ID == 0x401)
                                //{
                                //    RecordCount++;
                                //    int ActualAngel = receiveFrameinfo.Data[4]*256 + receiveFrameinfo.Data[5] - 1024;
                                //    if (Delay == 0 && ActualAngel != LastReceiveAngle)
                                //        Delay = RecordCount;
                                //    if (Complete == 0 && Math.Abs(Angle - ActualAngel) < 2)
                                //        Complete = RecordCount;
                                //    Log log = new Log();
                                //    log.Data = new List<int>();
                                //    log.Data.Add(RecordCount);
                                //    log.Data.Add(Angle);
                                //    log.Data.Add(ActualAngel);
                                //    log.Data.Add(Delay);
                                //    log.Data.Add(Complete);
                                //    LogData.Add(log);
                                //    LastReceiveAngle = ActualAngel;
                                //}
                                /*
                                if ( frameinfo.ID == 0x2e9)
                                {
                                    SpeedInfo = 16*(frameinfo.Data[6]&0x1f)+ frameinfo.Data[5]/16;
                                    AccelerateInfo = (SpeedInfo - SpeedInfoEx)/0.18;
                                    SpeedInfoEx = SpeedInfo;
                                    Record = new StringBuilder((DateTime.Now.Hour > 9 ? "" : "0") + DateTime.Now.Hour
                                    + (DateTime.Now.Minute > 9 ? ":" : ":0") + DateTime.Now.Minute
                                    + (DateTime.Now.Second > 9 ? ":" : ":0") + DateTime.Now.Second
                                    + (DateTime.Now.Millisecond > 9 ? ":" : ":0") + DateTime.Now.Millisecond + "\t");

                                    Record.Append("SpeedInfo:" + SpeedInfo + " Accelerate:" + AccelerateInfo );

                                    if (ModeButton.Text == "自动驾驶")
                                    {
                                        lock (recordList)
                                        {
                                            recordList.Add(Record.ToString());
                                        }
                                    }
                            
                                }
                                if (stsResult > 0 && frameinfo.ID == 0x403)
                                {
                                    GearInfo = frameinfo.Data[0] & 0x0f;
                                }
                                */
                            }
                        }

                        if (stsResult == 0xFFFFFFFF)
                        {
                            CanZLG.VCI_ReadErrInfo(m_devtype, 0, can_ind0, ref Err_Info);
                            CanZLG.VCI_ReadCANStatus(m_devtype, 0, can_ind0, ref Can_Status);
                            CanZLG.VCI_ClearBuffer(m_devtype, 0, can_ind0);
                        }
                        else
                            CanZLG.VCI_ClearBuffer(m_devtype, 0, can_ind1);

                    }
                }
                Thread.Sleep(1);
            }
        }

        private void ResetCanButton_Click(object sender, EventArgs e)
        {
            if (CanZLG.VCI_ResetCAN(m_devtype, 0, can_ind1) != CanZLG.STATUS_OK)
            {
                MessageBox.Show("复位失败");
            }
            StartCanButton.Enabled = true;
            ResetCanButton.Enabled = false;
        }

        private void CarTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                RecvThread.Abort();
                if (canOpen)
                    CanZLG.VCI_CloseDevice(m_devtype, 0);
                timer1.Stop();
                SimulateTimer.Stop();
                sw_Record.Close();
            }
            catch (Exception)
            {

            }
        }

        private bool SaveFile(string savePath, List<Log> logData, List<string> names)
        {
            bool flag = false;
            StringBuilder builder = new StringBuilder();
            int Count = 5;
            for (int i = 0; i < Count; i++)
            {
                builder.Append("");
                builder.Append(names[i]);
                builder.Append("");
                builder.Append(',');
            }
            builder.Remove(builder.Length - 1, 1);
            try
            {
                using (StreamWriter writer = new StreamWriter(savePath))
                {
                    writer.WriteLine(builder.ToString());
                    builder.Clear();
                    foreach (var log in logData)
                    {
                        foreach (var data in log.Data)
                        {
                            builder.Append("");
                            builder.Append(data);
                            builder.Append("");
                            builder.Append(",");
                        }
                        builder.Remove(builder.Length - 1, 1);
                        writer.WriteLine(builder.ToString());
                        builder.Clear();
                    }
                    writer.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }


        private void ResetRecordAngel()
        {
            Delay = 0;
            Complete = 0;
        }

        private void SimulateButton_Click(object sender, EventArgs e)
        {
            if (SimulateButton.Text == "开始模拟")
            {
                SimulateTimer.Interval = TimerInterval;
                SimulateTimer.Start();
                SimulateButton.Text = "结束模拟";
            }
            else
            {
                SimulateTimer.Stop();
                SimulateButton.Text = "开始模拟";
            }
        }

        private void SimulateTimer_Tick(object sender, EventArgs e)
        {
                if (IsSimAngleSub)
                {
                    SimAngle -= AngleStep;
                }
                else
                {
                    SimAngle += AngleStep;
                }

                if (SimAngle >= MaxAngle)
                {
                    SimAngle = MaxAngle;
                    IsSimAngleSub = true;
                }
                else if (SimAngle <= -MaxAngle)
                {
                    SimAngle = -MaxAngle;
                    IsSimAngleSub = false;
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int torque;
            if (int.TryParse(SimTorqueText.Text, out torque))
                Torque = torque;
            else
                Torque = 0x80;
            if (Torque > 0xff)
                Torque = 0xff;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int intetval;
            if (int.TryParse(SimTimeText.Text, out intetval))
                TimerInterval = intetval;
            else
                TimerInterval = 1000;
        }

        private void FarLightCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (FarLightCheck.Checked)
            {
                LightControl[2] = 1;
            }
            else
            {
                LightControl[2] = 0;
            }
            Send(ByteConvertInt(LightControl), SendType.Light);
        }

        private void NearLightCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (NearLightCheck.Checked)
            {
                LightControl[3] = 1;
            }
            else
            {
                LightControl[3] = 0;
            }
            Send(ByteConvertInt(LightControl), SendType.Light);
        }

        private void VoiceCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (VoiceCheck.Checked)
            {
                LightControl[6] = 1;
            }
            else
            {
                LightControl[6] = 0;
            }
            Send(ByteConvertInt(LightControl), SendType.Light);
        }

        private byte ConvertData1(int para)
        {
            int result = 0;
            result += (para & 0x1) * 0x20;
            result += (para >> 1 & 0x1) * 0x40;
            result += (para >> 2 & 0x1) * 0x80;
            return (byte)result;
        }

        private byte ConvertData2(int para)
        {
            int result = 0;
            result += (para >> 3 & 0x1) * 0x1;
            result += (para >> 4 & 0x1) * 0x2;
            result += (para >> 5 & 0x1) * 0x4;
            result += (para >> 6 & 0x1) * 0x8;
            return (byte)result;
        }

        private void LocationLightCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (LocationLightCheck.Checked)
            {
                LightControl[4] = 1;
            }
            else
            {
                LightControl[4] = 0;
            }
            Send(ByteConvertInt(LightControl), SendType.Light);
        }

        private void RightButton_Click(object sender, EventArgs e)
        {

        }

        public double ISsum = 0;
        public double Pserr = 3;//2.5(60 shang po);
        public double ISerr = 0.002, PBrake = 1;

        public double ISmax = 100;
        public int BrakeMax = 10;
        public int BrakeMin = 10;

        public int BrakeFlag = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            double Aim_Speed = double.Parse(SpeedTextBox.Text);
            double Aim_Steer = double.Parse(SteerTextBox.Text);
            
            if (!checkBoxSpeed.Checked)
                Aim_Speed = Math.Max(0, Control_Speed + (double)spoff * 3);
            
            if (!checkBoxSteer.Checked)
                Aim_Steer = Control_Steer + (double)stoff * 3;

            double speedcontrol = 0;

            ISsum += Aim_Speed - Receive_Speed;

            if (ISsum * ISerr > ISmax) ISsum = ISmax / ISerr;
            else if (ISsum * ISerr < -ISmax) ISsum = -ISmax / ISerr;

            ISsum = 0;

            #region Brake


            if (Aim_Speed > Receive_Speed)
            {
                speedcontrol = (Aim_Speed - Receive_Speed) * Pserr + ISsum * ISerr;

                if (Receive_Speed < Aim_Speed && BrakeFlag == 1)
                {
                    BrakeFlag = 0;
                    if (checkBoxBrake.Checked) //Send(Brake, SendType.BrakeReset, 0);
                        Brake = 0;
                }
            }
            else
            {
                speedcontrol = (Aim_Speed - Receive_Speed) * Pserr + ISsum * ISerr;

                if (Receive_Speed > Aim_Speed + 5 || Aim_Speed == 0)
                {
                    BrakeFlag = 1;
                    Brake = (int)(Math.Abs(Aim_Speed - Receive_Speed) * PBrake);
                    if (Brake > BrakeMax) Brake = (int)BrakeMax;
                    if (Brake < BrakeMin) Brake = (int)BrakeMin;
                    if (checkBoxBrake.Checked) //Send(Brake, SendType.Brake, 0);
                        Brake = 10;
                }
                else
                {
                    if (Receive_Speed < Aim_Speed && BrakeFlag == 1)
                    {
                        BrakeFlag = 0;
                        if (checkBoxBrake.Checked) //Send(Brake, SendType.BrakeReset, 0);
                            Brake = 0;
                    }
                }
            }
            #endregion

            CarControlTextBox.Text = speedcontrol.ToString("F2") + "\t" + (ISsum * ISerr).ToString("F2") + "\t刹车 " + Brake;

            if (Receive_Speed < 5)
            {
                if (speedcontrol > 30) speedcontrol = 30;
            }
            else if (Receive_Speed < 10)
            {
                if (speedcontrol > 50) speedcontrol = 50;
            }
            else if (Receive_Speed < 20)
            {
                if (speedcontrol > 70) speedcontrol = 70;
            }

            if (speedcontrol > 50) speedcontrol = 50;
            if (speedcontrol < 0) speedcontrol = 0;

            int speedpara = (int)(speedcontrol / 0.392);
            int pos = ((int)Aim_Steer + 1024);

            Send(pos, SendType.Auto, Brake);
            //Send(pos, SendType.Angle);
        }

        int stoff = 0;
        int spoff = 0;
        int CarControlMode = 0;

        private void CarTest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == Keys.Q.ToString())
                stoff--;
            else if (e.KeyChar.ToString() == Keys.E.ToString())
                stoff++;
            else if (e.KeyChar.ToString() == Keys.X.ToString())
                spoff--;
            else if (e.KeyChar.ToString() == Keys.C.ToString())
                spoff++;
            else if (e.KeyChar == (int)Keys.Escape)
            {
                if (ModeButton.Text != "人工驾驶")
                    ModeButton_Click(null, null);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Send(10, SendType.BrakeReset);
            Thread.Sleep(100);
            Send(10, SendType.Brake);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Send(0x0, SendType.Mode);
            Thread.Sleep(100);
            Send(0x9, SendType.Mode);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            double Aim_Speed = double.Parse(SpeedTextBox.Text);

            if (!checkBoxSpeed.Checked)
                Aim_Speed = Math.Max(0, Control_Speed + (double)spoff * 3);

            lastspeed.Add(Receive_Speed);

            if (Aim_Speed > 40)
            {
                if (Aim_Speed - Receive_Speed > 10 && !(lastspeed[0] < lastspeed[1] && lastspeed[1] < lastspeed[2]))
                {
                    Send(0x0, SendType.Mode);
                    //Thread.Sleep(100);
                    //Send(0x8, SendType.Mode);
                    Thread.Sleep(100);
                    Send(0x9, SendType.Mode);
                }
            }
            else if (Aim_Speed >= 20)
            {
                if (Aim_Speed - Receive_Speed > 5 && !(lastspeed[0] < lastspeed[1] && lastspeed[1] < lastspeed[2]))
                {
                    Send(0x0, SendType.Mode);
                    //Thread.Sleep(100);
                    //Send(0x8, SendType.Mode);
                    Thread.Sleep(100);
                    Send(0x9, SendType.Mode);
                }
            }
            else
            {
                if (Aim_Speed - Receive_Speed > 2 && !(lastspeed[0] < lastspeed[1] && lastspeed[1] < lastspeed[2]))
                {
                    Send(0x0, SendType.Mode);
                    //Thread.Sleep(100);
                    //Send(0x8, SendType.Mode);
                    Thread.Sleep(100);
                    Send(0x9, SendType.Mode);
                }
            }

            lastspeed.RemoveAt(0);
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            speedPower.portwrite(int.Parse(PowerTextBox.Text));
        }
    }
}
