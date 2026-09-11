namespace OpenCV
{
    partial class Form2
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
            groupCard = new GroupBox();
            pictureBox1 = new PictureBox();
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
            btnClose = new Button();
            panelHeader.SuspendLayout();
            groupCard.SuspendLayout();
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
            panelHeader.Size = new Size(840, 75);
            panelHeader.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(20, 10);
            label1.Name = "label1";
            label1.Size = new Size(346, 37);
            label1.TabIndex = 0;
            label1.Text = "REGISTERED PROFILE CARD";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = SystemColors.ControlDarkDark;
            lblSubtitle.Location = new Point(24, 45);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(256, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Verified Applicant Information Summary";
            // 
            // groupCard
            // 
            groupCard.Controls.Add(pictureBox1);
            groupCard.Controls.Add(textBox6);
            groupCard.Controls.Add(label8);
            groupCard.Controls.Add(textBox2);
            groupCard.Controls.Add(label3);
            groupCard.Controls.Add(textBox7);
            groupCard.Controls.Add(label7);
            groupCard.Controls.Add(textBox8);
            groupCard.Controls.Add(label2);
            groupCard.Controls.Add(textBox5);
            groupCard.Controls.Add(label6);
            groupCard.Controls.Add(textBox1);
            groupCard.Controls.Add(S);
            groupCard.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            groupCard.Location = new Point(20, 90);
            groupCard.Name = "groupCard";
            groupCard.Size = new Size(800, 310);
            groupCard.TabIndex = 1;
            groupCard.TabStop = false;
            groupCard.Text = " Profile Details ";
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(570, 35);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(210, 245);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // textBox6
            // 
            textBox6.BackColor = SystemColors.Window;
            textBox6.Font = new Font("Segoe UI", 9.5F);
            textBox6.Location = new Point(290, 220);
            textBox6.Name = "textBox6";
            textBox6.ReadOnly = true;
            textBox6.Size = new Size(250, 29);
            textBox6.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(290, 195);
            label8.Name = "label8";
            label8.Size = new Size(106, 20);
            label8.TabIndex = 10;
            label8.Text = "CONTACT NO";
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.Window;
            textBox2.Font = new Font("Segoe UI", 9.5F);
            textBox2.Location = new Point(20, 220);
            textBox2.Name = "textBox2";
            textBox2.ReadOnly = true;
            textBox2.Size = new Size(250, 29);
            textBox2.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(20, 195);
            label3.Name = "label3";
            label3.Size = new Size(150, 20);
            label3.TabIndex = 8;
            label3.Text = "REGISTRATION NO";
            // 
            // textBox7
            // 
            textBox7.BackColor = SystemColors.Window;
            textBox7.Font = new Font("Segoe UI", 9.5F);
            textBox7.Location = new Point(290, 135);
            textBox7.Name = "textBox7";
            textBox7.ReadOnly = true;
            textBox7.Size = new Size(250, 29);
            textBox7.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(290, 110);
            label7.Name = "label7";
            label7.Size = new Size(72, 20);
            label7.TabIndex = 6;
            label7.Text = "CNIC NO";
            // 
            // textBox8
            // 
            textBox8.BackColor = SystemColors.Window;
            textBox8.Font = new Font("Segoe UI", 9.5F);
            textBox8.Location = new Point(20, 135);
            textBox8.Name = "textBox8";
            textBox8.ReadOnly = true;
            textBox8.Size = new Size(250, 29);
            textBox8.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.Location = new Point(20, 110);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 4;
            label2.Text = "FATHER NAME";
            // 
            // textBox5
            // 
            textBox5.BackColor = SystemColors.Window;
            textBox5.Font = new Font("Segoe UI", 9.5F);
            textBox5.Location = new Point(290, 55);
            textBox5.Name = "textBox5";
            textBox5.ReadOnly = true;
            textBox5.Size = new Size(250, 29);
            textBox5.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.Location = new Point(290, 30);
            label6.Name = "label6";
            label6.Size = new Size(93, 20);
            label6.TabIndex = 2;
            label6.Text = "LAST NAME";
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.Window;
            textBox1.Font = new Font("Segoe UI", 9.5F);
            textBox1.Location = new Point(20, 55);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(250, 29);
            textBox1.TabIndex = 1;
            // 
            // S
            // 
            S.AutoSize = true;
            S.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            S.Location = new Point(20, 30);
            S.Name = "S";
            S.Size = new Size(97, 20);
            S.TabIndex = 0;
            S.Text = "FIRST NAME";
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnClose.Location = new Point(680, 415);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(140, 38);
            btnClose.TabIndex = 2;
            btnClose.Text = "CLOSE";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += (s, e) => this.Close();
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 465);
            Controls.Add(btnClose);
            Controls.Add(groupCard);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Applicant Profile Card";
            Load += Form2_Load;
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            groupCard.ResumeLayout(false);
            groupCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label label1;
        private Label lblSubtitle;
        private GroupBox groupCard;
        private PictureBox pictureBox1;
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
        private Button btnClose;
    }
}