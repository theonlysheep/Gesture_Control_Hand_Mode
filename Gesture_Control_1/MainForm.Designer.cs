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
            this.messageBox = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.radioDepth = new System.Windows.Forms.RadioButton();
            this.radioIR = new System.Windows.Forms.RadioButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
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
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultImage)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.fingerStatusTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceMenu,
            this.streamModeToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(996, 24);
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
            this.rgbImage.Size = new System.Drawing.Size(318, 235);
            this.rgbImage.TabIndex = 1;
            this.rgbImage.TabStop = false;
            // 
            // depthImage
            // 
            this.depthImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.depthImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.depthImage.Location = new System.Drawing.Point(327, 3);
            this.depthImage.Name = "depthImage";
            this.depthImage.Size = new System.Drawing.Size(318, 235);
            this.depthImage.TabIndex = 2;
            this.depthImage.TabStop = false;
            // 
            // resultImage
            // 
            this.resultImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.resultImage.Location = new System.Drawing.Point(651, 3);
            this.resultImage.Name = "resultImage";
            this.resultImage.Size = new System.Drawing.Size(318, 235);
            this.resultImage.TabIndex = 3;
            this.resultImage.TabStop = false;
            // 
            // messageBox
            // 
            this.messageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBox.Location = new System.Drawing.Point(13, 275);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(550, 169);
            this.messageBox.TabIndex = 4;
            this.messageBox.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(569, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Gesture recognition selection";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.buttonStop, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonStart, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(902, 374);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(83, 70);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(3, 38);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 1;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(3, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.radioDepth, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.radioIR, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(902, 291);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(83, 53);
            this.tableLayoutPanel3.TabIndex = 10;
            this.tableLayoutPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel3_Paint);
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
            // radioIR
            // 
            this.radioIR.AutoSize = true;
            this.radioIR.Location = new System.Drawing.Point(3, 29);
            this.radioIR.Name = "radioIR";
            this.radioIR.Size = new System.Drawing.Size(36, 17);
            this.radioIR.TabIndex = 1;
            this.radioIR.TabStop = true;
            this.radioIR.Text = "IR";
            this.radioIR.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 447);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(996, 22);
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
            this.tableLayoutPanel1.Controls.Add(this.rgbImage, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.depthImage, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.resultImage, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(972, 241);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // gestureListBox
            // 
            this.gestureListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gestureListBox.FormattingEnabled = true;
            this.gestureListBox.Location = new System.Drawing.Point(569, 290);
            this.gestureListBox.Name = "gestureListBox";
            this.gestureListBox.Size = new System.Drawing.Size(141, 154);
            this.gestureListBox.TabIndex = 13;
            this.gestureListBox.Visible = false;
            this.gestureListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.gestureListBox_ItemCheck);
            // 
            // fingerStatusTable
            // 
            this.fingerStatusTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.fingerStatusTable.Location = new System.Drawing.Point(716, 290);
            this.fingerStatusTable.Name = "fingerStatusTable";
            this.fingerStatusTable.RowCount = 6;
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.fingerStatusTable.Size = new System.Drawing.Size(180, 154);
            this.fingerStatusTable.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Left";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(122, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Right ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Thumb";
            // 
            // labelThumbLeft
            // 
            this.labelThumbLeft.AutoSize = true;
            this.labelThumbLeft.Location = new System.Drawing.Point(63, 26);
            this.labelThumbLeft.Name = "labelThumbLeft";
            this.labelThumbLeft.Size = new System.Drawing.Size(10, 13);
            this.labelThumbLeft.TabIndex = 3;
            this.labelThumbLeft.Text = "-";
            // 
            // labelThumbRight
            // 
            this.labelThumbRight.AutoSize = true;
            this.labelThumbRight.Location = new System.Drawing.Point(122, 26);
            this.labelThumbRight.Name = "labelThumbRight";
            this.labelThumbRight.Size = new System.Drawing.Size(10, 13);
            this.labelThumbRight.TabIndex = 4;
            this.labelThumbRight.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Index";
            // 
            // labelIndexLeft
            // 
            this.labelIndexLeft.AutoSize = true;
            this.labelIndexLeft.Location = new System.Drawing.Point(63, 51);
            this.labelIndexLeft.Name = "labelIndexLeft";
            this.labelIndexLeft.Size = new System.Drawing.Size(10, 13);
            this.labelIndexLeft.TabIndex = 6;
            this.labelIndexLeft.Text = "-";
            // 
            // labelIndexRight
            // 
            this.labelIndexRight.AutoSize = true;
            this.labelIndexRight.Location = new System.Drawing.Point(122, 51);
            this.labelIndexRight.Name = "labelIndexRight";
            this.labelIndexRight.Size = new System.Drawing.Size(10, 13);
            this.labelIndexRight.TabIndex = 7;
            this.labelIndexRight.Text = "-";
            // 
            // labelMiddleLeft
            // 
            this.labelMiddleLeft.AutoSize = true;
            this.labelMiddleLeft.Location = new System.Drawing.Point(63, 76);
            this.labelMiddleLeft.Name = "labelMiddleLeft";
            this.labelMiddleLeft.Size = new System.Drawing.Size(10, 13);
            this.labelMiddleLeft.TabIndex = 8;
            this.labelMiddleLeft.Text = "-";
            // 
            // labelMiddleRight
            // 
            this.labelMiddleRight.AutoSize = true;
            this.labelMiddleRight.Location = new System.Drawing.Point(122, 76);
            this.labelMiddleRight.Name = "labelMiddleRight";
            this.labelMiddleRight.Size = new System.Drawing.Size(10, 13);
            this.labelMiddleRight.TabIndex = 9;
            this.labelMiddleRight.Text = "-";
            // 
            // labelRingLeft
            // 
            this.labelRingLeft.AutoSize = true;
            this.labelRingLeft.Location = new System.Drawing.Point(63, 101);
            this.labelRingLeft.Name = "labelRingLeft";
            this.labelRingLeft.Size = new System.Drawing.Size(10, 13);
            this.labelRingLeft.TabIndex = 10;
            this.labelRingLeft.Text = "-";
            // 
            // labelRingRight
            // 
            this.labelRingRight.AutoSize = true;
            this.labelRingRight.Location = new System.Drawing.Point(122, 101);
            this.labelRingRight.Name = "labelRingRight";
            this.labelRingRight.Size = new System.Drawing.Size(10, 13);
            this.labelRingRight.TabIndex = 11;
            this.labelRingRight.Text = "-";
            // 
            // labelPinkyRight
            // 
            this.labelPinkyRight.AutoSize = true;
            this.labelPinkyRight.Location = new System.Drawing.Point(122, 126);
            this.labelPinkyRight.Name = "labelPinkyRight";
            this.labelPinkyRight.Size = new System.Drawing.Size(10, 13);
            this.labelPinkyRight.TabIndex = 12;
            this.labelPinkyRight.Text = "-";
            // 
            // labelPinkyLeft
            // 
            this.labelPinkyLeft.AutoSize = true;
            this.labelPinkyLeft.Location = new System.Drawing.Point(63, 126);
            this.labelPinkyLeft.Name = "labelPinkyLeft";
            this.labelPinkyLeft.Size = new System.Drawing.Size(10, 13);
            this.labelPinkyLeft.TabIndex = 13;
            this.labelPinkyLeft.Text = "-";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(4, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "Middle";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 101);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 13);
            this.label17.TabIndex = 15;
            this.label17.Text = "Ring";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(4, 126);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 13);
            this.label18.TabIndex = 16;
            this.label18.Text = "Pinky";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 469);
            this.Controls.Add(this.fingerStatusTable);
            this.Controls.Add(this.gestureListBox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.messageBox);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem deviceMenu;
        private System.Windows.Forms.PictureBox rgbImage;
        private System.Windows.Forms.PictureBox depthImage;
        private System.Windows.Forms.PictureBox resultImage;
        private System.Windows.Forms.RichTextBox messageBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.RadioButton radioDepth;
        private System.Windows.Forms.RadioButton radioIR;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusStripLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckedListBox gestureListBox;
        private System.Windows.Forms.ToolStripMenuItem streamModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem live;
        private System.Windows.Forms.ToolStripMenuItem play;
        private System.Windows.Forms.ToolStripMenuItem record;
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
    }
}