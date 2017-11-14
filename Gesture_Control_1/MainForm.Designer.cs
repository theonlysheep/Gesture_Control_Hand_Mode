namespace streams.cs
{
    partial class MainForm
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
            renders[0].Dispose();
            renders[1].Dispose();

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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.deviceMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.streamModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.live = new System.Windows.Forms.ToolStripMenuItem();
            this.play = new System.Windows.Forms.ToolStripMenuItem();
            this.record = new System.Windows.Forms.ToolStripMenuItem();
            this.rgbImage = new System.Windows.Forms.PictureBox();
            this.depthImage = new System.Windows.Forms.PictureBox();
            this.resultImage = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radioIR = new System.Windows.Forms.RadioButton();
            this.radioDepth = new System.Windows.Forms.RadioButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.gestureListBox = new System.Windows.Forms.CheckedListBox();
            this.fingerStatusTable = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelThumbLeft = new System.Windows.Forms.Label();
            this.labelThumbRight = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelIndexLeft = new System.Windows.Forms.Label();
            this.labelIndexRight = new System.Windows.Forms.Label();
            this.labelMiddleLeft = new System.Windows.Forms.Label();
            this.labelMiddleRight = new System.Windows.Forms.Label();
            this.labelRingLeft = new System.Windows.Forms.Label();
            this.labelRingRight = new System.Windows.Forms.Label();
            this.labelPinkyRight = new System.Windows.Forms.Label();
            this.labelPinkyLeft = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.stabilizer = new System.Windows.Forms.CheckBox();
            this.defualtCameraSettingsButton = new System.Windows.Forms.Button();
            this.defaultGestureSettingsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.laserPower = new System.Windows.Forms.NumericUpDown();
            this.filterOption = new System.Windows.Forms.NumericUpDown();
            this.motionRangeTradeoff = new System.Windows.Forms.NumericUpDown();
            this.depthConfidence = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.jointSpeed = new System.Windows.Forms.NumericUpDown();
            this.smoothingValue = new System.Windows.Forms.NumericUpDown();
            this.jointSpeedlabel = new System.Windows.Forms.Label();
            this.smoothingValueLabel = new System.Windows.Forms.Label();
            this.maxFoldnessFactor = new System.Windows.Forms.NumericUpDown();
            this.minExtendedFactor = new System.Windows.Forms.NumericUpDown();
            this.maxFoldnessFactorLabel = new System.Windows.Forms.Label();
            this.minExtendedFactorLabel = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.nearTrackingDistance = new System.Windows.Forms.NumericUpDown();
            this.farTrackingDistance = new System.Windows.Forms.NumericUpDown();
            this.nearTrackingWidth = new System.Windows.Forms.NumericUpDown();
            this.farTrackingHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.label21 = new System.Windows.Forms.Label();
            this.indexFingerDetailsTable = new System.Windows.Forms.TableLayoutPanel();
            this.label22 = new System.Windows.Forms.Label();
            this.indexSpeedYLabel = new System.Windows.Forms.Label();
            this.indexSpeedZLabel = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.indexSpeedXLabel = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.indexPositionXLabel = new System.Windows.Forms.Label();
            this.indexPositionYLabel = new System.Windows.Forms.Label();
            this.indexPositionZLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.fingerStatusTable.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laserPower)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionRangeTradeoff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthConfidence)).BeginInit();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jointSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.smoothingValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFoldnessFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minExtendedFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nearTrackingDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.farTrackingDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nearTrackingWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.farTrackingHeight)).BeginInit();
            this.tableLayoutPanel10.SuspendLayout();
            this.indexFingerDetailsTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceMenu,
            this.streamModeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(977, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // deviceMenu
            // 
            this.deviceMenu.Name = "deviceMenu";
            this.deviceMenu.Size = new System.Drawing.Size(54, 20);
            this.deviceMenu.Text = "Device";
            // 
            // streamModeToolStripMenuItem
            // 
            this.streamModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.live,
            this.play,
            this.record});
            this.streamModeToolStripMenuItem.Name = "streamModeToolStripMenuItem";
            this.streamModeToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.streamModeToolStripMenuItem.Text = "Stream Mode";
            // 
            // live
            // 
            this.live.Checked = true;
            this.live.CheckState = System.Windows.Forms.CheckState.Checked;
            this.live.Name = "live";
            this.live.Size = new System.Drawing.Size(146, 22);
            this.live.Text = "Live";
            this.live.Click += new System.EventHandler(this.liveToolStripMenuItem_Click);
            // 
            // play
            // 
            this.play.Name = "play";
            this.play.Size = new System.Drawing.Size(146, 22);
            this.play.Text = "Play from File";
            this.play.Click += new System.EventHandler(this.playFromFileToolStripMenuItem_Click);
            // 
            // record
            // 
            this.record.Name = "record";
            this.record.Size = new System.Drawing.Size(146, 22);
            this.record.Text = "Record File";
            this.record.Click += new System.EventHandler(this.recordFileToolStripMenuItem_Click);
            // 
            // rgbImage
            // 
            this.rgbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgbImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rgbImage.Location = new System.Drawing.Point(3, 3);
            this.rgbImage.Name = "rgbImage";
            this.rgbImage.Size = new System.Drawing.Size(313, 259);
            this.rgbImage.TabIndex = 1;
            this.rgbImage.TabStop = false;
            // 
            // depthImage
            // 
            this.depthImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.depthImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.depthImage.Location = new System.Drawing.Point(322, 3);
            this.depthImage.Name = "depthImage";
            this.depthImage.Size = new System.Drawing.Size(313, 259);
            this.depthImage.TabIndex = 2;
            this.depthImage.TabStop = false;
            // 
            // resultImage
            // 
            this.resultImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultImage.Location = new System.Drawing.Point(641, 3);
            this.resultImage.Name = "resultImage";
            this.resultImage.Size = new System.Drawing.Size(315, 259);
            this.resultImage.TabIndex = 3;
            this.resultImage.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonStart, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonStop, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(786, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(170, 27);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(3, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(79, 21);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(88, 3);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(79, 21);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.radioIR, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioDepth, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(587, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(174, 27);
            this.tableLayoutPanel3.TabIndex = 10;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
            // 
            // radioIR
            // 
            this.radioIR.AutoSize = true;
            this.radioIR.Location = new System.Drawing.Point(90, 3);
            this.radioIR.Name = "radioIR";
            this.radioIR.Size = new System.Drawing.Size(36, 17);
            this.radioIR.TabIndex = 1;
            this.radioIR.TabStop = true;
            this.radioIR.Text = "IR";
            this.radioIR.UseVisualStyleBackColor = true;
            // 
            // radioDepth
            // 
            this.radioDepth.AutoSize = true;
            this.radioDepth.Location = new System.Drawing.Point(3, 3);
            this.radioDepth.Name = "radioDepth";
            this.radioDepth.Size = new System.Drawing.Size(54, 17);
            this.radioDepth.TabIndex = 2;
            this.radioDepth.TabStop = true;
            this.radioDepth.Text = "Depth";
            this.radioDepth.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 597);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(977, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel
            // 
            this.statusStripLabel.Name = "statusStripLabel";
            this.statusStripLabel.Size = new System.Drawing.Size(39, 17);
            this.statusStripLabel.Text = "Ready";
            this.statusStripLabel.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.depthImage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.resultImage, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.rgbImage, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(959, 265);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(762, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Finger felxation Status";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Status Output ";
            // 
            // messageBox
            // 
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBox.Location = new System.Drawing.Point(3, 18);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(453, 101);
            this.messageBox.TabIndex = 4;
            this.messageBox.Text = "";
            // 
            // gestureListBox
            // 
            this.gestureListBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.gestureListBox.FormattingEnabled = true;
            this.gestureListBox.Location = new System.Drawing.Point(462, 21);
            this.gestureListBox.Name = "gestureListBox";
            this.gestureListBox.Size = new System.Drawing.Size(144, 94);
            this.gestureListBox.TabIndex = 13;
            this.gestureListBox.Visible = false;
            this.gestureListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.gestureListBox_ItemCheck);
            // 
            // fingerStatusTable
            // 
            this.fingerStatusTable.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.fingerStatusTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.fingerStatusTable.ColumnCount = 3;
            this.fingerStatusTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.fingerStatusTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.fingerStatusTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.fingerStatusTable.Controls.Add(this.label2, 1, 0);
            this.fingerStatusTable.Controls.Add(this.label3, 2, 0);
            this.fingerStatusTable.Controls.Add(this.label4, 0, 1);
            this.fingerStatusTable.Controls.Add(this.labelThumbLeft, 1, 1);
            this.fingerStatusTable.Controls.Add(this.labelThumbRight, 2, 1);
            this.fingerStatusTable.Controls.Add(this.label7, 0, 2);
            this.fingerStatusTable.Controls.Add(this.labelIndexLeft, 1, 2);
            this.fingerStatusTable.Controls.Add(this.labelIndexRight, 2, 2);
            this.fingerStatusTable.Controls.Add(this.labelMiddleLeft, 1, 3);
            this.fingerStatusTable.Controls.Add(this.labelMiddleRight, 2, 3);
            this.fingerStatusTable.Controls.Add(this.labelRingLeft, 1, 4);
            this.fingerStatusTable.Controls.Add(this.labelRingRight, 2, 4);
            this.fingerStatusTable.Controls.Add(this.labelPinkyRight, 2, 5);
            this.fingerStatusTable.Controls.Add(this.labelPinkyLeft, 1, 5);
            this.fingerStatusTable.Controls.Add(this.label16, 0, 3);
            this.fingerStatusTable.Controls.Add(this.label17, 0, 4);
            this.fingerStatusTable.Controls.Add(this.label18, 0, 5);
            this.fingerStatusTable.Location = new System.Drawing.Point(762, 18);
            this.fingerStatusTable.Name = "fingerStatusTable";
            this.fingerStatusTable.RowCount = 6;
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.Size = new System.Drawing.Size(194, 101);
            this.fingerStatusTable.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Left";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Right ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thumb";
            // 
            // labelThumbLeft
            // 
            this.labelThumbLeft.AutoSize = true;
            this.labelThumbLeft.Location = new System.Drawing.Point(68, 17);
            this.labelThumbLeft.Name = "labelThumbLeft";
            this.labelThumbLeft.Size = new System.Drawing.Size(10, 13);
            this.labelThumbLeft.TabIndex = 3;
            this.labelThumbLeft.Text = "-";
            // 
            // labelThumbRight
            // 
            this.labelThumbRight.AutoSize = true;
            this.labelThumbRight.Location = new System.Drawing.Point(132, 17);
            this.labelThumbRight.Name = "labelThumbRight";
            this.labelThumbRight.Size = new System.Drawing.Size(10, 13);
            this.labelThumbRight.TabIndex = 4;
            this.labelThumbRight.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Index";
            // 
            // labelIndexLeft
            // 
            this.labelIndexLeft.AutoSize = true;
            this.labelIndexLeft.Location = new System.Drawing.Point(68, 33);
            this.labelIndexLeft.Name = "labelIndexLeft";
            this.labelIndexLeft.Size = new System.Drawing.Size(10, 13);
            this.labelIndexLeft.TabIndex = 6;
            this.labelIndexLeft.Text = "-";
            // 
            // labelIndexRight
            // 
            this.labelIndexRight.AutoSize = true;
            this.labelIndexRight.Location = new System.Drawing.Point(132, 33);
            this.labelIndexRight.Name = "labelIndexRight";
            this.labelIndexRight.Size = new System.Drawing.Size(10, 13);
            this.labelIndexRight.TabIndex = 7;
            this.labelIndexRight.Text = "-";
            // 
            // labelMiddleLeft
            // 
            this.labelMiddleLeft.AutoSize = true;
            this.labelMiddleLeft.Location = new System.Drawing.Point(68, 49);
            this.labelMiddleLeft.Name = "labelMiddleLeft";
            this.labelMiddleLeft.Size = new System.Drawing.Size(10, 13);
            this.labelMiddleLeft.TabIndex = 8;
            this.labelMiddleLeft.Text = "-";
            // 
            // labelMiddleRight
            // 
            this.labelMiddleRight.AutoSize = true;
            this.labelMiddleRight.Location = new System.Drawing.Point(132, 49);
            this.labelMiddleRight.Name = "labelMiddleRight";
            this.labelMiddleRight.Size = new System.Drawing.Size(10, 13);
            this.labelMiddleRight.TabIndex = 9;
            this.labelMiddleRight.Text = "-";
            // 
            // labelRingLeft
            // 
            this.labelRingLeft.AutoSize = true;
            this.labelRingLeft.Location = new System.Drawing.Point(68, 65);
            this.labelRingLeft.Name = "labelRingLeft";
            this.labelRingLeft.Size = new System.Drawing.Size(10, 13);
            this.labelRingLeft.TabIndex = 10;
            this.labelRingLeft.Text = "-";
            // 
            // labelRingRight
            // 
            this.labelRingRight.AutoSize = true;
            this.labelRingRight.Location = new System.Drawing.Point(132, 65);
            this.labelRingRight.Name = "labelRingRight";
            this.labelRingRight.Size = new System.Drawing.Size(10, 13);
            this.labelRingRight.TabIndex = 11;
            this.labelRingRight.Text = "-";
            // 
            // labelPinkyRight
            // 
            this.labelPinkyRight.AutoSize = true;
            this.labelPinkyRight.Location = new System.Drawing.Point(132, 81);
            this.labelPinkyRight.Name = "labelPinkyRight";
            this.labelPinkyRight.Size = new System.Drawing.Size(10, 13);
            this.labelPinkyRight.TabIndex = 12;
            this.labelPinkyRight.Text = "-";
            // 
            // labelPinkyLeft
            // 
            this.labelPinkyLeft.AutoSize = true;
            this.labelPinkyLeft.Location = new System.Drawing.Point(68, 81);
            this.labelPinkyLeft.Name = "labelPinkyLeft";
            this.labelPinkyLeft.Size = new System.Drawing.Size(10, 13);
            this.labelPinkyLeft.TabIndex = 13;
            this.labelPinkyLeft.Text = "-";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Middle";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 65);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Ring";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 81);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Pinky";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(462, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Gesture Selection";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel10, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel9, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(965, 567);
            this.tableLayoutPanel4.TabIndex = 15;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel9.ColumnCount = 5;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel2, 4, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel3, 3, 0);
            this.tableLayoutPanel9.Controls.Add(this.stabilizer, 2, 0);
            this.tableLayoutPanel9.Controls.Add(this.defualtCameraSettingsButton, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.defaultGestureSettingsButton, 1, 0);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 531);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(959, 33);
            this.tableLayoutPanel9.TabIndex = 16;
            // 
            // stabilizer
            // 
            this.stabilizer.AutoSize = true;
            this.stabilizer.Checked = true;
            this.stabilizer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stabilizer.Location = new System.Drawing.Point(385, 3);
            this.stabilizer.Name = "stabilizer";
            this.stabilizer.Size = new System.Drawing.Size(68, 17);
            this.stabilizer.TabIndex = 4;
            this.stabilizer.Text = "Stabilizer";
            this.stabilizer.UseVisualStyleBackColor = true;
            this.stabilizer.CheckedChanged += new System.EventHandler(this.handModuleSettingsChangedHandler);
            // 
            // defualtCameraSettingsButton
            // 
            this.defualtCameraSettingsButton.Location = new System.Drawing.Point(3, 3);
            this.defualtCameraSettingsButton.Name = "defualtCameraSettingsButton";
            this.defualtCameraSettingsButton.Size = new System.Drawing.Size(140, 23);
            this.defualtCameraSettingsButton.TabIndex = 11;
            this.defualtCameraSettingsButton.Text = "Default Camera Settings";
            this.defualtCameraSettingsButton.UseVisualStyleBackColor = true;
            this.defualtCameraSettingsButton.Click += new System.EventHandler(this.defualtCameraSettingsButton_Click);
            // 
            // defaultGestureSettingsButton
            // 
            this.defaultGestureSettingsButton.Location = new System.Drawing.Point(194, 3);
            this.defaultGestureSettingsButton.Name = "defaultGestureSettingsButton";
            this.defaultGestureSettingsButton.Size = new System.Drawing.Size(140, 23);
            this.defaultGestureSettingsButton.TabIndex = 12;
            this.defaultGestureSettingsButton.Text = "Default Gesture Settings";
            this.defaultGestureSettingsButton.UseVisualStyleBackColor = true;
            this.defaultGestureSettingsButton.Click += new System.EventHandler(this.defaultHandModuleSettingsButton_Click);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel8, 1, 1);
            this.tableLayoutPanel6.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 402);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.76471F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.23529F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(959, 122);
            this.tableLayoutPanel6.TabIndex = 16;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.Controls.Add(this.laserPower, 1, 0);
            this.tableLayoutPanel7.Controls.Add(this.filterOption, 1, 1);
            this.tableLayoutPanel7.Controls.Add(this.motionRangeTradeoff, 1, 2);
            this.tableLayoutPanel7.Controls.Add(this.depthConfidence, 1, 3);
            this.tableLayoutPanel7.Controls.Add(this.label10, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.label13, 0, 3);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 4;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(313, 99);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // laserPower
            // 
            this.laserPower.Location = new System.Drawing.Point(159, 3);
            this.laserPower.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.laserPower.Name = "laserPower";
            this.laserPower.Size = new System.Drawing.Size(120, 20);
            this.laserPower.TabIndex = 0;
            this.laserPower.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.laserPower.ValueChanged += new System.EventHandler(this.cameraSettingsChangedHandler);
            // 
            // filterOption
            // 
            this.filterOption.Location = new System.Drawing.Point(159, 27);
            this.filterOption.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.filterOption.Name = "filterOption";
            this.filterOption.Size = new System.Drawing.Size(120, 20);
            this.filterOption.TabIndex = 1;
            this.filterOption.ValueChanged += new System.EventHandler(this.cameraSettingsChangedHandler);
            // 
            // motionRangeTradeoff
            // 
            this.motionRangeTradeoff.Location = new System.Drawing.Point(159, 51);
            this.motionRangeTradeoff.Name = "motionRangeTradeoff";
            this.motionRangeTradeoff.Size = new System.Drawing.Size(120, 20);
            this.motionRangeTradeoff.TabIndex = 2;
            this.motionRangeTradeoff.ValueChanged += new System.EventHandler(this.cameraSettingsChangedHandler);
            // 
            // depthConfidence
            // 
            this.depthConfidence.Location = new System.Drawing.Point(159, 75);
            this.depthConfidence.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.depthConfidence.Name = "depthConfidence";
            this.depthConfidence.Size = new System.Drawing.Size(120, 20);
            this.depthConfidence.TabIndex = 3;
            this.depthConfidence.ValueChanged += new System.EventHandler(this.cameraSettingsChangedHandler);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Laser Power:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Filter Option:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(128, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Motion / Range Tradeoff:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(96, 26);
            this.label13.TabIndex = 7;
            this.label13.Text = "Depth Confidence Threshould:";
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 4;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.Controls.Add(this.jointSpeed, 1, 0);
            this.tableLayoutPanel8.Controls.Add(this.smoothingValue, 1, 1);
            this.tableLayoutPanel8.Controls.Add(this.jointSpeedlabel, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.smoothingValueLabel, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.maxFoldnessFactor, 1, 2);
            this.tableLayoutPanel8.Controls.Add(this.minExtendedFactor, 1, 3);
            this.tableLayoutPanel8.Controls.Add(this.maxFoldnessFactorLabel, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.minExtendedFactorLabel, 0, 3);
            this.tableLayoutPanel8.Controls.Add(this.label14, 2, 0);
            this.tableLayoutPanel8.Controls.Add(this.label15, 2, 1);
            this.tableLayoutPanel8.Controls.Add(this.label19, 2, 2);
            this.tableLayoutPanel8.Controls.Add(this.label20, 2, 3);
            this.tableLayoutPanel8.Controls.Add(this.nearTrackingDistance, 3, 0);
            this.tableLayoutPanel8.Controls.Add(this.farTrackingDistance, 3, 1);
            this.tableLayoutPanel8.Controls.Add(this.nearTrackingWidth, 3, 2);
            this.tableLayoutPanel8.Controls.Add(this.farTrackingHeight, 3, 3);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(322, 17);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 4;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(634, 99);
            this.tableLayoutPanel8.TabIndex = 1;
            // 
            // jointSpeed
            // 
            this.jointSpeed.Location = new System.Drawing.Point(161, 3);
            this.jointSpeed.Name = "jointSpeed";
            this.jointSpeed.Size = new System.Drawing.Size(120, 20);
            this.jointSpeed.TabIndex = 0;
            this.jointSpeed.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.jointSpeed.ValueChanged += new System.EventHandler(this.handModuleSettingsChangedHandler);
            // 
            // smoothingValue
            // 
            this.smoothingValue.DecimalPlaces = 1;
            this.smoothingValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.smoothingValue.Location = new System.Drawing.Point(161, 27);
            this.smoothingValue.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.smoothingValue.Name = "smoothingValue";
            this.smoothingValue.Size = new System.Drawing.Size(120, 20);
            this.smoothingValue.TabIndex = 1;
            this.smoothingValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.smoothingValue.ValueChanged += new System.EventHandler(this.handModuleSettingsChangedHandler);
            // 
            // jointSpeedlabel
            // 
            this.jointSpeedlabel.AutoSize = true;
            this.jointSpeedlabel.Location = new System.Drawing.Point(3, 0);
            this.jointSpeedlabel.Name = "jointSpeedlabel";
            this.jointSpeedlabel.Size = new System.Drawing.Size(134, 24);
            this.jointSpeedlabel.TabIndex = 2;
            this.jointSpeedlabel.Text = "Joint Speed avarage Time [ms]:";
            // 
            // smoothingValueLabel
            // 
            this.smoothingValueLabel.AutoSize = true;
            this.smoothingValueLabel.Location = new System.Drawing.Point(3, 24);
            this.smoothingValueLabel.Name = "smoothingValueLabel";
            this.smoothingValueLabel.Size = new System.Drawing.Size(90, 13);
            this.smoothingValueLabel.TabIndex = 3;
            this.smoothingValueLabel.Text = "Smoothing Value:";
            // 
            // maxFoldnessFactor
            // 
            this.maxFoldnessFactor.Location = new System.Drawing.Point(161, 51);
            this.maxFoldnessFactor.Name = "maxFoldnessFactor";
            this.maxFoldnessFactor.Size = new System.Drawing.Size(120, 20);
            this.maxFoldnessFactor.TabIndex = 5;
            this.maxFoldnessFactor.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.maxFoldnessFactor.ValueChanged += new System.EventHandler(this.handModuleSettingsChangedHandler);
            // 
            // minExtendedFactor
            // 
            this.minExtendedFactor.Location = new System.Drawing.Point(161, 75);
            this.minExtendedFactor.Name = "minExtendedFactor";
            this.minExtendedFactor.Size = new System.Drawing.Size(120, 20);
            this.minExtendedFactor.TabIndex = 6;
            this.minExtendedFactor.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.minExtendedFactor.ValueChanged += new System.EventHandler(this.handModuleSettingsChangedHandler);
            // 
            // maxFoldnessFactorLabel
            // 
            this.maxFoldnessFactorLabel.AutoSize = true;
            this.maxFoldnessFactorLabel.Location = new System.Drawing.Point(3, 48);
            this.maxFoldnessFactorLabel.Name = "maxFoldnessFactorLabel";
            this.maxFoldnessFactorLabel.Size = new System.Drawing.Size(105, 13);
            this.maxFoldnessFactorLabel.TabIndex = 7;
            this.maxFoldnessFactorLabel.Text = "Finger Folded Offset:";
            // 
            // minExtendedFactorLabel
            // 
            this.minExtendedFactorLabel.AutoSize = true;
            this.minExtendedFactorLabel.Location = new System.Drawing.Point(3, 72);
            this.minExtendedFactorLabel.Name = "minExtendedFactorLabel";
            this.minExtendedFactorLabel.Size = new System.Drawing.Size(118, 13);
            this.minExtendedFactorLabel.TabIndex = 8;
            this.minExtendedFactorLabel.Text = "Finger Extended Offset:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(319, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(136, 13);
            this.label14.TabIndex = 12;
            this.label14.Text = "Nearest Tracking Dist. [cm]";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(319, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(137, 13);
            this.label15.TabIndex = 13;
            this.label15.Text = "Furthest Tracking Dist. [cm]";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(319, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(143, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Nearest Tracking Width [cm]";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(319, 72);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(147, 13);
            this.label20.TabIndex = 15;
            this.label20.Text = "Furthest Tracking Height [cm]";
            // 
            // nearTrackingDistance
            // 
            this.nearTrackingDistance.Location = new System.Drawing.Point(477, 3);
            this.nearTrackingDistance.Name = "nearTrackingDistance";
            this.nearTrackingDistance.Size = new System.Drawing.Size(120, 20);
            this.nearTrackingDistance.TabIndex = 16;
            this.nearTrackingDistance.ValueChanged += new System.EventHandler(this.handModuleSettingsChangedHandler);
            // 
            // farTrackingDistance
            // 
            this.farTrackingDistance.Location = new System.Drawing.Point(477, 27);
            this.farTrackingDistance.Name = "farTrackingDistance";
            this.farTrackingDistance.Size = new System.Drawing.Size(120, 20);
            this.farTrackingDistance.TabIndex = 17;
            this.farTrackingDistance.ValueChanged += new System.EventHandler(this.handModuleSettingsChangedHandler);
            // 
            // nearTrackingWidth
            // 
            this.nearTrackingWidth.Location = new System.Drawing.Point(477, 51);
            this.nearTrackingWidth.Name = "nearTrackingWidth";
            this.nearTrackingWidth.Size = new System.Drawing.Size(120, 20);
            this.nearTrackingWidth.TabIndex = 18;
            this.nearTrackingWidth.ValueChanged += new System.EventHandler(this.handModuleSettingsChangedHandler);
            // 
            // farTrackingHeight
            // 
            this.farTrackingHeight.Location = new System.Drawing.Point(477, 75);
            this.farTrackingHeight.Name = "farTrackingHeight";
            this.farTrackingHeight.Size = new System.Drawing.Size(120, 20);
            this.farTrackingHeight.TabIndex = 19;
            this.farTrackingHeight.ValueChanged += new System.EventHandler(this.handModuleSettingsChangedHandler);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Camera Settings";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(322, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Gesture Settings";
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 4;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel10.Controls.Add(this.label8, 1, 0);
            this.tableLayoutPanel10.Controls.Add(this.label9, 3, 0);
            this.tableLayoutPanel10.Controls.Add(this.messageBox, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.gestureListBox, 1, 1);
            this.tableLayoutPanel10.Controls.Add(this.label21, 2, 0);
            this.tableLayoutPanel10.Controls.Add(this.fingerStatusTable, 3, 1);
            this.tableLayoutPanel10.Controls.Add(this.indexFingerDetailsTable, 2, 1);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 274);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(959, 122);
            this.tableLayoutPanel10.TabIndex = 16;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(612, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(103, 13);
            this.label21.TabIndex = 20;
            this.label21.Text = "Index Finger Details ";
            // 
            // indexFingerDetailsTable
            // 
            this.indexFingerDetailsTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.indexFingerDetailsTable.ColumnCount = 3;
            this.indexFingerDetailsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.indexFingerDetailsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.indexFingerDetailsTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.indexFingerDetailsTable.Controls.Add(this.label22, 0, 1);
            this.indexFingerDetailsTable.Controls.Add(this.indexSpeedYLabel, 0, 2);
            this.indexFingerDetailsTable.Controls.Add(this.indexSpeedZLabel, 0, 3);
            this.indexFingerDetailsTable.Controls.Add(this.label25, 1, 0);
            this.indexFingerDetailsTable.Controls.Add(this.label26, 2, 0);
            this.indexFingerDetailsTable.Controls.Add(this.indexSpeedXLabel, 1, 1);
            this.indexFingerDetailsTable.Controls.Add(this.label28, 1, 2);
            this.indexFingerDetailsTable.Controls.Add(this.label29, 1, 3);
            this.indexFingerDetailsTable.Controls.Add(this.indexPositionXLabel, 2, 1);
            this.indexFingerDetailsTable.Controls.Add(this.indexPositionYLabel, 2, 2);
            this.indexFingerDetailsTable.Controls.Add(this.indexPositionZLabel, 2, 3);
            this.indexFingerDetailsTable.Location = new System.Drawing.Point(612, 18);
            this.indexFingerDetailsTable.Name = "indexFingerDetailsTable";
            this.indexFingerDetailsTable.RowCount = 4;
            this.indexFingerDetailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.indexFingerDetailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.indexFingerDetailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.indexFingerDetailsTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.indexFingerDetailsTable.Size = new System.Drawing.Size(144, 100);
            this.indexFingerDetailsTable.TabIndex = 21;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(4, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(14, 13);
            this.label22.TabIndex = 0;
            this.label22.Text = "X";
            // 
            // indexSpeedYLabel
            // 
            this.indexSpeedYLabel.AutoSize = true;
            this.indexSpeedYLabel.Location = new System.Drawing.Point(4, 49);
            this.indexSpeedYLabel.Name = "indexSpeedYLabel";
            this.indexSpeedYLabel.Size = new System.Drawing.Size(14, 13);
            this.indexSpeedYLabel.TabIndex = 1;
            this.indexSpeedYLabel.Text = "Y";
            // 
            // indexSpeedZLabel
            // 
            this.indexSpeedZLabel.AutoSize = true;
            this.indexSpeedZLabel.Location = new System.Drawing.Point(4, 73);
            this.indexSpeedZLabel.Name = "indexSpeedZLabel";
            this.indexSpeedZLabel.Size = new System.Drawing.Size(14, 13);
            this.indexSpeedZLabel.TabIndex = 2;
            this.indexSpeedZLabel.Text = "Z";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(33, 1);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 13);
            this.label25.TabIndex = 3;
            this.label25.Text = "Speed";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(90, 1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 23);
            this.label26.TabIndex = 4;
            this.label26.Text = "Position [m]";
            // 
            // indexSpeedXLabel
            // 
            this.indexSpeedXLabel.AutoSize = true;
            this.indexSpeedXLabel.Location = new System.Drawing.Point(33, 25);
            this.indexSpeedXLabel.Name = "indexSpeedXLabel";
            this.indexSpeedXLabel.Size = new System.Drawing.Size(10, 13);
            this.indexSpeedXLabel.TabIndex = 5;
            this.indexSpeedXLabel.Text = "-";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(33, 49);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(10, 13);
            this.label28.TabIndex = 6;
            this.label28.Text = "-";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(33, 73);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(10, 13);
            this.label29.TabIndex = 7;
            this.label29.Text = "-";
            // 
            // indexPositionXLabel
            // 
            this.indexPositionXLabel.AutoSize = true;
            this.indexPositionXLabel.Location = new System.Drawing.Point(90, 25);
            this.indexPositionXLabel.Name = "indexPositionXLabel";
            this.indexPositionXLabel.Size = new System.Drawing.Size(10, 13);
            this.indexPositionXLabel.TabIndex = 8;
            this.indexPositionXLabel.Text = "-";
            // 
            // indexPositionYLabel
            // 
            this.indexPositionYLabel.AutoSize = true;
            this.indexPositionYLabel.Location = new System.Drawing.Point(90, 49);
            this.indexPositionYLabel.Name = "indexPositionYLabel";
            this.indexPositionYLabel.Size = new System.Drawing.Size(10, 13);
            this.indexPositionYLabel.TabIndex = 9;
            this.indexPositionYLabel.Text = "-";
            // 
            // indexPositionZLabel
            // 
            this.indexPositionZLabel.AutoSize = true;
            this.indexPositionZLabel.Location = new System.Drawing.Point(90, 73);
            this.indexPositionZLabel.Name = "indexPositionZLabel";
            this.indexPositionZLabel.Size = new System.Drawing.Size(10, 13);
            this.indexPositionZLabel.TabIndex = 10;
            this.indexPositionZLabel.Text = "-";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 619);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.fingerStatusTable.ResumeLayout(false);
            this.fingerStatusTable.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.laserPower)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.filterOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.motionRangeTradeoff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthConfidence)).EndInit();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jointSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.smoothingValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxFoldnessFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minExtendedFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nearTrackingDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.farTrackingDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nearTrackingWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.farTrackingHeight)).EndInit();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.indexFingerDetailsTable.ResumeLayout(false);
            this.indexFingerDetailsTable.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem deviceMenu;
        private System.Windows.Forms.PictureBox rgbImage;
        private System.Windows.Forms.PictureBox depthImage;
        private System.Windows.Forms.PictureBox resultImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton radioDepth;
        private System.Windows.Forms.RadioButton radioIR;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem streamModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem live;
        private System.Windows.Forms.ToolStripMenuItem play;
        private System.Windows.Forms.ToolStripMenuItem record;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.CheckedListBox gestureListBox;
        private System.Windows.Forms.TableLayoutPanel fingerStatusTable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelThumbLeft;
        private System.Windows.Forms.Label labelThumbRight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelIndexLeft;
        private System.Windows.Forms.Label labelIndexRight;
        private System.Windows.Forms.Label labelMiddleLeft;
        private System.Windows.Forms.Label labelMiddleRight;
        private System.Windows.Forms.Label labelRingLeft;
        private System.Windows.Forms.Label labelRingRight;
        private System.Windows.Forms.Label labelPinkyRight;
        private System.Windows.Forms.Label labelPinkyLeft;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.NumericUpDown laserPower;
        private System.Windows.Forms.NumericUpDown filterOption;
        private System.Windows.Forms.NumericUpDown motionRangeTradeoff;
        private System.Windows.Forms.NumericUpDown depthConfidence;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown jointSpeed;
        private System.Windows.Forms.NumericUpDown smoothingValue;
        private System.Windows.Forms.Label jointSpeedlabel;
        private System.Windows.Forms.Label smoothingValueLabel;
        private System.Windows.Forms.CheckBox stabilizer;
        private System.Windows.Forms.NumericUpDown maxFoldnessFactor;
        private System.Windows.Forms.NumericUpDown minExtendedFactor;
        private System.Windows.Forms.Label maxFoldnessFactorLabel;
        private System.Windows.Forms.Label minExtendedFactorLabel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button defualtCameraSettingsButton;
        private System.Windows.Forms.NumericUpDown nearTrackingDistance;
        private System.Windows.Forms.NumericUpDown farTrackingDistance;
        private System.Windows.Forms.NumericUpDown nearTrackingWidth;
        private System.Windows.Forms.NumericUpDown farTrackingHeight;
        private System.Windows.Forms.Button defaultGestureSettingsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TableLayoutPanel indexFingerDetailsTable;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label indexSpeedYLabel;
        private System.Windows.Forms.Label indexSpeedZLabel;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label indexSpeedXLabel;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label indexPositionXLabel;
        private System.Windows.Forms.Label indexPositionYLabel;
        private System.Windows.Forms.Label indexPositionZLabel;
    }
}