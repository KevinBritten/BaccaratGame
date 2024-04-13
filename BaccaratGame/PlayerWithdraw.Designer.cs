namespace BaccaratGame
{
    partial class PlayerWithdraw
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
            WithdrawPlayerLabel = new Label();
            WithdrawButton = new Button();
            panel1 = new Panel();
            CloseButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // WithdrawPlayerLabel
            // 
            WithdrawPlayerLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            WithdrawPlayerLabel.Location = new Point(56, 18);
            WithdrawPlayerLabel.MaximumSize = new Size(680, 90);
            WithdrawPlayerLabel.Name = "WithdrawPlayerLabel";
            WithdrawPlayerLabel.Size = new Size(606, 86);
            WithdrawPlayerLabel.TabIndex = 2;
            WithdrawPlayerLabel.Text = "Would you like to take your winnings and leave?";
            WithdrawPlayerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // WithdrawButton
            // 
            WithdrawButton.Location = new Point(3, 3);
            WithdrawButton.Name = "WithdrawButton";
            WithdrawButton.Size = new Size(94, 29);
            WithdrawButton.TabIndex = 3;
            WithdrawButton.Text = "Yes!";
            WithdrawButton.UseVisualStyleBackColor = true;
            WithdrawButton.Click += WithdrawButton_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(CloseButton);
            panel1.Controls.Add(WithdrawButton);
            panel1.Location = new Point(211, 107);
            panel1.Name = "panel1";
            panel1.Size = new Size(296, 41);
            panel1.TabIndex = 4;
            // 
            // CloseButton
            // 
            CloseButton.Location = new Point(103, 3);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(187, 29);
            CloseButton.TabIndex = 4;
            CloseButton.Text = "No, keep playing.";
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // PlayerWithdraw
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(718, 172);
            Controls.Add(panel1);
            Controls.Add(WithdrawPlayerLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PlayerWithdraw";
            Text = "Welcome for playing";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label WithdrawPlayerLabel;
        private Button WithdrawButton;
        private Panel panel1;
        private Button CloseButton;
    }
}