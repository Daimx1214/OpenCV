namespace OpenCV
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new Panel();
            label1 = new Label();
            lblSubtitle = new Label();
            groupInput = new GroupBox();
            textBox6 = new TextBox();
            label8 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox7 = new TextBox();
            label7 = new Label();
            textBox8 = new TextBox();
            label2 = new Label();
            textBox5 = new TextBox();
            label6 = new Label();
            textBox1 = new TextBox();
            S = new Label();
            groupCamera = new GroupBox();
            lblStatus = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            panelHeader.SuspendLayout();
            groupInput.SuspendLayout();
            groupCamera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(label1);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1020, 80);
            panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(20, 12);
            label1.Name = "label1";
            label1.Size = new Size(491, 41);
            label1.TabIndex = 0;
            label1.Text = "FACE RECOGNITION & REGISTRATION";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = SystemColors.ControlDarkDark;
            lblSubtitle.Location = new Point(24, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(331, 21);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Student & Person Profile Verification System";
            // 
            // groupInput
            // 
            groupInput.Controls.Add(textBox6);
            groupInput.Controls.Add(label8);
            groupInput.Controls.Add(textBox2);
            groupInput.Controls.Add(label3);
            groupInput.Controls.Add(textBox7);
            groupInput.Controls.Add(label7);
            groupInput.Controls.Add(textBox8);
            groupInput.Controls.Add(label2);
            groupInput.Controls.Add(textBox5);
            groupInput.Controls.Add(label6);
            groupInput.Controls.Add(textBox1);
            groupInput.Controls.Add(S);
            groupInput.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupInput.Location = new Point(20, 100);
            groupInput.Name = "groupInput";
            groupInput.Size = new Size(640, 370);
            groupInput.TabIndex = 1;
            groupInput.TabStop = false;
            groupInput.Text = " Personal Information ";
            // 
            // textBox6
            // 
            textBox6.Font = new Font("Segoe UI", 9.5F);
            textBox6.Location = new Point(340, 225);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(270, 29);
            textBox6.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(340, 200);
            label8.Name = "label8";
            label8.Size = new Size(106, 20);
            label8.TabIndex = 10;
            label8.Text = "CONTACT NO";
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 9.5F);
            textBox2.Location = new Point(30, 225);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(270, 29);
            textBox2.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(30, 200);
            label3.Name = "label3";
            label3.Size = new Size(150, 20);
            label3.TabIndex = 8;
            label3.Text = "REGISTRATION NO";
            // 
            // textBox7
            // 
            textBox7.Font = new Font("Segoe UI", 9.5F);
            textBox7.Location = new Point(340, 145);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(270, 29);
            textBox7.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(340, 120);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 6;
            label7.Text = "CNIC NO";
            // 
            // textBox8
            // 
            textBox8.Font = new Font("Segoe UI", 9.5F);
            textBox8.Location = new Point(30, 145);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(270, 29);
            textBox8.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(30, 120);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 4;
            label2.Text = "FATHER NAME";
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Segoe UI", 9.5F);
            textBox5.Location = new Point(340, 65);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(270, 29);
            textBox5.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(340, 40);
            label6.Name = "label6";
            label6.Size = new Size(93, 20);
            label6.TabIndex = 2;
            label6.Text = "LAST NAME";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9.5F);
            textBox1.Location = new Point(30, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(270, 29);
            textBox1.TabIndex = 1;
            // 
            // S
            // 
            S.AutoSize = true;
            S.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            S.Location = new Point(30, 40);
            S.Name = "S";
            S.Size = new Size(97, 20);
            S.TabIndex = 0;
            S.Text = "FIRST NAME";
            // 
            // groupCamera
            // 
            groupCamera.Controls.Add(lblStatus);
            groupCamera.Controls.Add(button3);
            groupCamera.Controls.Add(button2);
            groupCamera.Controls.Add(button1);
            groupCamera.Controls.Add(pictureBox1);
            groupCamera.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupCamera.Location = new Point(680, 100);
            groupCamera.Name = "groupCamera";
            groupCamera.Size = new Size(320, 370);
            groupCamera.TabIndex = 2;
            groupCamera.TabStop = false;
            groupCamera.Text = " Camera & Verification ";
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStatus.Location = new Point(20, 175);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(280, 32);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Status: Ready (Turn Camera ON)";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button3.Location = new Point(20, 315);
            button3.Name = "button3";
            button3.Size = new Size(280, 40);
            button3.TabIndex = 3;
            button3.Text = "SUBMIT & SAVE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button2.Location = new Point(20, 265);
            button2.Name = "button2";
            button2.Size = new Size(280, 40);
            button2.TabIndex = 2;
            button2.Text = "CAPTURE PHOTO";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button1.Location = new Point(20, 215);
            button1.Name = "button1";
            button1.Size = new Size(280, 40);
            button1.TabIndex = 1;
            button1.Text = "CAMERA ON / OFF";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(20, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(280, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 490);
            Controls.Add(groupCamera);
            Controls.Add(groupInput);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Face Recognition & Registration System";
            Load += Form1_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupInput.ResumeLayout(false);
            groupInput.PerformLayout();
            groupCamera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label label1;
        private Label lblSubtitle;
        private GroupBox groupInput;
        private Label S;
        private TextBox textBox1;
        private Label label6;
        private TextBox textBox5;
        private Label label2;
        private TextBox textBox8;
        private Label label7;
        private TextBox textBox7;
        private Label label3;
        private TextBox textBox2;
        private Label label8;
        private TextBox textBox6;
        private GroupBox groupCamera;
        private PictureBox pictureBox1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label lblStatus;
    }
}
