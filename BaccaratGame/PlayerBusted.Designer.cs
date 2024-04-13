namespace BaccaratGame
{
    partial class PlayerBusted
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
            BustedPlayerLabel = new Label();
            ConfirmButton = new Button();
            label2 = new Label();
            panel1 = new Panel();
            FundsInput = new NumericUpDown();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)FundsInput).BeginInit();
            SuspendLayout();
            // 
            // BustedPlayerLabel
            // 
            BustedPlayerLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BustedPlayerLabel.Location = new Point(24, 9);
            BustedPlayerLabel.MaximumSize = new Size(696, 150);
            BustedPlayerLabel.Name = "BustedPlayerLabel";
            BustedPlayerLabel.Size = new Size(656, 86);
            BustedPlayerLabel.TabIndex = 2;
            BustedPlayerLabel.Text = "Sorry, you don't have enough funds to continue.";
            BustedPlayerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // ConfirmButton
            // 
            ConfirmButton.Location = new Point(304, 199);
            ConfirmButton.Name = "ConfirmButton";
            ConfirmButton.Size = new Size(94, 29);
            ConfirmButton.TabIndex = 5;
            ConfirmButton.Text = "Goodbye.";
            ConfirmButton.UseVisualStyleBackColor = true;
            ConfirmButton.Click += ConfirmButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(238, 95);
            label2.Name = "label2";
            label2.Size = new Size(227, 28);
            label2.TabIndex = 6;
            label2.Text = "Please top up or get out.";
            // 
            // panel1
            // 
            panel1.Controls.Add(FundsInput);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(196, 143);
            panel1.Name = "panel1";
            panel1.Size = new Size(310, 40);
            panel1.TabIndex = 7;
            // 
            // FundsInput
            // 
            FundsInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            FundsInput.Location = new Point(157, 6);
            FundsInput.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            FundsInput.Name = "FundsInput";
            FundsInput.Size = new Size(150, 27);
            FundsInput.TabIndex = 6;
            FundsInput.ValueChanged += FundsInput_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 8);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 5;
            label1.Text = "Select amount to add:";
            // 
            // PlayerBusted
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(709, 242);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(ConfirmButton);
            Controls.Add(BustedPlayerLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PlayerBusted";
            Text = "Game time decision for the player";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)FundsInput).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label BustedPlayerLabel;
        private Button button1;
        private Label label2;
        private Panel panel1;
        private NumericUpDown FundsInput;
        private Label label1;
        private Button ConfirmButton;
    }
}