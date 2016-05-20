namespace Digital_Pulse_Generator
{
    partial class Pulse_Generator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pulse_Generator));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.toolStripStatusXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_GenerateWave = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox_AnalogToDigitalSettings = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ADReferenceLow = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_ADReferenceHigh = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.period_text = new System.Windows.Forms.TextBox();
            this.mhz_label = new System.Windows.Forms.Label();
            this.ad_bits_textbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.period_label = new System.Windows.Forms.Label();
            this.ad_voltage_label = new System.Windows.Forms.Label();
            this.ad_bits_label = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.radioButton_PulseInfoDigital = new System.Windows.Forms.RadioButton();
            this.radioButton_PulseInfoAnalog = new System.Windows.Forms.RadioButton();
            this.textBox_PulseInformation = new System.Windows.Forms.RichTextBox();
            this.panel_PulseControls = new System.Windows.Forms.Panel();
            this.groupBox_WaveParameters = new System.Windows.Forms.GroupBox();
            this.textBox_Repetitions = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox_Formula = new System.Windows.Forms.GroupBox();
            this.pictureBox_Formula = new System.Windows.Forms.PictureBox();
            this.radioButton_Gaussian = new System.Windows.Forms.RadioButton();
            this.radioButton_TriangleWave = new System.Windows.Forms.RadioButton();
            this.radioButton_SquareWave = new System.Windows.Forms.RadioButton();
            this.radioButton_SineWave = new System.Windows.Forms.RadioButton();
            this.textBox_Phase = new System.Windows.Forms.TextBox();
            this.label_Phase = new System.Windows.Forms.Label();
            this.textBox_Period = new System.Windows.Forms.TextBox();
            this.label_Period = new System.Windows.Forms.Label();
            this.textBox_Amplitude = new System.Windows.Forms.TextBox();
            this.label_Amplitude = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_FileOpenDigital = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileSaveDigital = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_FileOpenAnalog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileSaveAnalog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_EditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_EditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_GraphShowGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_GraphResetZoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_GraphClearGraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_Frequency = new Digital_Pulse_Generator.NumerUpDownEx();
            this.groupBox_AnalogToDigitalSettings.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel_PulseControls.SuspendLayout();
            this.groupBox_WaveParameters.SuspendLayout();
            this.groupBox_Formula.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Formula)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Frequency)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.zedGraphControl1.Location = new System.Drawing.Point(10, 27);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0;
            this.zedGraphControl1.ScrollMaxX = 0;
            this.zedGraphControl1.ScrollMaxY = 0;
            this.zedGraphControl1.ScrollMaxY2 = 0;
            this.zedGraphControl1.ScrollMinX = 0;
            this.zedGraphControl1.ScrollMinY = 0;
            this.zedGraphControl1.ScrollMinY2 = 0;
            this.zedGraphControl1.Size = new System.Drawing.Size(983, 571);
            this.zedGraphControl1.TabIndex = 1;
            this.zedGraphControl1.MouseDownEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedGraphControl1_MouseDownEvent);
            this.zedGraphControl1.MouseUpEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedGraphControl1_MouseUpEvent);
            this.zedGraphControl1.MouseMoveEvent += new ZedGraph.ZedGraphControl.ZedMouseEventHandler(this.zedGraphControl1_MouseMoveEvent);
            // 
            // toolStripStatusXY
            // 
            this.toolStripStatusXY.Name = "toolStripStatusXY";
            this.toolStripStatusXY.Size = new System.Drawing.Size(0, 17);
            // 
            // button_GenerateWave
            // 
            this.button_GenerateWave.Location = new System.Drawing.Point(162, 129);
            this.button_GenerateWave.Name = "button_GenerateWave";
            this.button_GenerateWave.Size = new System.Drawing.Size(135, 23);
            this.button_GenerateWave.TabIndex = 8;
            this.button_GenerateWave.Text = "Generate Wave";
            this.button_GenerateWave.UseVisualStyleBackColor = true;
            this.button_GenerateWave.Click += new System.EventHandler(this.button_GenerateWave_Click);
            // 
            // groupBox_AnalogToDigitalSettings
            // 
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.label2);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.textBox_ADReferenceLow);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.label3);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.label14);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.textBox_Frequency);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.label13);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.textBox_ADReferenceHigh);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.label7);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.period_text);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.mhz_label);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.ad_bits_textbox);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.label10);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.period_label);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.ad_voltage_label);
            this.groupBox_AnalogToDigitalSettings.Controls.Add(this.ad_bits_label);
            this.groupBox_AnalogToDigitalSettings.Location = new System.Drawing.Point(517, 3);
            this.groupBox_AnalogToDigitalSettings.Name = "groupBox_AnalogToDigitalSettings";
            this.groupBox_AnalogToDigitalSettings.Size = new System.Drawing.Size(194, 168);
            this.groupBox_AnalogToDigitalSettings.TabIndex = 1;
            this.groupBox_AnalogToDigitalSettings.TabStop = false;
            this.groupBox_AnalogToDigitalSettings.Text = "Analog to Digital Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "V";
            // 
            // textBox_ADReferenceLow
            // 
            this.textBox_ADReferenceLow.Location = new System.Drawing.Point(83, 54);
            this.textBox_ADReferenceLow.Name = "textBox_ADReferenceLow";
            this.textBox_ADReferenceLow.Size = new System.Drawing.Size(73, 20);
            this.textBox_ADReferenceLow.TabIndex = 2;
            this.textBox_ADReferenceLow.TextChanged += new System.EventHandler(this.ad_voltage_textbox_TextChanged);
            this.textBox_ADReferenceLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_AllowOnlyNumericKeys_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Low Referece:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(161, 83);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Bits";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(161, 31);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "V";
            // 
            // textBox_ADReferenceHigh
            // 
            this.textBox_ADReferenceHigh.Location = new System.Drawing.Point(83, 28);
            this.textBox_ADReferenceHigh.Name = "textBox_ADReferenceHigh";
            this.textBox_ADReferenceHigh.Size = new System.Drawing.Size(73, 20);
            this.textBox_ADReferenceHigh.TabIndex = 0;
            this.textBox_ADReferenceHigh.TextChanged += new System.EventHandler(this.ad_voltage_textbox_TextChanged);
            this.textBox_ADReferenceHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_AllowOnlyNumericKeys_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "ns";
            // 
            // period_text
            // 
            this.period_text.Location = new System.Drawing.Point(83, 133);
            this.period_text.Name = "period_text";
            this.period_text.ReadOnly = true;
            this.period_text.Size = new System.Drawing.Size(73, 20);
            this.period_text.TabIndex = 5;
            this.period_text.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_AllowOnlyNumericKeys_KeyPress);
            // 
            // mhz_label
            // 
            this.mhz_label.AutoSize = true;
            this.mhz_label.Location = new System.Drawing.Point(161, 109);
            this.mhz_label.Name = "mhz_label";
            this.mhz_label.Size = new System.Drawing.Size(29, 13);
            this.mhz_label.TabIndex = 16;
            this.mhz_label.Text = "MHz";
            // 
            // ad_bits_textbox
            // 
            this.ad_bits_textbox.Location = new System.Drawing.Point(83, 80);
            this.ad_bits_textbox.Name = "ad_bits_textbox";
            this.ad_bits_textbox.Size = new System.Drawing.Size(73, 20);
            this.ad_bits_textbox.TabIndex = 3;
            this.ad_bits_textbox.TextChanged += new System.EventHandler(this.ad_bits_textbox_TextChanged);
            this.ad_bits_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_AllowOnlyNumericKeys_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Frequency:";
            // 
            // period_label
            // 
            this.period_label.AutoSize = true;
            this.period_label.Location = new System.Drawing.Point(46, 136);
            this.period_label.Name = "period_label";
            this.period_label.Size = new System.Drawing.Size(40, 13);
            this.period_label.TabIndex = 21;
            this.period_label.Text = "Period:";
            // 
            // ad_voltage_label
            // 
            this.ad_voltage_label.AutoSize = true;
            this.ad_voltage_label.Location = new System.Drawing.Point(7, 31);
            this.ad_voltage_label.Name = "ad_voltage_label";
            this.ad_voltage_label.Size = new System.Drawing.Size(79, 13);
            this.ad_voltage_label.TabIndex = 9;
            this.ad_voltage_label.Text = "High Referece:";
            // 
            // ad_bits_label
            // 
            this.ad_bits_label.AutoSize = true;
            this.ad_bits_label.Location = new System.Drawing.Point(26, 83);
            this.ad_bits_label.Name = "ad_bits_label";
            this.ad_bits_label.Size = new System.Drawing.Size(60, 13);
            this.ad_bits_label.TabIndex = 7;
            this.ad_bits_label.Text = "Resolution:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 775);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1004, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 28;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.radioButton_PulseInfoDigital);
            this.groupBox4.Controls.Add(this.radioButton_PulseInfoAnalog);
            this.groupBox4.Controls.Add(this.textBox_PulseInformation);
            this.groupBox4.Location = new System.Drawing.Point(717, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(266, 168);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pulse Information";
            // 
            // radioButton_PulseInfoDigital
            // 
            this.radioButton_PulseInfoDigital.AutoSize = true;
            this.radioButton_PulseInfoDigital.Location = new System.Drawing.Point(70, 17);
            this.radioButton_PulseInfoDigital.Name = "radioButton_PulseInfoDigital";
            this.radioButton_PulseInfoDigital.Size = new System.Drawing.Size(54, 17);
            this.radioButton_PulseInfoDigital.TabIndex = 1;
            this.radioButton_PulseInfoDigital.TabStop = true;
            this.radioButton_PulseInfoDigital.Text = "Digital";
            this.radioButton_PulseInfoDigital.UseVisualStyleBackColor = true;
            this.radioButton_PulseInfoDigital.CheckedChanged += new System.EventHandler(this.radioButton_PulseInfoAnalog_CheckedChanged);
            // 
            // radioButton_PulseInfoAnalog
            // 
            this.radioButton_PulseInfoAnalog.AutoSize = true;
            this.radioButton_PulseInfoAnalog.Checked = true;
            this.radioButton_PulseInfoAnalog.Location = new System.Drawing.Point(6, 17);
            this.radioButton_PulseInfoAnalog.Name = "radioButton_PulseInfoAnalog";
            this.radioButton_PulseInfoAnalog.Size = new System.Drawing.Size(58, 17);
            this.radioButton_PulseInfoAnalog.TabIndex = 0;
            this.radioButton_PulseInfoAnalog.TabStop = true;
            this.radioButton_PulseInfoAnalog.Text = "Analog";
            this.radioButton_PulseInfoAnalog.UseVisualStyleBackColor = true;
            this.radioButton_PulseInfoAnalog.CheckedChanged += new System.EventHandler(this.radioButton_PulseInfoAnalog_CheckedChanged);
            // 
            // textBox_PulseInformation
            // 
            this.textBox_PulseInformation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_PulseInformation.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_PulseInformation.Location = new System.Drawing.Point(4, 43);
            this.textBox_PulseInformation.Name = "textBox_PulseInformation";
            this.textBox_PulseInformation.ReadOnly = true;
            this.textBox_PulseInformation.Size = new System.Drawing.Size(258, 119);
            this.textBox_PulseInformation.TabIndex = 2;
            this.textBox_PulseInformation.Text = "";
            this.textBox_PulseInformation.WordWrap = false;
            // 
            // panel_PulseControls
            // 
            this.panel_PulseControls.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel_PulseControls.Controls.Add(this.groupBox_AnalogToDigitalSettings);
            this.panel_PulseControls.Controls.Add(this.groupBox_WaveParameters);
            this.panel_PulseControls.Controls.Add(this.groupBox4);
            this.panel_PulseControls.Location = new System.Drawing.Point(10, 601);
            this.panel_PulseControls.Name = "panel_PulseControls";
            this.panel_PulseControls.Size = new System.Drawing.Size(983, 171);
            this.panel_PulseControls.TabIndex = 0;
            // 
            // groupBox_WaveParameters
            // 
            this.groupBox_WaveParameters.Controls.Add(this.textBox_Repetitions);
            this.groupBox_WaveParameters.Controls.Add(this.label1);
            this.groupBox_WaveParameters.Controls.Add(this.groupBox_Formula);
            this.groupBox_WaveParameters.Controls.Add(this.radioButton_Gaussian);
            this.groupBox_WaveParameters.Controls.Add(this.radioButton_TriangleWave);
            this.groupBox_WaveParameters.Controls.Add(this.button_GenerateWave);
            this.groupBox_WaveParameters.Controls.Add(this.radioButton_SquareWave);
            this.groupBox_WaveParameters.Controls.Add(this.radioButton_SineWave);
            this.groupBox_WaveParameters.Controls.Add(this.textBox_Phase);
            this.groupBox_WaveParameters.Controls.Add(this.label_Phase);
            this.groupBox_WaveParameters.Controls.Add(this.textBox_Period);
            this.groupBox_WaveParameters.Controls.Add(this.label_Period);
            this.groupBox_WaveParameters.Controls.Add(this.textBox_Amplitude);
            this.groupBox_WaveParameters.Controls.Add(this.label_Amplitude);
            this.groupBox_WaveParameters.Controls.Add(this.label52);
            this.groupBox_WaveParameters.Controls.Add(this.label53);
            this.groupBox_WaveParameters.Location = new System.Drawing.Point(0, 3);
            this.groupBox_WaveParameters.Name = "groupBox_WaveParameters";
            this.groupBox_WaveParameters.Size = new System.Drawing.Size(511, 168);
            this.groupBox_WaveParameters.TabIndex = 0;
            this.groupBox_WaveParameters.TabStop = false;
            this.groupBox_WaveParameters.Text = "Signal";
            // 
            // textBox_Repetitions
            // 
            this.textBox_Repetitions.Location = new System.Drawing.Point(91, 131);
            this.textBox_Repetitions.Name = "textBox_Repetitions";
            this.textBox_Repetitions.Size = new System.Drawing.Size(51, 20);
            this.textBox_Repetitions.TabIndex = 7;
            this.textBox_Repetitions.Text = "1";
            this.textBox_Repetitions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_AllowOnlyNumericKeys_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 61;
            this.label1.Text = "Pulses to save:";
            // 
            // groupBox_Formula
            // 
            this.groupBox_Formula.Controls.Add(this.pictureBox_Formula);
            this.groupBox_Formula.Location = new System.Drawing.Point(162, 37);
            this.groupBox_Formula.Name = "groupBox_Formula";
            this.groupBox_Formula.Size = new System.Drawing.Size(343, 85);
            this.groupBox_Formula.TabIndex = 60;
            this.groupBox_Formula.TabStop = false;
            this.groupBox_Formula.Text = "Formula";
            // 
            // pictureBox_Formula
            // 
            this.pictureBox_Formula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox_Formula.Image = global::Digital_Pulse_Generator.Properties.Resources.GaussianPulse;
            this.pictureBox_Formula.Location = new System.Drawing.Point(4, 15);
            this.pictureBox_Formula.Name = "pictureBox_Formula";
            this.pictureBox_Formula.Size = new System.Drawing.Size(335, 62);
            this.pictureBox_Formula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_Formula.TabIndex = 59;
            this.pictureBox_Formula.TabStop = false;
            // 
            // radioButton_Gaussian
            // 
            this.radioButton_Gaussian.AutoSize = true;
            this.radioButton_Gaussian.Location = new System.Drawing.Point(166, 15);
            this.radioButton_Gaussian.Name = "radioButton_Gaussian";
            this.radioButton_Gaussian.Size = new System.Drawing.Size(69, 17);
            this.radioButton_Gaussian.TabIndex = 0;
            this.radioButton_Gaussian.Text = "Gaussian";
            this.radioButton_Gaussian.UseVisualStyleBackColor = true;
            this.radioButton_Gaussian.CheckedChanged += new System.EventHandler(this.radioButtonWaveType_CheckedChanged);
            // 
            // radioButton_TriangleWave
            // 
            this.radioButton_TriangleWave.AutoSize = true;
            this.radioButton_TriangleWave.Location = new System.Drawing.Point(370, 14);
            this.radioButton_TriangleWave.Name = "radioButton_TriangleWave";
            this.radioButton_TriangleWave.Size = new System.Drawing.Size(63, 17);
            this.radioButton_TriangleWave.TabIndex = 3;
            this.radioButton_TriangleWave.Text = "Triangle";
            this.radioButton_TriangleWave.UseVisualStyleBackColor = true;
            this.radioButton_TriangleWave.CheckedChanged += new System.EventHandler(this.radioButtonWaveType_CheckedChanged);
            // 
            // radioButton_SquareWave
            // 
            this.radioButton_SquareWave.AutoSize = true;
            this.radioButton_SquareWave.Location = new System.Drawing.Point(301, 14);
            this.radioButton_SquareWave.Name = "radioButton_SquareWave";
            this.radioButton_SquareWave.Size = new System.Drawing.Size(59, 17);
            this.radioButton_SquareWave.TabIndex = 2;
            this.radioButton_SquareWave.Text = "Square";
            this.radioButton_SquareWave.UseVisualStyleBackColor = true;
            this.radioButton_SquareWave.CheckedChanged += new System.EventHandler(this.radioButtonWaveType_CheckedChanged);
            // 
            // radioButton_SineWave
            // 
            this.radioButton_SineWave.AutoSize = true;
            this.radioButton_SineWave.Location = new System.Drawing.Point(245, 14);
            this.radioButton_SineWave.Name = "radioButton_SineWave";
            this.radioButton_SineWave.Size = new System.Drawing.Size(46, 17);
            this.radioButton_SineWave.TabIndex = 1;
            this.radioButton_SineWave.Text = "Sine";
            this.radioButton_SineWave.UseVisualStyleBackColor = true;
            this.radioButton_SineWave.CheckedChanged += new System.EventHandler(this.radioButtonWaveType_CheckedChanged);
            // 
            // textBox_Phase
            // 
            this.textBox_Phase.Location = new System.Drawing.Point(91, 101);
            this.textBox_Phase.Name = "textBox_Phase";
            this.textBox_Phase.Size = new System.Drawing.Size(51, 20);
            this.textBox_Phase.TabIndex = 6;
            this.textBox_Phase.Text = "0";
            this.textBox_Phase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_AllowOnlyNumericKeys_KeyPress);
            // 
            // label_Phase
            // 
            this.label_Phase.AutoSize = true;
            this.label_Phase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Phase.Location = new System.Drawing.Point(76, 102);
            this.label_Phase.Name = "label_Phase";
            this.label_Phase.Size = new System.Drawing.Size(18, 16);
            this.label_Phase.TabIndex = 49;
            this.label_Phase.Text = "c:";
            // 
            // textBox_Period
            // 
            this.textBox_Period.Location = new System.Drawing.Point(91, 71);
            this.textBox_Period.Name = "textBox_Period";
            this.textBox_Period.Size = new System.Drawing.Size(51, 20);
            this.textBox_Period.TabIndex = 5;
            this.textBox_Period.Text = "10000";
            this.textBox_Period.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_AllowOnlyNumericKeys_KeyPress);
            // 
            // label_Period
            // 
            this.label_Period.AutoSize = true;
            this.label_Period.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Period.Location = new System.Drawing.Point(12, 72);
            this.label_Period.Name = "label_Period";
            this.label_Period.Size = new System.Drawing.Size(82, 16);
            this.label_Period.TabIndex = 48;
            this.label_Period.Text = "½ Period (b):";
            // 
            // textBox_Amplitude
            // 
            this.textBox_Amplitude.Location = new System.Drawing.Point(91, 41);
            this.textBox_Amplitude.Name = "textBox_Amplitude";
            this.textBox_Amplitude.Size = new System.Drawing.Size(51, 20);
            this.textBox_Amplitude.TabIndex = 4;
            this.textBox_Amplitude.Text = "1";
            this.textBox_Amplitude.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_AllowOnlyNumericKeys_KeyPress);
            // 
            // label_Amplitude
            // 
            this.label_Amplitude.AutoSize = true;
            this.label_Amplitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Amplitude.Location = new System.Drawing.Point(4, 43);
            this.label_Amplitude.Name = "label_Amplitude";
            this.label_Amplitude.Size = new System.Drawing.Size(90, 16);
            this.label_Amplitude.TabIndex = 47;
            this.label_Amplitude.Text = "Amplitude (a):";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(142, 74);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(18, 13);
            this.label52.TabIndex = 50;
            this.label52.Text = "ns";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(142, 46);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(14, 13);
            this.label53.TabIndex = 51;
            this.label53.Text = "V";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File,
            this.toolStripMenuItem_Edit,
            this.ToolStripMenuItemGraph,
            this.toolStripMenuItem_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1004, 24);
            this.menuStrip1.TabIndex = 34;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_FileOpenDigital,
            this.toolStripMenuItem_FileSaveDigital,
            this.toolStripMenuItem1,
            this.toolStripMenuItem_FileOpenAnalog,
            this.toolStripMenuItem_FileSaveAnalog,
            this.toolStripSeparator2,
            this.toolStripMenuItem_FileExit});
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem_File.Text = "&File";
            // 
            // ToolStripMenuItem_FileOpenDigital
            // 
            this.ToolStripMenuItem_FileOpenDigital.Image = global::Digital_Pulse_Generator.Properties.Resources.open;
            this.ToolStripMenuItem_FileOpenDigital.Name = "ToolStripMenuItem_FileOpenDigital";
            this.ToolStripMenuItem_FileOpenDigital.Size = new System.Drawing.Size(144, 22);
            this.ToolStripMenuItem_FileOpenDigital.Text = "Open Digital";
            this.ToolStripMenuItem_FileOpenDigital.Click += new System.EventHandler(this.ToolStripMenuItem_FileOpenDigital_Click);
            // 
            // toolStripMenuItem_FileSaveDigital
            // 
            this.toolStripMenuItem_FileSaveDigital.Image = global::Digital_Pulse_Generator.Properties.Resources.save;
            this.toolStripMenuItem_FileSaveDigital.Name = "toolStripMenuItem_FileSaveDigital";
            this.toolStripMenuItem_FileSaveDigital.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_FileSaveDigital.Text = "Save Digital";
            this.toolStripMenuItem_FileSaveDigital.Click += new System.EventHandler(this.toolStripMenuItem_FileSaveDigital_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripMenuItem_FileOpenAnalog
            // 
            this.toolStripMenuItem_FileOpenAnalog.Image = global::Digital_Pulse_Generator.Properties.Resources.open;
            this.toolStripMenuItem_FileOpenAnalog.Name = "toolStripMenuItem_FileOpenAnalog";
            this.toolStripMenuItem_FileOpenAnalog.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_FileOpenAnalog.Text = "Open Analog";
            this.toolStripMenuItem_FileOpenAnalog.Click += new System.EventHandler(this.toolStripMenuItem_FileOpenAnalog_Click);
            // 
            // toolStripMenuItem_FileSaveAnalog
            // 
            this.toolStripMenuItem_FileSaveAnalog.Image = global::Digital_Pulse_Generator.Properties.Resources.save;
            this.toolStripMenuItem_FileSaveAnalog.Name = "toolStripMenuItem_FileSaveAnalog";
            this.toolStripMenuItem_FileSaveAnalog.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_FileSaveAnalog.Text = "Save Analog";
            this.toolStripMenuItem_FileSaveAnalog.Click += new System.EventHandler(this.toolStripMenuItem_FileSaveAnalog_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripMenuItem_FileExit
            // 
            this.toolStripMenuItem_FileExit.Image = global::Digital_Pulse_Generator.Properties.Resources.exit;
            this.toolStripMenuItem_FileExit.Name = "toolStripMenuItem_FileExit";
            this.toolStripMenuItem_FileExit.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_FileExit.Text = "E&xit";
            this.toolStripMenuItem_FileExit.Click += new System.EventHandler(this.toolStripMenuItem_FileExit_Click);
            // 
            // toolStripMenuItem_Edit
            // 
            this.toolStripMenuItem_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_EditUndo,
            this.toolStripSeparator3,
            this.toolStripMenuItem_EditCut,
            this.toolStripMenuItem_EditCopy,
            this.toolStripMenuItem_EditPaste,
            this.toolStripSeparator4,
            this.toolStripMenuItem_EditSelectAll});
            this.toolStripMenuItem_Edit.Name = "toolStripMenuItem_Edit";
            this.toolStripMenuItem_Edit.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItem_Edit.Text = "&Edit";
            this.toolStripMenuItem_Edit.Click += new System.EventHandler(this.toolStripMenuItem_Edit_Click);
            // 
            // toolStripMenuItem_EditUndo
            // 
            this.toolStripMenuItem_EditUndo.Name = "toolStripMenuItem_EditUndo";
            this.toolStripMenuItem_EditUndo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.toolStripMenuItem_EditUndo.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_EditUndo.Text = "&Undo";
            this.toolStripMenuItem_EditUndo.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripMenuItem_EditCut
            // 
            this.toolStripMenuItem_EditCut.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_EditCut.Image")));
            this.toolStripMenuItem_EditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_EditCut.Name = "toolStripMenuItem_EditCut";
            this.toolStripMenuItem_EditCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.toolStripMenuItem_EditCut.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_EditCut.Text = "Cu&t";
            this.toolStripMenuItem_EditCut.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_EditCopy
            // 
            this.toolStripMenuItem_EditCopy.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_EditCopy.Image")));
            this.toolStripMenuItem_EditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_EditCopy.Name = "toolStripMenuItem_EditCopy";
            this.toolStripMenuItem_EditCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.toolStripMenuItem_EditCopy.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_EditCopy.Text = "&Copy";
            this.toolStripMenuItem_EditCopy.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripMenuItem_EditPaste
            // 
            this.toolStripMenuItem_EditPaste.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem_EditPaste.Image")));
            this.toolStripMenuItem_EditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_EditPaste.Name = "toolStripMenuItem_EditPaste";
            this.toolStripMenuItem_EditPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.toolStripMenuItem_EditPaste.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_EditPaste.Text = "&Paste";
            this.toolStripMenuItem_EditPaste.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripMenuItem_EditSelectAll
            // 
            this.toolStripMenuItem_EditSelectAll.Name = "toolStripMenuItem_EditSelectAll";
            this.toolStripMenuItem_EditSelectAll.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_EditSelectAll.Text = "Select &All";
            this.toolStripMenuItem_EditSelectAll.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // ToolStripMenuItemGraph
            // 
            this.ToolStripMenuItemGraph.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_GraphShowGrid,
            this.toolStripMenuItem_GraphResetZoom,
            this.toolStripMenuItem_GraphClearGraph});
            this.ToolStripMenuItemGraph.Name = "ToolStripMenuItemGraph";
            this.ToolStripMenuItemGraph.Size = new System.Drawing.Size(51, 20);
            this.ToolStripMenuItemGraph.Text = "Graph";
            // 
            // toolStripMenuItem_GraphShowGrid
            // 
            this.toolStripMenuItem_GraphShowGrid.CheckOnClick = true;
            this.toolStripMenuItem_GraphShowGrid.Name = "toolStripMenuItem_GraphShowGrid";
            this.toolStripMenuItem_GraphShowGrid.Size = new System.Drawing.Size(137, 22);
            this.toolStripMenuItem_GraphShowGrid.Text = "Show Grid";
            this.toolStripMenuItem_GraphShowGrid.CheckedChanged += new System.EventHandler(this.toolStripMenuItem_GraphShowGrid_CheckedChanged);
            // 
            // toolStripMenuItem_GraphResetZoom
            // 
            this.toolStripMenuItem_GraphResetZoom.Name = "toolStripMenuItem_GraphResetZoom";
            this.toolStripMenuItem_GraphResetZoom.Size = new System.Drawing.Size(137, 22);
            this.toolStripMenuItem_GraphResetZoom.Text = "Reset Zoom";
            this.toolStripMenuItem_GraphResetZoom.Click += new System.EventHandler(this.reset_zoom_button_Click);
            // 
            // toolStripMenuItem_GraphClearGraph
            // 
            this.toolStripMenuItem_GraphClearGraph.Name = "toolStripMenuItem_GraphClearGraph";
            this.toolStripMenuItem_GraphClearGraph.Size = new System.Drawing.Size(137, 22);
            this.toolStripMenuItem_GraphClearGraph.Text = "Clear Graph";
            this.toolStripMenuItem_GraphClearGraph.Click += new System.EventHandler(this.clear_graph_button_Click);
            // 
            // toolStripMenuItem_Help
            // 
            this.toolStripMenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_HelpAbout});
            this.toolStripMenuItem_Help.Name = "toolStripMenuItem_Help";
            this.toolStripMenuItem_Help.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem_Help.Text = "&Help";
            // 
            // toolStripMenuItem_HelpAbout
            // 
            this.toolStripMenuItem_HelpAbout.Name = "toolStripMenuItem_HelpAbout";
            this.toolStripMenuItem_HelpAbout.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_HelpAbout.Text = "&About...";
            this.toolStripMenuItem_HelpAbout.Click += new System.EventHandler(this.toolStripMenuItem_HelpAbout_Click);
            // 
            // textBox_Frequency
            // 
            this.textBox_Frequency.Location = new System.Drawing.Point(83, 106);
            this.textBox_Frequency.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.textBox_Frequency.Name = "textBox_Frequency";
            this.textBox_Frequency.ShowUpDownButtons = true;
            this.textBox_Frequency.Size = new System.Drawing.Size(73, 20);
            this.textBox_Frequency.TabIndex = 4;
            this.textBox_Frequency.ValueChanged += new System.EventHandler(this.frequency_TextChanged);
            this.textBox_Frequency.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frequency_KeyUp);
            // 
            // Pulse_Generator
            // 
            this.AcceptButton = this.button_GenerateWave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 797);
            this.Controls.Add(this.panel_PulseControls);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.zedGraphControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1020, 835);
            this.Name = "Pulse_Generator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pulse Generator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Pulse_Generator_FormClosed);
            this.groupBox_AnalogToDigitalSettings.ResumeLayout(false);
            this.groupBox_AnalogToDigitalSettings.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel_PulseControls.ResumeLayout(false);
            this.groupBox_WaveParameters.ResumeLayout(false);
            this.groupBox_WaveParameters.PerformLayout();
            this.groupBox_Formula.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Formula)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox_Frequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusXY;
        private System.Windows.Forms.Button button_GenerateWave;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox_AnalogToDigitalSettings;
        private System.Windows.Forms.TextBox textBox_ADReferenceHigh;
        private System.Windows.Forms.Label ad_voltage_label;
        private System.Windows.Forms.TextBox ad_bits_textbox;
        private System.Windows.Forms.Label ad_bits_label;
        private System.Windows.Forms.Label mhz_label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox period_text;
        private System.Windows.Forms.Label period_label;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox textBox_PulseInformation;
        private System.Windows.Forms.Panel panel_PulseControls;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_FileSaveDigital;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_FileExit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Edit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditCut;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditCopy;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditSelectAll;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_HelpAbout;
        private NumerUpDownEx textBox_Frequency;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox_SquarePhase;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox textBox_TrianglePhase;
        private System.Windows.Forms.TextBox textBox_TrianglePeriod;
        private System.Windows.Forms.TextBox textBox_TriangleAmplitude;
        private System.Windows.Forms.GroupBox groupBox_WaveParameters;
        private System.Windows.Forms.RadioButton radioButton_TriangleWave;
        private System.Windows.Forms.RadioButton radioButton_SquareWave;
        private System.Windows.Forms.RadioButton radioButton_SineWave;
        private System.Windows.Forms.TextBox textBox_Phase;
        private System.Windows.Forms.Label label_Phase;
        private System.Windows.Forms.TextBox textBox_Period;
        private System.Windows.Forms.Label label_Period;
        private System.Windows.Forms.Label label_Amplitude;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.RadioButton radioButton_Gaussian;
        private System.Windows.Forms.TextBox textBox_Amplitude;
        private System.Windows.Forms.GroupBox groupBox_Formula;
        private System.Windows.Forms.PictureBox pictureBox_Formula;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditUndo;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemGraph;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_GraphShowGrid;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_GraphResetZoom;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_GraphClearGraph;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_FileOpenDigital;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_FileSaveAnalog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_FileOpenAnalog;
        private System.Windows.Forms.TextBox textBox_Repetitions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ADReferenceLow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton_PulseInfoDigital;
        private System.Windows.Forms.RadioButton radioButton_PulseInfoAnalog;
    }
}

