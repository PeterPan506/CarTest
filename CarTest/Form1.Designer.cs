namespace CarTest
{
    partial class CarTest
    {
        /// <summary>
        /// 
        /// 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.AngleCanCheck = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.AngelStepSetText = new System.Windows.Forms.TextBox();
            this.SetAngleRadio = new System.Windows.Forms.RadioButton();
            this.Angle30 = new System.Windows.Forms.RadioButton();
            this.Angle20 = new System.Windows.Forms.RadioButton();
            this.Angle10 = new System.Windows.Forms.RadioButton();
            this.Angle5 = new System.Windows.Forms.RadioButton();
            this.AngleBox = new System.Windows.Forms.TextBox();
            this.RightButton = new System.Windows.Forms.Button();
            this.LeftButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartCanButton = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBoxBrake = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.RealPressureText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PWMTextBox = new System.Windows.Forms.TextBox();
            this.ReleaseButton = new System.Windows.Forms.Button();
            this.BrakeStepControl = new System.Windows.Forms.NumericUpDown();
            this.BrakeButton = new System.Windows.Forms.Button();
            this.BrakeBox = new System.Windows.Forms.TextBox();
            this.ModeButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.VoiceCheck = new System.Windows.Forms.CheckBox();
            this.NearLightCheck = new System.Windows.Forms.CheckBox();
            this.FarLightCheck = new System.Windows.Forms.CheckBox();
            this.BrakeLightCheck = new System.Windows.Forms.CheckBox();
            this.LocationLightCheck = new System.Windows.Forms.CheckBox();
            this.RightLightCheck = new System.Windows.Forms.CheckBox();
            this.LeftLightCheck = new System.Windows.Forms.CheckBox();
            this.SimulateTimer = new System.Windows.Forms.Timer(this.components);
            this.RecInfoGroup = new System.Windows.Forms.GroupBox();
            this.DelayLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SpeedInfoLabel = new System.Windows.Forms.Label();
            this.GearInfoLabel = new System.Windows.Forms.Label();
            this.BrakeInfoLabel = new System.Windows.Forms.Label();
            this.GasInfoLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ResetCanButton = new System.Windows.Forms.Button();
            this.SimulateButton = new System.Windows.Forms.Button();
            this.SimTorqueText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SimTimeText = new System.Windows.Forms.TextBox();
            this.Can451TextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Steerlabel = new System.Windows.Forms.Label();
            this.Speedlabel = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.Can403TextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RecSpeedLabel = new System.Windows.Forms.Label();
            this.RecSteerLabel = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxSpeed = new System.Windows.Forms.CheckBox();
            this.checkBoxSteer = new System.Windows.Forms.CheckBox();
            this.SpeedTextBox = new System.Windows.Forms.TextBox();
            this.SteerTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.CarControlTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.PowerTextBox = new System.Windows.Forms.TextBox();
            this.PowerButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrakeStepControl)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.RecInfoGroup.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.groupBox1.Controls.Add(this.AngleCanCheck);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.AngleBox);
            this.groupBox1.Controls.Add(this.RightButton);
            this.groupBox1.Controls.Add(this.LeftButton);
            this.groupBox1.Location = new System.Drawing.Point(26, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 175);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "转向测试(Can)";
            // 
            // AngleCanCheck
            // 
            this.AngleCanCheck.AutoSize = true;
            this.AngleCanCheck.Location = new System.Drawing.Point(34, 18);
            this.AngleCanCheck.Name = "AngleCanCheck";
            this.AngleCanCheck.Size = new System.Drawing.Size(90, 16);
            this.AngleCanCheck.TabIndex = 28;
            this.AngleCanCheck.Text = "转向CAN测试";
            this.AngleCanCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.AngelStepSetText);
            this.groupBox9.Controls.Add(this.SetAngleRadio);
            this.groupBox9.Controls.Add(this.Angle30);
            this.groupBox9.Controls.Add(this.Angle20);
            this.groupBox9.Controls.Add(this.Angle10);
            this.groupBox9.Controls.Add(this.Angle5);
            this.groupBox9.Location = new System.Drawing.Point(154, 20);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(67, 149);
            this.groupBox9.TabIndex = 27;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "转向步长";
            // 
            // AngelStepSetText
            // 
            this.AngelStepSetText.Location = new System.Drawing.Point(30, 122);
            this.AngelStepSetText.Name = "AngelStepSetText";
            this.AngelStepSetText.Size = new System.Drawing.Size(31, 21);
            this.AngelStepSetText.TabIndex = 14;
            // 
            // SetAngleRadio
            // 
            this.SetAngleRadio.AutoSize = true;
            this.SetAngleRadio.Location = new System.Drawing.Point(9, 127);
            this.SetAngleRadio.Name = "SetAngleRadio";
            this.SetAngleRadio.Size = new System.Drawing.Size(14, 13);
            this.SetAngleRadio.TabIndex = 13;
            this.SetAngleRadio.TabStop = true;
            this.SetAngleRadio.UseVisualStyleBackColor = true;
            // 
            // Angle30
            // 
            this.Angle30.AutoSize = true;
            this.Angle30.Location = new System.Drawing.Point(9, 101);
            this.Angle30.Name = "Angle30";
            this.Angle30.Size = new System.Drawing.Size(35, 16);
            this.Angle30.TabIndex = 12;
            this.Angle30.TabStop = true;
            this.Angle30.Text = "30";
            this.Angle30.UseVisualStyleBackColor = true;
            // 
            // Angle20
            // 
            this.Angle20.AutoSize = true;
            this.Angle20.Location = new System.Drawing.Point(9, 74);
            this.Angle20.Name = "Angle20";
            this.Angle20.Size = new System.Drawing.Size(35, 16);
            this.Angle20.TabIndex = 11;
            this.Angle20.TabStop = true;
            this.Angle20.Text = "20";
            this.Angle20.UseVisualStyleBackColor = true;
            // 
            // Angle10
            // 
            this.Angle10.AutoSize = true;
            this.Angle10.Location = new System.Drawing.Point(9, 47);
            this.Angle10.Name = "Angle10";
            this.Angle10.Size = new System.Drawing.Size(35, 16);
            this.Angle10.TabIndex = 10;
            this.Angle10.TabStop = true;
            this.Angle10.Text = "10";
            this.Angle10.UseVisualStyleBackColor = true;
            // 
            // Angle5
            // 
            this.Angle5.AutoSize = true;
            this.Angle5.Location = new System.Drawing.Point(9, 20);
            this.Angle5.Name = "Angle5";
            this.Angle5.Size = new System.Drawing.Size(29, 16);
            this.Angle5.TabIndex = 9;
            this.Angle5.TabStop = true;
            this.Angle5.Text = "5";
            this.Angle5.UseVisualStyleBackColor = true;
            // 
            // AngleBox
            // 
            this.AngleBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AngleBox.Location = new System.Drawing.Point(52, 108);
            this.AngleBox.Name = "AngleBox";
            this.AngleBox.ReadOnly = true;
            this.AngleBox.Size = new System.Drawing.Size(72, 29);
            this.AngleBox.TabIndex = 2;
            this.AngleBox.Text = "0度";
            this.AngleBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // RightButton
            // 
            this.RightButton.BackgroundImage = global::CarTest.Properties.Resources.you;
            this.RightButton.FlatAppearance.BorderSize = 0;
            this.RightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RightButton.Location = new System.Drawing.Point(99, 42);
            this.RightButton.Name = "RightButton";
            this.RightButton.Size = new System.Drawing.Size(52, 50);
            this.RightButton.TabIndex = 0;
            this.RightButton.UseVisualStyleBackColor = true;
            this.RightButton.Click += new System.EventHandler(this.RightButton_Click);
            this.RightButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.RightButton_MouseDown);
            this.RightButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.RightButton_MouseUp);
            // 
            // LeftButton
            // 
            this.LeftButton.BackgroundImage = global::CarTest.Properties.Resources.zuo;
            this.LeftButton.FlatAppearance.BorderSize = 0;
            this.LeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LeftButton.Location = new System.Drawing.Point(20, 40);
            this.LeftButton.Name = "LeftButton";
            this.LeftButton.Size = new System.Drawing.Size(55, 50);
            this.LeftButton.TabIndex = 1;
            this.LeftButton.UseVisualStyleBackColor = true;
            this.LeftButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftButton_MouseDown);
            this.LeftButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LeftButton_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StartCanButton
            // 
            this.StartCanButton.Location = new System.Drawing.Point(12, 13);
            this.StartCanButton.Name = "StartCanButton";
            this.StartCanButton.Size = new System.Drawing.Size(75, 23);
            this.StartCanButton.TabIndex = 19;
            this.StartCanButton.Text = "启动Can";
            this.StartCanButton.UseVisualStyleBackColor = true;
            this.StartCanButton.Click += new System.EventHandler(this.StartCanButton_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.groupBox4.Controls.Add(this.checkBoxBrake);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.RealPressureText);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.PWMTextBox);
            this.groupBox4.Controls.Add(this.ReleaseButton);
            this.groupBox4.Controls.Add(this.BrakeStepControl);
            this.groupBox4.Controls.Add(this.BrakeButton);
            this.groupBox4.Controls.Add(this.BrakeBox);
            this.groupBox4.Location = new System.Drawing.Point(261, 125);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 218);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "速度控制区";
            // 
            // checkBoxBrake
            // 
            this.checkBoxBrake.AutoSize = true;
            this.checkBoxBrake.Checked = true;
            this.checkBoxBrake.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxBrake.Location = new System.Drawing.Point(107, 186);
            this.checkBoxBrake.Name = "checkBoxBrake";
            this.checkBoxBrake.Size = new System.Drawing.Size(48, 16);
            this.checkBoxBrake.TabIndex = 48;
            this.checkBoxBrake.Text = "Send";
            this.checkBoxBrake.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F);
            this.label9.Location = new System.Drawing.Point(20, 138);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "实际压力：";
            // 
            // RealPressureText
            // 
            this.RealPressureText.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RealPressureText.Location = new System.Drawing.Point(113, 132);
            this.RealPressureText.Name = "RealPressureText";
            this.RealPressureText.ReadOnly = true;
            this.RealPressureText.Size = new System.Drawing.Size(38, 29);
            this.RealPressureText.TabIndex = 30;
            this.RealPressureText.Text = "0";
            this.RealPressureText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.Location = new System.Drawing.Point(20, 70);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 29;
            this.label8.Text = "目标压力：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.Location = new System.Drawing.Point(30, 104);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "PWM：";
            // 
            // PWMTextBox
            // 
            this.PWMTextBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PWMTextBox.Location = new System.Drawing.Point(83, 99);
            this.PWMTextBox.Name = "PWMTextBox";
            this.PWMTextBox.Size = new System.Drawing.Size(55, 29);
            this.PWMTextBox.TabIndex = 25;
            this.PWMTextBox.Text = "0";
            this.PWMTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ReleaseButton
            // 
            this.ReleaseButton.Location = new System.Drawing.Point(24, 170);
            this.ReleaseButton.Name = "ReleaseButton";
            this.ReleaseButton.Size = new System.Drawing.Size(67, 47);
            this.ReleaseButton.TabIndex = 24;
            this.ReleaseButton.Text = "释放";
            this.ReleaseButton.UseVisualStyleBackColor = true;
            this.ReleaseButton.Click += new System.EventHandler(this.ReleaseButton_Click);
            // 
            // BrakeStepControl
            // 
            this.BrakeStepControl.Font = new System.Drawing.Font("宋体", 16F);
            this.BrakeStepControl.Location = new System.Drawing.Point(97, 24);
            this.BrakeStepControl.Name = "BrakeStepControl";
            this.BrakeStepControl.Size = new System.Drawing.Size(58, 32);
            this.BrakeStepControl.TabIndex = 23;
            // 
            // BrakeButton
            // 
            this.BrakeButton.Location = new System.Drawing.Point(16, 18);
            this.BrakeButton.Name = "BrakeButton";
            this.BrakeButton.Size = new System.Drawing.Size(75, 41);
            this.BrakeButton.TabIndex = 22;
            this.BrakeButton.Text = "制动";
            this.BrakeButton.UseVisualStyleBackColor = true;
            this.BrakeButton.Click += new System.EventHandler(this.BrakeButton_Click);
            // 
            // BrakeBox
            // 
            this.BrakeBox.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BrakeBox.Location = new System.Drawing.Point(113, 64);
            this.BrakeBox.Name = "BrakeBox";
            this.BrakeBox.ReadOnly = true;
            this.BrakeBox.Size = new System.Drawing.Size(38, 29);
            this.BrakeBox.TabIndex = 2;
            this.BrakeBox.Text = "0";
            this.BrakeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ModeButton
            // 
            this.ModeButton.Location = new System.Drawing.Point(180, 9);
            this.ModeButton.Name = "ModeButton";
            this.ModeButton.Size = new System.Drawing.Size(75, 31);
            this.ModeButton.TabIndex = 25;
            this.ModeButton.Text = "人工驾驶";
            this.ModeButton.UseVisualStyleBackColor = true;
            this.ModeButton.Click += new System.EventHandler(this.ModeButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.groupBox2.Controls.Add(this.VoiceCheck);
            this.groupBox2.Controls.Add(this.NearLightCheck);
            this.groupBox2.Controls.Add(this.FarLightCheck);
            this.groupBox2.Controls.Add(this.BrakeLightCheck);
            this.groupBox2.Controls.Add(this.LocationLightCheck);
            this.groupBox2.Controls.Add(this.RightLightCheck);
            this.groupBox2.Controls.Add(this.LeftLightCheck);
            this.groupBox2.Location = new System.Drawing.Point(262, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 104);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信号灯灯控制区";
            // 
            // VoiceCheck
            // 
            this.VoiceCheck.AutoSize = true;
            this.VoiceCheck.Location = new System.Drawing.Point(6, 77);
            this.VoiceCheck.Name = "VoiceCheck";
            this.VoiceCheck.Size = new System.Drawing.Size(60, 16);
            this.VoiceCheck.TabIndex = 30;
            this.VoiceCheck.Text = "位置灯";
            this.VoiceCheck.UseVisualStyleBackColor = true;
            this.VoiceCheck.CheckedChanged += new System.EventHandler(this.VoiceCheck_CheckedChanged);
            // 
            // NearLightCheck
            // 
            this.NearLightCheck.AutoSize = true;
            this.NearLightCheck.Location = new System.Drawing.Point(90, 58);
            this.NearLightCheck.Name = "NearLightCheck";
            this.NearLightCheck.Size = new System.Drawing.Size(60, 16);
            this.NearLightCheck.TabIndex = 29;
            this.NearLightCheck.Text = "近光灯";
            this.NearLightCheck.UseVisualStyleBackColor = true;
            this.NearLightCheck.CheckedChanged += new System.EventHandler(this.NearLightCheck_CheckedChanged);
            // 
            // FarLightCheck
            // 
            this.FarLightCheck.AutoSize = true;
            this.FarLightCheck.Location = new System.Drawing.Point(6, 58);
            this.FarLightCheck.Name = "FarLightCheck";
            this.FarLightCheck.Size = new System.Drawing.Size(60, 16);
            this.FarLightCheck.TabIndex = 28;
            this.FarLightCheck.Text = "远光灯";
            this.FarLightCheck.UseVisualStyleBackColor = true;
            this.FarLightCheck.CheckedChanged += new System.EventHandler(this.FarLightCheck_CheckedChanged);
            // 
            // BrakeLightCheck
            // 
            this.BrakeLightCheck.AutoSize = true;
            this.BrakeLightCheck.Location = new System.Drawing.Point(90, 39);
            this.BrakeLightCheck.Name = "BrakeLightCheck";
            this.BrakeLightCheck.Size = new System.Drawing.Size(60, 16);
            this.BrakeLightCheck.TabIndex = 27;
            this.BrakeLightCheck.Text = "刹车灯";
            this.BrakeLightCheck.UseVisualStyleBackColor = true;
            this.BrakeLightCheck.CheckedChanged += new System.EventHandler(this.BrakeLightCheck_CheckedChanged);
            // 
            // LocationLightCheck
            // 
            this.LocationLightCheck.AutoSize = true;
            this.LocationLightCheck.Location = new System.Drawing.Point(6, 39);
            this.LocationLightCheck.Name = "LocationLightCheck";
            this.LocationLightCheck.Size = new System.Drawing.Size(48, 16);
            this.LocationLightCheck.TabIndex = 2;
            this.LocationLightCheck.Text = "喇叭";
            this.LocationLightCheck.UseVisualStyleBackColor = true;
            this.LocationLightCheck.CheckedChanged += new System.EventHandler(this.LocationLightCheck_CheckedChanged);
            // 
            // RightLightCheck
            // 
            this.RightLightCheck.AutoSize = true;
            this.RightLightCheck.Location = new System.Drawing.Point(90, 20);
            this.RightLightCheck.Name = "RightLightCheck";
            this.RightLightCheck.Size = new System.Drawing.Size(60, 16);
            this.RightLightCheck.TabIndex = 1;
            this.RightLightCheck.Text = "右转向";
            this.RightLightCheck.UseVisualStyleBackColor = true;
            this.RightLightCheck.CheckedChanged += new System.EventHandler(this.RightLightCheck_CheckedChanged);
            // 
            // LeftLightCheck
            // 
            this.LeftLightCheck.AutoSize = true;
            this.LeftLightCheck.Location = new System.Drawing.Point(6, 20);
            this.LeftLightCheck.Name = "LeftLightCheck";
            this.LeftLightCheck.Size = new System.Drawing.Size(60, 16);
            this.LeftLightCheck.TabIndex = 0;
            this.LeftLightCheck.Text = "左转向";
            this.LeftLightCheck.UseVisualStyleBackColor = true;
            this.LeftLightCheck.CheckedChanged += new System.EventHandler(this.LeftLightCheck_CheckedChanged);
            // 
            // SimulateTimer
            // 
            this.SimulateTimer.Tick += new System.EventHandler(this.SimulateTimer_Tick);
            // 
            // RecInfoGroup
            // 
            this.RecInfoGroup.Controls.Add(this.DelayLabel);
            this.RecInfoGroup.Controls.Add(this.label5);
            this.RecInfoGroup.Controls.Add(this.SpeedInfoLabel);
            this.RecInfoGroup.Controls.Add(this.GearInfoLabel);
            this.RecInfoGroup.Controls.Add(this.BrakeInfoLabel);
            this.RecInfoGroup.Controls.Add(this.GasInfoLabel);
            this.RecInfoGroup.Controls.Add(this.label4);
            this.RecInfoGroup.Controls.Add(this.label3);
            this.RecInfoGroup.Controls.Add(this.label2);
            this.RecInfoGroup.Controls.Add(this.label1);
            this.RecInfoGroup.Location = new System.Drawing.Point(455, 13);
            this.RecInfoGroup.Name = "RecInfoGroup";
            this.RecInfoGroup.Size = new System.Drawing.Size(157, 230);
            this.RecInfoGroup.TabIndex = 27;
            this.RecInfoGroup.TabStop = false;
            this.RecInfoGroup.Text = "接收信息";
            // 
            // DelayLabel
            // 
            this.DelayLabel.AutoSize = true;
            this.DelayLabel.Location = new System.Drawing.Point(102, 177);
            this.DelayLabel.Name = "DelayLabel";
            this.DelayLabel.Size = new System.Drawing.Size(11, 12);
            this.DelayLabel.TabIndex = 9;
            this.DelayLabel.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "制动响应(ms)：";
            // 
            // SpeedInfoLabel
            // 
            this.SpeedInfoLabel.AutoSize = true;
            this.SpeedInfoLabel.Location = new System.Drawing.Point(70, 21);
            this.SpeedInfoLabel.Name = "SpeedInfoLabel";
            this.SpeedInfoLabel.Size = new System.Drawing.Size(0, 12);
            this.SpeedInfoLabel.TabIndex = 7;
            // 
            // GearInfoLabel
            // 
            this.GearInfoLabel.AutoSize = true;
            this.GearInfoLabel.Location = new System.Drawing.Point(54, 140);
            this.GearInfoLabel.Name = "GearInfoLabel";
            this.GearInfoLabel.Size = new System.Drawing.Size(0, 12);
            this.GearInfoLabel.TabIndex = 4;
            // 
            // BrakeInfoLabel
            // 
            this.BrakeInfoLabel.AutoSize = true;
            this.BrakeInfoLabel.Location = new System.Drawing.Point(54, 95);
            this.BrakeInfoLabel.Name = "BrakeInfoLabel";
            this.BrakeInfoLabel.Size = new System.Drawing.Size(0, 12);
            this.BrakeInfoLabel.TabIndex = 5;
            // 
            // GasInfoLabel
            // 
            this.GasInfoLabel.AutoSize = true;
            this.GasInfoLabel.Location = new System.Drawing.Point(54, 55);
            this.GasInfoLabel.Name = "GasInfoLabel";
            this.GasInfoLabel.Size = new System.Drawing.Size(0, 12);
            this.GasInfoLabel.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "档位：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "刹车：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "油门：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "速度(m/s):";
            // 
            // ResetCanButton
            // 
            this.ResetCanButton.Location = new System.Drawing.Point(99, 13);
            this.ResetCanButton.Name = "ResetCanButton";
            this.ResetCanButton.Size = new System.Drawing.Size(75, 23);
            this.ResetCanButton.TabIndex = 28;
            this.ResetCanButton.Text = "复位Can";
            this.ResetCanButton.UseVisualStyleBackColor = true;
            this.ResetCanButton.Click += new System.EventHandler(this.ResetCanButton_Click);
            // 
            // SimulateButton
            // 
            this.SimulateButton.Location = new System.Drawing.Point(645, 86);
            this.SimulateButton.Name = "SimulateButton";
            this.SimulateButton.Size = new System.Drawing.Size(75, 31);
            this.SimulateButton.TabIndex = 29;
            this.SimulateButton.Text = "开始模拟";
            this.SimulateButton.UseVisualStyleBackColor = true;
            this.SimulateButton.Click += new System.EventHandler(this.SimulateButton_Click);
            // 
            // SimTorqueText
            // 
            this.SimTorqueText.Location = new System.Drawing.Point(683, 208);
            this.SimTorqueText.Name = "SimTorqueText";
            this.SimTorqueText.Size = new System.Drawing.Size(50, 21);
            this.SimTorqueText.TabIndex = 15;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(618, 208);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 22);
            this.button1.TabIndex = 30;
            this.button1.Text = "设置扭矩";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(618, 52);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 22);
            this.button2.TabIndex = 32;
            this.button2.Text = "模拟周期";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SimTimeText
            // 
            this.SimTimeText.Location = new System.Drawing.Point(683, 52);
            this.SimTimeText.Name = "SimTimeText";
            this.SimTimeText.Size = new System.Drawing.Size(50, 21);
            this.SimTimeText.TabIndex = 31;
            // 
            // Can451TextBox
            // 
            this.Can451TextBox.Location = new System.Drawing.Point(104, 364);
            this.Can451TextBox.Name = "Can451TextBox";
            this.Can451TextBox.Size = new System.Drawing.Size(508, 21);
            this.Can451TextBox.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 367);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 12);
            this.label10.TabIndex = 34;
            this.label10.Text = "Can_ID_451:";
            // 
            // Steerlabel
            // 
            this.Steerlabel.AutoSize = true;
            this.Steerlabel.Location = new System.Drawing.Point(27, 283);
            this.Steerlabel.Name = "Steerlabel";
            this.Steerlabel.Size = new System.Drawing.Size(35, 12);
            this.Steerlabel.TabIndex = 36;
            this.Steerlabel.Text = "Steer";
            // 
            // Speedlabel
            // 
            this.Speedlabel.AutoSize = true;
            this.Speedlabel.Location = new System.Drawing.Point(26, 304);
            this.Speedlabel.Name = "Speedlabel";
            this.Speedlabel.Size = new System.Drawing.Size(35, 12);
            this.Speedlabel.TabIndex = 37;
            this.Speedlabel.Text = "Speed";
            // 
            // timer2
            // 
            this.timer2.Interval = 10;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Can403TextBox
            // 
            this.Can403TextBox.Location = new System.Drawing.Point(104, 390);
            this.Can403TextBox.Name = "Can403TextBox";
            this.Can403TextBox.Size = new System.Drawing.Size(508, 21);
            this.Can403TextBox.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 394);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "Can_ID_403:";
            // 
            // RecSpeedLabel
            // 
            this.RecSpeedLabel.AutoSize = true;
            this.RecSpeedLabel.Location = new System.Drawing.Point(131, 304);
            this.RecSpeedLabel.Name = "RecSpeedLabel";
            this.RecSpeedLabel.Size = new System.Drawing.Size(35, 12);
            this.RecSpeedLabel.TabIndex = 41;
            this.RecSpeedLabel.Text = "Speed";
            // 
            // RecSteerLabel
            // 
            this.RecSteerLabel.AutoSize = true;
            this.RecSteerLabel.Location = new System.Drawing.Point(132, 283);
            this.RecSteerLabel.Name = "RecSteerLabel";
            this.RecSteerLabel.Size = new System.Drawing.Size(35, 12);
            this.RecSteerLabel.TabIndex = 40;
            this.RecSteerLabel.Text = "Steer";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxSpeed);
            this.groupBox3.Controls.Add(this.checkBoxSteer);
            this.groupBox3.Controls.Add(this.SpeedTextBox);
            this.groupBox3.Controls.Add(this.SteerTextBox);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(455, 262);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(172, 80);
            this.groupBox3.TabIndex = 42;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "控制";
            // 
            // checkBoxSpeed
            // 
            this.checkBoxSpeed.AutoSize = true;
            this.checkBoxSpeed.Checked = true;
            this.checkBoxSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSpeed.Location = new System.Drawing.Point(143, 54);
            this.checkBoxSpeed.Name = "checkBoxSpeed";
            this.checkBoxSpeed.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSpeed.TabIndex = 47;
            this.checkBoxSpeed.UseVisualStyleBackColor = true;
            // 
            // checkBoxSteer
            // 
            this.checkBoxSteer.AutoSize = true;
            this.checkBoxSteer.Location = new System.Drawing.Point(143, 25);
            this.checkBoxSteer.Name = "checkBoxSteer";
            this.checkBoxSteer.Size = new System.Drawing.Size(15, 14);
            this.checkBoxSteer.TabIndex = 46;
            this.checkBoxSteer.UseVisualStyleBackColor = true;
            // 
            // SpeedTextBox
            // 
            this.SpeedTextBox.Location = new System.Drawing.Point(52, 51);
            this.SpeedTextBox.Name = "SpeedTextBox";
            this.SpeedTextBox.Size = new System.Drawing.Size(84, 21);
            this.SpeedTextBox.TabIndex = 45;
            this.SpeedTextBox.Text = "0";
            this.SpeedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SteerTextBox
            // 
            this.SteerTextBox.Location = new System.Drawing.Point(52, 21);
            this.SteerTextBox.Name = "SteerTextBox";
            this.SteerTextBox.Size = new System.Drawing.Size(84, 21);
            this.SteerTextBox.TabIndex = 43;
            this.SteerTextBox.Text = "0";
            this.SteerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 44;
            this.label11.Text = "速度";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 43;
            this.label12.Text = "方向盘";
            // 
            // CarControlTextBox
            // 
            this.CarControlTextBox.Location = new System.Drawing.Point(105, 417);
            this.CarControlTextBox.Name = "CarControlTextBox";
            this.CarControlTextBox.Size = new System.Drawing.Size(508, 21);
            this.CarControlTextBox.TabIndex = 43;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(645, 134);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 44;
            this.button3.Text = "制动复位";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(645, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 45;
            this.button4.Text = "回复油门";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // PowerTextBox
            // 
            this.PowerTextBox.Location = new System.Drawing.Point(645, 274);
            this.PowerTextBox.Name = "PowerTextBox";
            this.PowerTextBox.Size = new System.Drawing.Size(75, 21);
            this.PowerTextBox.TabIndex = 48;
            this.PowerTextBox.Text = "0";
            this.PowerTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // PowerButton
            // 
            this.PowerButton.Location = new System.Drawing.Point(645, 304);
            this.PowerButton.Name = "PowerButton";
            this.PowerButton.Size = new System.Drawing.Size(75, 23);
            this.PowerButton.TabIndex = 49;
            this.PowerButton.Text = "油门";
            this.PowerButton.UseVisualStyleBackColor = true;
            this.PowerButton.Click += new System.EventHandler(this.PowerButton_Click);
            // 
            // CarTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 454);
            this.Controls.Add(this.PowerButton);
            this.Controls.Add(this.PowerTextBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.CarControlTextBox);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.RecSpeedLabel);
            this.Controls.Add(this.RecSteerLabel);
            this.Controls.Add(this.Can403TextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Speedlabel);
            this.Controls.Add(this.Steerlabel);
            this.Controls.Add(this.Can451TextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.SimTimeText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SimTorqueText);
            this.Controls.Add(this.SimulateButton);
            this.Controls.Add(this.ResetCanButton);
            this.Controls.Add(this.RecInfoGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ModeButton);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.StartCanButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarTest";
            this.Text = "CarTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CarTest_FormClosing);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CarTest_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrakeStepControl)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.RecInfoGroup.ResumeLayout(false);
            this.RecInfoGroup.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton Angle30;
        private System.Windows.Forms.RadioButton Angle20;
        private System.Windows.Forms.RadioButton Angle10;
        private System.Windows.Forms.RadioButton Angle5;
        private System.Windows.Forms.TextBox AngleBox;
        private System.Windows.Forms.Button RightButton;
        private System.Windows.Forms.Button LeftButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartCanButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox BrakeBox;
        private System.Windows.Forms.NumericUpDown BrakeStepControl;
        private System.Windows.Forms.Button BrakeButton;
        private System.Windows.Forms.Button ReleaseButton;
        private System.Windows.Forms.Button ModeButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox RightLightCheck;
        private System.Windows.Forms.CheckBox LeftLightCheck;
        private System.Windows.Forms.CheckBox BrakeLightCheck;
        private System.Windows.Forms.CheckBox LocationLightCheck;
        private System.Windows.Forms.CheckBox AngleCanCheck;
        private System.Windows.Forms.Timer SimulateTimer;
        private System.Windows.Forms.GroupBox RecInfoGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SpeedInfoLabel;
        private System.Windows.Forms.Label GasInfoLabel;
        private System.Windows.Forms.Label BrakeInfoLabel;
        private System.Windows.Forms.Label GearInfoLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ResetCanButton;
        private System.Windows.Forms.Label DelayLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AngelStepSetText;
        private System.Windows.Forms.RadioButton SetAngleRadio;
        private System.Windows.Forms.Button SimulateButton;
        private System.Windows.Forms.TextBox SimTorqueText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox SimTimeText;
        private System.Windows.Forms.CheckBox VoiceCheck;
        private System.Windows.Forms.CheckBox NearLightCheck;
        private System.Windows.Forms.CheckBox FarLightCheck;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PWMTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox RealPressureText;
        private System.Windows.Forms.TextBox Can451TextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label Steerlabel;
        private System.Windows.Forms.Label Speedlabel;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox Can403TextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label RecSpeedLabel;
        private System.Windows.Forms.Label RecSteerLabel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox SpeedTextBox;
        private System.Windows.Forms.TextBox SteerTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CarControlTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.CheckBox checkBoxSpeed;
        private System.Windows.Forms.CheckBox checkBoxSteer;
        private System.Windows.Forms.CheckBox checkBoxBrake;
        private System.Windows.Forms.TextBox PowerTextBox;
        private System.Windows.Forms.Button PowerButton;
    }
}

