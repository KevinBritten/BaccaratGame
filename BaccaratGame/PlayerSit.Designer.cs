namespace BaccaratGame
{
    partial class PlayerSit
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
            FundCommit = new NumericUpDown();
            SeatNumberLabel = new Label();
            PlayerNameLabel = new Label();
            PlayerNameTextBox = new TextBox();
            FundLabel = new Label();
            ConfirmButton = new Button();
            CancelButton = new Button();
            AvatarBox = new GroupBox();
            avatarPictureBox9 = new PictureBox();
            avatarPictureBox8 = new PictureBox();
            avatarPictureBox7 = new PictureBox();
            avatarPictureBox6 = new PictureBox();
            avatarPictureBox5 = new PictureBox();
            avatarPictureBox4 = new PictureBox();
            avatarPictureBox3 = new PictureBox();
            avatarPictureBox2 = new PictureBox();
            avatarPictureBox1 = new PictureBox();
            NameRequiredErrorLabel = new Label();
            FundsRequiredErrorLabel = new Label();
            AvatarRequiredErrorLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)FundCommit).BeginInit();
            AvatarBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // FundCommit
            // 
            FundCommit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FundCommit.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            FundCommit.Location = new Point(14, 248);
            FundCommit.Margin = new Padding(3, 4, 3, 4);
            FundCommit.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            FundCommit.Name = "FundCommit";
            FundCommit.Size = new Size(137, 34);
            FundCommit.TabIndex = 0;
            // 
            // SeatNumberLabel
            // 
            SeatNumberLabel.AutoSize = true;
            SeatNumberLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SeatNumberLabel.Location = new Point(14, 12);
            SeatNumberLabel.Name = "SeatNumberLabel";
            SeatNumberLabel.Size = new Size(279, 41);
            SeatNumberLabel.TabIndex = 1;
            SeatNumberLabel.Text = "Let's occupy seat 1";
            // 
            // PlayerNameLabel
            // 
            PlayerNameLabel.AutoSize = true;
            PlayerNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayerNameLabel.Location = new Point(14, 92);
            PlayerNameLabel.Name = "PlayerNameLabel";
            PlayerNameLabel.Size = new Size(179, 28);
            PlayerNameLabel.TabIndex = 2;
            PlayerNameLabel.Text = "What is your name:";
            // 
            // PlayerNameTextBox
            // 
            PlayerNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayerNameTextBox.Location = new Point(14, 124);
            PlayerNameTextBox.Margin = new Padding(3, 4, 3, 4);
            PlayerNameTextBox.Name = "PlayerNameTextBox";
            PlayerNameTextBox.Size = new Size(228, 34);
            PlayerNameTextBox.TabIndex = 3;
            // 
            // FundLabel
            // 
            FundLabel.AutoSize = true;
            FundLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FundLabel.Location = new Point(14, 216);
            FundLabel.Name = "FundLabel";
            FundLabel.Size = new Size(386, 28);
            FundLabel.TabIndex = 4;
            FundLabel.Text = "How much funds would you like to commit";
            // 
            // ConfirmButton
            // 
            ConfirmButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConfirmButton.Location = new Point(14, 532);
            ConfirmButton.Margin = new Padding(3, 4, 3, 4);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(114, 40);
            ConfirmButton.TabIndex = 5;
            ConfirmButton.Text = "Confirm";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelButton.Location = new Point(160, 532);
            CancelButton.Margin = new Padding(3, 4, 3, 4);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(114, 40);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AvatarBox
            // 
            AvatarBox.Controls.Add(avatarPictureBox9);
            AvatarBox.Controls.Add(avatarPictureBox8);
            AvatarBox.Controls.Add(avatarPictureBox7);
            AvatarBox.Controls.Add(avatarPictureBox6);
            AvatarBox.Controls.Add(avatarPictureBox5);
            AvatarBox.Controls.Add(avatarPictureBox4);
            AvatarBox.Controls.Add(avatarPictureBox3);
            AvatarBox.Controls.Add(avatarPictureBox2);
            AvatarBox.Controls.Add(avatarPictureBox1);
            AvatarBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AvatarBox.Location = new Point(373, 16);
            AvatarBox.Margin = new Padding(3, 4, 3, 4);
            AvatarBox.Name = "AvatarBox";
            AvatarBox.Padding = new Padding(3, 4, 3, 4);
            AvatarBox.Size = new Size(528, 556);
            AvatarBox.TabIndex = 7;
            AvatarBox.TabStop = false;
            AvatarBox.Text = "Choices of avatars";
            // 
            // avatarPictureBox9
            // 
            avatarPictureBox9.Image = Properties.Resources.monkey;
            avatarPictureBox9.Location = new Point(359, 381);
            avatarPictureBox9.Name = "avatarPictureBox9";
            avatarPictureBox9.Size = new Size(160, 160);
            avatarPictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox9.TabIndex = 8;
            avatarPictureBox9.TabStop = false;
            avatarPictureBox9.Click += avatarPictureBox9_Click;
            // 
            // avatarPictureBox8
            // 
            avatarPictureBox8.Image = Properties.Resources.monkey;
            avatarPictureBox8.Location = new Point(179, 381);
            avatarPictureBox8.Name = "avatarPictureBox8";
            avatarPictureBox8.Size = new Size(160, 160);
            avatarPictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox8.TabIndex = 7;
            avatarPictureBox8.TabStop = false;
            avatarPictureBox8.Click += avatarPictureBox8_Click;
            // 
            // avatarPictureBox7
            // 
            avatarPictureBox7.Image = Properties.Resources.monkey;
            avatarPictureBox7.Location = new Point(0, 381);
            avatarPictureBox7.Name = "avatarPictureBox7";
            avatarPictureBox7.Size = new Size(160, 160);
            avatarPictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox7.TabIndex = 6;
            avatarPictureBox7.TabStop = false;
            avatarPictureBox7.Click += avatarPictureBox7_Click;
            // 
            // avatarPictureBox6
            // 
            avatarPictureBox6.Image = Properties.Resources.monkey;
            avatarPictureBox6.Location = new Point(359, 207);
            avatarPictureBox6.Name = "avatarPictureBox6";
            avatarPictureBox6.Size = new Size(160, 160);
            avatarPictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox6.TabIndex = 5;
            avatarPictureBox6.TabStop = false;
            avatarPictureBox6.Click += avatarPictureBox6_Click;
            // 
            // avatarPictureBox5
            // 
            avatarPictureBox5.Image = Properties.Resources.monkey;
            avatarPictureBox5.Location = new Point(179, 207);
            avatarPictureBox5.Name = "avatarPictureBox5";
            avatarPictureBox5.Size = new Size(160, 160);
            avatarPictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox5.TabIndex = 4;
            avatarPictureBox5.TabStop = false;
            avatarPictureBox5.Click += avatarPictureBox5_Click;
            // 
            // avatarPictureBox4
            // 
            avatarPictureBox4.Image = Properties.Resources.monkey;
            avatarPictureBox4.Location = new Point(0, 207);
            avatarPictureBox4.Name = "avatarPictureBox4";
            avatarPictureBox4.Size = new Size(160, 160);
            avatarPictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox4.TabIndex = 3;
            avatarPictureBox4.TabStop = false;
            avatarPictureBox4.Click += avatarPictureBox4_Click;
            // 
            // avatarPictureBox3
            // 
            avatarPictureBox3.Image = Properties.Resources.monkey;
            avatarPictureBox3.Location = new Point(359, 34);
            avatarPictureBox3.Name = "avatarPictureBox3";
            avatarPictureBox3.Size = new Size(160, 160);
            avatarPictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox3.TabIndex = 2;
            avatarPictureBox3.TabStop = false;
            avatarPictureBox3.Click += avatarPictureBox3_Click;
            // 
            // avatarPictureBox2
            // 
            avatarPictureBox2.Image = Properties.Resources.cat;
            avatarPictureBox2.Location = new Point(179, 34);
            avatarPictureBox2.Name = "avatarPictureBox2";
            avatarPictureBox2.Size = new Size(160, 160);
            avatarPictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox2.TabIndex = 1;
            avatarPictureBox2.TabStop = false;
            avatarPictureBox2.Click += avatarPictureBox2_Click;
            // 
            // avatarPictureBox1
            // 
            avatarPictureBox1.BackColor = SystemColors.Control;
            avatarPictureBox1.Image = Properties.Resources.monkey;
            avatarPictureBox1.Location = new Point(0, 34);
            avatarPictureBox1.Name = "avatarPictureBox1";
            avatarPictureBox1.Size = new Size(160, 160);
            avatarPictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox1.TabIndex = 0;
            avatarPictureBox1.TabStop = false;
            avatarPictureBox1.Click += avatarPictureBox1_Click;
            // 
            // NameRequiredErrorLabel
            // 
            NameRequiredErrorLabel.AutoSize = true;
            NameRequiredErrorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            NameRequiredErrorLabel.ForeColor = Color.Red;
            NameRequiredErrorLabel.Location = new Point(14, 162);
            NameRequiredErrorLabel.Name = "NameRequiredErrorLabel";
            NameRequiredErrorLabel.Size = new Size(153, 20);
            NameRequiredErrorLabel.TabIndex = 8;
            NameRequiredErrorLabel.Text = "Please enter a name.";
            NameRequiredErrorLabel.Visible = false;
            // 
            // FundsRequiredErrorLabel
            // 
            FundsRequiredErrorLabel.AutoSize = true;
            FundsRequiredErrorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            FundsRequiredErrorLabel.ForeColor = Color.Red;
            FundsRequiredErrorLabel.Location = new Point(14, 286);
            FundsRequiredErrorLabel.Name = "FundsRequiredErrorLabel";
            FundsRequiredErrorLabel.Size = new Size(225, 20);
            FundsRequiredErrorLabel.TabIndex = 9;
            FundsRequiredErrorLabel.Text = "Please add funds when joining.";
            FundsRequiredErrorLabel.Visible = false;
            // 
            // AvatarRequiredErrorLabel
            // 
            AvatarRequiredErrorLabel.AutoSize = true;
            AvatarRequiredErrorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            AvatarRequiredErrorLabel.ForeColor = Color.Red;
            AvatarRequiredErrorLabel.Location = new Point(373, 571);
            AvatarRequiredErrorLabel.Name = "AvatarRequiredErrorLabel";
            AvatarRequiredErrorLabel.Size = new Size(169, 20);
            AvatarRequiredErrorLabel.TabIndex = 10;
            AvatarRequiredErrorLabel.Text = "Please select an avatar.";
            AvatarRequiredErrorLabel.Visible = false;
            // 
            // PlayerSit
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(AvatarRequiredErrorLabel);
            Controls.Add(FundsRequiredErrorLabel);
            Controls.Add(NameRequiredErrorLabel);
            Controls.Add(AvatarBox);
            Controls.Add(CancelButton);
            Controls.Add(ConfirmButton);
            Controls.Add(FundLabel);
            Controls.Add(PlayerNameTextBox);
            Controls.Add(PlayerNameLabel);
            Controls.Add(SeatNumberLabel);
            Controls.Add(FundCommit);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PlayerSit";
            Text = "Sitting a player at the table";
            ((System.ComponentModel.ISupportInitialize)FundCommit).EndInit();
            AvatarBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox9).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox8).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)avatarPictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown FundCommit;
        private Label SeatNumberLabel;
        private Label PlayerNameLabel;
        private TextBox PlayerNameTextBox;
        private Label FundLabel;
        private Button ConfirmButton;
        private Button CancelButton;
        private GroupBox AvatarBox;
        private Label NameRequiredErrorLabel;
        private Label FundsRequiredErrorLabel;
        private PictureBox avatarPictureBox1;
        private PictureBox avatarPictureBox9;
        private PictureBox avatarPictureBox8;
        private PictureBox avatarPictureBox7;
        private PictureBox avatarPictureBox6;
        private PictureBox avatarPictureBox5;
        private PictureBox avatarPictureBox4;
        private PictureBox avatarPictureBox3;
        private PictureBox avatarPictureBox2;
        private Label AvatarRequiredErrorLabel;
    }
}