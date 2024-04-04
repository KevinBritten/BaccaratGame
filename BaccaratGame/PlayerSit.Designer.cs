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
            ((System.ComponentModel.ISupportInitialize)FundCommit).BeginInit();
            SuspendLayout();
            // 
            // FundCommit
            // 
            FundCommit.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FundCommit.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            FundCommit.Location = new Point(12, 186);
            FundCommit.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            FundCommit.Name = "FundCommit";
            FundCommit.Size = new Size(120, 29);
            FundCommit.TabIndex = 0;
            // 
            // SeatNumberLabel
            // 
            SeatNumberLabel.AutoSize = true;
            SeatNumberLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SeatNumberLabel.Location = new Point(12, 9);
            SeatNumberLabel.Name = "SeatNumberLabel";
            SeatNumberLabel.Size = new Size(228, 32);
            SeatNumberLabel.TabIndex = 1;
            SeatNumberLabel.Text = "Let's occupy seat 1";
            // 
            // PlayerNameLabel
            // 
            PlayerNameLabel.AutoSize = true;
            PlayerNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayerNameLabel.Location = new Point(12, 69);
            PlayerNameLabel.Name = "PlayerNameLabel";
            PlayerNameLabel.Size = new Size(144, 21);
            PlayerNameLabel.TabIndex = 2;
            PlayerNameLabel.Text = "What is your name:";
            // 
            // PlayerNameTextBox
            // 
            PlayerNameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayerNameTextBox.Location = new Point(12, 93);
            PlayerNameTextBox.Name = "PlayerNameTextBox";
            PlayerNameTextBox.Size = new Size(200, 29);
            PlayerNameTextBox.TabIndex = 3;
            // 
            // FundLabel
            // 
            FundLabel.AutoSize = true;
            FundLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FundLabel.Location = new Point(12, 162);
            FundLabel.Name = "FundLabel";
            FundLabel.Size = new Size(308, 21);
            FundLabel.TabIndex = 4;
            FundLabel.Text = "How much funds would you like to commit";
            // 
            // ConfirmButton
            // 
            ConfirmButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ConfirmButton.Location = new Point(12, 399);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(100, 30);
            ConfirmButton.TabIndex = 5;
            ConfirmButton.Text = "Confirm";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelButton.Location = new Point(140, 399);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(100, 30);
            CancelButton.TabIndex = 6;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // AvatarBox
            // 
            AvatarBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AvatarBox.Location = new Point(326, 12);
            AvatarBox.Name = "AvatarBox";
            AvatarBox.Size = new Size(462, 417);
            AvatarBox.TabIndex = 7;
            AvatarBox.TabStop = false;
            AvatarBox.Text = "Choices of avatars";
            // 
            // PlayerSit
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AvatarBox);
            Controls.Add(CancelButton);
            Controls.Add(ConfirmButton);
            Controls.Add(FundLabel);
            Controls.Add(PlayerNameTextBox);
            Controls.Add(PlayerNameLabel);
            Controls.Add(SeatNumberLabel);
            Controls.Add(FundCommit);
            Name = "PlayerSit";
            Text = "Sitting a player at the table";
            ((System.ComponentModel.ISupportInitialize)FundCommit).EndInit();
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
    }
}