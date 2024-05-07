namespace AppCsTp2Pwm
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbCom = new System.Windows.Forms.GroupBox();
            this.btOpenClose = new System.Windows.Forms.Button();
            this.cboPortNames = new System.Windows.Forms.ComboBox();
            this.gbTx = new System.Windows.Forms.GroupBox();
            this.cbForme = new System.Windows.Forms.ComboBox();
            this.nudOffset = new System.Windows.Forms.NumericUpDown();
            this.nudAmpl = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lstDataOut = new System.Windows.Forms.ListBox();
            this.btSendContinuous = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.nudFreq = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbRx = new System.Windows.Forms.GroupBox();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.txtAmpl = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lstDataIn = new System.Windows.Forms.ListBox();
            this.txtFreq = new System.Windows.Forms.TextBox();
            this.txtForme = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbCom.SuspendLayout();
            this.gbTx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmpl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).BeginInit();
            this.gbRx.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 19200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gbCom
            // 
            this.gbCom.Controls.Add(this.btOpenClose);
            this.gbCom.Controls.Add(this.cboPortNames);
            this.gbCom.Location = new System.Drawing.Point(12, 12);
            this.gbCom.Name = "gbCom";
            this.gbCom.Size = new System.Drawing.Size(515, 70);
            this.gbCom.TabIndex = 20;
            this.gbCom.TabStop = false;
            this.gbCom.Text = "Réglages communication";
            // 
            // btOpenClose
            // 
            this.btOpenClose.Location = new System.Drawing.Point(16, 30);
            this.btOpenClose.Name = "btOpenClose";
            this.btOpenClose.Size = new System.Drawing.Size(75, 23);
            this.btOpenClose.TabIndex = 19;
            this.btOpenClose.Text = "Open";
            this.btOpenClose.UseVisualStyleBackColor = true;
            this.btOpenClose.Click += new System.EventHandler(this.btOpenClose_Click);
            // 
            // cboPortNames
            // 
            this.cboPortNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortNames.FormattingEnabled = true;
            this.cboPortNames.Location = new System.Drawing.Point(114, 32);
            this.cboPortNames.Margin = new System.Windows.Forms.Padding(2);
            this.cboPortNames.Name = "cboPortNames";
            this.cboPortNames.Size = new System.Drawing.Size(98, 21);
            this.cboPortNames.Sorted = true;
            this.cboPortNames.TabIndex = 17;
            this.cboPortNames.DropDown += new System.EventHandler(this.cboPortNames_DropDown);
            // 
            // gbTx
            // 
            this.gbTx.Controls.Add(this.cbForme);
            this.gbTx.Controls.Add(this.nudOffset);
            this.gbTx.Controls.Add(this.nudAmpl);
            this.gbTx.Controls.Add(this.label1);
            this.gbTx.Controls.Add(this.label4);
            this.gbTx.Controls.Add(this.lstDataOut);
            this.gbTx.Controls.Add(this.btSendContinuous);
            this.gbTx.Controls.Add(this.btSend);
            this.gbTx.Controls.Add(this.chkSave);
            this.gbTx.Controls.Add(this.nudFreq);
            this.gbTx.Controls.Add(this.label3);
            this.gbTx.Controls.Add(this.label2);
            this.gbTx.Enabled = false;
            this.gbTx.Location = new System.Drawing.Point(12, 88);
            this.gbTx.Name = "gbTx";
            this.gbTx.Size = new System.Drawing.Size(250, 286);
            this.gbTx.TabIndex = 21;
            this.gbTx.TabStop = false;
            this.gbTx.Text = "Transmition";
            // 
            // cbForme
            // 
            this.cbForme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbForme.FormattingEnabled = true;
            this.cbForme.Items.AddRange(new object[] {
            "Sinus",
            "Carre",
            "Triangle",
            "Dent de scie"});
            this.cbForme.Location = new System.Drawing.Point(48, 22);
            this.cbForme.Name = "cbForme";
            this.cbForme.Size = new System.Drawing.Size(86, 21);
            this.cbForme.TabIndex = 62;
            this.cbForme.SelectedIndexChanged += new System.EventHandler(this.cbForme_SelectedIndexChanged);
            // 
            // nudOffset
            // 
            this.nudOffset.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudOffset.Location = new System.Drawing.Point(189, 51);
            this.nudOffset.Margin = new System.Windows.Forms.Padding(2);
            this.nudOffset.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudOffset.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.nudOffset.Name = "nudOffset";
            this.nudOffset.Size = new System.Drawing.Size(56, 20);
            this.nudOffset.TabIndex = 61;
            // 
            // nudAmpl
            // 
            this.nudAmpl.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nudAmpl.Location = new System.Drawing.Point(189, 22);
            this.nudAmpl.Margin = new System.Windows.Forms.Padding(2);
            this.nudAmpl.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudAmpl.Name = "nudAmpl";
            this.nudAmpl.Size = new System.Drawing.Size(56, 20);
            this.nudAmpl.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(135, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 58;
            this.label4.Text = "Amplitude";
            // 
            // lstDataOut
            // 
            this.lstDataOut.FormattingEnabled = true;
            this.lstDataOut.Location = new System.Drawing.Point(14, 137);
            this.lstDataOut.Margin = new System.Windows.Forms.Padding(2);
            this.lstDataOut.Name = "lstDataOut";
            this.lstDataOut.Size = new System.Drawing.Size(221, 134);
            this.lstDataOut.TabIndex = 56;
            // 
            // btSendContinuous
            // 
            this.btSendContinuous.Location = new System.Drawing.Point(135, 88);
            this.btSendContinuous.Name = "btSendContinuous";
            this.btSendContinuous.Size = new System.Drawing.Size(100, 23);
            this.btSendContinuous.TabIndex = 54;
            this.btSendContinuous.Text = "Envoi continu";
            this.btSendContinuous.UseVisualStyleBackColor = true;
            this.btSendContinuous.Click += new System.EventHandler(this.btSendContinuous_Click);
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(16, 88);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(100, 23);
            this.btSend.TabIndex = 52;
            this.btSend.Text = "Envoi";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // chkSave
            // 
            this.chkSave.AutoSize = true;
            this.chkSave.Location = new System.Drawing.Point(16, 116);
            this.chkSave.Margin = new System.Windows.Forms.Padding(2);
            this.chkSave.Name = "chkSave";
            this.chkSave.Size = new System.Drawing.Size(84, 17);
            this.chkSave.TabIndex = 49;
            this.chkSave.Text = "Sauvegarde";
            this.chkSave.UseVisualStyleBackColor = true;
            // 
            // nudFreq
            // 
            this.nudFreq.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFreq.Location = new System.Drawing.Point(74, 51);
            this.nudFreq.Margin = new System.Windows.Forms.Padding(2);
            this.nudFreq.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudFreq.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nudFreq.Name = "nudFreq";
            this.nudFreq.Size = new System.Drawing.Size(56, 20);
            this.nudFreq.TabIndex = 29;
            this.nudFreq.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 53);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Fréquence";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Forme";
            // 
            // gbRx
            // 
            this.gbRx.Controls.Add(this.txtOffset);
            this.gbRx.Controls.Add(this.txtAmpl);
            this.gbRx.Controls.Add(this.label7);
            this.gbRx.Controls.Add(this.label8);
            this.gbRx.Controls.Add(this.lstDataIn);
            this.gbRx.Controls.Add(this.txtFreq);
            this.gbRx.Controls.Add(this.txtForme);
            this.gbRx.Controls.Add(this.label6);
            this.gbRx.Controls.Add(this.label5);
            this.gbRx.Enabled = false;
            this.gbRx.Location = new System.Drawing.Point(277, 88);
            this.gbRx.Name = "gbRx";
            this.gbRx.Size = new System.Drawing.Size(250, 286);
            this.gbRx.TabIndex = 22;
            this.gbRx.TabStop = false;
            this.gbRx.Text = "Réception";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(72, 111);
            this.txtOffset.Margin = new System.Windows.Forms.Padding(2);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.ReadOnly = true;
            this.txtOffset.Size = new System.Drawing.Size(70, 20);
            this.txtOffset.TabIndex = 61;
            // 
            // txtAmpl
            // 
            this.txtAmpl.Location = new System.Drawing.Point(72, 82);
            this.txtAmpl.Margin = new System.Windows.Forms.Padding(2);
            this.txtAmpl.Name = "txtAmpl";
            this.txtAmpl.ReadOnly = true;
            this.txtAmpl.Size = new System.Drawing.Size(70, 20);
            this.txtAmpl.TabIndex = 60;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 114);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 59;
            this.label7.Text = "Offset";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 84);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 58;
            this.label8.Text = "Amplitude";
            // 
            // lstDataIn
            // 
            this.lstDataIn.FormattingEnabled = true;
            this.lstDataIn.Location = new System.Drawing.Point(17, 139);
            this.lstDataIn.Margin = new System.Windows.Forms.Padding(2);
            this.lstDataIn.Name = "lstDataIn";
            this.lstDataIn.Size = new System.Drawing.Size(221, 134);
            this.lstDataIn.TabIndex = 52;
            // 
            // txtFreq
            // 
            this.txtFreq.Location = new System.Drawing.Point(72, 51);
            this.txtFreq.Margin = new System.Windows.Forms.Padding(2);
            this.txtFreq.Name = "txtFreq";
            this.txtFreq.ReadOnly = true;
            this.txtFreq.Size = new System.Drawing.Size(70, 20);
            this.txtFreq.TabIndex = 57;
            // 
            // txtForme
            // 
            this.txtForme.Location = new System.Drawing.Point(72, 22);
            this.txtForme.Margin = new System.Windows.Forms.Padding(2);
            this.txtForme.Name = "txtForme";
            this.txtForme.ReadOnly = true;
            this.txtForme.Size = new System.Drawing.Size(70, 20);
            this.txtForme.TabIndex = 56;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Fréquence";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Forme";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 392);
            this.Controls.Add(this.gbRx);
            this.Controls.Add(this.gbTx);
            this.Controls.Add(this.gbCom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "App de test TP MINF";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.gbCom.ResumeLayout(false);
            this.gbTx.ResumeLayout(false);
            this.gbTx.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmpl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFreq)).EndInit();
            this.gbRx.ResumeLayout(false);
            this.gbRx.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox gbCom;
        private System.Windows.Forms.ComboBox cboPortNames;
        private System.Windows.Forms.GroupBox gbTx;
        private System.Windows.Forms.CheckBox chkSave;
        private System.Windows.Forms.NumericUpDown nudFreq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btOpenClose;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Button btSendContinuous;
        private System.Windows.Forms.GroupBox gbRx;
        private System.Windows.Forms.ListBox lstDataIn;
        private System.Windows.Forms.TextBox txtFreq;
        private System.Windows.Forms.TextBox txtForme;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lstDataOut;
        private System.Windows.Forms.NumericUpDown nudOffset;
        private System.Windows.Forms.NumericUpDown nudAmpl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.TextBox txtAmpl;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbForme;
    }
}

